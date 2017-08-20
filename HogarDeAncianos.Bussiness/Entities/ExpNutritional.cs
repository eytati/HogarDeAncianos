using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HogarDeAncianos.Bussiness.Entities
{
    public class ExpNutritional
    { 
        public string Cedula { get; set; }
        public int Edad { get; set; }
        public double CircunferenciaBraquial { get; set; }
        public double CircunferenciaDePantorrilla { get; set; }
        public double AlturaDeRodilla { get; set; }
        public string PesoActual { get; set; }
        public double PesoUsual { get; set; }
        public double PesoEstimado { get; set; }
        public double PesoIdeal { get; set; }
        public double PorcentajeDeCambioDePeso { get; set; }
        public double TallaActual { get; set; }
        public double TallaEstimada { get; set; }
        public double IMC { get; set; }
        public double TMB { get; set; }
        public double FTA { get; set; }
        public double FA { get; set; }
        public double FS { get; set; }
        public double VET { get; set; }
        public string Observaciones { get; set; }
    }
}
