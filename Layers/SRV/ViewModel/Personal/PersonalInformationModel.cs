using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Personal
{
    public class PersonalInformationModel
    {
        //public string IconPath { get; set; }
        public bool? IsMale { get; set; }
        public int BirthYear { get; set; }
        public IList<int> BirthYears { get; set; }
        public int BirthMonth { get; set; }
        public IList<int> BirthMonths { get; set; }
        public int BirthDate { get; set; }
        public IList<int> BirthDates { get; set; }
        public string UpperKeyword { get; set; }
        public IList<string> UpperKeywords { get; set; }
        public string LowerKeyword { get; set; }
        public IList<string> LowerKeywords { get; set; }
        public string PersonalDefineKeyword { get; set; }
        public string PersonalDescription { get; set; }



    }
}
