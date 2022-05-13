using Microsoft.Win32;
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
        Process imageAccess;
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
            addCombo(true);
        }

        /// <summary>
        /// **Imaging** This constructor is used when the user wants to access a previously created image file 
        /// </summary>
        /// <param name="patientname"> The patients name </param>
        /// <param name="username"> The users name </param>
        /// <param name="title"> The name of the Image to be displayed </param>
        /// <param name="cbitem"> The users name </param>
        /// <param name="Path"> path to patient files </param>
        public Imaging(string patientname, string username, string title, ObservableCollection<ComboBoxItem> cbitem, string Path)
        {
            InitializeComponent();
            this.DataContext = image;
            Username = username;
            PatientName = patientname;
            cbItems = cbitem;
            path = Path;
            if (File.Exists($"{path}/{patientname}/Images/{title}.jpg")) //Checks if the patient data already exists
            {
                try
                {
                    Uri resourceUri = new Uri($"{path}/{patientname}/Images/{title}.jpg");
                    imgPhoto.Source = new BitmapImage(resourceUri);
                }
                catch(IOException e) //Checks for issues with displaying the image
                {
                    MessageBox.Show("There was an error showing that image   " + e.Message);
                }
                

            }
            else { MessageBox.Show("That image does not exist"); } //Creates new form for patient if there is no data
            addCombo(true);
        }

        public Process getProcess()
        {
            return imageAccess;
        }

        /// <summary>
        /// Saves the image and description to the files
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons</param>
        /// <param name="e"> Default parameter for Buttons</param>


        /// <summary>
        /// Add option to list of images
        /// If the image already exists, it will not be added
        /// </summary>
        /// <param name="add"></param>
        private void addCombo(bool add)
        {
            int count = 0;
            int removeIndex = -1;
            foreach (ComboBoxItem combo in cbItems) //Loops through each combobo item
            {

                try {
                    if (string.IsNullOrEmpty(combo.Content.ToString()) && combo.Content.Equals(image.Title)) //Checks if another item already exists
                    {
                        add = false;
                    }
                } catch (NullReferenceException ex){
                    ex.GetBaseException();
                    removeIndex = count;
                }
                count++;
            }

            if(removeIndex > 0)
            {
                cbItems.RemoveAt(removeIndex);
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

            addCombo(true);
        }
    }
}
