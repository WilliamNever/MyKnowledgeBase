using System;
using System.Collections.Generic;
using System.Text;

namespace Core31TestProject.Models
{
    public class JsonPropertiesIgnoreTestClass : Hiface
    {
        public JsonPropertiesIgnoreTestClass()
        {
            HellWorld = "HellWorld";
        }

        public string HellWorld { private get; set; }

        string Hiface.HellWorld { get => HellWorld; set => HellWorld = value; }
    }

    public class JsPEx : JsonPropertiesIgnoreTestClass
    {
        public string Name { get; set; } = "HHHHH";
    }

    public interface Hiface
    {
        string HellWorld { get; set; }
    }
}
