using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hadware_Bestandsverwaltung.Interface
{
    public interface IGeraet
    {
        public int Id { get; init; }
        public string Marke { get; set; }
        public string Modell { get; set; }
       

        public void AnzeigenDetails();

        public enum Status
        {
         Aktiv,
         Inaktiv,
         Defekt,
         Bestand

        }
    }
}
