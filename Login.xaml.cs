using System;
using System.Collections.Generic;
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
using System.IO;


namespace CalendarSolution
{
    public partial class Login : Window
    {
        protected UserCreate users = new UserCreate(); //Is used to pass text from form to the current context
        protected string path; //The default path to all patient data

        /// <summary>
        /// This is the default constructor
        /// </summary>
        public Login()
        {
            InitializeComponent();
            this.DataContext = users; //Initializes all form and its data

            appointmentFolder();
        }

        void appointmentFolder()
        {
            if (!Directory.Exists("C:/Patient Forms/Appointments"))
            {
                Directory.CreateDirectory((System.IO.Path.GetPathRoot(Environment.SystemDirectory) + "/Patient Forms/Appointments"));
            }
        }

        /// <summary>
        /// This method is bound to the button that logs in the user
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param> 
        /// <param name="e"> Default parameter for Buttons </param>
        protected void LoginUser(object sender, RoutedEventArgs e)
        {
            path = ((System.IO.Path.GetPathRoot(Environment.SystemDirectory) + "/Patient Forms/" + users.Username));
            if (String.IsNullOrWhiteSpace(users.Username))
            {
                MessageBox.Show("That is not a valid username");
            }
            else if (Directory.Exists(path)) //Checks if the User already exists and has directories
            {
                if ((bool)hospital.IsChecked) //If the Hospital box is checked, use the hospital interface, otherwise it will default to MainWindow
                {
                    Hospital hospital = new Hospital(users.Username, path);
                    hospital.Show();
                    Close();
                }
                else
                {
                    MainWindow main = new MainWindow(users.Username, path); //Displays the main form
                    main.Show();
                    Close();
                }
            }

            else { MessageBox.Show("That User does not exist!"); }
        }

        /// <summary>
        /// The method used to create a new user and the files needed for each user
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param> 
        /// <param name="e"> Default parameter for Buttons </param>
        protected void CreateNew(object sender, RoutedEventArgs e)
        {
            path = ((System.IO.Path.GetPathRoot(Environment.SystemDirectory) + "/Patient Forms/" + users.Username));
            if (String.IsNullOrWhiteSpace(users.Username)) //Checks for presence of characters
            {
                MessageBox.Show("That is not a valid username");
            }

            else if(Directory.Exists(path)) //Does the user already exist 
            {
                MessageBox.Show("That user already exists");
            }

            else
            {
                Directory.CreateDirectory(path); //Creates necessary folders for the User
                MessageBox.Show("New User Created");
                Directory.CreateDirectory(path);
                MainWindow main = new MainWindow(users.Username, path); //Displays the main form
                main.Show();
                Close();
            }
        }
    }
}
