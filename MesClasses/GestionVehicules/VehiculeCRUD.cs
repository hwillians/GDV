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
                typeVehicule = GetString("Tapez c pour créer un camion, v pour créer une voiture : ");

            var marque = GetString("Marque (sans chiffres) : ");
            var modele = GetString("Modèle : ");
            var numero = GetInt("Numéro : ");
            var poidsOrPuissance = GetInt(typeVehicule == "v" ? "Puissance : " : "Poids : ");

            Vehicule vehicule = typeVehicule == "v" ?
                new Voiture(marque, modele, numero, poidsOrPuissance) :
                new Camion(marque, modele, numero, poidsOrPuissance);

            WriteLine(String.Format("Un{0} {1} viens d'être créé{0} : \n{2}",
                vehicule is Voiture ? "e" : "", vehicule.GetType().Name.ToLower(), vehicule));

            return vehicule;
        }

        public static Vehicule LireVehicule(List<Vehicule> vehicules)
        {
            if (!vehicules.Any())
                WriteLine("Il n'y a pas des véhicules enregistrés");
            else
            {
                foreach (Vehicule v in vehicules) WriteLine(v);

                var numero = GetInt("Tapez le numéro de véhicule : ");
                var vehicule = vehicules.Any(Test(numero)) ? vehicules.First(Test(numero)) : null;

                WriteLine(vehicules.Any(Test(numero)) ? vehicule : "Ce numéro n'est pas registré");
                return vehicule;
            }
            return null;
        }
        static Func<Vehicule, bool> Test(int numero) => v => v.Numero == numero;

        public static void ModifierVehicule(List<Vehicule> vehicules)
        {
            Vehicule vehicule = LireVehicule(vehicules);
            if (vehicule != null)
            {
                string modification = "";

                while (modification != "ma" && modification != "mo" && modification != "n" && modification != "p" && modification != "t")
                    modification = GetString($"Quelle donnée voulez-vous changer ? \n " +
                        $"marque (ma), modèle (mo), numéro (n), {(vehicule is Voiture ? "puissance" : "poids")} (p), pour tout chager (t) : ");

                switch (modification)
                {
                    case "ma":
                        vehicule.Marque = GetString("Marque  (sans chiffres) :  "); break;
                    case "mo":
                        vehicule.Modele = GetString("Modèle : "); break;
                    case "n":
                        vehicule.Numero = GetInt("Numéro : "); break;
                    case "p":
                        {
                            if (vehicule is Voiture) (vehicule as Voiture).Puissance = GetInt("Puissance : ");
                            else (vehicule as Camion).Poids = GetInt("Poids : ");
                        }; break;
                    case "t":
                        {
                            vehicule.Marque = GetString("Marque  (sans chiffres) : ");
                            vehicule.Modele = GetString("Modèle : ");
                            vehicule.Numero = GetInt("Numéro : ");
                            if (vehicule is Voiture)
                                (vehicule as Voiture).Puissance = GetInt("Puissance : ");
                            else
                                (vehicule as Camion).Poids = GetInt("Poids : ");
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
                tri = GetString($"Sur quel critère voulez-vous faire le tri ? \n " +
                    $"marque (ma), modèle (mo), numéro (nu), puissance (pu), poids (po) : ");

            switch (tri)
            {
                case "ma":
                    WriteLine(String.Join("\n", vehicules.OrderBy(v => v.Marque))); break;
                case "mo":
                    WriteLine(String.Join("\n", vehicules.OrderBy(v => v.Modele))); break;
                case "nu":
                    WriteLine(String.Join("\n", vehicules.OrderBy(v => v.Numero))); break;
                case "po":
                    WriteLine(String.Join("\n", vehicules.Where(v => v is Camion).OrderBy(v => (v as Camion).Poids))); break;
                case "pu":
                    WriteLine(String.Join("\n", vehicules.Where(v => v is Voiture).OrderBy(v => (v as Voiture).Puissance))); break;
                default: break;
            }
        }

        public static void FiltrerVehicules(List<Vehicule> vehicules)
        {
            string filtre = "";

            while (filtre != "ma" && filtre != "mo" && filtre != "nu" && filtre != "po" && filtre != "pu")
                filtre = GetString($"Sur quel critère voulez vous filtrer ? \n" +
                    $"marque : ma, modèle : mo, numéro : nu,  puissance : pu, poids : ");

            switch (filtre)
            {
                case "ma":
                    var marque = GetString("Marque : ").ToUpper();
                    AfficherVehiculesFiltres(vehicules.Where(v => v.Marque.StartsWith(marque)));
                    break;
                case "mo":
                    var modele = GetString("Modèle : ").ToUpper();
                    AfficherVehiculesFiltres(vehicules.Where(v => v.Modele.StartsWith(modele)));
                    break;
                case "nu":
                    var numero = GetInt("Numèro : ");
                    AfficherVehiculesFiltres(vehicules.Where(v => v.Numero == numero));
                    break;
                case "po":
                    var poids = GetInt("Poids : ");
                    AfficherVehiculesFiltres(vehicules.Where(v => v is Camion).Where(v => (v as Camion).Poids == poids));
                    break;
                case "pu":
                    var puissance = GetInt("Puissance : ");
                    AfficherVehiculesFiltres(vehicules.Where(v => v is Voiture).Where(v => (v as Voiture).Puissance == puissance));
                    break;
                default: break;
            }
        }
        static void AfficherVehiculesFiltres(IEnumerable<Vehicule> vehiculesFiltres) =>
            WriteLine(vehiculesFiltres.Any() ? String.Join("\n", vehiculesFiltres) : "Aucun vehicule corresponde à votre recherche.");
    }
}
