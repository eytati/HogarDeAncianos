using HogarDeAncianos.ParametersObjects.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HogarDeAncianos.Models
{
    public class AdultViewModel : AdultParameter 
    {
        public override string Identification { set; get; }

        public override string Name { set; get; }

        public override string FirstSurname { set; get; }

        public override string SecondSurname { set; get; }

        public override string Address { set; get; }

        public override string IdCCSS { get; set; }

        public override DateTime BirthDate { get; set; }

        public override DateTime EntryDate { get; set; }

        public override string Gender { get; set; }

        public override bool State { get; set; }

        public override int Age { get; set; }

        public override string EntryReasons { get; set; }

        public override string Occupation { get; set; }

        public override string CivilStatus { get; set; }

        public override string Biomechamical { get; set; }

        public override double Contribution { get; set; }

        public override double Pension { get; set; }

        public override double Total { get; set; }

        public override string CreatedByUser { get; set; }

        public override string EditedByUser { get; set; }

        public override DateTime CreationTime { get; set; }

        public override DateTime EditionTime { get; set; }

    }
}