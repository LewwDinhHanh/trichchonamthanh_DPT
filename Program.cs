using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH2_DPT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            extraceMFCC();
            Console.ReadKey();
        }

        static void extraceMFCC()
        {
            string fileWav = "english.wav";
            List<List<double>> lstLstMFCC = MFCC.GetMFCCFromFile(fileWav);

            if (lstLstMFCC != null )
            {
                foreach (List<double> lstMFCC in lstLstMFCC)
                {
                    foreach (double item in lstMFCC)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
                MFCC.ClearListData(ref lstLstMFCC);
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }
    }
}
