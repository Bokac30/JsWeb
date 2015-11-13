using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace ConsoleAppPi
{
    class Program
    {

        public static string DownloadedFileName { get; set; }

        private const string YOUTUBE = "youtube-dl";
        
        static void Main(string[] args)
        {
            RunProcess(args[0]);
        }

        private static void RunProcess(string youtubeLink)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = YOUTUBE;
            processInfo.Arguments = youtubeLink;
            processInfo.UseShellExecute = false;
            processInfo.CreateNoWindow = true;
            processInfo.RedirectStandardOutput = true;
            processInfo.RedirectStandardError = true;

            var proc = new Process();
            proc.StartInfo = processInfo;
            proc.OutputDataReceived += proc_OutputDataReceived;
            proc.Start();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            //Console.ReadLine();
            

        }

        static void proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            string line = e.Data;
            
            //Console.ReadLine();
            if(line != null && line.Contains("Destination"))
            {
                var fileName = line.Split(new char[] {':'})[1].Trim();
                Console.WriteLine(fileName);
                DownloadedFileName = fileName;
            }
            else
            {
                Console.Write(line);
            }
        }

       
    }
}
