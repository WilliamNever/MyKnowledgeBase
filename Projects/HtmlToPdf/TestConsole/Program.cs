using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Tested Lines
            //TestFirst(args);
            #endregion

            TestToSound(args);

            Console.WriteLine("Any key to exit......");
            Console.ReadKey();
        }

        public static void TestToSound(string[] args)
        {
            SpeechSynthesizer ss = new SpeechSynthesizer();
            ss.SelectVoice("Microsoft Zira Desktop");
            Console.WriteLine(ss.Voice.Name);
            ss.Rate = 0;
            ss.SetOutputToWaveFile("here.wav");
            ss.Speak(@"
I'd never given much thought to how I would die — though I'd had reason enough in the last few months — but even if I had, I would not have imagined it like this.
            ");

            var voices = ss.GetInstalledVoices();
            foreach (var itm in voices)
            {
                Console.WriteLine(itm.VoiceInfo.Name);
            }
        }

        public static void TestFirst(string[] args)
        {
            Console.WriteLine(Process.GetCurrentProcess().ToString());
        }
    }
}
