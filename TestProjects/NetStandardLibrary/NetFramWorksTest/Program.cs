using NetStandardLibrary.ConvertHelpers;
using StandardBaseInfors.TestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetFramWorksTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestTaskRunTemplateRunAsync();

            XMLCovertTEST();

            ConsoleEndLine();
        }

        private static void XMLCovertTEST()
        {
            HttpCModel htcm = new HttpCModel()
            {
                FlexibleFields = new List<FlexibleCodeField>() {
                new FlexibleCodeField{ Id=1, value="BRANCHSTORE" },
                new FlexibleCodeField{ Id=15, value="ISERIES" },
                new FlexibleCodeField{ Id=16, value="PROGRAM1" },
            }
            };

            XMLConverter<HttpCModel> converter = new XMLConverter<HttpCModel>();
            var xml = converter.Serializer(htcm);
        }

        private static void TestTaskRunTemplateRunAsync()
        {
            var mess = NetStandardLibrary.TaskHelpers.TaskRunTemplate.RunAsync(
                            () =>
                            {
                                return GetHellowName("Morning");
                            }
                            ).Result;
            Console.WriteLine(mess);
        }

        private static string GetHellowName(string Name)
        {
            return $"Hello {Name}!";
        }

        private static void ConsoleEndLine()
        {
            Console.WriteLine();
            Console.WriteLine($"Finished .net Fx Test! Any key to exit......");
            Console.ReadKey();
        }
    }
}
