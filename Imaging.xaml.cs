using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace CalendarSolution
{

    public partial class Imaging : Page
    {
        ImageUpload image = new ImageUpload(); //Creates an object for storing and accessing images and image descriptions
        string PatientName; //Stores the patients name in a string
        string Username; //Stores the Username of the user, primarily used to access proper storage files
        string path; //path to patient files
        public ObservableCollection<ComboBoxItem> cbItems { get; set; } //The selectable options from the combo box

        /// <summary>
        /// Empty Constructor for **Imaging** to add security
        /// </summary>
        public Imaging()
        {
            InitializeComponent();
        }

        /// <summary>
        /// **Imaging** This constructor is used when the user wants to create a new image file
        /// </summary>
        /// <param name="patientname"> The patients name </param>
        /// <param name="username"> The users name </param>
        /// <param name="cbitem"> The selectable options from the combo box </param>
        /// <param name="Path"> path to patient files </param>
        public Imaging(string patientname, string username, ObservableCollection<ComboBoxItem> cbitem, string Path)
        {
            InitializeComponent();
            this.DataContext = image;
            Username = username;
            PatientName = patientname; //Initialization of the form, patients name, and username
            cbItems = cbitem;
            path = Path;
        }

        /// <summary>
        /// **Imaging** This constructor is used when the user wants to access a previously created image file 
        /// </summary>
        /// <param name="patientname"> The patients name </param>
        /// <param name="username"> The users name </param>
        /// <param name="descname"> The name of the Image to be displayed </param>
        /// <param name="cbitem"> The users name </param>
        /// <param name="Path"> path to patient files </param>
        public Imaging(string patientname, string username, string descname, ObservableCollection<ComboBoxItem> cbitem, string Path)
        {
            InitializeComponent();
            this.DataContext = image;
            Username = username;
            PatientName = patientname;
            cbItems = cbitem;
            path = Path;
            if (File.Exists(path + "/" + patientname + "/Images/" + descname + ".jpg") && File.Exists("C:/Patient Forms/" + Username + "/" + patientname + "/Images/Names/" + descname + ".json")) //Checks if the patient data already exists
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(image.GetType()); //Serializes data
                    StreamReader reader = File.OpenText(path + "/" + patientname + "/Images/Names/" + descname + ".json");
                    this.DataContext = serializer.Deserialize(reader);
                    image = (ImageUpload)this.DataContext;
                    reader.Close();

                    Uri resourceUri = new Uri(path + "/" + patientname + "/Images/" + descname + ".jpg");
                    imgPhoto.Source = new BitmapImage(resourceUri);
                }
                catch(IOException e) //Checks for issues with displaying the image
                {
                    MessageBox.Show("There was an error showing that image   " + e.Message);
                }
                

            }
            else { MessageBox.Show("That image does not exist"); } //Creates new form for patient if there is no data
        }

        /// <summary>
        /// Saves the image and description to the files
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons</param>
        /// <param name="e"> Default parameter for Buttons</param>
        protected void btnSave_Click(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializer = new XmlSerializer(image.GetType());
            StreamWriter writer = File.CreateText(path + "/" + PatientName + "/Images/Names/" + image.Title + ".json"); //Copies the image description to the storage folder
            serializer.Serialize(writer.BaseStream, this.DataContext);
            writer.Close();

            DirectoryInfo di = new DirectoryInfo(path + "/" + PatientName + "/Images/Names");
            FileInfo[] files = di.GetFiles();


            addCombo(true);
            

        }

        /// <summary>
        /// Add option to list of images
        /// If the image already exists, it will not be added
        /// </summary>
        /// <param name="add"></param>
        private void addCombo(bool add)
        {
            foreach (ComboBoxItem combo in cbItems) //Loops through each combobo item
            {
                if (combo.Content.Equals(image.Title)) //Checks if another item already exists
                {
                    add = false;
                }
            }

            if (add) //Adds new item
            {
                cbItems.Add(new ComboBoxItem { Content = image.Title, HorizontalContentAlignment = 0, VerticalContentAlignment = 0 });
            }
        }

        /// <summary>
        /// utilizes **OpenFileDialog** to save and display images
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"> Default parameter for Buttons </param>
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            SaveFileDialog save = new SaveFileDialog();
            op.Title = "Select an Image";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png"; //The initialization of OpenFileDialog window for accessing images

            if (op.ShowDialog() == true)
            {
                File.Copy(op.FileName, path + "/" + PatientName + "/Images/" + image.Title + ".jpg"); //Copies the selected image to a storage folder
                Uri uri = new Uri(op.FileName);
                imgPhoto.Source = new BitmapImage(uri); //Displays the Image
            }
            XmlSerializer serializer = new XmlSerializer(image.GetType());

            if (File.Exists(path + "/Images/Names/" + image.Title + ".json"))
            {
                File.Delete(path + "/Images/Names/" + image.Title + ".json");
            }

            StreamWriter writer = File.CreateText(path + "/" + PatientName + "/Images/Names/" + image.Title + ".json"); //Copies the image description to the storage folder
            serializer.Serialize(writer.BaseStream, this.DataContext);
            writer.Close();
        }
    }
}
