using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using TestProjects.Models;
using TestProjects.TestClasses;

namespace TestProjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region
            //Console.WriteLine($"Max Decimal = {decimal.MaxValue} \t/\t Min Decimal = {decimal.MinValue}");
            //Console.WriteLine($"Max int = {int.MaxValue} \t/\t Min int = {int.MinValue}");
            //Console.WriteLine($"Max float = {float.MaxValue} \t/\t Min float = {float.MinValue}");
            //Console.WriteLine($"Max double = {double.MaxValue} \t/\t Min double = {double.MinValue}");
            //Console.WriteLine($"Max short = {short.MaxValue} \t/\t Min short = {short.MinValue}");
            //Console.WriteLine($"Max long = {long.MaxValue} \t/\t Min long = {long.MinValue}");

            //Console.WriteLine();

            //FunctionTest1();
            //FunctionTestOperator();
            //Console.WriteLine($"-------------------------------------------------------------------");
            //FunctionTestExOperator();

            //OpTEx otex = new OpTEx();

            //FunctionGroupTest();

            //SomeSmallTest();

            //DateTimeConvertTest();

            //TaskRunTest();

            //SynchronizedTest();

            MapperTest();

            //Console.WriteLine(AsyncSTESTAsync().Result);

            //InheritAndExTEST();

            //DateTimeOffsetTest();
            #endregion

            //ReadDateNowFrequently().Wait();

            //DateTimeOffsetDateTimeConvertTest();

            //JsonSerializeTEST();

            //StringFormatTEST();

            EndInfor();
        }

        private static void StringFormatTEST()
        {
            Console.WriteLine(string.Format("{0}-{1}", 0, 1, 2));
            Console.WriteLine(string.Format("{0:N}",decimal.MinValue));
            Console.WriteLine(string.Format("{0:X}", 12));
            Console.WriteLine((100.0/3).ToString("N"));
        }

        private static void JsonSerializeTEST()
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            InforModel ifm = new InforModel() { Messages = "Next Messages" };
            Console.WriteLine(jss.Serialize(ifm));
            ifm = null;
            Console.WriteLine(jss.Serialize(ifm));
        }

        private static void DateTimeOffsetDateTimeConvertTest()
        {
            string ExpireTime = "4:30";
            TimeSpan removeTime;
            DateTimeOffset removeDateTime;
            if (!TimeSpan.TryParse(ExpireTime, out removeTime))
            {
                removeTime = TimeSpan.FromHours(3d);
            }
            removeDateTime = DateTimeOffset.Now.Date.Add(removeTime);

            Console.WriteLine(removeDateTime);
        }

        private static async Task ReadDateNowFrequently()
        {
            List<Task> tasks = new List<Task>();

            for (int i = 0; i < 1000; i++)
            {
                tasks.Add(CWrite(i));
            }

            await Task.WhenAll(tasks);
        }

        private static async Task CWrite(int ix)
        {
            await Task.Run(() =>
              {
                  var istr = ix.ToString();
                  Console.WriteLine($"{istr} - {DateTime.Now}");
              });
        }

        private static void DateTimeOffsetTest()
        {
            List<InforBaseExClass> listBEx = new List<InforBaseExClass>();
            for (int i = 0; i < 5; i++)
            {
                listBEx.Add(
                    new InforBaseExClass
                    {
                        Age = new InforModel { Messages = i.ToString() }
                    }
                    );
            }
            var lob = listBEx.FirstOrDefault(x => x.Age.Messages == "1");
            lob.Age.Messages = $"{lob.Age.Messages} - Added";

            Console.WriteLine($"{DateTimeOffset.Now} / {DateTimeOffset.UtcNow}");

            DateTimeOffset dto = DateTimeOffset.Parse("2015-08-09 1:00");

            Console.WriteLine($"{dto.Date.ToString()}");
            Console.WriteLine($"{dto.UtcDateTime.Date.ToString()}");
            Console.WriteLine($"{dto.Date.DayOfWeek}");
        }

        private static void InheritAndExTEST()
        {
            int ix = 1;
            Console.WriteLine(ix == 1);
            Console.WriteLine(ix is 1);
            Console.WriteLine(ix is 2);
            Console.WriteLine();

            InforBaseExClass ExBase = new InforBaseExClass();
            ExBase.Age.Messages = "19DC";
            Console.WriteLine(ExBase.Age.Messages);

            Action<MapperOriModel> mpAct = mom =>
            {
                mom.Age = 15;
                mom.FirstName = "First Name";
                mom.LastName = "Last Name";
                mom.MemoSelf = "Memo Self";
            };

            GetOptions(
                    (op, str) =>
                    {
                        op.Age = 157;
                        op.FirstName = "First Name 157";
                        op.LastName = $"Last Name 157 - {str}";
                        op.MemoSelf = "Memo Self 157";
                    }
                    , "Header XXX"
                );
        }

        private static void GetOptions(Action<MapperOriModel, string> mpAct, string Name)
        {
            MapperOriModel mom = new MapperOriModel();
            mpAct(mom, Name);

            Console.WriteLine(mom.LastName);
        }

        private async static Task<bool> AsyncSTESTAsync()
        {
            var tHandler = Task.Run(() => { return new MapperOriModel { Age = 99, FirstName = "Henry", LastName = "Herbi", MemoSelf = "Missing anything!" }; });
            var va = await tHandler;
            va.Age = 103;
            Console.WriteLine(va.Age);
            var vb = await tHandler;
            Console.WriteLine(vb.Age);
            return true;
        }

        private static void MapperTest()
        {
            AutoMapper.Mapper.Initialize(x => x.AddProfile<Models.MapperConfigProfile>());
            var ori = new MapperOriModel { FirstName = "Marian", LastName = "Honck", Age = 22, MemoSelf = "Mself", Jobs = null, LineId="55655" };

            var msd = AutoMapper.Mapper.Map<MapperSimpleDestiModel>(ori);
            //msd.Age = msd.Age + 1;
            //msd.ArgContents = "Arg Contents";
            //var desOri = AutoMapper.Mapper.Map<MapperOriModel>(msd);

            //var type = msd.GetType().GetProperty("ArgContents", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            //Console.WriteLine(type.Name);

            var MmsdFromOri = AutoMapper.Mapper.Map<MapperMoreSimpDestiModel>(ori);
            //var MmsdFromMsd = AutoMapper.Mapper.Map<MapperMoreSimpDestiModel>(msd);
            Console.WriteLine("finished......");
        }

        private static void SynchronizedTest()
        {
            for (int i = 0; i < 10000; i++)
            {
                //Console.WriteLine("----------------------------------------------------------------");
                FuncLamdaTestAsync(i).Wait();
                //Console.WriteLine("----------------------------------------------------------------");
            }
        }

        private static async Task FuncLamdaTestAsync(int Round)
        {
            var aa = Task.Run(() => CTestRun(1, Round));    //CTestRun(1);//
            var bb = Task.Run(() => CTestRun(2, Round));    //CTestRun(2);//

            var tt = Task.WhenAll(aa, bb);
            //Console.WriteLine($"Middle running........");
            await tt;
            var getIntValue = Task.Run(() => { return 7; });
            var intResult = await getIntValue;
            //Console.WriteLine($"{await aa}/{await bb}");
            //Console.WriteLine($"End");
        }
        private static bool IsOpen = false;
        private static async Task<int> CTestRun(int x = 0, int Round = 0)
        {
            var tt = Task.Run(() => { IsOpen = true; /*Thread.Sleep(1000);*/ if (!IsOpen) Console.WriteLine($"Inner Infor...{Round.ToString()}/{x}/{IsOpen.ToString()}"); IsOpen = false; return 8; });
            return await tt;
        }

        private static void TaskRunTest()
        {
            Console.WriteLine("Begin!");
            RunOutLine().Wait();
            Console.WriteLine("Over!");
        }

        private static async Task RunOutLine()
        {
            var dtResult1 = await GetDateTimeAsync();

            await DelayAsync(2);
            Console.WriteLine();

            var tt = GetDateTimeAsync();
            Console.WriteLine($"Running tt");
            var dtResult2 = await tt;   //执行并返回结果
            Console.WriteLine($"Run after tt");

            await DelayAsync(3);
            Console.WriteLine();

            var dtResult4 = await GetDateTimeAsync();
            var dtResult3 = await tt;   //直接检索结果不会重新执行方法内的内容

            Console.WriteLine();
            Console.WriteLine(dtResult1);
            Console.WriteLine(dtResult2);
            Console.WriteLine(dtResult3);
            Console.WriteLine(dtResult4);
        }

        private static async Task<DateTime> GetDateTimeAsync()
        {
            Console.WriteLine($"Pre Begin GetDateTimeAsync ------");
            await Task.Delay(1000);
            Console.WriteLine($"Begin GetDateTimeAsync ------");
            //Task.FromResult 是一个占位符，类型为 DateTime
            var dt = await Task.FromResult(DateTime.Now);
            Console.WriteLine($"GetDateTimeAsync - {dt}");
            Console.WriteLine($"End GetDateTimeAsync ------");
            return dt;
        }

        private static async Task DelayAsync(int Second = 1)
        {
            //Task.Delay 是一个占位符，用于假设方法正处于工作状态。
            await Task.Delay(1000 * Second);

            Console.WriteLine($"DelayAsync OK! Delay {Second} seconds.");
        }

        private static void DateTimeConvertTest()
        {
            InforBaseClass ifbc = new InforBaseClass
            {
                Age = { Age = 10, FirstName = "f", LastName = "l", MemoSelf = "msmelf" }
            };
            Console.WriteLine(ifbc.Age.MemoSelf);
            Console.WriteLine("---------------------");
            Console.WriteLine(DateTime.Parse("2018-11-28T00:00:00"));
            Console.WriteLine(DateTime.Parse("11/28/2018 12:00:00 AM"));

            Console.WriteLine("*****************");

            DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
            var dt = Convert.ToDateTime("10/28/18", myDTFI);

            Console.WriteLine($"{dt.ToString()}");
        }

        private static void SomeSmallTest()
        {
            string voc = "";
            var stArry = voc.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine(stArry.Length);

            Console.WriteLine(string.IsNullOrWhiteSpace(voc));
        }

        private static void FunctionGroupTest()
        {
            List<LstModel> list = new List<LstModel>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(new LstModel
                {
                    ID = i,
                    Age = i / 5 + 100,
                    FirstName = $"{i / 5 + 100}",
                    LastName = $"{1000 + i}",
                });
            }

            var grped = list.GroupBy(x => new CompareKey { FirstName = x.FirstName, Age = x.Age }, new CompContents());


            Console.WriteLine(grped.Count());

            foreach (var x in grped)
            {
                Console.WriteLine($"{x.Key.FirstName}/{x.Key.Age}");
                Console.WriteLine("-----------------------------------------------");
                foreach (var y in x.ToList())
                {
                    Console.WriteLine($"{y.FirstName}/{y.Age}/{y.LastName}/{y.ID}");
                }
                Console.WriteLine("***********************************************\n\n");
            }

            Console.WriteLine($"Grouped!\n\n");

            var distincted = list.Distinct(new CompContents());
            Console.WriteLine(distincted.Count());
            Console.WriteLine("Distincted \n\n");
        }

        private static void FunctionTestExOperator()
        {
            OperatorTestEx opt1 = new OperatorTestEx(4);
            opt1.NamesCollections.Add("A1-A");
            opt1.NamesCollections.Add("A1-B");
            OperatorTestEx opt2 = new OperatorTestEx(5);
            opt2.NamesCollections.Add("B1-A");
            opt2.NamesCollections.Add("B1-B");
            opt2.NamesCollections.Add("B1-C");
            opt2.NamesCollections.Add("B1-D");
            var opt = opt1 + opt2;

            Console.WriteLine($"Result: \nCount:{opt.NCCount}/AG:{opt.AG}");
            foreach (var str in opt.NamesCollections)
            {
                Console.WriteLine($"{str}");
            }
            Console.WriteLine($"For ex Message:{opt.Message}");
        }

        private static void FunctionTestOperator()
        {
            OperatorTest opt1 = new OperatorTest(2);
            opt1.NamesCollections.Add("A-A");
            opt1.NamesCollections.Add("A-B");
            OperatorTest opt2 = new OperatorTest(5);
            opt2.NamesCollections.Add("B-A");
            opt2.NamesCollections.Add("B-B");
            opt2.NamesCollections.Add("B-C");
            var opt = opt1 + opt2;

            Console.WriteLine($"Result: \nCount:{opt.NCCount}/AG:{opt.AG}");
            foreach (var str in opt.NamesCollections)
            {
                Console.WriteLine($"{str}");
            }
        }

        private static void FunctionTest1()
        {
            int thrg = 0;

            Func<int, int> func1 = (int i) =>
            {
                thrg += i;
                Console.WriteLine($"{thrg}");
                return i * i;
            };

            Console.WriteLine(func1(4));

            func1 = (int i) =>
            {
                thrg += i;
                Console.WriteLine($"{thrg}");
                return i + i;
            };

            Console.WriteLine(func1(4));

            Console.WriteLine($"--------------------------------------------------");

            TestFunc(func1);

            Console.WriteLine($"{thrg} in FunctionTest1");
        }

        private static void TestFunc(Func<int, int> func1)
        {
            //CallMethod
            int thrg = 0;
            Console.WriteLine(func1(3));
            Console.WriteLine($"--------------------------------------------------");
            Console.WriteLine($"{thrg} in TestFunc");
        }

        private static void EndInfor()
        {
            Console.WriteLine();
            Console.WriteLine($"Any key to exit......");
            Console.ReadKey();
        }
    }
}
