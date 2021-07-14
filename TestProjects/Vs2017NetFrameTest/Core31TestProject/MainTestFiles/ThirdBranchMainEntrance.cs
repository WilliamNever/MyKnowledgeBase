using Core31TestProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core31TestProject.MainTestFiles
{
    public class ThirdBranchMainEntrance : TestBaseForMainEntrance
    {
        public override void MainRun()
        {
            //Task.WaitAll(FirstTest());
            //Task.WaitAll(JsonSerialTest());
            Task.WaitAll(TaskDiscardTest());
        }

        private async Task TaskDiscardTest()
        {
            int maxLoop = 10;
            _ = Task.Run(()=> {
                for (int i = 0; i < maxLoop; i++)
                {
                    Console.WriteLine($"t1 - {i}");
                    Thread.Sleep(1000);
                }
            });
            var t2 = Task.Run(()=> {
                for (int i = 0; i < maxLoop; i++)
                {
                    Console.WriteLine($"t2 - {i}");
                    Thread.Sleep(500);
                }
            });

            //await t1;
            await t2;
        }

        private async Task JsonSerialTest()
        {
            var ssdf = "ssssfff"[0..3];


            double numfir = 5;
            int divided = 4;
            var nump = Math.Ceiling(numfir / divided);

            string aa = "aa", bb = "bb";
            var url = $"{aa + bb}?dl={{0}}&q={{1}}&rpp={{2}}&sort={{3}}&page={{4}}";
            Console.WriteLine(url);

            var oriUrl = "dl=category,supplier,price,color,material,size&page=1&q=0000+price:39:44%7C%7C1+size:4294308696:4293936722:4292570631%7C%7C2+preferred:1,2,3,4,5&rpp=20&sort=PVRN";
            var deUrl = System.Web.HttpUtility.UrlDecode(oriUrl);
            Console.WriteLine(deUrl);

            var enUrl = System.Web.HttpUtility.UrlEncode(deUrl);
            Console.WriteLine(enUrl);

            Console.WriteLine(oriUrl.Equals(enUrl));

            System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
            //Dictionary<string, string> hashtable = new Dictionary<string, string>();
            hashtable.Add("aa", "aa");
            hashtable.Add("bb", "bb");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(hashtable));



            //var dic = new Dictionary<string, List<KeyValuePair<string, string>>>();
            //dic.Add("aa", new List<KeyValuePair<string, string>> { 
            //    new KeyValuePair<string, string>("a1", "a1v"),
            //    new KeyValuePair<string, string>("a2","a2v"),
            //    new KeyValuePair<string, string>("a3","a3v")
            //});

            //dic.Add("bb", new List<KeyValuePair<string, string>> {
            //    new KeyValuePair<string, string>("b1", "b1v"),
            //    new KeyValuePair<string, string>("b2","b2v"),
            //    new KeyValuePair<string, string>("b3","ab3v")
            //});

            var dic = new System.Collections.Specialized.StringDictionary();
            dic.Add("aaa", "bbb");
            dic.Add("ccc", "ddd");
            var val = dic["aaa"];
            var str = Newtonsoft.Json.JsonConvert.SerializeObject(dic);
            Console.WriteLine(str);

            string classString = @"
                {""Sizes"": [
                      {
                        ""Id"": ""4293979073"",
                        ""Name"": ""Other Sizes"",
                        ""ContextPath"": ""4294308696:4293979073||1"",
                        ""Products"": 33
                      },
                      {
                        ""Id"": ""4293936722"",
                        ""Name"": "">= 60\"""",
                        ""ContextPath"": ""4294308696:4293936722||1"",
                        ""Products"": 19
                      },
                      {
                        ""Id"": ""4293770119"",
                        ""Name"": ""Standard & Numbered - Other"",
                        ""ContextPath"": ""4294308696:4293770119||1"",
                        ""Products"": 19
                      },
                      {
                        ""Id"": ""4293999022"",
                        ""Name"": ""12\"" - 18\"""",
                        ""ContextPath"": ""4294308696:4293999022||1"",
                        ""Products"": 18
                      }],
                ""Colors"": [
                      {
                        ""Id"": ""4293979073"",
                        ""Name"": ""Other Sizes"",
                        ""ContextPath"": ""4294308696:4293979073||1"",
                        ""Products"": 33
                      },
                      {
                        ""Id"": ""4293936722"",
                        ""Name"": "">= 60\"""",
                        ""ContextPath"": ""4294308696:4293936722||1"",
                        ""Products"": 19
                      },
                      {
                        ""Id"": ""4293770119"",
                        ""Name"": ""Standard & Numbered - Other"",
                        ""ContextPath"": ""4294308696:4293770119||1"",
                        ""Products"": 19
                      },
                      {
                        ""Id"": ""4293999022"",
                        ""Name"": ""12\"" - 18\"""",
                        ""ContextPath"": ""4294308696:4293999022||1"",
                        ""Products"": 18
                      }]
                }";

            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, List<DimensionItem>>>(classString);
        }

        private async Task FirstTest()
        {
            NameContainer nc = new NameContainer { FirstName="fn", MiddleNames="mn", LastName="ln" };
            Console.WriteLine($"|{nc}|");
            Console.WriteLine(nc.GetFullName());

            string ssst = "aaa";
            ssst ??= new string("Hello");
            Console.WriteLine(DateTime.UtcNow.ToString("yyyyMMdd").Substring(1));
            string str = "_ssss";
            var indexOf = str.IndexOf('_');
            var subStr = str.Substring(0, indexOf);
            var flist = Directory.GetFiles("D:\\TmpDocs");
            var fn = Path.GetFileName(flist[0]);
        }
    }
}
