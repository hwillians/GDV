namespace MesClasses.Vehicules
{
    public class Voiture : Vehicule
    {
        public int Puissance { get; set; }
        public Voiture(string marque, string modele, int numero, int puissance) : base(marque, modele, numero)
        {
            Puissance = puissance;
        }
        public override string ToString() => base.ToString() + $"puissance : {Puissance}";
    }
}
