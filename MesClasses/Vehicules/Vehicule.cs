using System;
using System.Linq;
using System.Xml.Serialization;

namespace MesClasses.Vehicules
{
    [XmlInclude(typeof(Voiture)), XmlInclude(typeof(Camion))]
    public abstract class Vehicule
    {
        private string marque;
        private string modele;
        private int numero;

        public string Marque
        {
            get => marque;
            set
            {
                if (!value.Any(x => char.IsDigit(x))) marque = value.ToUpper();
                else throw new Exception("La marque ne peut pas comporter de chiffre");
            }
        }
        public string Modele
        {
            get => modele;
            set => modele = value.ToUpper();
        }
        public int Numero
        {
            get => numero;
            set
            {
                if (value >= 1000 && value <= 999999) numero = value;
                else throw new Exception("La longueur du numéro doit être comprise entre 4 et 6");
            }
        }

        public Vehicule() { }

        public Vehicule(string marque, string modele, int numero)
        {
            Marque = marque;
            Modele = modele;
            Numero = numero;
        }
        public override string ToString() => $"Marque : {Marque}, modèle : {Modele}, numéro : {Numero}, ";
    }
}
