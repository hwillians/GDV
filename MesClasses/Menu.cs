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

            Console.WriteLine($"*.*.*.*.* Menu Gestion de véhicules *.*.*.*.*");
            while (choix != 0)
            {
                choix = GetInt($"Choisissez une action :\n" +
                   $"1._ Lister tous les véhicules\n" +
                   $"2._ Créer un véhicule\n" +
                   $"3._ Voir un véhicule\n" +
                   $"4._ Mettre à jour un véhicule\n" +
                   $"5._ Supprimer un véhicule\n" +
                   $"6._ Trier les véhicules\n" +
                   $"7._ Filtrer les véhicules\n" +
                   $"8._ Sauvegarder les véhicules\n" +
                   $"0._ Sortir\n");

                switch (choix)
                {
                    case 1:
                        foreach (Vehicule vehicule in vehicules) Console.WriteLine(vehicule); break;
                    case 2:
                        try
                        {
                            vehicules.Add(CreerVehicule());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 3: LireVehicule(vehicules); break;
                    case 4:
                        try
                        {
                            ModifierVehicule(vehicules);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case 5: SupprimerVehicule(vehicules); break;
                    case 6: TrierVehicules(vehicules); break;
                    case 7: FiltrerVehicules(vehicules); break;
                    case 8: Fichier.Ecrire(vehicules); break;
                    case 0:
                        {
                            var confirmation = "";
                            while (confirmation != "o" && confirmation != "n")
                                confirmation = GetString("Voulez-vous enregistrer avant de sortir ? (o/n) : ").ToLower();

                            if (confirmation == "o") Fichier.Ecrire(vehicules);
                            Console.WriteLine("à bientôt...");
                        }
                        break;
                    default: Console.WriteLine("Action pas reconnue"); break;
                }
                Console.WriteLine("------------------");
            }
        }
    }
}
