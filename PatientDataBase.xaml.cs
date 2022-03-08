using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Xml.Serialization;



namespace CalendarSolution
{
    public partial class PatientDataBase : Window
    {
        string Username; //Stores the Username of the user, primarily used to access proper storage files
        public string PatientName { get; set; }
        PatientAll PatientData = new PatientAll();
        public ObservableCollection<ComboBoxItem> cbItems { get; set; }
        public ComboBoxItem SelectedcbItem { get; set; }
        public ObservableCollection<ComboBoxItem> vitalCB { get; set; }
        public ComboBoxItem selectedVital { get; set; }
        string path;

        /// <summary>
        /// Empty constructor for **medHistory** to add security
        /// </summary>
        public PatientDataBase()
        { InitializeComponent(); }

        /// <summary>
        /// **PatientData** manages all the forms and is able to save the curent patient data when closed
        /// This is the main structure that organizes the form and data
        /// </summary>
        /// <param name="patientname"> The patients name </param>
        /// <param name="username"> The users name </param>
        /// <param name="fulldata"> All the data accumulated for the patient </param>
        /// <param name="Path"> The path to the file system </param>
        public PatientDataBase(string patientname, string username, PatientAll fulldata, string Path)
        {
            InitializeComponent();
            PatientData = fulldata;
            PatientName = patientname; //FIX VARIABLE NAMES, make them more descriptive
            Username = username; //Initialization of the form, patients name, and username
            path = Path;
            createCombo();

            if (File.Exists(path + "/" + PatientName + "/PatientData/" + PatientName + "_Data.json")) //Checks if the patient data already exists
            {
                XmlSerializer serializer = new XmlSerializer(PatientData.GetType()); //Serializes data if it exists
                StreamReader reader = File.OpenText("C:/Patient Forms/" + Username + "/" + PatientName + "/PatientData/" + PatientName + "_Data.json");
                PatientData = (PatientAll)serializer.Deserialize(reader);
                reader.Close();
            }
        }

        /// <summary>
        /// In case of an unhandled exception, save the data
        /// NEEDS FURTHER TESTING
        /// </summary>
        /// <param name="sender"> Default parameter </param>
        /// <param name="e"> Default paramerter </param>
        protected void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            XmlSerializer Fullserializer = new XmlSerializer(PatientData.GetType()); //Saves all data to the specified folder
            StreamWriter Fullwriter = File.CreateText(path + "/" + PatientName + "/PatientData/" + PatientName + "_Data.json"); //The folder location
            Fullserializer.Serialize(Fullwriter.BaseStream, PatientData);
            Fullwriter.Close();
            e.Handled = true;
        }
        
        /// <summary>
        /// Opens the **VitalsPage** form
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"></param>
        protected void OpenVital(object sender, RoutedEventArgs e)
        {
            frame1.Content = new VitalsPage(PatientName, Username, PatientData); //Opens vital form
        }

        /// <summary>
        /// Opens the **medHistory** form
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"> Default parameter for Buttons </param>
        protected void OpenHist(object sender, RoutedEventArgs e)
        {
            frame1.Content = new medHistory(PatientData); //Opens medical history forms
        }

        /// <summary>
        /// Opens the **Demographic** form
        /// </summary>
        /// <param name="sender"> Default paramter for Buttons </param>
        /// <param name="e"> Default parameter for Buttons </param>
        protected void OpenDemo(object sender, RoutedEventArgs e) 
        {
            frame1.Content = new Demograpic(PatientData); //Opens demographics form
        }

        /// <summary>
        /// Opens the **Immune** form
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"> Default parameter for Buttons </param>
        protected void OpenImmune(object sender, RoutedEventArgs e) 
        {
            frame1.Content = new Immune(PatientData); //Opens immunizations form
        }

        /// <summary>
        /// Opens the **Urinalysis** form
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"> Default parameter for Buttons </param>
        protected void OpenUrinalysis(object sender, RoutedEventArgs e) 
        {
            frame1.Content = new Urinalysis(PatientData); //Opens Urinalysis form
        }

        /// <summary>
        /// Opens the **LabResults** form
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"> Default parameter for Buttons </param>
        protected void OpenLab(object sender, RoutedEventArgs e)
        {
            frame1.Content = new LabResults(PatientData); //Opens LabResults form
        }

        /// <summary>
        /// Opens the **Imaging** form for creating a new image
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"> Default parameter for Buttons </param>
        protected void UploadImage(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Imaging(PatientName, Username, cbItems, path); //Opens Imaging form for creating new image
            
        }

        /// <summary>
        /// Opens the **Imaging** form for accessing a previously saved image
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"> Default parameter for Buttons </param>
        protected void OpenImage(object sender, RoutedEventArgs e) //Opens image upload page
        {
            frame1.Content = new Imaging(PatientName, Username, SelectedcbItem.Content.ToString(), cbItems, path); //Opens Imaging form for accessing a previously saved image
        }

        /// <summary>
        /// Opens the **graphVital** form
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"> Demograpic </param>
        protected void OpenGraph(object sender, RoutedEventArgs e)
        {
            frame1.Content = new graphVital(PatientName, selectedVital.Content.ToString(), path); //Opens vital graphing form
        }

        /// <summary>
        /// Opens the **FullPatientFile** form
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"> Default parameter for </param>
        protected void genFile(object sender, RoutedEventArgs e)
        {
            frame1.Content = new FullPatientFile(PatientName, PatientData); //Opens full patient data file
        }

        /// <summary>
        /// Opens the **Progress** form
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"> Default parameter for Buttons </param>
        void Progress(object sender, RoutedEventArgs e)
        {
            frame1.Content = new Progress(PatientName, PatientData); //Opens progress file
        }


        /// <summary>
        /// This method createCombo is used to create combo boxes for selecting from a list, pls update or im mad
        /// </summary>
        public void createCombo()
        {
            

            DataContext = this;

            cbItems = new ObservableCollection<ComboBoxItem>();
            var cbItem = new ComboBoxItem { Content = "<--Select-->", HorizontalContentAlignment = 0, VerticalContentAlignment = 0 };
            SelectedcbItem = cbItem;
            cbItems.Add(cbItem);

            DirectoryInfo di = new DirectoryInfo(path + "/" + PatientName + "/Images/Names");
            FileInfo[] files = di.GetFiles();
            
            

            foreach (var file in files)
            {
                int position = file.Name.IndexOf('.');
                string title = file.Name.Substring(0, position);
                cbItems.Add(new ComboBoxItem { Content = title, HorizontalContentAlignment = 0, VerticalContentAlignment = 0});
            }

            vitalCB = new ObservableCollection<ComboBoxItem>();
            var vitalCBItem = new ComboBoxItem { Content = "<--Select-->", HorizontalContentAlignment = 0, VerticalContentAlignment = 0 };
            selectedVital = vitalCBItem;
            vitalCB.Add(vitalCBItem);

            string[] vitals = new string[] { "Temperature", "Pulse", "Respirations", "Blood Pressure", "Pulse Ox"};
            
            foreach(string Vital in vitals)
            {
                vitalCB.Add(new ComboBoxItem { Content = Vital, HorizontalContentAlignment = 0, VerticalContentAlignment = 0 });
            }

        }

        /// <summary>
        /// Saves the current data when the form is closed
        /// </summary>
        /// <param name="e"> Default parameter for Buttonss </param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            XmlSerializer Fullserializer = new XmlSerializer(PatientData.GetType()); //Saves all data to the specified folder
            StreamWriter Fullwriter = File.CreateText(path + "/" + PatientName + "/PatientData/" + PatientName + "_Data.json"); //The folder location
            Fullserializer.Serialize(Fullwriter.BaseStream, PatientData);
            Fullwriter.Close();
        }

    }

}

