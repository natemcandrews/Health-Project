using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSolution
{
    public class LogVital
    {

        private string tempValue;
        public string Temp
        {
            get { return tempValue; }
            set { tempValue = value; }
        }


        private string pulseValue;
        public string Pulse
        {
            get { return pulseValue; }
            set { pulseValue = value; }
        }


        private string respValue;
        public string Respirations
        {
            get { return respValue; }
            set { respValue = value; }
        }


        private string bpValue;
        public string BP
        {
            get { return bpValue; }
            set { bpValue = value; }
        }


        private string pulseoxValue;
        public string PulseOx
        {
            get { return pulseoxValue; }
            set { pulseoxValue = value; }
        }

        public string TimeofLog = DateTime.Now.TimeOfDay.Hours.ToString() + ":" + DateTime.Now.TimeOfDay.Minutes.ToString() + ":" + DateTime.Now.TimeOfDay.Seconds.ToString();
    }
}
