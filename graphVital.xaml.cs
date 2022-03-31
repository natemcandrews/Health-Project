using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
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
    public partial class graphVital : Page
    {

        LogVital vitals = new LogVital(); //object for logging patient data
        string PatientName; //The patients name
        string path; //path to patient files

        /// <summary>
        /// Empty Constructor for **graphVital** to add security
        /// </summary>
        public graphVital()
        {
            InitializeComponent();
        }

        /// <summary>
        /// **graphVital** used as a template for displaying all data collected about a patient
        /// </summary>
        /// <param name="name"> The patients name </param>
        /// <param name="vitalToGraph"> The specific vital that is going to be displayed </param>
        /// <param name="Path"> The path to access the vital data </param>
        public graphVital(string name, string vitalToGraph, string Path)
        {
            InitializeComponent();
            PatientName = name;
            path = Path;
            makeGraph(vitalToGraph);
        }

        /// <summary>
        /// The method that generates a graph for the specified vital
        /// </summary>
        /// <param name="vitalToGraph"> The specific vital sign </param>
        protected void makeGraph(string vitalToGraph)
        {
            string pathToVital = path + "/" + PatientName + "/Vital Logs/";

            if (vitalToGraph.Equals("Temperature")) //Graphs temperature
            {
                MyChart.Title = "Temperature of " + PatientName;
                LineName.Title = "Temperature";

                List<KeyValuePair<string, double>> pointData = new List<KeyValuePair<string, double>>();

                if (Directory.Exists(pathToVital)) //Gathers vital data to plot on graph
                {
                    String[] vitalFiles = Directory.GetFiles(pathToVital);
                    foreach (string vitalFileName in vitalFiles)
                    {
                        XmlSerializer serializer = new XmlSerializer(vitals.GetType()); //Serializes data 
                        StreamReader reader = File.OpenText(vitalFileName); 
                        LogVital vitalData = (LogVital)serializer.Deserialize(reader);
                        if(int.Parse(vitalData.TimeofLog.Substring(0,2))>= 12) //Converts time from 24 hour to 12 hour
                        {
                            string oldHour = vitalData.TimeofLog.Substring(0, 2);
                            string noHour = vitalData.TimeofLog.Substring(2);
                            string newHour = (int.Parse(oldHour) - 12).ToString();
                            vitalData.TimeofLog = newHour + noHour;

                        }
                        try {
                            if (Double.Parse(vitalData.Temp)  > 0) {
                                pointData.Add(new KeyValuePair<string, double>(vitalData.TimeofLog, Double.Parse(vitalData.Temp))); 
                            } //Plots temperature
                         }
                        catch (System.FormatException) //Checks for incorrectly entered temperatures
                        {
                            MessageBox.Show("One of the previous forms was incorrectly filled out\nThe issue was: " + vitalData.Temp);
                            reader.Close();
                        }
                    }
                    ((LineSeries)MyChart.Series[0]).ItemsSource = pointData; //Loads graph into the window
                }
            }


            else if (vitalToGraph.Equals("Pulse")) //Graphs pulse
            {
                MyChart.Title = "Pulse of " + PatientName;
                LineName.Title = "Pulse";

                List<KeyValuePair<string, double>> pointData = new List<KeyValuePair<string, double>>();

                if (Directory.Exists(pathToVital)) //Gets pulse data if it exists
                {
                    String[] vitalFiles = Directory.GetFiles(pathToVital);
                    foreach (string vitalFileName in vitalFiles)
                    {
                        XmlSerializer serializer = new XmlSerializer(vitals.GetType()); //Serializes data 
                        StreamReader reader = File.OpenText(vitalFileName);
                        LogVital vitalData = (LogVital)serializer.Deserialize(reader);
                        if (int.Parse(vitalData.TimeofLog.Substring(0, 2)) >= 12) //Converts time from 24 hour to 12 hour
                        {
                            string oldHour = vitalData.TimeofLog.Substring(0, 2);
                            string noHour = vitalData.TimeofLog.Substring(2);
                            string newHour = (int.Parse(oldHour) - 12).ToString();
                            vitalData.TimeofLog = newHour + noHour;

                        }
                        try { pointData.Add(new KeyValuePair<string, double>(vitalData.TimeofLog, double.Parse(vitalData.Pulse.Trim()))); } //Plots Pulse
                        catch (System.FormatException) //Checks for incorrectly entered Pulse
                        {
                            MessageBox.Show("One of the previous forms was incorrectly filled out\nThe issue was: " + vitalData.Pulse);
                            reader.Close();
                        }
                    }
                    ((LineSeries)MyChart.Series[0]).ItemsSource = pointData; //Loads graph into the window
                }
            }

            else if (vitalToGraph.Equals("Respirations")) //Graphs respirations
            {
                MyChart.Title = "Respirations of " + PatientName;
                LineName.Title = "Respirations";

                List<KeyValuePair<string, double>> pointData = new List<KeyValuePair<string, double>>();

                if (Directory.Exists(pathToVital)) //Gets respiration data if it exists
                {
                    String[] vitalFiles = Directory.GetFiles(pathToVital);
                    foreach (string vitalFileName in vitalFiles)
                    {
                        XmlSerializer serializer = new XmlSerializer(vitals.GetType()); //Serializes data 
                        StreamReader reader = File.OpenText(vitalFileName);
                        LogVital vitalData = (LogVital)serializer.Deserialize(reader);
                        if (int.Parse(vitalData.TimeofLog.Substring(0, 2)) >= 12) //Converts time from 24 hour to 12 hour
                        {
                            string oldHour = vitalData.TimeofLog.Substring(0, 2);
                            string noHour = vitalData.TimeofLog.Substring(2);
                            string newHour = (int.Parse(oldHour) - 12).ToString();
                            vitalData.TimeofLog = newHour + noHour;

                        }
                        try { pointData.Add(new KeyValuePair<string, double>(vitalData.TimeofLog, double.Parse(vitalData.Respirations.Trim()))); } //Plots Respirations
                        catch (System.FormatException) //Checks for incorrectly entered Respirations
                        {
                            MessageBox.Show("One of the previous forms was incorrectly filled out\nThe issue was: " + vitalData.Respirations);
                            reader.Close();
                        }
                    }
                    ((LineSeries)MyChart.Series[0]).ItemsSource = pointData; //Loads graph into the window
                }
            }


            else if (vitalToGraph.Equals("Blood Pressure")) //Graphs Blood Pressure
            {
                MyChart.Title = "Blood Pressure of " + PatientName;
                LineName.Title = "Systolic";

                MyChart.Series.Add(new LineSeries() //Creates two lines for each blood pressure measurement
                {
                    Name = "LineName2",
                    Title = "Diastolic",
                    IndependentValuePath = "Key",
                    DependentValuePath = "Value"
                });

                List<KeyValuePair<string, double>> pointData = new List<KeyValuePair<string, double>>();
                List<KeyValuePair<string, double>> pointData2 = new List<KeyValuePair<string, double>>();

                if (Directory.Exists(pathToVital)) //Gets Blood Pressure data if it exists
                {
                    String[] vitalFiles = Directory.GetFiles(pathToVital);
                    foreach (string vitalFileName in vitalFiles)
                    {
                        XmlSerializer serializer = new XmlSerializer(vitals.GetType()); //Serializes data 
                        StreamReader reader = File.OpenText(vitalFileName);
                        LogVital vitalData = (LogVital)serializer.Deserialize(reader);
                        if (int.Parse(vitalData.TimeofLog.Substring(0, 2)) >= 12)//Converts time from 24 hour to 12 hour
                        {
                            string oldHour = vitalData.TimeofLog.Substring(0, 2);
                            string noHour = vitalData.TimeofLog.Substring(2);
                            string newHour = (int.Parse(oldHour) - 12).ToString();
                            vitalData.TimeofLog = newHour + noHour;
                        }

                        string[] BPS = vitalData.BP.Trim().Split('/');
                        
                        try { pointData.Add(new KeyValuePair<string, double>(vitalData.TimeofLog, double.Parse(BPS[0]))); } //plots Blood Pressure Systolic
                        catch (System.FormatException) //Checks for incorrectly entered Blood Pressure 
                        {
                            MessageBox.Show("One of the previous forms was incorrectly filled out\nThe issue was: " + vitalData.BP + " Systolic");
                            reader.Close();
                        }
                        try { pointData2.Add(new KeyValuePair<string, double>(vitalData.TimeofLog, double.Parse(BPS[1]))); } //plots Blood Pressure Diastolic
                        catch (System.FormatException) //Checks for incorrectly entered Blood Pressure 
                        {
                            MessageBox.Show("One of the previous forms was incorrectly filled out\nThe issue was: " + vitalData.BP + " Diastolic");
                            reader.Close();
                        }

                    }
                    ((LineSeries)MyChart.Series[0]).ItemsSource = pointData; //Loads Systolic Blood Pressure into the window
                    ((LineSeries)MyChart.Series[1]).ItemsSource = pointData2; //Loads Diastolic blood Pressure into the window
                }
            }

            else if (vitalToGraph.Equals("Pulse Ox")) //Graphs Pulse Ox
            {
                MyChart.Title = "Pulse Ox of " + PatientName;
                LineName.Title = "Pulse Ox";

                List<KeyValuePair<string, double>> pointData = new List<KeyValuePair<string, double>>();

                if (Directory.Exists(pathToVital)) //Gets Pulse ox data if it exists
                {
                    String[] vitalFiles = Directory.GetFiles(pathToVital);
                    foreach (string vitalFileName in vitalFiles)
                    {
                        XmlSerializer serializer = new XmlSerializer(vitals.GetType()); //Serializes data 
                        StreamReader reader = File.OpenText(vitalFileName); 
                        LogVital vitalData = (LogVital)serializer.Deserialize(reader);
                        if (int.Parse(vitalData.TimeofLog.Substring(0, 2)) >= 12) //Converts 24 hour time to 12 hour time
                        {
                            string oldHour = vitalData.TimeofLog.Substring(0, 2);
                            string noHour = vitalData.TimeofLog.Substring(2);
                            string newHour = (int.Parse(oldHour) - 12).ToString();
                            vitalData.TimeofLog = newHour + noHour;

                        }
                        try { pointData.Add(new KeyValuePair<string, double>(vitalData.TimeofLog, double.Parse(vitalData.PulseOx.Trim()))); } //Plots Pulse Ox
                        catch (System.FormatException) { //checks for incorrectly entered Pulse Ox
                            MessageBox.Show("One of the previous forms was incorrectly filled out\nThe issue was: " + vitalData.PulseOx);
                            reader.Close();
                        }
                    }
                    ((LineSeries)MyChart.Series[0]).ItemsSource = pointData; //Loads the graph into the window
                }
            }
            else { MessageBox.Show("Please select a vital"); } //If the user has not selcted a vital, this message will show
        }
    }
}



