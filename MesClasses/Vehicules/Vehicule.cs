namespace MesClasses.Vehicules
{
    public abstract class Vehicule
    {
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int Numero { get; set; }

        public Vehicule(string marque, string modele, int numero)
        {
            Marque = marque;
            Modele = modele;
            Numero = numero;
        }
        public override string ToString() => $"Marque : {Marque}, modèle : {Modele}, numéro : {Numero}, ";
    }
}
