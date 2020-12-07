using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTest.ClassesBases;

namespace TaskTest
{
    public delegate void actOx(string str);
    class Program
    {
        static void Main(string[] args)
        {
            var lis = TBaseT.Generate(5, "x");

            var emuList = Enumerable.Range(4, 5);
            Console.WriteLine($"{emuList.Count()}");
            Console.WriteLine("-----------------------------------------------------------------");
            EndingParam();
        }

        static void EndingParam()
        {
            Console.WriteLine();
            Console.WriteLine("Finished, any key to exit......");
            Console.ReadKey();
        }
        static void Main1(string[] args)
        {
            object ax = "null";
            Console.WriteLine((string)ax);

            if (string.IsNullOrEmpty((string)ax))
            {
                Console.WriteLine("NULL");
            }
            else
            {
                Console.WriteLine(ax.ToString().Trim());
            }

            Console.WriteLine($"933{ax}/{1}+{2}={1 + 2}");

            Console.WriteLine();
            Console.WriteLine("Finished, any key to exit......");
            Console.ReadKey();
        }
        static void Main2(string[] args)
        {
            int Round = 500;
            Demo1 dm1 = new TaskTest.Demo1();
            List<double> listResult = new List<double>();
            List<Task<double>> listTask = new List<Task<double>>();

            for (int i = 0; i < Round; i++)
            {
                listTask.Add(dm1.GetValueAsync(12, 1.0000001));
            }
            Console.WriteLine("-------------------------------------------------------------");
            for (int i = 0; i < Round; i++)
            {
                //if (listTask[i].Wait(3000))
                {
                    listTask[i].Wait();
                    listResult.Add(listTask[i].Result);
                }
            }
            foreach (var itm in listResult)
            {
                Console.WriteLine(itm);
            }
            Console.WriteLine();
            Console.WriteLine(listResult.Count);

            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine();
            Console.WriteLine("Finished, any key to exit......");
            Console.ReadKey();
        }
        static void MainX1(string[] args)
        {
            int RunRound = 1;
            /**/
            for (int i = 0; i < RunRound; i++)
            {
                Console.WriteLine("Round: " + i.ToString());
                Console.WriteLine(
                    string.Format("Main Thread {1} above the task!/{0}",
                    DateTime.Now.ToString(),
                    System.Threading.Thread.CurrentThread.ManagedThreadId)
                    );

                var task =
                    Task.Run(async () =>
                    {
                        Console.WriteLine(string.Format("Task Thread {1} above the Delay 3sec!/{0}", DateTime.Now.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));
                        await Task.Delay(3000);
                        Console.WriteLine(string.Format("Task Thread {1} below the Delay 3sec!/{0}", DateTime.Now.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));
                        return "Over Task!";
                    });
                Console.WriteLine(string.Format("Main Thread {1} below the task!/{0}", DateTime.Now.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine(string.Format("Main Thread {1} below the Sleep!/{0}", DateTime.Now.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));
                var ax = task.Result;
                Console.WriteLine(string.Format("Task Run Result - {0} / {1}", ax, DateTime.Now.ToString()));
                Console.WriteLine();
                Console.WriteLine();
            }
            
            for (int i = 0; i < RunRound; i++)
            {
                Console.WriteLine("Round: " + i.ToString());
                Console.WriteLine(
                    string.Format("Main Thread {1} above the task!/{0}",
                    DateTime.Now.ToString(),
                    System.Threading.Thread.CurrentThread.ManagedThreadId)
                    );

                var task =
                    //Task.Run(async () =>
                    //{
                    //    Console.WriteLine(string.Format("Task Thread {1} above the Delay 3sec!/{0}", DateTime.Now.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));
                    //    await Task.Delay(3000);
                    //    Console.WriteLine(string.Format("Task Thread {1} below the Delay 3sec!/{0}", DateTime.Now.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));
                    //    return "Over Task!";
                    //});
                    GetMessageAsync();
                Console.WriteLine(string.Format("Main Thread {1} below the task!/{0}", DateTime.Now.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));
                //System.Threading.Thread.Sleep(3000);
                Console.WriteLine(string.Format("Main Thread {1} below the Sleep!/{0}", DateTime.Now.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));
                task.Wait();//??在某些同步调异步方法出现死锁时会有作用！！！！！！！未测试
                var ax = task.Result;
                Console.WriteLine(string.Format("Task Run Result - {0} / {1}", ax, DateTime.Now.ToString()));
                Console.WriteLine();
                Console.WriteLine();
            }

            /*
            Demo1 tmp;
            var act = GetDemoAction(out tmp);
            //Console.WriteLine(tmp.InvokeNum);
            tmp.InvokeNum++;
            //Console.WriteLine(tmp.InvokeNum);
            act += () => {
                Console.WriteLine(string.Format("NoNameMethod:{0} - {1}", "act++", tmp.InvokeNum));
            };
            act();
            tmp.InvokeNum++;
            Console.WriteLine(string.Format("Main Thread value:{0}", tmp.InvokeNum));

            actOx opAct = (string str) => {
                tmp.InvokeNum++;
                Console.WriteLine(string.Format("NoNameMethod:{0} - {1}/{2}", "opAct", tmp.InvokeNum, str));
            };
            opAct("Hello");
            */

            //var task = System.Net.Dns.GetHostEntryAsync("");
            //task.Wait();//??在某些同步调异步方法出现死锁时会有作用！！！！！！！未测试
            //var aa = task.Result;

            Console.WriteLine("Finished, any key to exit......");
            Console.ReadKey();
        }

        private static Action GetDemoAction(out Demo1 dm1)
        {
            dm1 = new Demo1();
            return dm1.GetTempAction();
        }

        private static void RunInMethod(Action ac)
        {
            ac.Invoke();
        }

        public static async Task<string> GetMessageAsync()
        {
            string str = "?";
            Console.WriteLine(string.Format("Task Thread {1} Enter GetMessageAsync!/{0}", DateTime.Now.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));
            var task =
            Task.Run(async () =>
            {
                Console.WriteLine(string.Format("Task Thread {1} above the Delay 3sec!/{0}", DateTime.Now.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));
                await Task.Delay(3000);
                Console.WriteLine(string.Format("Task Thread {1} below the Delay 3sec!/{0}", DateTime.Now.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));
                return "Over Task!";
            });

            await task;
            Console.WriteLine(string.Format("Task Thread {1} Leave GetMessageAsync!/{0}", DateTime.Now.ToString(), System.Threading.Thread.CurrentThread.ManagedThreadId));

            Action ac = () => {
                str += "abc";
                Console.WriteLine(task.Result);
            };
            Console.WriteLine(str);
            ac.Invoke();
            RunInMethod(ac);
            Console.WriteLine(str);

            ParamClass pc = new TaskTest.ParamClass { Num = 10 };
            Action<string, ParamClass> abd = (string strm, ParamClass pcm) => {
                Console.WriteLine(strm);
                pcm.Num++;
                Console.WriteLine(pcm.Num);
            };
            abd.Invoke("num", pc);
            Console.WriteLine(pc.Num);

            return task.Result;
        }
    }

    public class Demo1
    {
        public int InvokeNum { get; set; }
        private Action ac { get; set; }
        private Action<ParamClass> abc { get; set; }
        public Demo1(int beginNum)
        {
            InvokeNum = beginNum;

            ac = () => { InvokeNum++; };

            abc = (ParamClass pc) => { pc.Num++; };
        }

        public Demo1()
        {
            InvokeNum = 0;
        }

        public Action GetTempAction()
        {
            //var tt =  GetValueAsync(3.3, 0.9);
            //tt.Wait();
            //var result = tt.Result;

            return () =>
            {
                InvokeNum++;
                Console.WriteLine(string.Format(@"Class/Demo1/NoNameMethod:{0} - {1}", "GetTempAction", InvokeNum));
            };
        }
        public async Task<double> GetValueAsync(double num1, double num2)
        {
            Console.WriteLine(System.Threading.Thread.CurrentThread.ManagedThreadId);
            return await Task.Run(() =>
            {
                Console.WriteLine(string.Format("Begin to Sleep TaskRun. - {0}", System.Threading.Thread.CurrentThread.ManagedThreadId));
                //System.Threading.Thread.Sleep(1000);
                for (int i = 0; i < 10000000; i++)
                {
                    num1 = num1 / num2;
                }
                return num1;
            });
        }
    }

    public class ParamClass
    {
        public int Num { get; set; }
    }
}