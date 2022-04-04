using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public Records(string Username, string Path, PatientAll fullData)
        {
            InitializeComponent();
            this.DataContext = fullData;
            path = Path;
            PatientName = fullData.Name;
            displayRecords(Username, fullData);
            createCombo();
        }

        protected void displayRecords(string Username, PatientAll fullData)
        {
            RecordFrame.Content = new FullPatientFile(Username, fullData);
        }





        public void createCombo()
        {


            DataContext = this;

            cbItems = new ObservableCollection<ComboBoxItem>();
            var cbItem = new ComboBoxItem { Content = "<--Select-->", HorizontalContentAlignment = 0, VerticalContentAlignment = 0 };
            SelectedcbItem = cbItem;
            cbItems.Add(cbItem);

            DirectoryInfo di = new DirectoryInfo($"{path}/{PatientName}/Images/Names");
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
