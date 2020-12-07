using Microsoft.Extensions.Logging;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core31TestProject.Services
{
    public class FTPService : ITrasnferService
    {
        public FTPService()
        {
        }

        public async Task<List<DownLoadedFileModel>> DownLoadAsync(FTPSettings ftpSetting)
        {
            List<DownLoadedFileModel> result = null;
            var files = await GetRootFilesAsync(ftpSetting);
            if (files != null)
            {
                if (!Directory.Exists(ftpSetting.OutPutPath)) Directory.CreateDirectory(ftpSetting.OutPutPath);
                List<Task<DownLoadedFileModel>> tasks = new List<Task<DownLoadedFileModel>>();
                SemaphoreSlim SemaphoreForRecord = new SemaphoreSlim(ftpSetting.SemaphoreSlimInit, ftpSetting.SemaphoreSlimMax);
                foreach (var item in files) {
                    tasks.Add(
                        DownLoadAFileProcessAsync(item, ftpSetting, SemaphoreForRecord)
                        );
                }
                var dlFiles = await Task.WhenAll(tasks);
                result = dlFiles.ToList();
            }
            return result;
        }

        public async Task DeleteFilesAsync(List<DownLoadedFileModel> files, FTPSettings ftpSetting)
        {
            if (files != null)
            {
                List<Task> tasks = new List<Task>();
                SemaphoreSlim SemaphoreForRecord = new SemaphoreSlim(ftpSetting.SemaphoreSlimInit, ftpSetting.SemaphoreSlimMax);
                foreach (var item in files)
                {
                    tasks.Add(
                        DeleteFtpFileAsync(item.FtpPath, ftpSetting, SemaphoreForRecord)
                        );
                }
                await Task.WhenAll(tasks.ToArray());
            }
        }

        private async Task DeleteFtpFileAsync(string file, FTPSettings ftpSetting, SemaphoreSlim SemaphoreForRecord)
        {
            await Task.Run(() =>
            {
                SemaphoreForRecord.Wait();
                try
                {
                    var request = GetFtpWebRequest(file, ftpSetting);
                    request.Method = WebRequestMethods.Ftp.DeleteFile;
                    using (var response = request.GetResponse())
                    {
                        response.Close();
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    SemaphoreForRecord.Release();
                }
            });
        }

        private FtpWebRequest GetFtpWebRequest(string ftpPath, FTPSettings ftpSetting)
        {
            var listRequest = (FtpWebRequest)WebRequest.Create(ftpPath);
            listRequest.Credentials = new NetworkCredential(ftpSetting.Server.UserId, ftpSetting.Server.Password);
            return listRequest;
        }

        private async Task<List<string>> GetRootFilesAsync(FTPSettings ftpSetting)
        {
            string RootPath = $"{ftpSetting.Server.Host}:{ftpSetting.Server.Port}/{ftpSetting.RootPath}";
            var listRequest = GetFtpWebRequest(RootPath, ftpSetting);
            listRequest.Method = WebRequestMethods.Ftp.ListDirectory;
            List<string> files = new List<string>();
            using (var listResponse = listRequest.GetResponse())
            {
                using var listStream = listResponse.GetResponseStream();
                using var listReader = new StreamReader(listStream);
                while (!listReader.EndOfStream)
                {
                    files.Add($"{RootPath}/{await listReader.ReadLineAsync()}");
                }
            }
            return files;
        }

        private async Task<DownLoadedFileModel> DownLoadAFileProcessAsync(string file, FTPSettings ftpSetting, SemaphoreSlim SemaphoreForRecord)
        {
            /// if an exception occurred, the LocalPath is null and ExceptionMessage has value in DownLoadFileModel.
            return await Task.Run( () =>
            {
                DownLoadedFileModel result = new DownLoadedFileModel();
                result.FtpPath = file;
                result.LocalPath = $"{ftpSetting.OutPutPath}\\{Path.GetFileName(file)}";

                SemaphoreForRecord.Wait();
                try
                {
                    var fileRequest = GetFtpWebRequest(file, ftpSetting);
                    fileRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                    using var response = fileRequest.GetResponse();
                    using var responseStream = response.GetResponseStream();
                    using var localFile = new FileStream(result.LocalPath, FileMode.Create, FileAccess.Write);
                    responseStream.CopyTo(localFile);
                    localFile.Flush();
                }
                catch (Exception ex)
                {
                    result.LocalPath = null;
                    result.ExceptionMessage = ex.Message;
                }
                finally
                {
                    SemaphoreForRecord.Release();
                }
                return result;
            });
        }
    }
}
