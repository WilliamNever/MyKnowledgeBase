using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core31TestProject.Services
{
    public class SftpSingleFileService
    {
        private readonly TransferSetting _setting;
        public SftpSingleFileService(TransferSetting setting)
        {
            _setting = setting ?? throw new NullReferenceException("SFTP Settings parameter parsed as null");
        }

        public async Task DeleteFileAsync(string filename)
        {
            await Task.Run(() =>
            {
                string remotefile = $"{_setting.RemotePath}/{filename}";
                var connInfoSource = new PasswordConnectionInfo(_setting.Host, _setting.Port, _setting.User, _setting.Password);
                using (var sftp = new SftpClient(connInfoSource))
                {
                    sftp.Connect();
                    sftp.DeleteFile(remotefile);
                    sftp.Disconnect();
                }
            });
        }

        public async Task DeleteLocalFileAsync(string filename)
        {
            var file = $"{_setting.LocalPath}\\{filename}";
            if (File.Exists(file))
            {
                File.Delete(file);
            }
        }

        public async Task<string> DownloadFileAsync(string filename)
        {
            return await Task.Run(() =>
            {
                string remotefile = $"{_setting.RemotePath}/{filename}";
                string localfile = $"{_setting.LocalPath}\\{filename}";
                var connInfoSource = new PasswordConnectionInfo(_setting.Host, _setting.Port, _setting.User, _setting.Password);
                using (var sftp = new SftpClient(connInfoSource))
                {
                    sftp.Connect();
                    using (FileStream wrt = new FileStream(localfile, FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        sftp.DownloadFile(remotefile, wrt);
                        wrt.Flush();
                    }
                    sftp.Disconnect();
                }
                return localfile;
            });
        }

        public async Task<IEnumerable<string>> GetFilesAsync()
        {
            return await Task.Run(() =>
            {
                IEnumerable<string> files;
                var connInfoSource = new PasswordConnectionInfo(_setting.Host, _setting.Port, _setting.User, _setting.Password);
                using (var sftp = new SftpClient(connInfoSource))
                {
                    sftp.Connect();
                    files = sftp.ListDirectory(_setting.RemotePath).Where(x => x.IsRegularFile).Select(x => Path.GetFileName(x.FullName)).ToList();
                    sftp.Disconnect();
                }
                return files;
            });
        }

        public async Task UploadFileAsync(string filepath)
        {
            await Task.Run(() =>
            {
                if (File.Exists(filepath))
                {
                    var connInfoSource = new PasswordConnectionInfo(_setting.Host, _setting.Port, _setting.User, _setting.Password);
                    using (var sftp = new SftpClient(connInfoSource))
                    {
                        sftp.Connect();
                        if (!sftp.Exists(_setting.RemotePath))
                        {
                            sftp.CreateDirectory(_setting.RemotePath);
                        }
                        using (FileStream wrt = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            sftp.UploadFile(wrt, $"{_setting.RemotePath}/{Path.GetFileName(filepath)}", true);
                        }
                        sftp.Disconnect();
                    }
                }
            });
        }
    }


    public class TransferSetting
    {
        /// <summary>
        /// The server we will be transfering from or to.
        /// The Host should only be a domain name Without the Protocol name.
        /// Such as: sftp.myLocal.com
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Username needed for whichever server we are accesssing
        /// </summary>
        public string User { get; set; }
        /// <summary>
        /// Password for whichever server we are accessing
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// The path we will download the file from
        /// </summary>
        public string RemotePath { get; set; }
        /// <summary>
        /// Where a file should be downloaded to locally, should that be needed
        /// </summary>
        public string LocalPath { get; set; }
        /// <summary>
        /// Port we're going over, shouldn't always be needed. 
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// A property so we can easily dictate which transfer service we will use. For example, FTP, SFTP, HTTP
        /// </summary>
        public string Protocol { get; set; }
    }
}
