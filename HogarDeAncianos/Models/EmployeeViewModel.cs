using HogarDeAncianos.ParametersObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HogarDeAncianos.Models
{
    public class EmployeeViewModel : EmployeeParameter
    {
        [Required]
        [Display(Name = "Nombre")]
        public override string Name { get; set; }

        [Required]
        [Display(Name = "Apellidos")]
        public override string LastName { get; set; }

        [Required]
        [Display(Name = "Cedula")]
        public override string Identification { get; set; }

        [Required]
        [Display(Name = "Telefono")]
        public override string Phone { get; set; }

        [Required]
        [Display(Name = "Correo Electronico")]
        public override string Email { get; set; }

        [Required]
        [Display(Name = "Fecha de Ingreso")]
        public override DateTime EntryDate { get; set; }

        [Required]
        [Display(Name = "Puesto Actual")]
        public override string Occupation { get; set; }

        [Required]
        [Display(Name = "Estado Actual")]
        public override bool State { get; set; }
    }
}