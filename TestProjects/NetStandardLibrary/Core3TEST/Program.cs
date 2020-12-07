using Core3TEST.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Core3TEST
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestTaskRunTemplateRunAsync();

            JsonSerializeTEST();




            ConsoleEndLine();
        }

        private static void JsonSerializeTEST()
        {
            BaseModel bm = new BaseModel();
            ExModel1 exm1 = new ExModel1();

            Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(bm));

            var jsot = new System.Text.Json.JsonSerializerOptions();
            //jsot.MaxDepth = 1;
            jsot.PropertyNameCaseInsensitive = false;
            //jsot.PropertyNamingPolicy
            

            var jso = System.Text.Json.JsonSerializer.Serialize<ExModel1>(exm1,jsot);


            Console.WriteLine(jso);
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
            Console.WriteLine($"Finished .net Core Test! Any key to exit......");
            Console.ReadKey();
        }
    }
}
