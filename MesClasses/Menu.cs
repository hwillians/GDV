using MesClasses.Vehicules;
using System;
using System.Collections.Generic;
using static MesClasses.Autres.Outils;
using static MesClasses.GestionVehicules.VehiculeCRUD;

namespace MesClasses
{
    public class Menu
    {
        public static void Selection()
        {
            int? choix = null;
            var vehicules = new List<Vehicule>() {
                new Voiture("Seat", "leon", 1000, 150),
                new Voiture("Renault", "megane", 1001,130),
                new Voiture("Citroën", "c3", 1005, 140),
                new Camion("Volkswagen","Transporter",1004,3000),
                new Camion("Reanult","Truck",1002,3500),
                new Camion("Iveco","Eurocargo",1003,1500)};

            Console.WriteLine($"*.*.*.*.* Menu Gestion de vehicules *.*.*.*.*");
            while (choix != 0)
            {
                choix = GetInt($"Choisissez une action :\n" +
                   $"1._ Créer un véhicule\n" +
                   $"2._ Voir un véhicule\n" +
                   $"3._ Mettre à jour un véhicule\n" +
                   $"4._ Supprimer un véhicule\n" +
                   $"5._ Trier les véhicules\n" +
                   $"6._ Filtrer les véhicules\n" +
                   $"7._ Sauvegarder les véhicules\n" +
                   $"0._ Sortir\n");

                switch (choix)
                {
                    case 1: vehicules.Add(CreerVehicule()); break;
                    case 2: LireVehicule(vehicules); break;
                    case 3: ModifierVehicule(vehicules); break;
                    case 4: SupprimerVehicule(vehicules); break;
                    case 5: TrierVehicules(vehicules); break;
                    case 6: FiltrerVehicules(vehicules); break;
                    case 7: Console.WriteLine("Cette action n'est pas encore disponible"); break;
                    case 0: Console.WriteLine("à bientôt..."); break;
                    default: Console.WriteLine("Action pas recunnue"); break;
                }
                Console.WriteLine();
            }
        }
    }
}
