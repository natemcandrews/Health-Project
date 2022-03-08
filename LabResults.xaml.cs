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
    public partial class LabResults : Page
    {
        /// <summary>
        /// Empty constructor for **LabResults** to add security
        /// </summary>
        public LabResults()
        {
            InitializeComponent();
        }

        /// <summary>
        /// **LabResults** class used to create the window for demographic data
        /// </summary>
        /// <param name="fullData"> All the data accumulated for the patient </param>
        public LabResults(PatientAll fullData)
        {
            InitializeComponent();
            this.DataContext = fullData;//Creates new form for patient if there is no data
        }
    }
}
