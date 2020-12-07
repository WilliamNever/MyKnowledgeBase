using System;
using System.Collections.Generic;
using System.Text;

namespace NetStandardLibrary.Models
{
    public class HttpWebContent
    {
        public string URL { get; set; }
        public string ContentType { get; set; }
        public string SendBody { get; set; }
        public string Method { get; set; }
        public string ResponseAccept { get; set; }
    }
}
