//#define ArrayPartTest
//#define CollectionSortTest
//#define  HeapSort
//#define MixQuickHeapSort

using ConsoleTestForLog4Net.TestClasses.ArrySort;
using ConsoleTestForLog4Net.TestClasses.CSV;
using ConsoleTestForLog4Net.TestClasses.FindTheShortestWay;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;

//[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace ConsoleTestForLog4Net
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Main_XML(args);

            //Main_CSVReader(args);
            string str = null;
            Console.WriteLine($"Here is a null value:{str}");

            //Main_ArgsList(args);

            //MainScriptDeserialTest(args);

            Main_TestFunc(args);

            Console.WriteLine();
            Console.WriteLine("Any key to exit......");
            Console.ReadKey();
        }

        private static void Main_TestFunc(string[] args)
        {
            Func<int, int, int> ix = (int i1, int i2) => i1 * 10 + i2;
            Func<int, int, int> ix1 = (int i1, int i2) => { return i1 * 10 + i2; };
            Func<int, int, int> ix2 = (int i1, int i2) => 3;

            Console.WriteLine($"{ix(2, 8)}");
            Console.WriteLine($"{ix1(2, 8)}");

            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"i Param is /{i}/ and Result is ");
                Console.WriteLine($"{ix2(i,i)}");
            }
        }

        private static void MainScriptDeserialTest(string[] args)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<string> ax = new List<string>();
            ax.Add("aaa");
            Console.WriteLine(jss.Serialize(ax));
            ax.Add("bbb");
            Console.WriteLine(jss.Serialize(ax));

            string aaa = "\"aaa\"";
            string bbb = "[\"aaa\", \"bbb\"]";
            ax = jss.Deserialize<List<string>>(aaa);
            Console.WriteLine();
        }

        private static void Main_ArgsList(string[] args)
        {
            Console.WriteLine(args.Length);
            for (var i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
        }

        private static void Main_CSVReader(string[] args)
        {
            CSVReader csv = new TestClasses.CSV.CSVReader();
            var dt = csv.GetData(System.IO.File.Open("Manju.csv", System.IO.FileMode.Open));
        }

        static void Main_XML(string[] args)
        {
            string xmlString = "<OrderRequestHeader orderID=\"97 - 001044\" orderDate=\"2010-09-25T18:36:00\" orderType=\"regular\" type=\"new\" agreementID=\"4556566566\">   <Total>     <Money currency=\"USD\"/>   </Total>   <ShipTo>     <Address isoCountryCode=\"US\">       <Name xml:lang=\"EN\">ARKANSAS SURGICAL HOSPITAL</Name>       <PostalAddress name=\"default\">         <DeliverTo>ARKANSAS SURGICAL HOSPITAL</DeliverTo>         <Street>5201 NORTH SHORE DR</Street>         <City>NORTH LITTLE ROCK</City>         <State>AR</State>         <PostalCode>72118</PostalCode>         <Country isoCountryCode=\"US\">US</Country>       </PostalAddress>     </Address>   </ShipTo>   <BillTo>     <Address isoCountryCode=\"US\">       <Name xml:lang=\"en\">CORPORATE EXPRESS</Name>       <PostalAddress>         <Street>4205 SOUTH 96TH STREET</Street>         <City>OMAHA</City>         <State>NE</State>         <PostalCode>68127</PostalCode>         <Country isoCountryCode=\"US\">US</Country>       </PostalAddress>     </Address>   </BillTo>   <PaymentTerm payInNumberOfDays=\"SSP\"/>   <Contact role=\"Buyer\">     <Name xml:lang=\"EN\">MILLER, JOE L</Name>     <Email>Joe.Miller@staples.com                            </Email>     <Phone>       <TelephoneNumber>         <CountryCode isoCountryCode=\"\">1</CountryCode>         <AreaOrCityCode>402</AreaOrCityCode>         <Number>8986255</Number>       </TelephoneNumber>     </Phone>   </Contact>   <SupplierOrderInfo orderID=\"4556566566\"/>   <Extrinsic name=\"Payment Terms Desc\">2% 20 Days Net 45 4.5% Rebate</Extrinsic>   <Extrinsic name=\"E-mail\">dpm.eservices@cexp.com</Extrinsic>   <Extrinsic name=\"HEADERNOTES\">Test Header Notes.</Extrinsic>   <Extrinsic name=\"Confirmation Number\">M000733.3178</Extrinsic>   <Extrinsic name=\"POType\">P02</Extrinsic>   <Extrinsic name=\"PO Reference A\">mike vac</Extrinsic>   <Extrinsic name=\"PO Reference B\">mike v</Extrinsic>   <Extrinsic name=\"Carrier Code\">FedEx Ground</Extrinsic>   <Extrinsic name=\"FreightApplied\">Y</Extrinsic>   <Extrinsic name=\"ChargeApplied\">Y</Extrinsic>   <Extrinsic name=\"DeliveryTerm\">110</Extrinsic>   <Extrinsic name=\"Delivery Terms Desc\">Prepaid / Charge              </Extrinsic>   <Extrinsic name=\"FooterNotes\">VENDOR:  UNIVERSITY PRINTING SUP011056 COST OF $175.00 LOT OR $17.50/PKG DELIVERED TO LR SALES OFFICE REPEAT OF 43-229186 FOR 10 PKG @ 125/PKG - SHRINKWRAPPED</Extrinsic> </OrderRequestHeader>";

            //Console.WriteLine(xmlString);

            XmlDocument xdc = new XmlDocument();
            xdc.LoadXml(xmlString);
            var xitm = xdc.GetElementsByTagName("OrderRequestHeader")[0].Attributes["orderID"].Value;
            Console.WriteLine(xitm);

            var obItm = (from x in xdc.GetElementsByTagName("OrderRequestHeader").OfType<XmlNode>() select x).First().Attributes["orderID"].Value;
            Console.WriteLine(obItm);
            Console.WriteLine(xdc.InnerXml);

            Console.WriteLine("--------------------");

            XDocument xdoc = new XDocument();
            xdoc = XDocument.Parse(xmlString);
            Console.WriteLine(xdoc.Descendants("OrderRequestHeader").First().Attribute("orderID").Value);

        }
        static void Main_PathSearcher(string[] args)
        {
            List<StationNode> list = new List<TestClasses.FindTheShortestWay.StationNode> {
                new StationNode { ID = 0, Name = "Start" }, //0
                new StationNode { ID = 10, Name = "A" },    //1
                new StationNode { ID = 20, Name = "B" },    //2
                new StationNode { ID = 100, Name = "End" }  //3
            };

            DicLagosSearch dls = new DicLagosSearch();
            dls.Nodes.Add(
                new StationNeighborCost(list.First(x => x.ID == 0))
                {
                    ChildNodes = new List<KeyValuePair<StationNode, int>> {
                    new KeyValuePair<StationNode, int>(list.First(x=>x.ID==10),6),
                    new KeyValuePair<StationNode, int>(list.First(x=>x.ID==20),2)
                }
                }
                );
            dls.Nodes.Add(
                new StationNeighborCost(list.First(x => x.ID == 10))
                {
                    ChildNodes = new List<KeyValuePair<StationNode, int>> {
                    new KeyValuePair<StationNode, int>(list.First(x=>x.ID==100),1)
                }
                }
                );
            dls.Nodes.Add(
                new StationNeighborCost(list.First(x => x.ID == 20))
                {
                    ChildNodes = new List<KeyValuePair<StationNode, int>> {
                    new KeyValuePair<StationNode, int>(list.First(x=>x.ID==10),3),
                    new KeyValuePair<StationNode, int>(list.First(x=>x.ID==100),5)
                }
                }
                );
            dls.Nodes.Add(
                new StationNeighborCost(list.First(x => x.ID == 100)) { ChildNodes = new List<KeyValuePair<StationNode, int>>() }
                );
            //

            dls.FindWays();

            foreach (var itm in dls.GoThroughWays)
            {
                Console.WriteLine($"{itm.PathDisplay}{itm.PathWeight}");
            }


            Console.WriteLine();
            Console.WriteLine("Any key to exit......");
            Console.ReadKey();
        }

        static void Main_Sort(string[] args)
        {
            ArrySortClass asc = new ArrySortClass();

            #region 快速排序
#if ArrayPartTest
            int[] array = new int[20];//100,100000000
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = asc.GetRandomeInt(1, 100);//100,1000000000
            }
            Console.WriteLine("-----------------------------Sync-----------------------------");
            Console.WriteLine(DateTime.Now);
            asc.SortAsc(array);
            //Array.Sort(array);
            Console.WriteLine(DateTime.Now);
            foreach (int itm in array)
                Console.Write($"{itm} / ");
            Console.WriteLine();
#endif

#if CollectionSortTest
            /**/
            //for (int i = 0; i < 1; i++)
            //{
            List<int> list = new List<int>();
            for (int v = 0; v < 100000000; v++)//134217728/100000
            {
                list.Add(asc.GetRandomeInt(1, 1000000000));
            }
            Console.WriteLine("-----------------------------Sync-----------------------------");
            Console.WriteLine(DateTime.Now);
            asc.SortAsc(list);
            //list.Sort();
            Console.WriteLine(DateTime.Now);
            //foreach (int itm in list)
            //    Console.Write($"{itm} / ");
            Console.WriteLine();
            //}
#endif
            #endregion

            #region 堆排序
#if HeapSort
            for (int round = 0; round < 1000; round++)
            {
                int[] array = new int[10000];//100,100000000
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = asc.GetRandomeInt(1, 10000);//100,1000000000
                }

                Console.WriteLine(DateTime.Now);
                asc.HeapSort(array);
                Console.WriteLine(DateTime.Now);
                if (asc.IsSorted(array)) { Console.WriteLine($"Test Sort OK-{round}"); } else { Console.WriteLine($"Test Sort Error!"); break; }
                //foreach (int itm in array)
                //    Console.Write($"{itm} / ");
            }
        Console.WriteLine();
            Console.WriteLine();

            //int ix = 5, yx = 8;
            //Console.WriteLine($"{ix}-{yx}");
            //asc.Swap(ref ix, ref yx);
            //Console.WriteLine($"{ix}-{yx}");
#endif
            #endregion

            #region MixQuickHeapSort
#if MixQuickHeapSort
            for (int round = 0; round < 1000; round++)
            {
                int[] array = new int[100000];//100,100000000
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = asc.GetRandomeInt(1, 100000);//100,2000000000
                }

                Console.WriteLine(DateTime.Now);
                asc.MixQuickHeapSort(array);
                //Array.Sort(array);
                Console.WriteLine(DateTime.Now);

                //foreach (int itm in array)
                //    Console.Write($"{itm} / ");

                if (asc.IsSorted(array)) { Console.WriteLine($"Test Sort OK-{round}"); } else { Console.WriteLine($"Test Sort Error!-{round}"); break; }
            }
#endif
            #endregion

            Console.WriteLine();
            Console.WriteLine("Any key to exit......");
            Console.ReadKey();
        }

        #region 递归 / 尾递归测试 Rescuvie / TailRescuvie
        /*
         * 当递归调用是整个函数体中最后执行的语句且它的返回值不属于表达式的一部分时，这个递归调用就是尾递归。
         * 尾递归函数的特点是在回归过程中不用做任何操作，这个特性很重要，因为大多数现代的编译器会利用这种特点自动生成优化的代码。
         */
        static void Main_RescuvieTest(string[] args)
        {
            /*
            Console.WriteLine($"{double.MaxValue:N0}");
            Console.WriteLine();

            Console.WriteLine($"{Rescuvie(20):N0}");
            Console.WriteLine($"{TailRescuvie(20):N0}");

            Console.WriteLine($"{divisor(1680, 640):N0}");
            Console.WriteLine($"{divisor(1997, 615):N0}");

            Console.WriteLine($"{tdivisor(1680, 640):N0}");
            Console.WriteLine($"{tdivisor(1997, 615):N0}");
            */

            //Console.WriteLine(TestFunc());
            //TestFunc1();
            Console.WriteLine(LamdaAddDivsor(10));
            Console.WriteLine(AddFromiTo1(9));

            Console.WriteLine();
            Console.WriteLine("Any key to exit......");
            Console.ReadKey();
        }

        public static int TestFunc()
        {
            Func<int, int, int> func = (x, y) => { return x + y; };
            return func(1, 3);
        }

        public static int AddFromiTo1(int i)
        {
            Func<int, Func<int, int>, Func<int, int>> sfunc = null;
            sfunc = (m, n) =>
              {
                  return
                  m < 1 ? n : sfunc(m - 1, x => n(x + m));
              }
            ;

            return sfunc(i, x => x)(0);
        }

        public static void TestFunc1()
        {
            Func<int, Func<int, int>, int> func = (x, y) =>
                 {
                     y = m => { return m + 1; };
                     return x + y(x);
                 }
            ;
            Console.WriteLine(func(5, n => n));
        }

        public static int LamdaAddDivsor(int i)
        {
            //后继传递模式的阶乘，感觉像是在拼运算表达式

            int result;

            Func<int, Func<int, int>, Func<int, int>> sfunc = null;
            sfunc = (x, y) =>
              {
                  var xcc = y(1);
                  return x == 1 ? y : sfunc(x - 1, a => y(x * a));
              }
            ;
            result = sfunc(i, x => x)(1);

            //Func<int, Func<int, int>, int> sfunc = null;
            //sfunc = (x, y) =>
            //{
            //    var xcc = y(1);
            //    return x == 1 ? y(1) : sfunc(x - 1, a => y(x * a));
            //}
            //;
            //result = sfunc(i, x => x);

            return result;
        }

        public static int divisor(int m, int n)
        {
            return
               divisor(m, n, 1);
        }

        public static int divisor(int m, int n, int result)
        {
            return
                n == 0 ? result : divisor(n, m % n, n);
        }

        public static int tdivisor(int m, int n)
        {
            return
                m % n == 0 ? n : tdivisor(n, m % n);
        }

        public static double Rescuvie(double i)
        {
            return
                i > 1 ? Rescuvie(i - 1) * i : 1;
        }

        public static double TailRescuvie(double i)
        {
            return
                TailRescuvie(i, 1);
        }

        public static double TailRescuvie(double i, double counter)
        {
            return
                !(i > 1) ? counter : TailRescuvie(i - 1, i * counter);
        }
        #endregion

        #region HashCode_MainArgumentsTest
        static void Main_HashCode_MainArgumentsTest(string[] args)
        {
            #region
            /*
            string ss = "a";
            Console.WriteLine(ss.GetHashCode());
            ss = "b";
            Console.WriteLine(ss.GetHashCode());
            Console.WriteLine("c".GetHashCode());

            TestHashCode thc = new TestHashCode("aaa",18);
            Console.WriteLine($"{thc.TestHCode()} / {thc.StructHCode()} / {thc.FieldStrHCode()}");

            TestHashCode thc1;
            thc1.str = "ax";
            thc1.age = 39;
            Console.WriteLine($"{thc1.TestHCode()} / {thc1.StructHCode()} / {thc1.FieldStrHCode()}");
            */
            #endregion

            Console.WriteLine(args.Length);
            foreach (string str in args)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine("Any key to exit......");
            Console.ReadKey();
        }

        public struct TestHashCode
        {
            public string str;
            public int age;

            public TestHashCode(string str, int age)
            {
                this.str = str;
                this.age = age;
            }

            public string TestHCode()
            {
                return
                    this.GetHashCode() == str.GetHashCode() ? "Equal" : "Not Equal";
            }

            public int StructHCode()
            {
                return GetHashCode();
            }

            public int FieldStrHCode()
            {
                return str.GetHashCode();
            }
        }
        #endregion

        #region Main_AsyncTest
        static void Main_AsyncTest(string[] args)
        {
            //可以写在 AssemblyInfo.cs 中进行配置, 或在命名空间上进行配置。
            //log4net.Config.XmlConfigurator.Configure();

            //Console.OutputEncoding = Encoding.Unicode;
            //Console.OutputEncoding = Encoding.UTF8;

            //Console.WriteLine($"中文测试");

            Console.WriteLine($"Begin reading ThreadID:{System.Threading.Thread.CurrentThread.ManagedThreadId}");

            int round = 10000;
            List<string> CList = new List<string>();
            List<Task<string>> tasksList = new List<Task<string>>();

            for (var i = 0; i < round; i++)
            {
                tasksList.Add(ReadingXmlAsync("log4net.config"));
            }

            foreach (var task in tasksList)
            {
                CList.Add(task.Result);
            }

            bool result =
            //WriteToFileAsync(tasksList).Result;
            WriteToFileAsync(CList).Result;

            Console.WriteLine($"{result}/{tasksList.Count}");


            //for (int i = 0; i < 10; i++)
            //{
            try
            {
                int ibase = 0;
                var ix = 90 / ibase;
            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger(typeof(Program)).Error("-- Test Log4Net --", ex);
                //log4net.LogManager.GetLogger("testApp.Logging").Error("-- Test Log4Net --", ex);
            }

            //System.Threading.Thread.Sleep(2000);
            //}

            Console.WriteLine("Any key to exit......");
            Console.ReadKey();
        }

        public static async Task<bool> WriteToFileAsync(List<Task<string>> CList)
        {
            //var task = Task.Run(async() =>
            //{

            System.IO.StreamWriter sw = new System.IO.StreamWriter("OutPut.txt", true, Encoding.UTF8);
            try
            {
                foreach (var tk in CList)
                {
                    Console.WriteLine($"Begin reading ThreadID:{System.Threading.Thread.CurrentThread.ManagedThreadId}");
                    string str = await tk;
                    await sw.WriteLineAsync(str);
                }
            }
            catch (Exception ex)
            {
                log4net.LogManager.GetLogger(typeof(Program)).Error("Write To File Error.", ex);
                return false;
            }
            finally
            {
                sw.Flush();
                sw.Close();
            }
            return true;
            //});
            //return await task;
        }
        public static async Task<bool> WriteToFileAsync(List<string> CList)
        {
            //Console.WriteLine($"Begin reading ThreadID:{System.Threading.Thread.CurrentThread.ManagedThreadId}");
            var task = Task.Run(() =>
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter("OutPut.txt", false, Encoding.UTF8);
                try
                {
                    foreach (var str in CList)
                    {
                        Console.WriteLine($"Begin reading ThreadID:{System.Threading.Thread.CurrentThread.ManagedThreadId}");
                        sw.WriteLine(str);
                    }
                }
                catch (Exception ex)
                {
                    log4net.LogManager.GetLogger(typeof(Program)).Error("Write To File Error.", ex);
                    return false;
                }
                finally
                {
                    sw.Flush();
                    sw.Close();
                }
                return true;
            });
            return await task;
        }
        public static async Task<string> ReadingXmlAsync(string path)
        {
            var task = Task.Run(() =>
            {
                using (var xmlRd = new XMLTextReaderTest.TestXMLReader(path))
                {
                    //Console.WriteLine($"Begin reading ThreadID:{System.Threading.Thread.CurrentThread.ManagedThreadId}");
                    string contents = xmlRd.ReadALL();
                    return contents;
                }
            });

            return await task;
        }
        #endregion
    }
}
