using HogarDeAncianos.ParametersObjects.People;
using System.ComponentModel.DataAnnotations;

namespace HogarDeAncianos.Models
{
    public class RelativeViewModel : RelativeParameter
    {
        [Required]
        [Display(Name = "Cedula")]
        public override string Identification { set; get; }

        [Required]
        [Display(Name = "Nombre")]
        public override string Name { set; get; }

        [Required]
        [Display(Name = "Primer Apellido")]
        public override string FirstSurname { set; get; }

        [Required]
        [Display(Name = "Segundo Apellido")]
        public override string SecondSurname { set; get; }

        [Required]
        [Display(Name = "Dirección")]
        public override string Address { set; get; }

        [Required]
        [Display(Name = "Parentesco")]
        public override string Related { set; get; }

        [Required]
        [Display(Name = "Telefono")]
        public override string Phone { set; get; }


        [Required]
        [Display(Name = "Correo electronico")]
        public override string Email { get; set; }

        [Required]
        [Display(Name = "Cedula del Adulto Mayor")]
        public override string OlderAdultId { get; set; }
    }
}