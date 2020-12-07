using OtherTestProjects.Classes;
using OtherTestProjects.CompleteClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherTestProjects
{
    class Program
    {
        private static string SeparateLine = "------------------------------------------------------------";
        static void Main(string[] args)
        {
            Test1();
            //QRTest();
            Console.WriteLine("Any key to exit......");
            Console.ReadKey();
        }

        private static void QRTest()
        {
            QRCoderTester qt = new QRCoderTester();
            var btm = qt.GetQRBitmap("William Wang\r\nMail:WiWang@nltechdev.com");
            btm.Save("NameAndMail.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        private static void Test1()
        {
            InforBase ib = new InforBase();
            ib.ClassName = "/Show IB/";
            ib.Show();
            ib.ToShow();
            var iba = new InforBaseA();
            iba.ClassName = "/Show IBA/";
            iba.Show();
            iba.ToShow();

            Console.WriteLine($"{SeparateLine}");
            ExtendClass.ToShow(ib);
            ExtendClass.ToShow(iba);

            InforBaseExChild ibe = new Classes.InforBaseExChild();
            ibe.ToShow();
            Console.WriteLine($"{ibe.GetClassName()}");
        }
    }
}
