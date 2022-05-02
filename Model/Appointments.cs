using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;
using System.Xml.Serialization;
using CalendarSolution.Controls;

namespace OutlookCalendar.Model
{
    public class Appointments : ObservableCollection<Appointment>
    {

        public Appointments()
        { 

        }
    }
}
