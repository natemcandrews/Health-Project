using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace CalendarSolution
{
    public partial class VitalsPage : Page
    {

        string PatientName; //Stores the patients name in a string
        string Username; //Stores the Username of the user, primarily used to access proper storage files

        /// <summary>
        /// Empty constructor for **VitalsPage** to add security
        /// </summary>
        VitalsPage() 
        {
            InitializeComponent();
        }

        /// <summary>
        /// **VitalsPage** class used to display vital data
        /// </summary>
        /// <param name="name"> The patients name </param>
        /// <param name="username"> The users name </param>
        /// <param name="fullData"> All the data accumulated for the patient </param>
        public VitalsPage(string name, string username, PatientAll fullData)
        {
            InitializeComponent();
            PatientName = name;
            Username = username; //Initialization of the form, patients name, and username
            this.DataContext = fullData;
        }


        /// <summary>
        /// Saves and logs the vitals for graphing and future review
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"> Default parameter for Buttons </param>
        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            PatientAll logVitalCast = (PatientAll) this.DataContext;

            LogVital log = new LogVital { Temp = double.Parse(logVitalCast.Temp), Pulse = logVitalCast.Pulse, Respirations = logVitalCast.Respirations, BP = logVitalCast.BP, PulseOx = logVitalCast.PulseOx };
            XmlSerializer LogSerializer = new XmlSerializer(log.GetType());
            StreamWriter LogWriter = File.CreateText("C:/Patient Forms/" + Username + "/" + PatientName + "/Vital Logs/" + "   " + log.TimeofLog.Replace(':', '-') + ".json");
            LogSerializer.Serialize(LogWriter.BaseStream, log);
            LogWriter.Close();

            MessageBox.Show("Form Saved");
        }
    }
}
