using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace CalendarSolution
{
    
    public partial class Records : Window
    {

        public ObservableCollection<ComboBoxItem> cbItems { get; set; }
        public ComboBoxItem SelectedcbItem { get; set; }
        public ObservableCollection<ComboBoxItem> vitalCB { get; set; }
        public ComboBoxItem selectedVital { get; set; }
        string PatientName;
        string path;
        string Username;

        /// <summary>
        /// Empty constructor for **Records** to add security
        /// </summary>
        public Records()
        {
            InitializeComponent();
        }

        /// <summary>
        /// **Records** class used to create a seperate window for showing records
        /// </summary>
        /// <param name="fullData"></param>
        public Records(string username, string Path, PatientAll fullData)
        {
            InitializeComponent();
            this.DataContext = fullData;
            path = Path;
            PatientName = fullData.Name;
            Username = username;
            displayRecords(username, fullData);
            createCombo();
        }

        protected void displayRecords(string Username, PatientAll fullData)
        {
            RecordFrame.Content = new FullPatientFile(Username, fullData);
        }

        protected void Open_Image(object sender, RoutedEventArgs e) //Opens image upload page
        {
            RecordFrame.Content = new Imaging(PatientName, Username, SelectedcbItem.Content.ToString(), cbItems, path); //Opens Imaging form for accessing a previously saved image
        }

        protected void Delete(object sender, RoutedEventArgs e)
        {
            ListProcesses();
            RecordFrame.Content = null; //How is image being used
            this.Close();
            Directory.Delete($"{path}/{PatientName}", true);
        }

        private void ListProcesses()
        {
            Process[] processCollection = Process.GetProcesses();
            foreach (Process p in processCollection)
            {
                Console.WriteLine(p.ProcessName);
            }
        }


        public void createCombo()
        {
            DataContext = this;

            cbItems = new ObservableCollection<ComboBoxItem>();
            var cbItem = new ComboBoxItem { Content = "<--Select-->", HorizontalContentAlignment = 0, VerticalContentAlignment = 0 };
            SelectedcbItem = cbItem;
            cbItems.Add(cbItem);

            DirectoryInfo di = new DirectoryInfo($"{path}/{PatientName}/Images");
            FileInfo[] files = di.GetFiles();



            foreach (var file in files)
            {
                int position = file.Name.IndexOf('.');
                string title = file.Name.Substring(0, position);
                cbItems.Add(new ComboBoxItem { Content = title, HorizontalContentAlignment = 0, VerticalContentAlignment = 0 });
            }

            vitalCB = new ObservableCollection<ComboBoxItem>();
            var vitalCBItem = new ComboBoxItem { Content = "<--Select-->", HorizontalContentAlignment = 0, VerticalContentAlignment = 0 };
            selectedVital = vitalCBItem;
            vitalCB.Add(vitalCBItem);

            string[] vitals = new string[] { "Temperature", "Pulse", "Respirations", "Blood Pressure", "Pulse Ox" };

            foreach (string Vital in vitals)
            {
                vitalCB.Add(new ComboBoxItem { Content = Vital, HorizontalContentAlignment = 0, VerticalContentAlignment = 0 });
            }
        }
    }
}