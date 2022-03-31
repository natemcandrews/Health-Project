using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarSolution
{
    public class PatientAll
    {

        private bool hipaaValue;
        public bool HIPPA
        {
            get { return hipaaValue; }
            set { hipaaValue = value; }
        }

        private string emergnameValue;
        public string EmergencyName //Emergency contact name
        {
            get { return emergnameValue; }
            set { emergnameValue = value; }
        }

        private string emergnumValue;
        public string EmergencyNumber //Emergency contact number
        {
            get { return emergnumValue; }
            set { emergnumValue = value; }
        }

        private string companyValue;
        public string Company //Insurance company
        {
            get { return companyValue; }
            set { companyValue = value; }
        }

        private string numberValue;
        public string Number //Insurance number
        {
            get { return numberValue; }
            set { numberValue = value; }
        }

        private string groupValue;
        public string Group //Insurance group number
        {
            get { return groupValue; }
            set { groupValue = value; }
        }

        private string immuneValue;
        public string Immunity
        {
            get { return immuneValue; }
            set { immuneValue = value; }
        }

        private string appValue;
        public string Appointment
        {
            get { return appValue; }
            set { appValue = value; }
        }


        private string occValue;
        public string Occupation
        {
            get { return occValue; }
            set { occValue = value; }
        }


        private string reasonValue;
        public string VisitReason
        {
            get { return reasonValue; }
            set { reasonValue = value; }
        }


        private string medValue;
        public string Medication
        {
            get { return medValue; }
            set { medValue = value; }
        }


        private string allergyValue;
        public string Allergy
        {
            get { return allergyValue; }
            set { allergyValue = value; }
        }


        private string symptomValue;
        public string Symptom
        {
            get { return symptomValue; }
            set { symptomValue = value; }
        }


        private string prevValue;
        public string PreviousVisit
        {
            get { return prevValue; }
            set { prevValue = value; }
        }


        private string histValue;
        public string History
        {
            get { return histValue; }
            set { histValue = value; }
        }


        private string transfuseValue;
        public string Transfusion
        {
            get { return transfuseValue; }
            set { transfuseValue = value; }
        }


        private string concernValue;
        public string WorkConcerns
        {
            get { return concernValue; }
            set { concernValue = value; }
        }


        private string habitValue;
        public string Habits
        {
            get { return habitValue; }
            set { habitValue = value; }
        }


        private string pregValue;
        public string Pregnancy
        {
            get { return pregValue; }
            set { pregValue = value; }
        }

        private string nameValue;
        public string Name
        {
            get { return nameValue; }
            set { nameValue = value; }
        }

        private string dobValue;
        public string DOB
        {
            get { return dobValue; }
            set { dobValue = value; }
        }

        private string ageValue;
        public string Age
        {
            get { return ageValue; }
            set { ageValue = value; }
        }

        private string tempValue;
        public string Temp
        {
            get { return tempValue; }
            set { tempValue = value; }
        }

        private string pulseValue;
        public string Pulse
        {
            get { return pulseValue; }
            set { pulseValue = value; }
        }

        private string respValue;
        public string Respirations
        {
            get { return respValue; }
            set { respValue = value; }
        }

        private string bpValue;
        public string BP
        {
            get { return bpValue; }
            set { bpValue = value; }
        }

        private string pulseoxValue;
        public string PulseOx
        {
            get { return pulseoxValue; }
            set { pulseoxValue = value; }
        }

        private string heightValue;
        public string Height
        {
            get { return heightValue; }
            set { heightValue = value; }
        }

        private string weightValue;
        public string Weight
        {
            get { return weightValue; }
            set { weightValue = value; }
        }

        private string docValue;
        public string Doc
        {
            get { return docValue; }
            set { docValue = value; }
        }

        private string dateValue;

        public string Date
        {
            get { return dateValue; }
            set { dateValue = value; }
        }

        private string timeValue;
        public string Time
        {
            get { return timeValue; }
            set { timeValue = value; }
        }

        private string colorValue;
        public string UrineColor
        {
            get { return colorValue; }
            set { colorValue = value; }
        }

        private string urinetempValue;
        public string UrineTemp
        {
            get { return urinetempValue; }
            set { urinetempValue = value; }
        }

        private string phValue;
        public string PH
        {
            get { return phValue; }
            set { phValue = value; }
        }

        private string glucoseValue;
        public string Glucose
        {
            get { return glucoseValue; }
            set { glucoseValue = value; }
        }

        private string bloodValue;
        public string BloodPresence
        {
            get { return bloodValue; }
            set { bloodValue = value; }
        }

        private string proteinValue;
        public string Protein
        {
            get { return proteinValue; }
            set { proteinValue = value; }
        }

        private string leukocyteValue;
        public string Leukocytes
        {
            get { return leukocyteValue; }
            set { leukocyteValue = value; }
        }

        private string testTimeValue;
        public string UrineTime
        {
            get { return testTimeValue; }
            set { testTimeValue = value; }
        }

        private string testDateValue;
        public string UrineDate
        {
            get { return testDateValue; }
            set { testDateValue = value; }
        }

        private string cbcValue;
        public string CBC
        {
            get { return cbcValue; }
            set { cbcValue = value; }
        }

        private string wbcValue;
        public string WBC
        {
            get { return wbcValue; }
            set { wbcValue = value; }
        }

        private string rbcValue;
        public string RBC
        {
            get { return rbcValue; }
            set { rbcValue = value; }
        }

        private string labTimeValue;
        public string LabTime
        {
            get { return labTimeValue; }
            set { labTimeValue = value; }
        }

        private string ptValue;
        public string PTT
        {
            get { return ptValue; }
            set { ptValue = value; }
        }

        private string hemoValue;
        public string Hemoglobin
        {
            get { return hemoValue; }
            set { hemoValue = value; }
        }

        private string hemaValue;
        public string Hematocrit
        {
            get { return hemaValue; }
            set { hemaValue = value; }
        }

        private string labDateValue;
        public string LabDate
        {
            get { return labDateValue; }
            set { labDateValue = value; }
        }

        private string plateletValue;
        public string Platelets
        {
            get { return plateletValue; }
            set { plateletValue = value; }
        }

        private string a1cValue;
        public string A1C
        {
            get { return a1cValue; }
            set { a1cValue = value; }
        }


        private string[] FullTimevalue = DateTime.Now.ToString().Split(' ');
        private string currentTimeValue;
        private string currentDateValue;

        public string CurrentDate
        {
            get { return "Current Date: " + FullTimevalue[0]; }
            set { currentDateValue = value; }
        }

        public string CurrentTime
        {
            get { return "Current Time: " + FullTimevalue[1]; }
            set { currentTimeValue = value; }
        }

        public string Phone { get; set;}
        public string Address { get; set; }

        public List<List<string>> PatientNotes = new List<List<string>>();
    }
}
