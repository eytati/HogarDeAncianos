using HogarDeAncianos.ParametersObjects.Records;
using System;

namespace HogarDeAncianos.Bussiness.Entities.Records
{
    public class Psychological
    {
        public Psychological() { }

        public Psychological(PsychologicalParameter parameter)
        {
            this.CreatedByUser = parameter.CreatedByUser;
            this.EditedByUser = parameter.EditedByUser;
            this.Identification = parameter.Identification;
            this.MentalTest = parameter.MentalTest;
            this.Monitoring = parameter.Monitoring;
            this.Observations = parameter.Observations;
            this.PersonalHistory = parameter.PersonalHistory;
            this.PsychologicalTest = parameter.PsychologicalTest;
        }

        public Guid Id { get => Guid.NewGuid(); set { } }
        public string Identification { get; set; }
        public string MentalTest { get; set; }
        public string PersonalHistory { get; set; }
        public string Monitoring { get; set; }
        public string PsychologicalTest { get; set; }
        public string Observations { get; set; }
        public string CreatedByUser { get; set; }
        public string EditedByUser { get; set; }
        public DateTime CreationTime { get => DateTime.Now; set { } }
        public DateTime EditionTime { get => DateTime.Now; set { } }

    }
}
