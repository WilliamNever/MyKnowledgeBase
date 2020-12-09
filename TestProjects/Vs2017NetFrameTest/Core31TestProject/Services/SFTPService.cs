using Microsoft.Extensions.Logging;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core31TestProject.Services
{
    public class SFTPService : ITrasnferService
    {
        public SFTPService()
        {
        }

        public async Task<List<DownLoadedFileModel>> DownLoadAsync(FTPSettings ftpSetting)
        {
            var SemaphoreForRecord = new SemaphoreSlim(ftpSetting.SemaphoreSlimInit, ftpSetting.SemaphoreSlimMax);
            List<DownLoadedFileModel> files = new List<DownLoadedFileModel>();

            List<SftpFile> ftpFiles;
            List<Task<DownLoadedFileModel>> DLFileTasks = new List<Task<DownLoadedFileModel>>();
            var connInfoSource = new PasswordConnectionInfo(ftpSetting.Server.Host, ftpSetting.Server.Port, ftpSetting.Server.UserId, ftpSetting.Server.Password);
            using (var sftp = new SftpClient(connInfoSource))
            {
                sftp.Connect();
                ftpFiles = sftp.ListDirectory(ftpSetting.RootPath).Where(x => x.IsRegularFile).ToList();

                foreach (var file in ftpFiles)
                {
                    DLFileTasks.Add(DownLoadAFileProcessAsync(file, sftp, ftpSetting.OutPutPath, SemaphoreForRecord));
                }
                var downloadfiles = await Task.WhenAll(DLFileTasks);
                files = downloadfiles.Where(x => !string.IsNullOrEmpty(x.LocalPath)).ToList();
                sftp.Disconnect();
            }
            return files;
        }

        private async Task DeleteFtpFileAsync(string path, SftpClient sftp, SemaphoreSlim SemaphoreForRecord)
        {
            await Task.Run(() =>
            {
                SemaphoreForRecord.Wait();
                try
                {
                    sftp.DeleteFile(path);
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

        private async Task<DownLoadedFileModel> DownLoadAFileProcessAsync(SftpFile file, SftpClient sftp, string SavedPath, SemaphoreSlim SemaphoreForRecord)
        {
            /// if an exception occurred, the LocalPath is null and ExceptionMessage has value in DownLoadFileModel.
            return await Task.Run(() =>
            {
                DownLoadedFileModel rslt = new DownLoadedFileModel
                {
                    FtpPath = file.FullName,
                    LocalPath = $"{SavedPath}\\{Path.GetFileName(file.FullName)}",
                };

                SemaphoreForRecord.Wait();
                try
                {
                    using (FileStream wrt = new FileStream(rslt.LocalPath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        sftp.DownloadFile(file.FullName, wrt);
                        wrt.Flush();
                    }
                }
                catch (Exception ex)
                {
                    rslt.LocalPath = null;
                    rslt.ExceptionMessage = ex.Message;
                }
                finally
                {
                    SemaphoreForRecord.Release();
                }
                return rslt;
            });
        }
    }

    #region Basic Settings
    public interface ITrasnferService
    {
        Task<List<DownLoadedFileModel>> DownLoadAsync(FTPSettings ftpSetting);
    }
    public class DownLoadedFileModel
    {
        public string FtpPath { get; set; }
        public string LocalPath { get; set; }
        public string ExceptionMessage { get; set; }
    }

    public class FTPSettings
    {
        public FTPServer Server { get; set; }
        public string RootPath { get; set; }
        public int SemaphoreSlimInit { get; set; }
        public int SemaphoreSlimMax { get; set; }
        public string OutPutPath { get; set; }
    }

    public class FTPServer
    {
        /// <summary>
        /// The server we will be transfering from or to.
        /// The Host should only be a domain name Without the Protocol name.
        /// Such as: sftp.myLocal.com
        /// </summary>
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
    #endregion
}
