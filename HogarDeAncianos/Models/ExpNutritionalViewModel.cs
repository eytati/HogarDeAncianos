using HogarDeAncianos.ParametersObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HogarDeAncianos.Models
{
    public class ExpNutritionalViewModel : ExpNutritionalParameter
    {
        [Required]
        [Display(Name = "Cedula")]
        public override string Cedula { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public override int Edad { get; set; }

        [Required]
        [Display(Name = "Circunferencia braquial")]
        public override double CircunferenciaBraquial { get; set; }

        [Required]
        [Display(Name = "Circunferencia de pantorrilla")]
        public override double CircunferenciaDePantorrilla { get; set; }

        [Required]
        [Display(Name = "Altura de rodilla")]
        public override double AlturaDeRodilla { get; set; }

        [Required]
        [Display(Name = "Peso actual")]
        public override string PesoActual { get; set; }

        [Required]
        [Display(Name = "Peso usual")]
        public override double PesoUsual { get; set; }

        [Required]
        [Display(Name = "Peso estimado")]
        public override double PesoEstimado { get; set; }

        [Required]
        [Display(Name = "Peso ideal")]
        public override double PesoIdeal { get; set; }

        [Required]
        [Display(Name = "Porcentaje de cambio de peso")]
        public override double PorcentajeDeCambioDePeso { get; set; }

        [Required]
        [Display(Name = "Talla actual")]
        public override double TallaActual { get; set; }

        [Required]
        [Display(Name = "Talla estimada")]
        public override double TallaEstimada { get; set; }

        [Required]
        [Display(Name = "IMC")]
        public override double IMC { get; set; }
        
        [Required]
        [Display(Name = "TBM")]
        public override double TMB { get; set; }

        [Required]
        [Display(Name = "FTA")]
        public override double FTA { get; set; }

        [Required]
        [Display(Name = "FA")]
        public override double FA { get; set; }

        [Required]
        [Display(Name = "FS")]
        public override double FS { get; set; }

        [Required]
        [Display(Name = "VET")]
        public override double VET { get; set; }

        [Required]
        [Display(Name = "Observaciones")]
        public override string Observaciones { get; set; }
    }
}