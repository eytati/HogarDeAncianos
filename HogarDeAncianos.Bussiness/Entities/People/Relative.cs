using HogarDeAncianos.Bussiness.Entities.People;
using HogarDeAncianos.ParametersObjects.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.Bussiness.Entities.Records
{
    public class Relative: Person 
    {
        public Relative(RelativeParameter parameter)
        {
            this.Address = parameter.Address;
            this.Email = parameter.Email;
            this.Name = parameter.Name;
            this.FirstSurname = parameter.FirstSurname;
            this.SecondSurname = parameter.SecondSurname;
            this.Identification = parameter.Identification;
            this.Phone = parameter.Phone;
            this.Related = parameter.Related;
            this.OlderAdultId = parameter.OlderAdultId;
        }

        public Relative() { }

        public string Related { set; get; }

        public string Phone { set; get; }

        public string OlderAdultId { get; set; }

        public string Email { get; set; }
    }
}
