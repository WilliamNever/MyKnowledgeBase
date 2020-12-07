using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace ReadTargetInfor.ClassCodes.Utilities
{
    public class WriteReportLog
    {
        private readonly Encoding FileEncoding = Encoding.UTF8;
        private readonly string NREnter = "\r\n";

        private string path;
        private FileStream fs = null;

        private MemoryStream memStream = null;

        public bool HasContentsInMemoryStream { get; private set; }

        public long MemoryCount { get { return this.memStream.Length; } }

        public WriteReportLog(string path)
        {
            this.path = path;
        }

        public void WriteLine(string str)
        {
            var bytes = this.GetBytes(str);
            this.fs.Write(bytes, 0, bytes.Length);
        }
        public void Flush()
        {
            this.fs.Flush();
        }
        public void FlushMemoryStream()
        {
            this.memStream.Flush();
        }
        public void Close()
        {
            if (this.fs != null)
            {
                this.fs.Close();
            }
            this.CloseMemoryStream();
        }

        public void WriteMemoryStream(string str)
        {
            this.HasContentsInMemoryStream = true;
            var bytes = this.GetBytes(str);
            this.memStream.Write(bytes, 0, bytes.Length);
        }

        public void ReNewMemoryStream()
        {
            CloseMemoryStream();
            this.HasContentsInMemoryStream = false;
            this.memStream = new MemoryStream();
        }
        public void WriteMemoryStreamToFile()
        {
            this.FlushMemoryStream();
            this.Flush();
            var bytes = this.memStream.ToArray();
            this.fs.Write(bytes, 0, bytes.Length);
            this.Flush();
            this.CloseMemoryStream();
        }
        public void CloseMemoryStream()
        {
            if (this.memStream != null)
            {
                this.memStream.Close();
            }
        }

        public void Open()
        {
            this.fs = new FileStream(this.path, FileMode.Create);
        }

        private byte[] GetBytes(string str)
        {
            string temp = str + this.NREnter;
            return FileEncoding.GetBytes(temp);
        }
    }
}
