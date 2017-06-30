using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.Bussiness.Entities
{
    public class Employee
    {
        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Identification { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime EntryDate { get; set; }

        public string Occupation { get; set; }

        public bool State { get; set; }
    }
}
