using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.ParametersObjects
{
    public abstract class EmployeeParameter
    {
        public abstract string Name { get; set; }

        public abstract string LastName { get; set; }

        public abstract string Identification { get; set; }

        public abstract string Phone { get; set; }

        public abstract string Email { get; set; }

        public abstract DateTime EntryDate { get; set; }

        public abstract string Occupation { get; set; }

        public abstract bool State { get; set; }
    }
}
