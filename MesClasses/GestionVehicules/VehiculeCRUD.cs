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

        private static bool UneVoiture(Vehicule vehicule) => vehicule.GetType().Name == "Voiture";

        static Func<Vehicule, bool> Test(int numero) => v => v.Numero == numero;

        public static Vehicule CreerVehicule()
        {
            string typeVehicule = "";

            while (typeVehicule != "v" && typeVehicule != "c")
                typeVehicule = GetString("Tapaz c pour créer un Camion, v pour créer une voiture : ");

            Vehicule vehicule = typeVehicule == "v" ?
                new Voiture(GetString("Marque (sans chiffer) : "), GetString("Modèle : "), GetInt("Numéro : "), GetInt("Puissance : ")) :
                new Camion(GetString("Marque (sans chiffer) : "), GetString("Modèle : "), GetInt("Numéro : "), GetInt("Poids : "));

            WriteLine(String.Format("Un{0} {1} viens d'être créé{0} : \n{2}",
                UneVoiture(vehicule) ? "e" : "", vehicule.GetType().Name.ToLower(), vehicule));
            return vehicule;
        }

        public static Vehicule LireVehicule(List<Vehicule> vehicules)
        {
            if (vehicules.Count == 0) WriteLine("Il y a pas des vehicules enregistrés");
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

                while (modification != "ma" && modification != "mo" && modification != "n" && modification != "p" && modification != "t")
                    modification = GetString($"Quelle donnée voulez vous changer ? \n " +
                        $"marque  : ma, modèle : mo, numéro : n, {(UneVoiture(vehicule) ? "puissance" : "poids")} : p, pour tout chager : t");

                switch (modification)
                {
                    case "ma": vehicule.Marque = GetString("Marque : "); break;
                    case "mo": vehicule.Modele = GetString("Modèle : "); break;
                    case "n": vehicule.Numero = GetInt("Numéro : "); break;
                    case "p":
                        {
                            if (UneVoiture(vehicule)) (vehicule as Voiture).Puissance = GetInt("Puissance : ");
                            else (vehicule as Camion).Poids = GetInt("Poids : ");
                        };
                        break;
                    case "t":
                        {
                            vehicule.Marque = GetString("Marque : ");
                            vehicule.Modele = GetString("Modèle : ");
                            vehicule.Numero = GetInt("Numéro : ");
                            if (UneVoiture(vehicule)) (vehicule as Voiture).Puissance = GetInt("Puissance : ");
                            else (vehicule as Camion).Poids = GetInt("Poids : ");
                        }; break;
                    default: break;
                }
            }
        }

        public static void SupprimerVehicule(List<Vehicule> vehicules)
        {
            Vehicule vehicule = LireVehicule(vehicules);
            if (vehicule != null)
            {
                vehicules.Remove(vehicule);
                WriteLine("Le vehicule a été supprimé");
            }
        }

        public static void TrierVehicules(List<Vehicule> vehicules)
        {
            string tri = "";

            while (tri != "ma" && tri != "mo" && tri != "nu" && tri != "po" && tri != "pu")
                tri = GetString($"Sur quel critère voulez vous faire le tri ? \n " +
                    $"marque : ma, modèle : mo, numéro : nu,  puissance : pu, poids : ");

            switch (tri)
            {
                case "ma":
                    WriteLine(String.Join("\n", vehicules.OrderBy(v => v.Marque))); break;
                case "mo":
                    WriteLine(String.Join("\n", vehicules.OrderBy(v => v.Modele))); break;
                case "nu":
                    WriteLine(String.Join("\n", vehicules.OrderBy(v => v.Numero))); break;
                case "po":
                    WriteLine(String.Join("\n", vehicules.Where(v => !UneVoiture(v)).OrderBy(v => (v as Camion).Poids))); break;
                case "pu":
                    WriteLine(String.Join("\n", vehicules.Where(v => UneVoiture(v)).OrderBy(v => (v as Voiture).Puissance))); break;
                default: break;
            }
        }

        public static void FiltrerVehicules(List<Vehicule> vehicules)
        {
            string filtre = "";

            while (filtre != "ma" && filtre != "mo" && filtre != "nu" && filtre != "po" && filtre != "pu")
            {
                filtre = GetString($"Sur quel critère voulez vous filtrer ? \n " +
                     $"marque : ma, modèle : mo, numéro : nu,  puissance : pu, poids : ");
            }

            switch (filtre)
            {
                case "ma":
                    {
                        var marque = GetString("Marque : ").ToLower();
                        AfficherVehiculesFiltres(vehicules.Where(v => v.Marque.ToLower().StartsWith(marque)));
                    }
                    break;
                case "mo":
                    {
                        var modele = GetString("Modèle : ").ToLower();
                        AfficherVehiculesFiltres(vehicules.Where(v => v.Modele.ToLower().StartsWith(modele)));
                    }
                    break;
                case "nu":
                    {
                        var numero = GetInt("Numèro : ");
                        AfficherVehiculesFiltres(vehicules.Where(v => v.Numero == numero));
                    }
                    break;
                case "po":
                    {
                        var poids = GetInt("Poids : ");
                        AfficherVehiculesFiltres(vehicules.Where(v => !UneVoiture(v)).Where(v => (v as Camion).Poids == poids)); break;
                    }
                case "pu":
                    {
                        var puissance = GetInt("Puissance : ");
                        AfficherVehiculesFiltres(vehicules.Where(v => UneVoiture(v)).Where(v => (v as Voiture).Puissance == puissance)); break;
                    }
                default: break;
            }
            static void AfficherVehiculesFiltres(IEnumerable<Vehicule> vehiculesFiltres) =>
                WriteLine(!vehiculesFiltres.Any() ? "Aucun vehicule corresponde à votre recherche." : String.Join("\n", vehiculesFiltres));
        }
    }
}
