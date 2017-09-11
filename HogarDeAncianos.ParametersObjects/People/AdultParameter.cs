using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.ParametersObjects.People
{
    public abstract class AdultParameter
    {
        public abstract string Identification { set; get; }

        public abstract string Name { set; get; }

        public abstract string FirstSurname { set; get; }

        public abstract string SecondSurname { set; get; }

        public abstract string Address { set; get; }

        public abstract string IdCCSS { get; set; }

        public abstract DateTime BirthDate { get; set; }

        public abstract DateTime EntryDate { get; set; }

        public abstract string Gender { get; set; }

        public abstract bool State { get; set; }

        public abstract int Age { get; set; }

        public abstract string EntryReasons { get; set; }

        public abstract string Occupation { get; set; }

        public abstract string CivilStatus { get; set; }

        public abstract string Biomechamical { get; set; }

        public abstract double Contribution { get; set; }

        public abstract double Pension { get; set; }

        public abstract double Total { get; set; }

        public abstract string CreatedByUser { get; set; }

        public abstract string EditedByUser { get; set; }

        public abstract DateTime CreationTime { get; set;  }

        public abstract DateTime EditionTime { get; set; }
        
    }
}
