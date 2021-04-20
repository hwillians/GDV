namespace MesClasses.Vehicules
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
