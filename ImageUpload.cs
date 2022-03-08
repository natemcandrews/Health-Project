using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSolution
{
    public class ImageUpload //A class used for formatting and storing an image description
    {
        private string titleValue;
        public string Title
        {
            get { return titleValue; }
            set { titleValue = value; }
        }

        private string descriptionValue;
        public string Description
        {
            get { return descriptionValue; }
            set { descriptionValue = value; }
        }
    }
}
