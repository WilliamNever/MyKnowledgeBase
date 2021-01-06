using Core31TestProject.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core31TestProject.MainTestFiles
{
    public class SolvedScenarioService : TestBaseForMainEntrance
    {
        public override void MainRun()
        {
            #region Tested
            StringTest();
            //Task.WaitAll();
            #endregion
        }

        private void StringTest()
        {
            int loop = 1000;
            Console.WriteLine($"Begin......");
            for (int i = 0; i < loop; i++)
            {
                if (i != GetIntFromExcelColumn(GetExcelColumnFromInt(i)))
                {
                    Console.WriteLine($"Error Line i = {i} - {GetExcelColumnFromInt(i)} - {GetIntFromExcelColumn(GetExcelColumnFromInt(i))}");
                    break;
                }
                else
                {
                    Console.WriteLine(GetExcelColumnFromInt(i));
                }
            }
            Console.WriteLine($"Over......");
        }

        private int GetIntFromExcelColumn(string str)
        {
            int result = 0;
            var array = str.ToUpper().ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                result += (int)Math.Pow(26, array.Length - i - 1) * (array[i] - 'A' + 1);
            }
            return result - 1;
        }
        private string GetExcelColumnFromInt(int shipSequence)
        {
            var result = "";
            int major, sequence = shipSequence;
            do
            {
                major = sequence / 26;
                var minor = sequence % 26;
                result = ((char)(minor + 'A')).ToString() + result;
                sequence = major - 1;
            } while (major > 0);
            return result;
        }
        private string GetHashCode(string str)
        {
            string rsl = "";
            using (MD5 md5 = MD5.Create())
            {
                byte[] md5Bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                md5.Clear();
                rsl = BitConverter.ToString(md5Bytes).Replace("-", "");
            }
            return rsl;
        }
    }
}
