using Office365ManagementSamples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office365Management
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Task.Factory.StartNew();
            ActivityCase.ListSharePointAudiLog();
            stopWatch.Stop();
            Console.WriteLine($"\r\nThe task costs time:{stopWatch.Elapsed}");
            Console.ReadLine();
        }
    }
}
