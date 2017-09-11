using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.Bussiness.Entities.People
{
    public class Person
    {
        public string Identification { set; get; }

        public string Name { set; get; }

        public string FirstSurname { set; get; }

        public string SecondSurname { set; get; }

        public string Address { set; get; }
    }
}
