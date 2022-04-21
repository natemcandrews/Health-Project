using CalendarSolution.Controls;
using OutlookCalendar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CalendarSolution
{
    /// <summary>
    /// Interaction logic for AppointmentWindow.xaml
    /// </summary>
    public partial class AppointmentWindow : Window
    {
        private Appointments appointments = new Appointments();

        public AppointmentWindow()
        {
            InitializeComponent();

            DataContext = appointments;
        }



        private void Calendar_AddAppointment(object sender, RoutedEventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.Subject = "Subject?";
            appointment.StartTime = DateProperty.ScheduleDate;
            appointment.EndTime = DateProperty.ScheduleDate;

            AddAppointmentWindow aaw = new AddAppointmentWindow();
            aaw.DataContext = appointment;
            aaw.ShowDialog();

            appointments.Add(appointment);
        }
    }
}
