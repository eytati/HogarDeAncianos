using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.ParametersObjects.People
{
    public abstract class RelativeParameter
    {
        public abstract string Identification { set; get; }

        public abstract string Name { set; get; }

        public abstract string FirstSurname { set; get; }

        public abstract string SecondSurname { set; get; }

        public abstract string Address { set; get; }

        public abstract string Related { set; get; }

        public abstract string Phone { set; get; }

        public abstract string OlderAdultId { get; set; }

        public abstract string Email { get; set; }
    }
}
