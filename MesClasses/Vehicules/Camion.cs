namespace MesClasses.Vehicules
{
    public class Camion : Vehicule
    {
        public int Poids { get; set; }

        public Camion():base()
        {

        }
        public Camion(string marque, string modele, int numero, int poids = 0) : base(marque, modele, numero)
        {
            Poids = poids;
        }
        public override string ToString() => base.ToString() + $"poids : {Poids}";
    }
}
