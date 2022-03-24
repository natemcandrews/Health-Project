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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalendarSolution
{
    public partial class Progress : Page
    {
        string Patient; //Stores the patients name in a string
        List<List<string>> PatientNotes = new List<List<string>>();
        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();

        /// <summary>
        /// Empty constructor for **Progress** to add security
        /// </summary>
        public Progress()
        {
            InitializeComponent();
        }

        /// <summary>
        /// **Progress** class is used to keep track of patient progress and doctor notes
        /// </summary>
        /// <param name="name"> Patient name </param>
        /// <param name="fullData"> All the data accumulated for the patient </param>
        public Progress(string name, PatientAll fullData)
        {
            InitializeComponent();
            Patient = name;
            PatientNotes = fullData.PatientNotes;
            this.DataContext = fullData;
            

            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Start();
            Timer.Interval = new TimeSpan(0, 0, 1);

            loadNotes();

        }

        /// <summary>
        /// loads in saved doctor notes
        /// </summary>
        protected void loadNotes()
        {
            int[] spacingArray = { 20, 95, 165, 200, 225 };
            int verticalSpacing = 0;


            foreach(List<string> Note in PatientNotes)
            {
                int spacingIndex = 0;
                foreach (string noteText in Note)
                {
                    Label newLabel = new Label();
                    newLabel.Content = noteText;

                    ProgressList.Children.Add(newLabel);
                    Canvas.SetTop(newLabel, verticalSpacing);
                    Canvas.SetLeft(newLabel, spacingArray[spacingIndex]); //Check spacing
                    spacingIndex++;
                }
                verticalSpacing += 20;
            }
        }

        
        /// <summary>
        /// Connects to a label to display current time
        /// </summary>
        /// <param name="sender"> Default parameter for label </param>
        /// <param name="e"> Default parameter for label </param>
        protected void Timer_Click(object sender, EventArgs e)
        {
            Clock.Content = "Current Time:  " + DateTime.Now.ToString().Split(' ')[1];
        }

        /// <summary>
        /// Adds new note to the list
        /// </summary>
        /// <param name="sender"> Default parameter for Buttons </param>
        /// <param name="e"> Default parameter for Buttons </param>
        protected void AddNote(object sender, RoutedEventArgs e)
        {
            List<string> PatientNote = new List<string>();
            PatientNote.Add(DateTime.Now.ToString().Split(' ')[1]);
            PatientNote.Add(DateTime.Now.ToString().Split(' ')[0]);
            PatientNote.Add(Patient);
            PatientNote.Add(Note.Text);

            PatientNotes.Add(PatientNote);
            loadNotes();
        }
    }
}


