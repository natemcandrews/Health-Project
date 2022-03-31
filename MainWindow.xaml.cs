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
            getAppointments();
        }


        void getAppointments()
        {
        }

        /// <summary>
        /// Creates new directory path for a new patient
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"> Default parameter for Buttons </param>
        void NewDatabase(object sender, RoutedEventArgs e)
        {
            Directory.CreateDirectory(path + "/" + PatientData.Name + "/Images");
            Directory.CreateDirectory(path + "/" + PatientData.Name + "/Images/Names");
            Directory.CreateDirectory(path + "/" + PatientData.Name + "/PatientData");
            Directory.CreateDirectory(path + "/" + PatientData.Name + "/Vital Logs");
            PatientDataBase DataBase = new PatientDataBase(PatientData.Name, Username, PatientData, path);
            DataBase.Show();
        }
    }
}



//Check the saving for Images like test results
//Seeing past records for a patient
//Appointment Scheduler