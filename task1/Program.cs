using System;
using System.Diagnostics;

namespace task1
{
    public static class Program
    {
        private const long OneKb = 1024;
        private const long OneMb = OneKb * 1024;
        private const long OneGb = OneMb * 1024;
        private const long OneTb = OneGb * 1024;
        static void Main(string[] args)
        {
            Console.WriteLine("Process name                              PID Session Name         Session#    Mem Usage");
            Console.WriteLine("====================================== ====== ================== ========== ============");
            int pageCounter = 0;
            foreach (Process p in Process.GetProcesses())
            {
                string memSize = ToPrettySize(p.);
                Console.WriteLine("{0, -38} {1, -6} {2, -18} {3, -10} {4, -12}",p.ProcessName, p.Id, p.MachineName, p.SessionId, memSize);
                pageCounter++;
                if(pageCounter > 25)
                {
                    Console.WriteLine("Press Enter to print other page");
                    Console.Read();                    
                    //Console.WriteLine("Process name                              PID Session Name         Session#    Mem Usage");
                    //Console.WriteLine("====================================== ====== ================== ========== ============");
                    pageCounter = 0;
                }
            }
        }
        public static string ToPrettySize(this long value, int decimalPlaces = 0)
        {
            var asTb = Math.Round((double)value / OneTb, decimalPlaces);
            var asGb = Math.Round((double)value / OneGb, decimalPlaces);
            var asMb = Math.Round((double)value / OneMb, decimalPlaces);
            var asKb = Math.Round((double)value / OneKb, decimalPlaces);
            string chosenValue = asTb > 1 ? string.Format("{0}Tb", asTb)
                : asGb > 1 ? string.Format("{0}Gb", asGb)
                : asMb > 1 ? string.Format("{0}Mb", asMb)
                : asKb > 1 ? string.Format("{0}Kb", asKb)
                : string.Format("{0}B", Math.Round((double)value, decimalPlaces));
            return chosenValue;
        }        
    }
}
