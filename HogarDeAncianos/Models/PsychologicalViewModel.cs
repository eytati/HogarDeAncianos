using HogarDeAncianos.ParametersObjects.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HogarDeAncianos.Models
{
    public class PsychologicalViewModel: PsychologicalParameter
    {
 

        [Required]
        [Display(Name = "Cedula")]
        public override string Identification { get; set; }

        [Display(Name = "Examen mental")]
        public override string MentalTest { get; set; }

        [Display(Name = "Historia personal")]
        public override string PersonalHistory { get; set; }

        [Display(Name = "Monitoreo")]
        public override string Monitoring { get; set; }

        [Display(Name = "Examen psicologico")]
        public override string PsychologicalTest { get; set; }

        [Display(Name = "Observacioens")]
        public override string Observations { get; set; }

        [Display(Name = "Creado por")]
        public override string CreatedByUser { get; set; }


        [Display(Name = "Editado por")]
        public override string EditedByUser { get; set; }

        [Display(Name = "Creado el")]
        public override DateTime CreationTime { get; set; }

        [Display(Name = "Editado el")]
        public override DateTime EditionTime { get; set; }
    }
}