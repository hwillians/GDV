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

        public static Vehicule LireVehicule(List<Vehicule> vehicules)
        {
            if (vehicules.Count == 0) WriteLine("Il y a  pas encore des vehicules enregistrés");
            else
            {
                foreach (Vehicule v in vehicules) WriteLine(v);

                var numero = GetInt("Tapez le numéro de vehicule : ");
                var vehicule = vehicules.Any(Test(numero)) ? vehicules.First(Test(numero)) : null;

                WriteLine(vehicules.Any(Test(numero)) ? vehicule : "Ce numéro n'est pas registré");
                return vehicule;
            }
            return null;
        }

        public static void ModifierVehicule(List<Vehicule> vehicules)
        {
            Vehicule vehicule = LireVehicule(vehicules);
            if (vehicule != null)
            {
                string modification = "";
                bool uneVoiture = vehicule.GetType().Name == "Voiture";

                while (modification != "ma" && modification != "mo" && modification != "n" && modification != "p" && modification != "t")
                    modification = GetString($"Quelle donnée voulez vous changer ? \n " +
                        $"marque  : ma, modèle : mo, numéro : n, {(uneVoiture ? "puissance" : "poids")} : p, pour tout chager : t");

                switch (modification)
                {
                    case "ma": vehicule.Marque = GetString("Marque : "); break;
                    case "mo": vehicule.Modele = GetString("Modèle : "); break;
                    case "n": vehicule.Numero = GetInt("Numéro : "); break;
                    case "p":
                        {
                            if (uneVoiture) (vehicule as Voiture).Puissance = GetInt("Puissance : ");
                            else (vehicule as Camion).Poids = GetInt("Poids : ");
                        };
                        break;
                    case "t":
                        {
                            vehicule.Marque = GetString("Marque : ");
                            vehicule.Modele = GetString("Modèle : ");
                            vehicule.Numero = GetInt("Numéro : ");
                            if (uneVoiture) (vehicule as Voiture).Puissance = GetInt("Puissance : ");
                            else (vehicule as Camion).Poids = GetInt("Poids : ");
                        }; break;
                    default: break;
                }
            }
        }
    }
}
