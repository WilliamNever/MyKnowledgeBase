using System;

namespace NetCoreTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestTaskRunTemplateRunAsync();

            ConsoleEndLine();
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
