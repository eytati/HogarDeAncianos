using HogarDeAncianos.Bussiness.Entities.People;
using HogarDeAncianos.ParametersObjects.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.Bussiness.Entities
{
    public class Adult : Person 
    {
        public Adult(AdultParameter parameter)
        {
            this.Address = parameter.Address;
            this.Age = parameter.Age;
            this.Biomechamical = parameter.Biomechamical;
            this.BirthDate = parameter.BirthDate;
            this.CivilStatus = parameter.CivilStatus;
            this.Contribution = parameter.Contribution;
            this.CreatedByUser = parameter.CreatedByUser;
            this.CreationTime = parameter.CreationTime;
            this.EditedByUser = parameter.EditedByUser;
            this.EditionTime = parameter.EditionTime;
            this.EntryDate = parameter.EntryDate;
            this.EntryReasons = parameter.EntryReasons;
            this.FirstSurname = parameter.FirstSurname;
            this.Gender = parameter.Gender;
            this.IdCCSS = parameter.IdCCSS;
            this.Identification = parameter.Identification;
            this.Name = parameter.Name;
            this.Occupation = parameter.Occupation;
            this.Pension = parameter.Pension;
            this.SecondSurname = parameter.SecondSurname;
            this.State = parameter.State;
            this.Total = parameter.Total;
        }

        public Adult() { }

        public string IdCCSS { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime EntryDate { get; set; }

        public string Gender { get; set; }

        public bool State { get; set; }
        public int Age { get; set; }

        public string EntryReasons { get; set; }

        public string Occupation { get; set; }

        public string CivilStatus { get; set; }

        public string Biomechamical { get; set; }

        public double Contribution { get; set; }

        public double Pension { get; set; }

        public double Total { get; set; }
    
        public string CreatedByUser { get; set; }

        public string EditedByUser { get; set; }

        public DateTime CreationTime { get => DateTime.Now; set { } }

        public DateTime EditionTime { get => DateTime.Now; set { } }
      
    }
}
