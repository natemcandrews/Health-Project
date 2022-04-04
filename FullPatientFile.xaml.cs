using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
    public partial class FullPatientFile : Page
    {
        PatientAll PatientData = new PatientAll(); // Creates an object that stores all the patient data
        string Username;

        /// <summary>
        /// Empty Constructor for **FullPatientFile** to add security
        /// </summary>
        public FullPatientFile()
        {
            InitializeComponent();
        }

        /// <summary>
        /// **FullPatientFile** used as a template for displaying all data collected about a patient
        /// </summary>
        /// <param name="username"> The current User </param>
        /// <param name="fullData"> All the data accumulated for the patient </param>
        public FullPatientFile(string username, PatientAll fullData)
        {
            InitializeComponent();
            Username = username;
            this.DataContext = fullData;
            PatientData = fullData;
            createLabels();
        }
        
        /// <summary>
        /// Creates all the labels needed for displaying data
        /// </summary>
        protected void createLabels()
        {
            double topSpace = 0;
            double leftSpace = 0;

            string FileLocation = "C:/Patient Forms/" + Username + "/PatientData/" + PatientData.Name + "_Data.json";

            string[] propNames = { "HIPPA", "Emergency Contact Name", "Emergency Contact number", "Insurance Company", "Insurance Number", "Insurance Group", "Appointment Date", "Occupation", "Reason for visit", "Medications", "Allergies", "Symptoms", "Amount of Hospital Visits", "Medical History", "Blood Transfusion", "Work Concerns", "Health habits", "Pregnant", "Name", "Date of birth", "Age", "Temperature", "Pulse", "Respirations", "Blood Pressure", "Pulse Ox", "Height", "Weight", "Doctor name", "Current Date", "Current Time", "Urine Color",  "Urine Temperature", "Urine PH", "Urine Glucose Level", "Urine Blood Presence", "Urine Protein Presence", "Leukocytes", "Urine Test Time", "Urine Test Date", "CBC", "WBC", "RBC", "Time of Lab Test", "PT/PTT", "Hemoglobin", "Hematocrit", "Date of lab test", "Platelets", "A1C"};


            int propPos = 0;

            foreach (PropertyInfo property in PatientData.GetType().GetProperties()) //loops through each patient property
            {
                string Value = "";
                if (property.GetValue(PatientData, null) != null) //checks if property has a value
                {
                    Value = property.GetValue(PatientData, null).ToString();
                }

                if (property.Name != "Immunity") //ignores immunity
                {
                    Label mylabel = new Label();
                    try {
                        mylabel.Content = propNames[propPos] + ": " + Value; //find a way to get variables value into form
                    } catch(IndexOutOfRangeException e) {
                        Console.Write(e.Data);
                        break;
                    }

                    //adds property to the form window
                    myCanvas.Children.Add(mylabel); 
                    Canvas.SetTop(mylabel, topSpace);
                    Canvas.SetLeft(mylabel, leftSpace);
                    topSpace += 25;
                    if (topSpace >= 390)
                    {
                        topSpace = 0;
                        leftSpace += 225;
                    }
                    propPos++;
                }
            }
        }
    }
}
