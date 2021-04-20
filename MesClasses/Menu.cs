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
            var vehicules = new List<Vehicule>();
            while (choix != 0)
            {
                choix = GetInt($"Menu Gestion de vehicules :\n" +
                   $"Choisissez une action :\n" +
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
                    case 3: Console.WriteLine("Cette action n'est pas encore disponible"); break;
                    case 4: Console.WriteLine("Cette action n'est pas encore disponible"); break;
                    case 5: Console.WriteLine("Cette action n'est pas encore disponible"); break;
                    case 6: Console.WriteLine("Cette action n'est pas encore disponible"); break;
                    case 7: Console.WriteLine("Cette action n'est pas encore disponible"); break;
                    case 0: Console.WriteLine("à bientôt..."); break;
                    default: Console.WriteLine("Action pas recunnue"); break;
                }
                foreach (var item in vehicules) Console.WriteLine(item);
            }
        }
    }
}
