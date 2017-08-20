using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.ParametersObjects
{
    public abstract class ExpNutritionalParameter
    {
        public abstract string Cedula { get; set; }
        public abstract int Edad { get; set; }
        public abstract double CircunferenciaBraquial { get; set; }
        public abstract double CircunferenciaDePantorrilla { get; set; }
        public abstract double AlturaDeRodilla { get; set; }
        public abstract string PesoActual { get; set; }
        public abstract double PesoUsual { get; set; }
        public abstract double PesoEstimado { get; set; }
        public abstract double PesoIdeal { get; set; }
        public abstract double PorcentajeDeCambioDePeso { get; set; }
        public abstract double TallaActual { get; set; }
        public abstract double TallaEstimada { get; set; }
        public abstract double IMC { get; set; }
        public abstract double TMB { get; set; }
        public abstract double FTA { get; set; }
        public abstract double FA { get; set; }
        public abstract double FS { get; set; }
        public abstract double VET { get; set; }
        public abstract string Observaciones { get; set; }
    }
}
