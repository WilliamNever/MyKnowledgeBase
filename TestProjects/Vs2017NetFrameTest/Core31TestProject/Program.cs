using Core31TestProject.Interfaces;
using Core31TestProject.MainTestFiles;
using Core31TestProject.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;
using OfficeOpenXml;
using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Core31TestProject
{
    class Program : IEqualityComparer<string>, IEqualityComparer<int>, IEqualityComparer<Employee>
    {
        private static IServiceCollection services = new ServiceCollection();
        private static IServiceProvider provider;
        static void Main(string[] args)
        {
            services.AddTransient<BsInterface, SvrClass>();
            services.AddTransient<BsInterface, ServicesClass>();

            services.AddTransient<Svr<string>, ServicesClass>();

            provider = services.BuildServiceProvider();

            #region Test Entrance methods
            //StringValueTest();
            //SelectManyTEST();
            //TFTest();
            //ListUnitIntersectExpectTest();
            //ListGroupTEST();
            //ListTEST();
            //IEqualityComparerTEST();
            //MemoryCacheTest();
            //DictionaryTest();
            //InterfaceWithBodyTest();
            //TupleTest();
            //ArrayTest();
            //AwaitTaskTest();
            //StringSplitTEST();
            //StaticConstructureTEST();
            //ListEntityTEST();

            //EPPlusCSVTEST();
            //EPPlusExcelTEST();

            //ValueTest();
            //Task.Run(async () =>
            //{
            //    await TaskSearchReturnValueTest();
            //}).Wait();
            //TaskConcurrentLimited();
            //SerialObjTEST();
            //SftpTest();
            //FileNameSubTest();
            //DateTimeTest();
            #endregion

            #region BranchMainTest
            TestBaseForMainEntrance fBranchMain
                = new ThirdBranchMainEntrance();
            //= new FBranchMainEntrance();
            //= new SolvedScenarioService();
            fBranchMain.MainRun();
            #endregion
            //<---------------------------------------->\\
            EndInfor();
        }

        private static void DateTimeTest()
        {
            List<int> intList = new List<int> { 2,1,5,3,6,7,22,12 };
            var itm = intList.OrderByDescending(x => x).First();

            var now = DateTime.Now;
            var nowAdded = now.AddMinutes(2D);
            var span = nowAdded.Subtract(now);
            Console.WriteLine($"{span.TotalSeconds}");
        }

        private static void FileNameSubTest()
        {
            var fname = "ftp://www.ds.com/aaa";
            Console.WriteLine($"{Path.GetFileName(fname)}/{Path.GetExtension(fname) == ""}");

            Console.WriteLine($"{Path.Combine(Environment.CurrentDirectory, "src")}");
        }

        private static void TaskConcurrentLimited()
        {
            var semaphoreForRecord = new SemaphoreSlim(3, 5);
            List<Task<string>> tList = new List<Task<string>>();
            for (int i = 0; i < 30; i++)
            {
                tList.Add(Task.Run(() => {
                    int rec = i;
                    semaphoreForRecord.Wait();
                    Console.WriteLine($"Task {rec} running");
                    Thread.Sleep(1000);
                    semaphoreForRecord.Release();
                    return rec.ToString();
                }));
            }
            Task.WhenAll(tList).Wait();

            Console.WriteLine($"All finished...");
        }

        private static void SftpTest()
        {
            var connInfoSource = new PasswordConnectionInfo("", 22, "", "");
            using (var sftp = new SftpClient(connInfoSource))
            {
                sftp.Connect();
                sftp.ChangeDirectory("outgoing");
                var ftpFiles = sftp.ListDirectory(".").ToList();
                var root = sftp.ListDirectory("").ToList();

                var Directories = ftpFiles.Where(x => x.IsDirectory).ToList();
                var files = ftpFiles.Where(x => x.IsRegularFile).ToList();
            }
        }

        private static void SerialObjTEST()
        {
            string[] Arr1 = new string[] { "NJ", "OH", "IA", "NE", "KS", "MD", "UT" };
            string str = Newtonsoft.Json.JsonConvert.SerializeObject(Arr1);

            string[] arr2 = new string[] { "KY", "MI", "NH", "RI", "WI", "ID", "AK", "HI", "NV", "OK", "MS", "LA" };
            string[] arr3 = new string[] { "IL", "IN", "MA", "AR", "ME", "ND", "MT", "CO", "OR", "AZ", "CA", "WA", "WY" };
            string[] arr4 = new string[] { "FL", "GA", "PA", "SC", "TN", "TX", "VA", "WV", "SD", "MN", "NM", "AL" };
            string[] arr5 = new string[] { "CT", "DE", "NC", "NY", "MS", "VT" };

            var list = new List<string>();
            list.AddRange(Arr1);
            list.AddRange(arr2);
            list.AddRange(arr3);
            list.AddRange(arr4);
            list.AddRange(arr5);

            int oriRecNum = list.Count;
            int distinctNum = list.Distinct().ToList().Count;
            var grp = list.GroupBy(x => x).Select(x => new { name = x.Key, num = x.Count() }).Where(x => x.num > 1).ToList();
        }

        private static async Task TaskSearchReturnValueTest()
        {
            var tsk1 = ReturnTestIntValueAsync(3000, 11);
            var tsk2 = ReturnTestIntValueAsync(5000, 12);
            var tsk3 = ReturnTestIntValueAsync(8000, 13);

            var result = await Task.WhenAll(tsk1, tsk2, tsk3)
                .ContinueWith((tt) =>
                {
                    var rs = tt.Result;
                    Console.WriteLine(rs.Length);
                    return rs;
                })
                ;
            Console.WriteLine($"----------------------------------------------------------");
            foreach (int it in result)
            {
                Console.WriteLine(it);
            }
        }

        private static async Task<int> ReturnTestIntValueAsync(int sleeping, int id)
        {
            //if (id == 13)
            //    throw new Exception("Nothing");
            return await Task.Run(() => { 
                Thread.Sleep(sleeping);
                //if (id == 13)
                //    throw new Exception("Nothing");
                Console.WriteLine(id);
                return id; 
            });
        }

        private static void ValueTest()
        {
            var aaa = default(DateTime?);
            var dt = DateTime.Now;
            var dta = dt.Date;
            var dtb = dta.AddDays(45D);
        }

        private static void EPPlusCSVTEST()
        {
            ExcelTextFormat format = new ExcelTextFormat();
            format.Delimiter = '\t';
            format.Culture = new CultureInfo(Thread.CurrentThread.CurrentCulture.ToString());

            //format.DataTypes = new eDataTypes[] { eDataTypes.String, eDataTypes.String, eDataTypes.String, eDataTypes.String };
            //format.SkipLinesBeginning = 1;
            //format.Culture.DateTimeFormat.ShortDatePattern = "dd-mm-yyyy";
            //format.Encoding = new UTF8Encoding();

            //List<eDataTypes> list = new List<eDataTypes>();
            //for (int i = 0; i < 50; i++)
            //{
            //    list.Add(eDataTypes.String);
            //}
            //format.DataTypes = list.ToArray();

            string csvPath = @"D:\Temp\OFP\Extracts\11111.TXT";

            StringBuilder sb = new StringBuilder();
            var finfo = new FileInfo(csvPath);

            string fline;
            using (var strm = finfo.OpenText())
            {
                fline = strm.ReadLine();
            }

            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells["A1"].LoadFromText(finfo, format);

                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;

                //List<eDataTypes> list = new List<eDataTypes>();
                //for (int i = 0; i < ColCount; i++)
                //{
                //    list.Add(eDataTypes.String);
                //}
                //format.DataTypes = list.ToArray();
                //worksheet.Cells["A1"].LoadFromText(finfo, format);

                for (int row = 1; row <= rowCount; row++)
                {
                    sb.Append($"{row}\t");
                    for (int col = 1; col <= ColCount; col++)
                    {
                        var cell = worksheet.Cells[row, col];
                        var tmp = (cell.Value ?? "").ToString() + "\t";
                        //var tmp = (cell.Text ?? default) + "\t";
                        sb.Append(tmp);
                    }
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                }
            }
            var txt = sb.ToString();
        }

        private static void EPPlusExcelTEST()
        {
            string exlPath = @"D:\Temp\20201009.xlsx";

            StringBuilder sb = new StringBuilder();
            var finfo = new FileInfo(exlPath);
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(finfo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;
                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 1; col <= ColCount; col++)
                    {
                        var cell = worksheet.Cells[row, col];
                        var tmp = cell.Text.ToString() + "\t";
                        sb.Append(tmp);
                    }
                    worksheet.SetValue(row, ColCount + 1, "Hello Kitty!");
                    sb.Append(Environment.NewLine);
                }
                package.Save();
            }
            var txt = sb.ToString();
        }

        private static void ListEntityTEST()
        {
            var list = new List<NameContainer>() {
                new NameContainer{ FirstName="aaa" },
                new NameContainer{  FirstName="bbb"}
            };
            var itm = list.FirstOrDefault();
            list.RemoveAll(x => true);
            itm.FirstName = "CCC";
        }

        private static void StaticConstructureTEST()
        {
            int ix = 1;
            ix = ++ix;
            var list = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("key", "value") };
            var str = Newtonsoft.Json.JsonConvert.SerializeObject(list);

            var isrunning = ExFromBase.IsRunning;
            var istrue = ExFromBase.IsTrue;

            var isbaseT = BaseClass.IsTrue;
        }

        private static void StringSplitTEST()
        {
            string aaa = "====";
            var array = aaa.Split("=");
        }

        private static void AwaitTaskTest()
        {
            Base2 bs2 = new Base2 { Acx = 100 };
            var tt = Task.Run(() => { return bs2; });
            var bsGet = GetFromTask(tt).Result;
            bs2.Acx = -1;
            var bsGet1 = GetFromTask(tt).Result;
        }

        private async static Task<Base2> GetFromTask(Task<Base2> tt)
        {
            return await tt;
        }

        private static void ArrayTest()
        {
            int[] intArray = new int[] { 1, 2, 3, 4, 5, 10, 20, 30, 40, 50, 90 };
            var mm = intArray[^1];
            Console.WriteLine($"{mm}");

            Task.Run(async () => {
                var tts = await GetVsAsync(string.Join(", ", intArray));
                Console.WriteLine(tts);
            }).Wait();

            int[] intOthArray = new int[] { 1, 2, 3, 4, 5, 10, 20, 30, 40, 50, 90, 120 };

            var existers = intOthArray.Where(_ => intArray.Any(x => x == _)).ToList();
            var notExisters = intOthArray.Where(_ => !intArray.Any(x => x == _)).ToList();
        }
        private static async Task<string> GetVsAsync(string str)
        {
            return str;
        }
        private static void TupleTest()
        {
            List<Tuple<string, int>> tuples = new List<Tuple<string, int>> {
                new Tuple<string, int>("hello", 1),
                new Tuple<string, int>("hello", 2),
                new Tuple<string, int>("hello3", 3),
                new Tuple<string, int>("hello3", 4),
                new Tuple<string, int>("hello5", 5),
            };
            var tuple = tuples.Where(x => x.Item2 == 3).FirstOrDefault();
            var tuple1 = tuples.Where(x => x.Item2 == 30).FirstOrDefault();

            var grpd = tuples.GroupBy(x => x.Item1).ToList();

            _ = Task<bool>.Run(() =>
                {
                    Console.WriteLine($"In Task...");
                    return true;
                }
            );
            Console.WriteLine(tuples[^1].Item1);
        }

        private static void InterfaceWithBodyTest()
        {
            CSLog cslog = new CSLog();
            cslog.NullAttrTest = null;
            //cslog.ConsoleLog();
            cslog.ConsoleLogPub();
            cslog.ConSoleLogContents();
            (cslog as ICSLog).ConSoleLogContents();
            cslog.CSL();

            Console.WriteLine(cslog.NullAttrTest is null);

            ValidationContext context = new ValidationContext(cslog);
            List<ValidationResult> results = new List<ValidationResult>();
            bool isValid;

            isValid = Validator.TryValidateObject(cslog, context, results, true);
            Console.WriteLine(isValid);

            context.DisplayName = "NullAttrTest";
            context.MemberName = "NullAttrTest";
            isValid = Validator.TryValidateProperty(cslog.NullAttrTest, context, results);
            Console.WriteLine(isValid);

            isValid = Validator.TryValidateValue(null, context, results, new List<ValidationAttribute> { new RequiredAttribute() });
            Console.WriteLine(isValid);

            Employee strInfo = null;
            cslog.DisableNullInput(ref strInfo);
        }

        private static void DictionaryTest()
        {
            Dictionary<int, string> dics = new Dictionary<int, string> { { 1, "k1" }, { 2, "k2" }, { 3, "k3" } };
            var sms = dics.GetValueOrDefault(2, "K4");
        }

        private static void MemoryCacheTest()
        {
            MemoryCacheOptions mOption = new MemoryCacheOptions
            {
                ExpirationScanFrequency = TimeSpan.FromMinutes(2)
                ,SizeLimit = 2
            };
            MemoryCache memoryCache = new MemoryCache(mOption);

            Func<CacheItemPriority, long, MemoryCacheEntryOptions> CacheItemOption =
            (CacheItemPriority itemPriority, long size) =>
            {
                var slidingTimeSpan = TimeSpan.FromMinutes(1);
                var NowDateTime = DateTimeOffset.Now;
                MemoryCacheEntryOptions CacheOptions = new MemoryCacheEntryOptions().SetSize(size);
                var removeDateTime = NowDateTime.DateTime.Add(TimeSpan.FromMinutes(5d));
                CacheOptions.SetAbsoluteExpiration(removeDateTime)
                    .SetSlidingExpiration(slidingTimeSpan)
                    .RegisterPostEvictionCallback(
                        delegate (object key, object value, EvictionReason reason, object state)
                        {

                        }
                    );

                CacheOptions.SetPriority(itemPriority);
                return CacheOptions;
            };
            string item = "ForKey1";
            item = null;
            memoryCache.Set("Key1", item, CacheItemOption.Invoke(CacheItemPriority.Low, 2));
            memoryCache.Set("Key2", "ForKey2", CacheItemOption.Invoke(CacheItemPriority.Low, 1));
        }

        private static void IEqualityComparerTEST()
        {
            List<Employee> ems = new List<Employee> {
                new Employee { FName="AA" },
                new Employee { FName="Aa" },
                new Employee { FName="aA" },
                new Employee { FName="aa" },
                new Employee { FName="BB" },
            };
            string[] comp = new string[] { "aa" };
            var list = ems.Where(x => comp.Contains(x.FName, new Program()));
            var list1 = ems.Where(x => comp.Any(y => y.Equals(x.FName, StringComparison.OrdinalIgnoreCase)));
            var distictList = ems.Distinct(new Program()).ToList();
            var taskNum = ems.Skip(-1).Take(1).ToList();

            string strReturned, NameString = "William";
            var NameObj = new NameContainer { FirstName = "William" };
            Employee em, newEm;
            var task = Task.Run(async () => {
                em = new Employee();
                strReturned = await em.ChangeValueForRefTest(NameString);
                newEm = await em.ChangeValueForRefTest(em);
                var nameStr = await em.ChangeValueForRefTest(NameObj);
            });
            task.Wait();

            var subList = ems.Take(3).ToList();
            ems.RemoveAt(0);
            ems.RemoveAt(0);
            ems.RemoveAt(0);
            var ssz = subList;
        }

        private static void ListTEST()
        {
            var srv = provider.GetRequiredService<Svr<string>>();
            var srv1 = provider.GetRequiredService<Svr<string>>();
            var srv2 = provider.GetRequiredService<BsInterface>();

            var svrs = provider.GetServices<BsInterface>();

            List<string> list = new List<string>();
            var str = list.FirstOrDefault();
        }

        private static void ListGroupTEST()
        {
            var empList = new List<Employee>
                {
                    new Employee {ID = 1, FName = "John", Age = 23, Sex = 'M'},
                    new Employee {ID = 2, FName = "Mary", Age = 25, Sex = 'F'},
                    new Employee {ID = 3, FName = "Amber", Age = 23, Sex = 'M'},
                    new Employee {ID = 4, FName = "Kathy", Age = 25, Sex = 'F'},
                    new Employee {ID = 5, FName = "Lena", Age = 27, Sex = 'F'},
                    new Employee {ID = 6, FName = "Bill", Age = 28, Sex = 'M'},
                    new Employee {ID = 7, FName = "Celina", Age = 27, Sex = 'F'},
                    new Employee {ID = 8, FName = "John", Age = 28, Sex = 'M'},
                    new Employee {ID = 9, FName = "Cacy", Age = 23, Sex = 'F'},
                };
            var QueryWithLamda = empList.GroupBy(x => new { x.Age, x.Sex }).ToList();
        }

        private static void ListUnitIntersectExpectTest()
        {
            string ccc = "s0.-.0ss-vvvv";
            Console.WriteLine($"{ccc.IndexOf('-')} - {ccc.LastIndexOf('-')}");
            List<string> lA = new List<string> { "1", "2", "3", "4", "5B" };
            List<string> lB = new List<string> { "4", "5b", "6", "7", "8" };
            var list = lA.Except(lB).ToList();
            var leftSkus = lA.Where(x => !lB.Contains(x)).ToList();
            var lc = lB.Select(x => x.ToUpper()).ToList();
        }

        private static void TFTest()
        {
            Console.WriteLine("".Equals(null));
            object obj = DateTime.Parse("2020-05-21T20:45:55.813Z");
            var dt = (DateTime)obj;
            var dt1 = Convert.ToDateTime(obj);

            string emt = "";
            bool isTrue = emt?.Length > 2;
            Console.WriteLine(isTrue);

            Regex reg = new Regex(@"^[\d ]+$");
            bool isValid = reg.IsMatch(emt);
            Console.WriteLine(isValid);
        }

        private static void SelectManyTEST()
        {
            var list = new List<Base0> {
                new Base0{ Rec=1, b1List =new List<Base1>{ new Base1 { Acg=1, b2List=new List<Base2> { new Base2 { Acx=1 } } }, null } },
                new Base0{ Rec=2, b1List =new List<Base1>{ new Base1 { Acg=2, b2List=new List<Base2> { new Base2 { Acx=2 } } },null } },
                null,
                new Base0{ Rec=3, b1List =new List<Base1>{ null } },
                new Base0{ Rec=4, b1List =null },
            };

            var surfaces = list?
                .Where(x => x != null && x.b1List != null).SelectMany(x => x.b1List).Where(x => x != null).ToList();
            var surfaceAreas = surfaces.Where(x => x.b2List != null).SelectMany(x => x.b2List)
                .Where(x => x != null).ToList();

            Console.WriteLine();
        }

        private static void StringValueTest()
        {
            StringValues sv = new StringValues(new string[] { "Infors", "Inf1", "Inf2", "Inf3", "Inf4" });
            var ssr = sv.ToString();
            var ssr1 = sv.ToList();

            string tt = "aa";
            var resBool = (tt?.Equals("aa")) ?? false;

            string[] svcString = null;
            StringValues svV = new StringValues(svcString);
            Console.WriteLine(svV.ToString());
        }

        private static void EndInfor()
        {
            Console.WriteLine();
            Console.WriteLine($"Any key to exit......");
            Console.ReadKey();
        }

        #region inline interface
        bool IEqualityComparer<string>.Equals(string x, string y)
        {
            return x.Equals(y, StringComparison.OrdinalIgnoreCase);
        }
        int IEqualityComparer<string>.GetHashCode(string obj)
        {
            return this.GetHashCode();
        }
        bool IEqualityComparer<int>.Equals(int x, int y)
        {
            return x == y;
        }
        int IEqualityComparer<int>.GetHashCode(int obj)
        {
            return this.GetHashCode();
        }

        bool IEqualityComparer<Employee>.Equals(Employee x, Employee y)
        {
            return x.FName.Equals(y.FName, StringComparison.OrdinalIgnoreCase);
        }

        int IEqualityComparer<Employee>.GetHashCode(Employee obj)
        {
            return this.GetHashCode();
        }
        #endregion
    }
}
