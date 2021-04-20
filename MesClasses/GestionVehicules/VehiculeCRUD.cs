using MesClasses.Vehicules;
using System;
using System.Collections.Generic;
using System.Linq;
using static MesClasses.Autres.Outils;
using static System.Console;

namespace MesClasses.GestionVehicules
{
    public static class VehiculeCRUD
    {
        public static Vehicule CreerVehicule()
        {
            string typeVehicule = "";

            while (typeVehicule != "v" && typeVehicule != "c")
                typeVehicule = GetString("Tapaz c pour créer un Camion, v pour créer une voiture : ");

            Vehicule vehicule = typeVehicule == "v" ?
                new Voiture(GetString("Marque (sans chiffer) : "), GetString("Modèle : "), GetInt("Numéro : "), GetInt("Puissance : ")) :
                new Camion(GetString("Marque (sans chiffer) : "), GetString("Modèle : "), GetInt("Numéro : "), GetInt("Poids : "));

            var e = typeVehicule == "v" ? "e" : "";

            WriteLine($"Un{e} {vehicule.GetType().Name.ToLower()} viens d'être créé{e} : \n{vehicule}");
            return vehicule;
        }

        static Func<Vehicule, bool> Test(int numero) => v => v.Numero == numero;

        public static void LireVehicule(List<Vehicule> vehicules)
        {
            if (vehicules.Count == 0) WriteLine("Il y a  pas encore des vehicules enregistrés");
            else
            {
                foreach (Vehicule v in vehicules) WriteLine(v);

                var numero = GetInt("Tapez le numéro : ");

                WriteLine(vehicules.Any(Test(numero)) ? vehicules.First(Test(numero)) : "Ce numéro n'est pas registré");
            }
        }
    }
}
