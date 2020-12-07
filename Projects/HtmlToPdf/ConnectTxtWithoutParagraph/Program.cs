using System;
using System.Configuration;
using System.IO;
using System.Text.RegularExpressions;

namespace ConnectTxtWithoutParagraph
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPause = true;

            try
            {
                bool.TryParse(ConfigurationManager.AppSettings["IsPauseEnd"], out isPause);
            }
            catch
            { }

            if (args.Length < 1)
            {
                Console.WriteLine("Input the file name like below.");
                Console.WriteLine("CTxt log.txt");
                PauseEnd(isPause);
                return;
            }
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("Confirm the Ori-Text file exist.");
                PauseEnd(isPause);
                return;
            }

            int checkBeginCharacter;
            Regex isNum;
            if (!int.TryParse(ConfigurationManager.AppSettings["CheckLength"], out checkBeginCharacter))
            { checkBeginCharacter = 1; }
            string breakPattern = ConfigurationManager.AppSettings["BreakLinePattern"];

            try {
                isNum = new Regex(breakPattern);//"^[0-9=]+$"
            }
            catch
            {
                Console.WriteLine($"The input pattern <{breakPattern}> is illegal.");
                PauseEnd(isPause);
                return;
            }

            Console.WriteLine($"The number of characters to be checked from the left is {checkBeginCharacter}.");
            Console.WriteLine($"The character pattern to break line is {breakPattern}");


            string OriFPath = args[0].Trim();
            string DesFPath = $"{OriFPath}.txt";
            
            bool isNewBegin = false;

            var sr = new StreamReader(OriFPath, true);
            var sw = new StreamWriter(DesFPath, false, sr.CurrentEncoding);

            string lineTxt = sr.ReadLine();
            while (lineTxt != null)
            {
                lineTxt = lineTxt.Trim().Replace("\r\n", "");

                if (!lineTxt.EndsWith("."))
                {
                    if (
                    string.IsNullOrWhiteSpace(lineTxt)
                    || isNum.IsMatch(lineTxt.Trim().Substring(0, checkBeginCharacter))
                    || lineTxt.Equals(lineTxt.ToUpper())
                    )
                    {
                        sw.WriteLine();
                        sw.Write(lineTxt);
                        sw.WriteLine();
                        isNewBegin = true;
                    }
                    else
                    {
                        if (isNewBegin)
                        {
                            sw.WriteLine();
                            isNewBegin = false;
                        }
                        sw.Write(lineTxt);
                        sw.Write(" ");
                    }
                }
                else
                {
                    sw.Write(lineTxt);
                    sw.WriteLine();
                    sw.WriteLine();
                }
                lineTxt = sr.ReadLine();
            }
            sw.Flush();
            sw.Close();
            sr.Close();
            Console.WriteLine($"Run Over......");
            PauseEnd(isPause);
        }

        public static void PauseEnd(bool isPause)
        {
            if (isPause)
            {
                Console.WriteLine("Any key to exit......");
                Console.ReadKey();
            }
        }
    }
}
