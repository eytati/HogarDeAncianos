using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.ParametersObjects.Records
{
    public abstract class PsychologicalParameter
    {
        public abstract string Identification { get; set; }
        public abstract string MentalTest { get; set; }
        public abstract string PersonalHistory { get; set; }
        public abstract string Monitoring { get; set; }
        public abstract string PsychologicalTest { get; set; }
        public abstract string Observations { get; set; }
        public abstract string CreatedByUser { get; set; }
        public abstract string EditedByUser { get; set; }
        public abstract DateTime CreationTime { get; set; }
        public abstract DateTime EditionTime { get; set; }
    }
}
