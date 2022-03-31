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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace CalendarSolution
{
    public partial class Demograpic : Page
    {        
        /// <summary>
        /// Empty constructor for **Demograpic** to add security
        /// </summary>
        public Demograpic()
        {
            InitializeComponent();
        }

        /// <summary>
        /// **Demograpic** class used to create the window for demographic data
        /// </summary>
        /// <param name="fullData"> All the data accumulated for the patient </param>
        public Demograpic(PatientAll fullData)
        {
            InitializeComponent();
            this.DataContext = fullData;//Creates new form for patient if there is no data
        }

    }
}
