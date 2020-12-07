using ConsoleTestFor.Models;
using ConsoleTestFor.Utilities;
using ForTestLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTestFor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                var t = GetInfor(i);
                Console.WriteLine(string.Format("Main-{0}", i));
                Console.WriteLine(string.Format("I am the main:{0}-{1}/{2}"
                    , Thread.CurrentThread.ManagedThreadId
                    , t.Result, i   //t.Result 阻塞当前线程，等待 Task 执行完毕再取返回值
                    ));
                Console.WriteLine("---------------");
            }
            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();
        }

        public static async Task<int> GetInfor(int i)
        {
            Console.WriteLine(string.Format("//I am the sub function:{0}-{1}", Thread.CurrentThread.ManagedThreadId, i));

            var tt = Task.Run(() =>
              {
                //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
                //Thread.Sleep(500);
                Console.WriteLine(string.Format("I am the sub new Task:{0}-{1}", Thread.CurrentThread.ManagedThreadId, i));
                  return Thread.CurrentThread.ManagedThreadId;
              });
            Console.WriteLine("Sub Function before await tt is running?");
            await tt;   //await 会阻塞当前 async 方法
            Console.WriteLine("Sub Function After await tt How?");
            return tt.Result;
        }
    }
}


/*
mvc 中调用异步Action ； 
注意：在异步Action中才能调用异步方法，否则会出现死锁。此说法不全正确，只有在下方村里是‘高概率 dead lock 示例组’时的情况下才会出现死锁。
而一般应尽量返回task这种另类的thread，只将task做为一个执行的容器，应该不会出现在同步方法中调用异步方法的死锁。

        //[AsyncTimeout(3000)]
        //[NoAsyncTimeout]
        public async Task<ActionResult> Contact()   //ActionResult//
        {
            ViewBag.Message = "Your contact page.";

            // A or B both Ok. 我更喜欢A，await是一个强制同步点，至少在await之前的代码是同时执行的。
            //A:
            var aaa = GetInforAsync();
            var ii = await aaa;   // await aaa; 
            var bbb = ii;         // var bbb=aaa.Result;
            //------------------------------------------------
            //B:
            //var aaa = await GetInforAsync();

            return View();
        }

        public async Task<int> GetInforAsync()
        {
            var tt = Task.Run(() => {
                //Thread.Sleep(10000);
                return 1;
            });
            //await tt;
            return await tt;
        }
 */


/////一套测试代码，应该不会写出这种特点的task
namespace Dpfb.Manage.Controllers
{
    public class AsyncsController : Controller
    {
        private void Assign()
        {
            _container = "Hello World";
        }

        private static string _container;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _container = string.Empty;
        }

        public async Task AssignValue2()
        {
            await Task.Delay(500);
            await Task.Run(() => Assign());
        }

        public async Task AssignValue()
        {
            await Task.Run(() => Assign()).ConfigureAwait(false);
        }

        public async Task Wrapped()
        {
            await AssignValue().ConfigureAwait(false);
        }

        public async Task Wrapped2()
        {
            await AssignValue2().ConfigureAwait(false);
        }

        public async Task Update()
        {
            await Task.Run(() => { _container = _container + "Hello "; });
        }

        public async Task Update2()
        {
            await Task.Run(() => { _container = _container + "World"; });
        }

        #region 基本调用

        /// <summary>
        /// 调用层次最深的异步方法（第一个调用的异步方法）不要求返回到主线程
        /// </summary>
        /// <returns></returns>
        public ActionResult Asv1()
        {
            var task = AssignValue();
            task.Wait();
            return Content(_container);
        }

        /// <summary>
        /// ...返回主线程
        /// </summary>
        /// <returns></returns>
        public ActionResult Asv2()
        {
            //dead lock
            var task = AssignValue2();
            task.Wait();
            return Content(_container);
        }

        /// <summary>
        /// 所有都不要求返回主线程
        /// </summary>
        /// <returns></returns>
        public ActionResult Wrp()
        {
            var task = Wrapped();
            task.Wait();
            return Content(_container);
        }

        /// <summary>
        /// 其中一个要求返回主线程
        /// </summary>
        /// <returns></returns>
        public ActionResult Wrp2()
        {
            //dead lock
            var task = Wrapped2();
            task.Wait();
            return Content(_container);
        }

        #endregion

        #region 次线程创建，次次线程wait（continue with），主线程wait次次线程

        public ActionResult Twait()
        {
            Task task = null;
            Task.Run(() => { task = AssignValue(); })
                .ContinueWith(token => task.Wait())
                .Wait();
            return Content(_container);
        }

        public ActionResult Twait2()
        {
            Task.Run(() => AssignValue2())
                .ContinueWith(task => { task.Wait(); })
                .Wait();
            return Content(_container);
        }

        public ActionResult Swait()
        {
            AsyncHelper.InvokeAndWait(AssignValue2);
            return Content(_container);
        }

        #endregion

        #region 次线程创建，主线程wait
        //高概率 dead lock 示例组

        public ActionResult TcreateMwait()
        {
            Task task = null;
            Task.Run(() => { task = AssignValue2(); }).Wait();
            task.Wait();
            return Content(_container);
        }

        public ActionResult TcreateMunwait()
        {
            //主线程不等待的对比组
            Task task = null;
            Task.Run(() => { task = AssignValue2(); }).Wait();
            return Content(_container);
        }

        #endregion

        #region waitsafely examples

        public ActionResult Inorder()
        {
            AsyncHelper.InvokeAndWait(Update);
            AsyncHelper.InvokeAndWait(Update2);
            return Content(_container);
        }

        public ActionResult NotInOrder()
        {
            AsyncHelper.InvokeAndWait(() => Task.WhenAll(Update(), Update2()));
            return Content(_container);
        }

        #endregion


        public async Task A()
        {
            await Task.Run(() => { });
        }

        public async Task B()
        {
            await A();
            //B.L
        }

        public async Task C()
        {
            await B();
            //C.L
        }
    }
}

code_full
