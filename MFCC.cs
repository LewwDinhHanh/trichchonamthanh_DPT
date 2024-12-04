using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TH2_DPT
{
    public class MFCC
    {
        public static List<List<double>> GetMFCCFromFile(string fileAudio)
        {
            string para = $"example.py {fileAudio}";

            RunExe("python",para);

            string fileResult = "mfcc.txt";
             
            if (File.Exists(fileResult))
            {
                List<List<double>> lstLstMFCC = GetMFCCFromTextFile(fileResult);
                File.Delete(fileResult);
                return lstLstMFCC;
            }
            else
            {
                return null;
            }
        }
        private static void RunExe(string filexe, string para)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.CreateNoWindow = false;
            processStartInfo.UseShellExecute = false;
            processStartInfo.Arguments = para;
            processStartInfo.FileName = filexe;
            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            Process process = Process.Start(processStartInfo);
            process.WaitForExit();
        }

        private static List<List<double>> GetMFCCFromTextFile(string fileMFCC)
        {
            StreamReader sr = new StreamReader(fileMFCC);
            string line = sr.ReadLine();
            List<List<double>> lstLstMFCC = new List<List<double>>();
            while (line != null)
            {
                string[] strings = line.Split(new char[] { ' ' });
                if (strings.Length == 13 )
                {
                    List<double> lstMFCC = new List<double>();
                    foreach (string s in strings ) 
                        lstMFCC.Add(double.Parse(s));
                    lstLstMFCC.Add(lstMFCC);
                }
                line = sr.ReadLine();
            }
            sr.Close();
            return lstLstMFCC;
        }
        public static void ClearListData(ref List<List<double>> lstLstMFCC)
        {
            lstLstMFCC.Clear();
        }
    }
}
