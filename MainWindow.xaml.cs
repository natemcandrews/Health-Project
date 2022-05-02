using CalendarSolution.Controls;
using OutlookCalendar.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;
using System.Xml.Serialization;

namespace CalendarSolution
{

    public partial class MainWindow : Window
    {
        /*Creating the Object needed for moving data 
         * dir = Patient name for file finding,
         */
        string Username;
        PatientAll PatientData = new PatientAll();
        string path;

        /// <summary>
        /// Empty Constructor for **MainWindow** to add security
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// **MainWindow** is used to display a calendar with patient appointments
        /// It is also used to create or access patient files
        /// </summary>
        /// <param name="username"> The users name</param>
        /// <param name="Path"> The path to save the patient files to</param>
        public MainWindow(string username, string Path)
        {
            InitializeComponent();
            Username = username;
            this.DataContext = PatientData;
            path = Path;
        }



        /// <summary>
        /// Creates new directory path for a new patient
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"> Default parameter for Buttons </param>
        void NewDatabase(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory(path + "/" + PatientData.Name + "/Images");
            Directory.CreateDirectory(path + "/" + PatientData.Name + "/PatientData");
            Directory.CreateDirectory(path + "/" + PatientData.Name + "/Vital Logs");
            PatientDataBase DataBase = new PatientDataBase(PatientData.Name, Username, PatientData, path);
            DataBase.Show();
        }

        protected void ToggleHospital(object sender, RoutedEventArgs e)
        {
            Hospital hospital = new Hospital(Username, path);
            hospital.Show();
            this.Close();
        }

        protected void newSchedule(object sender, RoutedEventArgs e)
        {
            
            Button temp = (Button)sender;
            try
            {
                DateTime theDate = (DateTime)temp.Content;
                DateProperty.ScheduleDate = theDate;
                AppointmentWindow schedule = new AppointmentWindow();
                AppointmentLoader.firstRun = true;
                schedule.Show();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Please select a date first");
            }

        }
    }
}



