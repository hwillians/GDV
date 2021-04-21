using MesClasses.Vehicules;
using System;
using System.Collections.Generic;
using static MesClasses.Autres.Outils;
using MesClasses.GestionFichiers;
using static MesClasses.GestionVehicules.VehiculeCRUD;

namespace MesClasses
{
    public class Menu
    {
        public static void Selection()
        {
            int? choix = null;
            var vehicules = Fichier.Lire();

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
                    case 1:
                        try
                        {
                            vehicules.Add(CreerVehicule());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 2: LireVehicule(vehicules); break;
                    case 3:
                        try
                        {
                            ModifierVehicule(vehicules);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 4: SupprimerVehicule(vehicules); break;
                    case 5: TrierVehicules(vehicules); break;
                    case 6: FiltrerVehicules(vehicules); break;
                    case 7: Fichier.Ecrire(vehicules); break;
                    case 0:
                        {
                            var confirmation = "";
                            while (confirmation != "o" && confirmation != "n")
                                confirmation = GetString("Voulez vous enregistrer avant sortit ? (o/n) : ").ToLower();

                            if (confirmation == "o") Fichier.Ecrire(vehicules);
                            Console.WriteLine("à bientôt...");
                        }
                        break;
                    default: Console.WriteLine("Action pas recunnue"); break;
                }
                Console.WriteLine();
            }
        }
    }
}
