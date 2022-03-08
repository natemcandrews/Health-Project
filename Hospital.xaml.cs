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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace CalendarSolution
{
    public partial class Hospital : Window
    {
        PatientAll PatientData = new PatientAll();
        string Username;
        string path;

        /// <summary>
        /// Empty Constructor for **Hospital** to add security
        /// </summary>
        public Hospital()
        {
            InitializeComponent();
        }

        /// <summary>
        /// **Hospital** is the hospital side of the program, used as a replacement for **Main**
        /// It displays the current patients and limited information about them
        /// </summary>
        /// <param name="username"> The users name </param>
        /// <param name="Path"> The path to access the vital dataBase </param>
        public Hospital(string username, string Path)
        {
            InitializeComponent();
            Username = username;
            this.DataContext = PatientData;
            path = Path;
            genPatients();
        }

        /// <summary>
        /// Genrates a list of the current patients
        /// </summary>
        protected void genPatients()
        {
            string[] patients = Directory.GetDirectories(path);
            int[] spacing = { 20, 100, 180};
            int spacingIndex = 0;
            int verticalSpacing = 40;
            int roomnumber = 1000;
            makeLabel();
       


            foreach (string patient in patients) //Loops through each patient and their hospital info notes
            {
                string[] DirList = patient.Split('\\');
                string patientName = DirList[DirList.Length - 1];
                PatientAll tempData = deserialize(path + "/" + patientName + "/PatientData/" + patientName + "_Data.json");

                Label roomLabel = new Label();
                roomLabel.Content = roomnumber;
                PatientList.Children.Add(roomLabel);
                Canvas.SetTop(roomLabel, verticalSpacing);
                Canvas.SetLeft(roomLabel, spacing[spacingIndex]);
                roomnumber++;
                spacingIndex++;

                Label patientLabel = new Label();
                patientLabel.Content = tempData.Name;
                PatientList.Children.Add(patientLabel);
                Canvas.SetTop(patientLabel, verticalSpacing);
                Canvas.SetLeft(patientLabel, spacing[spacingIndex]);
                spacingIndex++;

                Label docLabel = new Label();
                docLabel.Content = tempData.Doc;
                PatientList.Children.Add(docLabel);
                Canvas.SetTop(docLabel, verticalSpacing);
                Canvas.SetLeft(docLabel, spacing[spacingIndex]);
                spacingIndex=0;
                verticalSpacing += 20;
            }
        }

        /// <summary>
        /// Creates the indivifual labels
        /// </summary>
        protected void makeLabel()
        {
            TextBlock roomLabel = new TextBlock();
            roomLabel.Text = "Room Number";
            roomLabel.TextDecorations = TextDecorations.Underline;
            PatientList.Children.Add(roomLabel);
            Canvas.SetTop(roomLabel, 0);
            Canvas.SetLeft(roomLabel, 20);

            TextBlock patientLabel = new TextBlock();
            patientLabel.Text = "Patient Name";
            patientLabel.TextDecorations = TextDecorations.Underline;
            PatientList.Children.Add(patientLabel);
            Canvas.SetTop(patientLabel, 0);
            Canvas.SetLeft(patientLabel, 105);

            TextBlock docLabel = new TextBlock();
            docLabel.Text = "Doctor Name";
            docLabel.TextDecorations = TextDecorations.Underline;
            PatientList.Children.Add(docLabel);
            Canvas.SetTop(docLabel, 0);
            Canvas.SetLeft(docLabel, 180);
        }

        /// <summary>
        /// Retrieves individual patients from file system
        /// </summary>
        /// <param name="pathToData"></param>
        /// <returns></returns>
        PatientAll deserialize(string pathToData)
        {
            XmlSerializer serializer = new XmlSerializer(PatientData.GetType()); //Serializes data if it exists
            StreamReader reader = File.OpenText(pathToData);
            PatientAll tempData = (PatientAll)serializer.Deserialize(reader);
            reader.Close();
            return tempData;
        }

        /// <summary>
        /// Creates a new patient file 
        /// **MAY BE REMOVED**
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
