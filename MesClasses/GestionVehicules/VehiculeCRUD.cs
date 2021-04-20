using MesClasses.Vehicules;
using System;
using static MesClasses.Autres.Outils;

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

            Console.WriteLine($"Un{e} {vehicule.GetType().Name.ToLower()} viens d'être crée \n{vehicule}");
            return vehicule;
        }
    }
}
