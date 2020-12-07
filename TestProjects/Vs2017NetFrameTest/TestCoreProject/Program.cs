using KellermanSoftware.CompareNetObjects;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using NetStandardLibrary.ConvertHelpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using TestCoreProject.ClassExTest;
using TestCoreProject.Enums;
using TestCoreProject.Models;
using TestCoreProject.Services;

namespace TestCoreProject
{
    class Program
    {
        private static IServiceCollection services;
        static Program()
        {
            services = new ServiceCollection();

            services.AddSingleton(op => new AATest(services.BuildServiceProvider().GetRequiredService<BATest>(), "Injection_AMess"));
            services.AddTransient(op => { Func<string, AATest> method = (Message) => { return services.BuildServiceProvider().GetRequiredService<AATest>(); }; return method; });
            services.AddSingleton(op => new BATest(services.BuildServiceProvider().GetService<Func<string, AATest>>(), "Injection_BMess"));
            //services.AddTransient<CCTest>();
            services.AddScoped<CCTest>();
            services.AddTransient<BaseService>(x => new TestServices());

            services.AddSingleton<IGetSet>(op => new HttpClientResponse(services.BuildServiceProvider().GetRequiredService<BATest>(), "Injection_AMess"));
            services.AddTransient<BInIGETSET>();
        }
        static void Main(string[] args)
        {
            #region expired Test Methods
            //TaskCancellationTokenSourceTest().Wait();
            //MemoryCacheTEST();
            //TimerTest();
            //CopyListTest();
            //TimeSpanTEST();

            //ListAddRemovedInTwoTask();
            //ReferenceConvertTest();
            //TaskReActTest().Wait();
            //ListSkipTakeTest();
            //ReflectObjectTest();

            //ComplexClassReferences();
            //RegisterServicesTest();
            //var ABaseClass = InjectionTest3();
            //DynamicTest();
            //InjectionTest4();

            //StringTest();
            //InjectionTest5();
            //XdocTest();
            //MemoryCacheTestV2();
            //EnumTest();

            //TaskTestReTest().Wait();
            //Console.WriteLine(DateTimeOffset.Now);
            //SortForDateTime();
            //BoolOperationTest();

            //ArrayConvertTEST();

            //IntTryParseTEST();

            //DictionaryCollectionTest();

            //LockTest();

            //EnumerableRangeTest();

            //Console.WriteLine(string.Join("||", new List<string>() { "1", "2", "3" }));

            //OutPutTest();

            //EnumDescriptionAttributeTest();

            //AddScopedTest();

            //CircularReferencesValidate();

            //ListAddRemoveInteract();

            //TaskConcurrentLimited();

            //PathTest();


            //NewtonTEST();

            //InjectionTest6();

            //ListReferenceTEST();

            //PathCutTest();

            //Core11.Class1 c11 = new Core11.Class1();



            //TaskReturResultTEST().Wait();

            //HttpReadHeaderTest();

            KeyValuePairValueTEST();

            //DerivedTest();

            //ArrayTEST();

            //IncludedClassTest();
            //ChildInjectTest();
            #endregion

            //IsEqualTEST();

            EndInfor();
        }

        private static void IsEqualTEST()
        {
            var aa = (object)4;
            var rslx = aa is (object)4;
            var rsl = aa == (object)4;
            Console.WriteLine(rsl);

            /*
             * Summary
             * 'is' equal, it compared the values.
             * '==' equal, it compared the reference of the object.
             */

            TestFdBEx test = new TestFdBEx();
            var rsl1 = test is TestFDeriveBase;
            TestFDeriveBase xx = new TestFDeriveBase();
            var rsl2 = xx is TestFdBEx;
            TestFDeriveBase xsx = new TestFdBEx();
            var rsl3 = xsx is TestFdBEx;
            Console.WriteLine(rsl1);
        }

        private static void ChildInjectTest()
        {
            var cct = services.BuildServiceProvider().GetService<BaseService>();
            string cname = cct.GetClassName();
            Console.WriteLine(cname);
            Console.WriteLine("-----------------------------------");
            Console.WriteLine(new BaseService().GetClassName());
            Console.WriteLine(new TestServices().GetClassName());
        }

        private static void IncludedClassTest()
        {
            string pattern = "{0} |-| {1}";
            string p1 = string.Format(pattern, 1, "{0}");
            Console.WriteLine(p1);
            Console.WriteLine(string.Format(p1, 2));

            IncludedCpontModel icm = new IncludedCpontModel();
            var cmp = icm.CpModel;
            var tp = cmp.GetType();

            var type = typeof(ReflectCreatedModel);
            var objBase = type.Assembly.CreateInstance(type.FullName) as ReflectCreatedModel;

            var obj = type.Assembly.CreateInstance(type.FullName, true,
                System.Reflection.BindingFlags.CreateInstance, null, new object[] { 4, 9 }, CultureInfo.CurrentCulture, null) as ReflectCreatedModel;
            var obj1 = type.Assembly.CreateInstance(type.FullName, true,
                System.Reflection.BindingFlags.CreateInstance, null, null, CultureInfo.CurrentCulture, null) as ReflectCreatedModel;
            var obj2 = type.Assembly.CreateInstance(type.FullName, true,
                System.Reflection.BindingFlags.Default, null, new object[] { 5, 56 }, CultureInfo.CurrentCulture, null) as ReflectCreatedModel;
            var obj3 = type.Assembly.CreateInstance(type.FullName, true,
                System.Reflection.BindingFlags.Default, null, null, CultureInfo.CurrentCulture, null) as ReflectCreatedModel;

            var obj11 = Activator.CreateInstance(type, 3, 5) as ReflectCreatedModel;
            var obj12 = Activator.CreateInstance<ReflectCreatedModel>();
        }

        private static void DerivedTest()
        {
            string str = string.Join(',', new List<string> {  });

            int ixc = 10000;
            Console.WriteLine(ixc.ToString("N0"));
            Console.WriteLine($"/{ixc:N0}/");

            TestFdEx1 tfx1 = new TestFdEx1();
            tfx1.WriteInfor();
        }

        private static void KeyValuePairValueTEST()
        {
            var ssd = null ?? "";
            Regex reg = new Regex("^[a-zA-Z0-9]{0,30}$");
            var isMatch = reg.IsMatch("");

            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("aaa","aaav"),
                new KeyValuePair<string, string>("bbb","bbbv"),
            };
            var rs = list.FirstOrDefault(x => x.Key == "aaax");
            //isMatch = reg.IsMatch(rs.Value);
        }

        private static void HttpReadHeaderTest()
        {
            //List<string> list = null;

            //foreach (string itm in list)
            //{
            //}

            string url = "https://demo.nowsource.nowdocs.com/images/KLIC-Header.jpg";
            System.Net.Http.HttpClient _httpClient = new System.Net.Http.HttpClient();
            var response = _httpClient.GetAsync(url, System.Net.Http.HttpCompletionOption.ResponseHeadersRead).Result;
        }

        private async static Task TaskReturResultTEST()
        {
            var buyersTask = Task.Run(() => { return default(List<BaseTestModel>); });
            var result = await buyersTask as List<BaseTestModel>;
            var grouped = result?.GroupBy(x => x.Name);
        }

        private static void PathCutTest()
        {
            string path = "\\\\ppp\\c:\\gg\\p.txty";
            Console.WriteLine(Path.GetFileName(path));
            Console.WriteLine(Path.GetFileNameWithoutExtension(path));
            Console.WriteLine(Path.GetExtension(path));
        }

        private static void ListReferenceTEST()
        {
            CtorTestModel ct = new CtorTestModel();


            BaseTestModel jb = new BaseTestModel { Lid = 1, Age = 1000 + 1, Name = $"Name {1}" };
            object jbObj = jb;
            var jsStr = Newtonsoft.Json.JsonConvert.SerializeObject(jbObj);
            var objectSerial = Newtonsoft.Json.JsonConvert.DeserializeObject<object>(jsStr);
            var objectSerial1 = Newtonsoft.Json.JsonConvert.DeserializeObject<BaseTestModel>(objectSerial.ToString());
            Console.WriteLine(objectSerial.ToString());


            BaseTestModel[] baseTestModels = new BaseTestModel[10];
            for (int i = 0; i < 10; i++)
            {
                baseTestModels[i] = new BaseTestModel { Lid = i, Age = 1000 + i, Name = $"Name {i}" };
            }

            var items = baseTestModels.ToList();

            foreach (var itm in items)
            {
                baseTestModels = new BaseTestModel[] { itm };
            }
        }

        private static void InjectionTest6()
        {
            var provider = services.BuildServiceProvider();
            var cct = provider.GetService<IGetSet>();
            Console.WriteLine(cct.Get());
            var service1 = provider.GetService<BInIGETSET>();
            Console.WriteLine(service1.GetString());

            cct.Set("Update a new valeu.");

            Console.WriteLine(service1.GetString());

            var cct1 = provider.GetService<IGetSet>();
            Console.WriteLine(cct1.Get());
            Console.WriteLine(provider.GetService<BInIGETSET>().GetString());
        }

        private static void NewtonTEST()
        {
            var str = Newtonsoft.Json.JsonConvert.SerializeObject(new TModel { Infor = "A", NaList = new List<string> { "AAA", "BBB", "CCC" } });
            Console.WriteLine(str);
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject<TModel[]>("[" + str + "," + str + "]");
        }

        private static void PathTest()
        {
            string path = "d:\\ssa\\abv.svgs";
            Console.WriteLine(Path.GetFileNameWithoutExtension(path));
            var st = Path.GetExtension(path);
            Console.WriteLine(st);

            List<TModelVa> tmvList = new List<TModelVa>() {
                new TModelVa() { Infor=1 },
                new TModelVa() { Infor=2 },
                new TModelVa() { Infor=3 },
                new TModelVa() { Infor=4 },
                new TModelVa() { Infor=5 },
            };

            for (int i = 0; i < tmvList.Count; i++)
            {
                //var model = tmvList[i];
                tmvList[i] = new TModelVa { Infor = 10 + i };
            }
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

        private static void ListAddRemoveInteract()
        {
            List<int> aaa = new List<int> { 1, 2, 5, 3, 4, 5 };
            List<int> bbb = new List<int> { 1, 5, 5, 6 };

            var ccc = aaa.Except(bbb).ToList();
            var ddd = aaa.Union(bbb).ToList();
            var eee = aaa.Intersect(bbb).ToList();

            List<BaseTestModel> list1 = new List<BaseTestModel> {
                new BaseTestModel { Age = 11, Lid = 2, Name = "bbb", Gid = Guid.Empty }
                ,new BaseTestModel { Age = 11, Lid = 2, Name = "bbb", Gid = Guid.Empty },
                new BaseTestModel { Age = 10, Lid = 1, Name = "aaa", Gid = Guid.Empty }
                ,null
            };

            List<BaseTestModel> list2 = new List<BaseTestModel> {
                new BaseTestModel { Age = 10, Lid = 1, Name = "aaa", Gid = Guid.Empty }
                ,new BaseTestModel { Age = 10, Lid = 1, Name = "aaa", Gid = Guid.Empty }
                ,new BaseTestModel { Age = 11, Lid = 2, Name = "bbb", Gid = Guid.Empty }
                //,new BaseTestModel { Age = 11, Lid = 2, Name = "bbb", Gid = Guid.Empty }
                ,null
            };

            var compare = new CompareLogic();
            var result = compare.Compare(list1, list2);

            var inter = list1.Intersect(list2, new BaseTestModel()).ToList();
        }

        private static void CircularReferencesValidate()
        {
            List<ComponentModel> circuled = new List<ComponentModel> {
                new ComponentModel{ line_number = 1, parent_line_number = 2},
                new ComponentModel{ line_number = 2, parent_line_number = 1},

                //new ComponentModel{ line_number = 1, parent_line_number = 2},
                //new ComponentModel{ line_number = 2, parent_line_number = 3},
                //new ComponentModel{ line_number = 3, parent_line_number = 1},

                //new ComponentModel{ line_number = 2, parent_line_number = 3},
                //new ComponentModel{ line_number = 1, parent_line_number = 2},
                //new ComponentModel{ line_number = 3, parent_line_number = 1},

                //new ComponentModel{ line_number = 1, parent_line_number = 2},
                //new ComponentModel{ line_number = 2, parent_line_number = 3},
                //new ComponentModel{ line_number = 2, parent_line_number = 4},
                //new ComponentModel{ line_number = 3, parent_line_number = 1}
            };
            List<ComponentModel> noCircule = new List<ComponentModel>() {
                new ComponentModel{ line_number = 1, parent_line_number = 2},
                new ComponentModel{ line_number = 2, parent_line_number = 3},
                new ComponentModel{ line_number = 3, parent_line_number = 4}
            };

            List<ComponentModel> bigModels = new List<ComponentModel>();
            for (int i = 0; i < 10000; i++)
            {
                bigModels.Add(new ComponentModel { line_number = i, parent_line_number = i + 1 });
            }
            //bigModels.Add(new ComponentModel { line_number = 10000, parent_line_number = 5 });
            var TestList = bigModels;


            Console.WriteLine($"Begin to Validate - {DateTime.Now.ToString()}..............");
            var isValid = ListSearchTEST(TestList);
            Console.WriteLine($"Is Valid = '{isValid}'");
            Console.WriteLine($"End validation - {DateTime.Now.ToString()}");
        }

        private static bool ListSearchTEST(List<ComponentModel> TestList)
        {
            bool isValid = true;
            List<ComponentModel> hasValidated = new List<ComponentModel>();
            Stack<int> exams = new Stack<int>();

            ComponentModel[] copied = new ComponentModel[TestList.Count];
            TestList.CopyTo(copied);
            var copiedList = copied.ToList();
            var cmp = copiedList.FirstOrDefault();
            if (cmp == null) return isValid;
            do
            {
                //copiedList.RemoveAll(x => x.line_number == cmp.line_number && x.parent_line_number == cmp.parent_line_number);
                var htCode = cmp.line_number;
                hasValidated.Add(cmp);
                exams.Push(htCode);
                var nxt = TestList.FirstOrDefault(x => x.line_number == cmp.parent_line_number);
                if (nxt != null)
                {
                    do
                    {
                        hasValidated.Add(nxt);
                        isValid = !exams.Any(x => x == nxt.parent_line_number);
                        if (!isValid) break;
                        exams.Push(nxt.line_number);
                        nxt = TestList.FirstOrDefault(x => x.line_number == nxt.parent_line_number);
                    } while (nxt != null);
                    if (!isValid) break;
                }
                exams = new Stack<int>();
                copiedList = TestList.Except(hasValidated).ToList();
                cmp = copiedList.FirstOrDefault();
            } while (cmp != null);
            return isValid;
        }

        private static void FindParentsSearch(List<ComponentModel> TestList)
        {
            Stack<ComponentModel> stck = new Stack<ComponentModel>();
            List<ComponentModel> hasValidated = new List<ComponentModel>();
            foreach (var cmp in TestList)
            {
                if (hasValidated.Any(x => x.line_number == cmp.line_number && x.parent_line_number == cmp.parent_line_number))
                    continue;
                stck.Push(cmp);
                var isValid = ValidFunc(cmp, TestList, stck);
                if (!isValid) break;
                hasValidated.AddRange(stck);
                stck = new Stack<ComponentModel>();
            }
        }

        private static bool ValidFunc(ComponentModel SNode, List<ComponentModel> ALLElements, Stack<ComponentModel> stck)
        {
            bool rValue = true;
            var children = ALLElements.FindAll(x => x.line_number == SNode.parent_line_number).ToList();
            foreach (var child in children)
            {
                var searched = stck.Any(x => x.line_number == child.parent_line_number);
                stck.Push(child);
                rValue = searched ? false : ValidFunc(child, ALLElements, stck);
                if (!rValue)
                {
                    Console.WriteLine($"Got it!({child.line_number},{child.parent_line_number})");
                    break;
                }
            }
            return rValue;
        }

        private static void AddScopedTest()
        {
            var provider = services.BuildServiceProvider();
            var ctst = provider.GetService<CCTest>();
            var c1tst= provider.GetService<CCTest>();

            Console.WriteLine("");
        }

        private static void EnumDescriptionAttributeTest()
        {
            var attrs = typeof(EnWeekDay).GetField(EnWeekDay.Monday.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);
            var attrs1 = typeof(EnWeekDay).GetField(EnWeekDay.Friday.ToString())
                .GetCustomAttributes(typeof(DescriptionAttribute), false);

            var values = typeof(EnWeekDay).GetEnumNames();
            var infors = (from x in values
                          let sattr = typeof(EnWeekDay).GetField(x).GetCustomAttributes(typeof(DescriptNamesAttribute), false)
                          where sattr.Length > 0
                          from y in sattr
                          select ((DescriptNamesAttribute)y).Description).ToList();

            var oInfor = (from x in values
                          let sattr = typeof(EnWeekDay).GetField(x).GetCustomAttributes(typeof(DescriptNamesAttribute), false)
                          where sattr.Length > 0
                          from y in sattr
                          select new { EnValue = x, ((DescriptNamesAttribute)y).Description }).ToList();
        }

        private static void OutPutTest()
        {
            System.Reflection.Assembly assemble = System.Reflection.Assembly.GetExecutingAssembly();
            string path = assemble.Location;
            string filename = System.IO.Path.GetFileName(path);

            Console.WriteLine(path);
            Console.WriteLine(filename);

            Console.WriteLine("----------------------------------------------------------------");

            object aa = new int[] { 1, 2, 3, 5, 4, 6 };
            Console.WriteLine(aa is Array);
            Console.WriteLine(aa is IList);
            Console.WriteLine(string.Join(", ", aa as IList<int>));
            Console.WriteLine(string.Concat(aa as IList<int>));
        }

        private static void ArrayTEST()
        {
            NodeAttr[] Items = {
                new NodeAttr{ name="id",value="1" },
                //new KeyValuePair<string,bool>("Status",true)
                new NodeAttr{name="Status",value ="true"}
            };

            List<object> oLst = new List<object>();
            var aaa = new NodeAttr { name = "id", value = "1" };
            XMLConverter<NodeAttr[]> xConvert = new XMLConverter<NodeAttr[]>();

            var str = xConvert.Serializer(Items);
            var deserObj = xConvert.DeSerializer(str);

            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Items);
            oLst.Add(new { id = 1 });
            oLst.Add(new { status = true });
            var jsn = Newtonsoft.Json.JsonConvert.SerializeObject(oLst.ToArray());
            //XMLConverter<object[]> oxConvert = new XMLConverter<object[]>();
            //var strOlst = oxConvert.Serializer(oLst.ToArray());

            TModel tmodel = new TModel()
            {
                Infor = "InforMation",
                NaList = new List<string> { "List1" }
            };

            var xmlString = @"
                    <?xml version=""1.0"" encoding=""utf-16""?>
                        <TModel xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
                          <Infor>InforMation</Infor>
                          <string>List1</string>
                        </TModel>
                ";  //<string>List2</string>

            XMLConverter<TModel> TMConvert = new XMLConverter<TModel>();
            var derObj = TMConvert.DeSerializer(xmlString);
        }


        private static void EnumerableRangeTest()
        {
            var list = Enumerable.Repeat(0, 50).ToList();
            Console.WriteLine($"{list.Count}");

            decimal mm = 3m;
            for (int i = 0; i < 10; i++)
            {
                mm += 0.1m;
                Console.WriteLine($"{mm}-{(int)mm}");
            }
        }

        private static void LockTest()
        {
            Dictionary<int, string> diction = new Dictionary<int, string>
            {
                { 1, "string1" },
                { 2, "string2" },
                { 3, "string3" }
            };

            Task.Run(() =>
            {
                lock (diction)
                {
                    if (diction.TryAdd(4, "string4")) Console.WriteLine($"Added the 4th object.");
                    Console.WriteLine($"Enter lock......");
                    //diction.Remove(2);
                    Thread.Sleep(5000);
                }
                Console.WriteLine($"Out lock......");
            });

            Thread.Sleep(1000);

            if (!diction.TryAdd(4, "string4")) Console.WriteLine($"Failed to add the 4th object.");
            //lock (diction)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (diction.TryGetValue(2, out string str))
                        Console.WriteLine($"{str} - {i} / {diction.Count}");
                }
            }
        }

        private static void DictionaryCollectionTest()
        {
            Dictionary<int, string> diction = new Dictionary<int, string>();
            diction.Add(1, "string");
            lock (diction)
            {
                diction.Remove(1);
                diction.Add(1, "bbbbbbb");
            }
        }

        private static void IntTryParseTEST()
        {
            int x = 8;
            Console.WriteLine(int.TryParse("5", out x));
            Console.WriteLine(x);
            Console.WriteLine(int.TryParse("10x", out x));
            Console.WriteLine(x);
            Console.WriteLine(int.TryParse(null, out x));
            Console.WriteLine(x);
            Console.WriteLine(int.TryParse("55".ToArray(), out x));
            Console.WriteLine(x);
        }

        private static void ArrayConvertTEST()
        {
            object arrayString = new string[] { "aa", "ab", "ac" };
            object arrayString1 = new List<string> { "aa", "ab", "ac" };

            IList array = arrayString as IList;
            IList array1 = arrayString1 as IList;
            IList array11 = arrayString1 as IList;

            var arrayList = array.OfType<string>().ToList();
            var arrayList1 = array1.OfType<string>().ToList();
        }

        private static void BoolOperationTest()
        {
            Console.WriteLine(false && RaisedException()); //短路运算，不会引发方法中的Exception
            Console.WriteLine(false & RaisedException());   //会引发方法中的Exception
        }

        private static bool RaisedException()
        {
            throw new NotImplementedException();
        }

        private static void SortForDateTime()
        {
            List<TListSort> list = new List<TListSort>();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
                list.Add(new TListSort { id = i, dt = DateTime.Now });
                Thread.Sleep(1000);
            }

            var ordered = list.Where(x => x.id > 15).OrderBy(x => x.dt).ToList();
        }

        private async static Task TaskTestReTest()
        {
            var task = Task.Run(async () => { var intVle = await GetIntValue(); return intVle; });

            Console.WriteLine($"task = {await task}");
            Console.WriteLine(
            string.Format("For {0}, no ship methods were found using {1}", "{0}", string.Join(':', "carrier", "service"))
            );
        }

        private async static Task<int> GetIntValue()
        {
            return await Task.Run(() => { return 100; });
        }

        private static void EnumTest()
        {
            //Array ary = Array.CreateInstance(typeof(string), 10);
            var enNames = Enum.GetNames(typeof(EnumTest));
            var enValues = Enum.GetValues(typeof(EnumTest));
            var itms = enValues.OfType<EnumTest>().ToList();
            EnumTest[] ets = (EnumTest[])enValues;

            var enWeekdayValue = Enum.Parse<EnWeekDay>("monday", true);
            Console.WriteLine(enWeekdayValue.GetDayName());

            Console.ReadLine();
        }

        private static void MemoryCacheTestV2()
        {
            MemoryCacheOptions mco = new MemoryCacheOptions();

            MemoryCache mc = new MemoryCache(mco);
            MyMemoryCacheTest mmc = new MyMemoryCacheTest(mco);

            mc.Set(1, 11);
            mmc.Set(2, 22);

            var value = mc.GetOrCreate(1, x =>
            {
                x.SlidingExpiration = TimeSpan.FromMinutes(3);
                return 33;
            });

            Console.WriteLine($"{value}");
            value = mc.GetOrCreate(2, x =>  // if the value exists, return the value, or add a cache entity with the cache entry option
            {
                x.SlidingExpiration = TimeSpan.FromMinutes(3);
                return 33;
            });
            Console.WriteLine($"{value}");
        }

        private static void XdocTest()
        {
            string xmlDocString
            #region the value of xmlDoc
                = @"
<DataDTO xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"" xmlns=""http://schemas.datacontract.org/2004/07/TaylorCorp.TD.ICSMCodes.DTO"">
  <Dataset>
    <CodeDefinitionDTO>
      <Code>BG</Code>
      <Definition>BAG</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2018-08-14T15:27:51.737</LastModified>
      <ModifiedBy>CORP\ZDonev</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>BK</Code>
      <Definition>Book</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2004-09-27T14:37:36</LastModified>
      <ModifiedBy>cdbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>BL</Code>
      <Definition>Bundle</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2018-08-14T15:27:29.22</LastModified>
      <ModifiedBy>CORP\ZDonev</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>BT</Code>
      <Definition>Bottle</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2018-08-14T15:28:15.71</LastModified>
      <ModifiedBy>CORP\ZDonev</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>BX</Code>
      <Definition>Box</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2004-09-27T14:37:36</LastModified>
      <ModifiedBy>cdbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>CA</Code>
      <Definition>Carton</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2009-03-27T12:52:37.9</LastModified>
      <ModifiedBy>CORP\cbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>CB</Code>
      <Definition>Cube</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2004-09-27T14:37:36</LastModified>
      <ModifiedBy>cdbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>CS</Code>
      <Definition>Case</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2004-10-19T11:13:28.17</LastModified>
      <ModifiedBy>cdbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>DZ</Code>
      <Definition>Dozen</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2004-09-27T14:37:36</LastModified>
      <ModifiedBy>cdbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>EA</Code>
      <Definition>Each</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2004-09-27T14:37:36</LastModified>
      <ModifiedBy>cdbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>FT</Code>
      <Definition>Feet</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2009-03-27T12:52:16.98</LastModified>
      <ModifiedBy>CORP\cbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>GA</Code>
      <Definition>Gallon</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2009-03-27T12:52:24.503</LastModified>
      <ModifiedBy>CORP\cbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>GS</Code>
      <Definition>Gross</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2004-09-27T14:37:36</LastModified>
      <ModifiedBy>cdbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>KT</Code>
      <Definition>Kit</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2018-08-14T15:29:57.187</LastModified>
      <ModifiedBy>CORP\ZDonev</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>LB</Code>
      <Definition>Pounds</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2006-04-12T18:22:19.02</LastModified>
      <ModifiedBy>Doug Griffin</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>LT</Code>
      <Definition>Lot</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2018-08-14T15:31:08.067</LastModified>
      <ModifiedBy>CORP\ZDonev</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>MI</Code>
      <Definition>Millions</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2004-09-27T14:37:36</LastModified>
      <ModifiedBy>cdbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>PD</Code>
      <Definition>Pad</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2004-09-27T14:37:36</LastModified>
      <ModifiedBy>cdbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>PK</Code>
      <Definition>Pack</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2004-09-27T14:37:36</LastModified>
      <ModifiedBy>cdbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>PL</Code>
      <Definition>Pallet</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2018-08-14T15:34:33.537</LastModified>
      <ModifiedBy>CORP\ZDonev</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>PR</Code>
      <Definition>Pair</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2018-08-14T15:32:15.493</LastModified>
      <ModifiedBy>CORP\ZDonev</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>RL</Code>
      <Definition>Roll</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2004-09-27T14:37:36</LastModified>
      <ModifiedBy>cdbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>RM</Code>
      <Definition>Ream</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2004-09-27T14:37:36</LastModified>
      <ModifiedBy>cdbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>SH</Code>
      <Definition>Sheet</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2018-08-14T15:33:50.173</LastModified>
      <ModifiedBy>CORP\ZDonev</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>SK</Code>
      <Definition>Skids</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2018-08-14T15:35:47.493</LastModified>
      <ModifiedBy>CORP\ZDonev</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>ST</Code>
      <Definition>Set</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2009-03-27T12:52:31.33</LastModified>
      <ModifiedBy>CORP\cbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>TB</Code>
      <Definition>Tub</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2018-08-14T15:34:11.3</LastModified>
      <ModifiedBy>CORP\ZDonev</ModifiedBy>
    </CodeDefinitionDTO>
    <CodeDefinitionDTO>
      <Code>TH</Code>
      <Definition>Thousands</Definition>
      <DomainName>ICSM</DomainName>
      <FieldName>unitOfMeasure</FieldName>
      <LastModified>2004-09-27T14:37:36</LastModified>
      <ModifiedBy>cdbuzzell</ModifiedBy>
    </CodeDefinitionDTO>
  </Dataset>
</DataDTO>
                "
            #endregion
                   ;
            var reader = new StringReader(xmlDocString);
            var xmlDoc = XDocument.Load(reader);
            reader.Close();
            XNamespace ns = @"http://schemas.datacontract.org/2004/07/TaylorCorp.TD.ICSMCodes.DTO";
            var xlst = xmlDoc.Element(ns + "DataDTO").Element(ns + "Dataset").Elements(ns + "CodeDefinitionDTO").ToList();
            var list = (from x in xlst
                       select new { Code = x.Element(ns + "Code").Value, Definition = x.Element(ns + "Definition").Value })
                       .ToList()
                     ;
        }

        private static void InjectionTest5()
        {
            var cct = services.BuildServiceProvider().GetService<CCTest>();
            Console.WriteLine(cct.Aatest.Messages);
            Console.WriteLine(cct.bATest.Messages);
            Console.WriteLine(cct.CtorFrom);
        }

        private static void StringTest()
        {
            string aa = (string)null;
            Console.WriteLine(aa==null);
            Console.WriteLine(aa?.Length > 10);
            Console.WriteLine(null > 10);

            aa = "000000000000000000000000";
            int i = 300;
            switch (i)
            {
                case 20:
                    aa += " - 20";
                    break;
                case 30:
                    aa += " - 30";
                    break;
            }
            Console.WriteLine(aa);
        }

        private static void InjectionTest4()
        {
            var cct = services.BuildServiceProvider().GetService<CCTest>();
            Console.WriteLine(cct.Aatest.Messages);
            Console.WriteLine(cct.bATest.Messages);
            Console.WriteLine(cct.CtorFrom);
        }

        private static void DynamicTest()
        {
            dynamic xc = 44;
            dynamic xd = "STR";

            ShowParameter(xc);
            ShowParameter(xd);

            Console.WriteLine("------------------------------------");

            dynamic tmdl = new TModel { Infor = "Messages" };
            dynamic tmdlVa = new TModelVa { Infor = 555 };
            ShowParameter(tmdl.Infor);
            ShowParameter(tmdlVa.Infor);
        }

        private static void ShowParameter(int xc)
        {
            Console.WriteLine($"Int Value = {xc + 100000}");
        }
        private static void ShowParameter(string xc)
        {
            Console.WriteLine($"String Value = / {xc} /");
        }

        private static AATest InjectionTest3()
        {
            AATest aa = null;
            BATest bb = null;
            Func<string, AATest> method = (Name) => {
                return aa;
            };

            bb = new BATest(method, "bb");
            aa = new AATest(bb, "aa");

            var isNull = aa == null;

            return aa;
        }

        private static void RegisterServicesTest()
        {
            var cc = services.BuildServiceProvider().GetService<AATest>();
            var dd = services.BuildServiceProvider().GetService<BATest>();

            var isNull = cc == null;
        }

        private static void ReflectObjectTest()
        {
            var t = typeof(AATest);
            AATest tobj = t.Assembly.CreateInstance(t.FullName, true, System.Reflection.BindingFlags.CreateInstance
                , null, new object[] {

                    typeof(BATest).Assembly.CreateInstance(typeof(BATest).FullName, true, System.Reflection.BindingFlags.CreateInstance
                        , null, new object[] {services.BuildServiceProvider().GetRequiredService<Func<string, AATest>>(), "InforsB" }, null, null) as BATest

                    ,"InforsA" }, null, null) as AATest;
            //var obj = Activator.CreateInstance(t);

            var constructuresList = t.GetConstructors();

            var ctor1 = constructuresList[0];
            //var ctor2 = constructuresList[1];

            //var types = ctor1.GetParameters()[0];

            var isNull = tobj == null;
        }

        private static void ComplexClassReferences()
        {
            //AATest atst = null;
            //AATest abtst;
            //abtst = new AATest(new BATest(atst, "BATest"), "AATest");
            //abtst.Batest.Aatest = new AATest(new BATest(abtst, "BATest1"), "AATest1");

            Func<string, AATest> method = (Message) =>
            {
                return services.BuildServiceProvider().GetRequiredService<AATest>();
            };

            BATest bt = new BATest(method, () => { return "messFunc"; });

            var isNULL = bt == null;
        }

        private static void ListSkipTakeTest()
        {
            List<int> intList = new List<int>();
            int length = 30;
            for (int i = 0; i < length; i++)
            {
                intList.Add(i);
            }

            var result = intList.Skip(10).Take(10);

            var filtered = result.Where(x => x > 150).ToList();

            var grped = result.GroupBy(x => x);

            List<TModel> tmList = new List<TModel> {
                null,
                new TModel { Infor = null, NaList = new List<string> { "1aa", "1bb", "1cc" } },
                new TModel { Infor = null, NaList = new List<string> { "2aa", "2bb", "2cc" } },
                new TModel { Infor = null, NaList = new List<string> { "3aa", "3bb", "3cc" } }
            };

            var rsLst = (from x in tmList
                         where x != null && x.Infor != null
                         from y in x.NaList
                         select y).ToList();

            Console.WriteLine($"{result.Count()}");
        }

        #region
        private static async Task TaskReActTest()
        {
            double UpperLimited = 50;

            double step = 10;

            for (double i = step; i < UpperLimited + 1; i += step)
            {
                var tskA = Task.Run(async () => { Console.WriteLine($"Up Task A Show:{await AddNextAsync((int)i)}"); });
                var tskB = Task.Run(() => { LengthOfCircle(i); });
                await Task.WhenAll(tskA, tskB,
                    Task.Run(() => { AreaOfCircle(i); })
                    );
                Console.WriteLine($"------------------------------------------------------------------------------------");
            }

            //seed = 20;
            //tskA = Task.Run(async () => { Console.WriteLine($"Up Task Show:{await AddNextAsync(seed)}"); });
            //tskB = Task.Run(() => { LengthOfCircle(seed); });
            //await Task.WhenAll(tskA, tskB);

            //Console.WriteLine($"------------------------------------------------------------------------------------");

            //seed = 30;
            //tskA = Task.Run(async () => { Console.WriteLine($"Up Task Show:{await AddNextAsync(seed)}"); });
            //tskB = Task.Run(() => { LengthOfCircle(seed); });
            //await Task.WhenAll(tskA, tskB);
        }

        private async static Task<int> AddNextAsync(int seed)
        {
            var rValue =
                await Task.Run(() =>
                {
                    int result = 0;
                    for (int i = 0; i <= seed; i++)
                    {
                        result += i;
                    }
                    Console.WriteLine($"tskA:{result}");
                    return result;
                });
            return rValue;
        }
        private static double LengthOfCircle(double r)
        {
            double result = 2 * Math.Floor(Math.PI * 100) / 100 * r;
            Console.WriteLine($"LengthOfCircle:{string.Format("{0}", result)}");
            return result;
        }
        private static double AreaOfCircle(double r)
        {
            double result = Math.Floor(Math.PI * 100) / 100 * r * r;
            Console.WriteLine($"AreaOfCircle:{string.Format("{0}", result)}");
            return result;
        }

        private static void ReferenceConvertTest()
        {
            List<TokenClass> tokens = new List<TokenClass>() {
                new TokenClass(), new TokenClass(), new TokenClass()
            };
            IEnumerable<object> ioEnumber = (IEnumerable<object>)tokens;

            List<TokenClass> ioTokens = (List<TokenClass>)ioEnumber;

            try
            {
                for (int x = 0; x < ioTokens.Count; x++)
                {
                    var mode = ioTokens[x];
                    mode.TokenName = "Changed Toke Name";
                    if (x == 1) throw new Exception();
                }
            }
            catch
            { }

            for (int x = 0; x < tokens.Count; x++)
            {
                Console.WriteLine(tokens[x].TokenName);
            }

            Console.WriteLine();
        }

        private static void ListAddRemovedInTwoTask()
        {
            var cts = new TokenClass().cts;

            List<Guid> Keys = new List<Guid>();
            MemoryCacheOptions mCOptions = new MemoryCacheOptions() { ExpirationScanFrequency = TimeSpan.FromSeconds(1) };
            MemoryCache CacheKeys = new MemoryCache(mCOptions);

            System.Timers.Timer timer = new System.Timers.Timer
            {
                AutoReset = true,
                //timer.Enabled = true;
                Interval = 1000
            };
            timer.Elapsed += new System.Timers.ElapsedEventHandler(
                delegate (object sender, System.Timers.ElapsedEventArgs e)
                {
                    CacheKeys.TryGetValue("dd", out string result);
                    Console.WriteLine($"{DateTime.Now} - {CacheKeys.Count} / {Keys.Count}");
                    if (!(CacheKeys.Count > 0))
                    {
                        timer.Stop();
                        lock (Keys)
                        {
                            Console.WriteLine($"Stop! - {DateTime.Now} - {CacheKeys.Count} / {Keys.Count}");
                            if (Keys.Count > 0)
                                Console.WriteLine($"Error");
                        }
                    }
                }
                );
            timer.Start();

            Func<MemoryCacheEntryOptions> delegateCreateMemoryOptions = () =>
             {
                 var rValue = new MemoryCacheEntryOptions
                 {
                     AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5)
                 };

                 PostEvictionDelegate pDelegate = delegate (object key, object value, EvictionReason reason, object state)
                 {
                     Console.WriteLine(reason);
                     if (reason == EvictionReason.Expired)
                     {
                         if (Guid.TryParse(key.ToString(), out Guid guid))
                         {
                             lock (Keys)
                             {
                                 Keys.RemoveAll(x => x.Equals(guid));
                             }
                         }
                     }
                 };
                 rValue.RegisterPostEvictionCallback(pDelegate);

                 return rValue;
             };

            Task.Factory.StartNew(() =>
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    var guid = Guid.NewGuid();
                    CacheKeys.Set(guid, new TokenClass().cts, delegateCreateMemoryOptions());
                    lock (Keys)
                    {
                        Keys.Add(guid);
                    }
                    Thread.Sleep(400);
                }
            }, cts.Token);

            Task.Factory.StartNew(() =>
            {
                while (!cts.Token.IsCancellationRequested)
                {
                    var guid = Guid.NewGuid();
                    CacheKeys.Set(guid, new TokenClass().cts, delegateCreateMemoryOptions());
                    lock (Keys)
                    {
                        Keys.Add(guid);
                    }
                    Thread.Sleep(300);
                }
            }, cts.Token);

            while (true)
            {
                Console.WriteLine("Input Key .......");
                var keyInput = Console.ReadKey();
                Console.WriteLine($"..........................................------------------------------>");
                if (keyInput.KeyChar.Equals('K'))
                {
                    cts.Cancel();
                    break;
                }
            }
            Console.WriteLine($"Input Next End Key");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine($"End! - {DateTime.Now} - {CacheKeys.Count} / {Keys.Count}");
        }

        private static void TimeSpanTEST()
        {
            var tSp = TimeSpan.FromSeconds(30d);
            Console.WriteLine($"{tSp.TotalMinutes} - {tSp.TotalSeconds} - {tSp.TotalMilliseconds}");
            Console.WriteLine();

            int from, to;
            from = 1;
            to = 100;
            double result = 0;

            var x = from;
            while (x <= to)
            {
                //var y = Math.Pow(2, x);
                result += Math.Pow(2, -x);
                x++;
            }

            Console.WriteLine(result);
        }

        private static void CopyListTest()
        {
            List<int> intList = new List<int> { 1, 2, 3, 4, 5, 6, 0, 1, 2, 3 };
            var copiedList = (from x in intList select x).ToList();
            intList.RemoveAll(x => x.Equals(1));
            intList.RemoveAll(x => x.Equals(2));
            intList.RemoveAll(x => x.Equals(3));
            Console.WriteLine($"{intList.Count}/{copiedList.Count}");
        }

        private static void TimerTest()
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.AutoReset = true;
            //timer.Enabled = true;
            timer.Interval = 1000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(
                delegate(object sender,System.Timers.ElapsedEventArgs e)
                {
                    Console.WriteLine(DateTime.Now);
                }
                );
            timer.Start();
            Console.WriteLine($"Start to Run....");
            Thread.Sleep(5000);
            timer.Stop();
            Console.WriteLine($"Stop to Run....");
            Thread.Sleep(5000);
            Console.WriteLine($"ReStart to Run....");
            timer.Start();
            timer.Start();
            timer.Start();
            Console.WriteLine($"ReStart to Over....");
            Thread.Sleep(10000);
            Console.WriteLine($"ReStart to Run1....");
            timer.Start();
            timer.Start();
            Console.WriteLine($"ReStart Over1....");
            Thread.Sleep(5000);
        }

        private static void MemoryCacheTEST()
        {
            MemoryCacheOptions mCOptions = new MemoryCacheOptions();
            mCOptions.ExpirationScanFrequency = TimeSpan.FromSeconds(1);
            MemoryCache mech = new MemoryCache(mCOptions);

            mech.Set("aa", "aab", CreateMemoryCacheEntryOptions());
            Thread.Sleep(3000);
            mech.Set("aa", "aab", CreateMemoryCacheEntryOptions());
            Thread.Sleep(2000);
            mech.Set("aac", "aab", CreateMemoryCacheEntryOptions());

            string value;
            while (true)
            {
                Thread.Sleep(1000);
                Console.WriteLine(DateTime.Now.Second);
                mech.TryGetValue("cc", out value);
                if (!(mech.Count > 0))
                {
                    break;
                }
            }
        }

        private static MemoryCacheEntryOptions CreateMemoryCacheEntryOptions()
        {
            var rValue = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(5)
            };

            PostEvictionDelegate pDelegate = delegate(object key, object value, EvictionReason reason, object state) {
                Console.WriteLine(reason);
                if (reason == EvictionReason.Expired)
                {
                    Console.WriteLine($"{reason.ToString()}/{key.ToString()} - {value.ToString()}");
                }
            };
            rValue.RegisterPostEvictionCallback(pDelegate);

            return rValue;
        }

        private async static Task TaskCancellationTokenSourceTest()
        {
            TokenClass tc = new TokenClass();

            var ctsCurrent = CancellationTokenSource.CreateLinkedTokenSource(tc.cts.Token);

            var task = await
                Task.Factory.StartNew(async op => { Console.WriteLine("ax"); await Run(ctsCurrent.Token); Console.WriteLine("ax1"); }, ctsCurrent.Token);
            //await task;

            //var tt =
            //Task.Run(() => { Run(ctsCurrent.Token).Wait(); });
            //await Task.Factory.StartNew(async() => {await Run(ctsCurrent.Token); });
            //tt.Wait();

            #region Xml Serializer and Deserailizer is not a same one.
            //XMLConverter<TokenClass> xConvert = new XMLConverter<TokenClass>();
            //var ctsCopy = xConvert.DeSerailizer(xConvert.Serializer(tc));
            //ctsCopy.cts.Cancel();
            #endregion

            #region CancellationTokenSource cannot be Serialized.
            //System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //var formatter = new BinaryFormatter();
            //formatter.Serialize(ms, tc);
            //var cctsCopy = formatter.Deserialize(ms) as TokenClass;
            //ms.Close();
            //cctsCopy.cts.Cancel();
            #endregion

            Console.WriteLine("bx");
            Thread.Sleep(10000);
            tc.cts.Cancel();
            //ctsCurrent.Cancel();
            Console.WriteLine("canceled");
            Thread.Sleep(2000);
            //tc.cts.Cancel();
            Console.WriteLine("re-canceled");
        }

        private static async Task Run(CancellationToken cts)
        {
            await
            Task.Run(() =>
            {
                while (!cts.IsCancellationRequested)
                {
                    Console.WriteLine(DateTime.Now);
                    Thread.Sleep(1000);
                }
                Console.WriteLine("Exit......");
            });
        }
        #endregion

        private static void EndInfor()
        {
            Console.WriteLine();
            Console.WriteLine($"Any key to exit......");
            Console.ReadKey();
        }
    }
    public interface IGetSet
    {
        string Get();
        string Set(string str);
    }
    public class HttpClientResponse : AATest
    {
        public HttpClientResponse(BATest bt, string mess)
            : base(bt, mess)
        {

        }
    }
    public class AATest:IGetSet
    {
        public string Name;
        public BATest Batest;
        public string Messages { get; set; }

        //public AATest(string mess)
        //{
        //    Messages = mess;
        //}
        //public AATest(BATest bt)
        //{
        //    Batest = bt;
        //}
        public AATest(BATest bt, string mess)
        {
            Batest = bt;
            Messages = mess;
            Name = this.GetType().FullName;
        }

        public void ModiFyNewValue(string mess)
        {
            Messages = mess;
        }

        public string Get()
        {
            return Messages;
        }

        public string Set(string str)
        {
            ModiFyNewValue(str);
            return str;
        }
    }

    public class BInIGETSET
    {
        IGetSet igetset;
        public BInIGETSET(IGetSet igetset)
        {
            this.igetset = igetset;
        }

        public string GetString()
        {
            return igetset.Get();
        }
    }

    public class BATest
    {
        public string Name;
        public AATest Aatest { get { return Method(""); } }
        public string Messages { get; set; }
        public Func<string, AATest> Method;
        //public BATest(string mess)
        //{
        //    Messages = mess;
        //}
        //public BATest(AATest aat)
        //{
        //    Aatest = aat;
        //}
        //public BATest(AATest aat, string mess)
        //{
        //    Aatest = aat;
        //    Messages = mess;
        //}
        public BATest(Func<string, AATest> method, string mess)
        {
            Method = method;
            Messages = mess;
            Name = this.GetType().FullName;
        }
        public BATest(Func<string, AATest> method, Func<string> func)
        {
            Method = method;
            Messages = func?.Invoke();
            Name = this.GetType().FullName;
        } 
    }

    public class CCTest
    {
        public string CtorFrom;
        public AATest Aatest;
        public BATest bATest;
        public Func<string, AATest> Method;

        public Guid guid;
        public CCTest(AATest Aatest)
        {
            CtorFrom = "A";
            this.Aatest = Aatest;
        }
        public CCTest(AATest Aatest, BATest bATest)
        {
            CtorFrom = "B";
            this.bATest = bATest;
            this.Aatest = Aatest;
            guid = Guid.NewGuid();
        }
        //public CCTest(Func<string, AATest> method)
        //{
        //    CtorFrom = "C";
        //    Method = method;
        //}
        public CCTest(BATest bATest)
        {
            CtorFrom = "D";
            this.bATest = bATest;
        }
    }

    public static class Constants
    {
        static Constants()
        {
        }
    }

    public class TListSort
    {
        public int id { get; set; }
        public DateTime dt { get; set; }
    }
}
