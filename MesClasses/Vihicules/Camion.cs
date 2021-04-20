using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesClasses.Vihicules
{
    public class Camion : Vehicule
    {
        public int Poids { get; set; }
        public Camion(string marque, string modele, int numero, int poids) : base(marque, modele, numero)
        {
            Poids = poids;
        }
        public override string ToString() => base.ToString() + $"poids : {Poids}";
    }
}
