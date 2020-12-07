using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace StandardBaseInfors.TestModels
{
    public class HttpCModel
    {
        public string URL { get; set; }
        public string ContentType { get; set; }
        public string SendBody { get; set; }
        public string Method { get; set; }
        public string ResponseAccept { get; set; }
        public List<FlexibleCodeField> FlexibleFields { get; set; }
    }

    public class FlexibleCodeField
    {
        [XmlAttribute("fieldId")]
        public int Id { get; set; }
        [XmlText]
        public string value { get; set; }
    }
}
