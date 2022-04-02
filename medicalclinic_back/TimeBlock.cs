using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Web;

namespace medicalclinic_back
{
    public static class TimeBlock
    {
        private static bool block = false;
        public static bool Block { get { return block; } set { block = value; } }
        public static void blockForm()
        {
            DateTime d1 = DateTime.Now;
            double d2 = 1;
            DateTime czasblok = d1.AddMinutes(d2);
            TimeSpan timeSpan = czasblok - d1;
            TimeSpan timeSpan1 = TimeSpan.Zero;
            
            if (timeSpan != timeSpan1)
            {
                do
                {
                    timeSpan = timeSpan.Subtract(TimeSpan.FromSeconds(1));
                    Thread.Sleep(1000);
                }
                while (timeSpan != timeSpan1);
            }
            else
            {
                Block = false;
            }
            Block = true;
        }
    }
}
