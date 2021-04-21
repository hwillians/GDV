using MesClasses.Vehicules;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MesClasses.GestionFichiers
{
    public static class Fichiers
    {
        public static void Ecrire(List<Vehicule> vehicules)
        {
            using var stream = new FileStream("vehicules.xml", FileMode.OpenOrCreate, FileAccess.Write);
            var xmlSerializer = new XmlSerializer(typeof(List<Vehicule>));
            xmlSerializer.Serialize(stream, vehicules);
        }
        public static List<Vehicule> Lire()
        {
            if (!File.Exists("vehicules.xml"))
            {
                var voitures = new List<Vehicule>() {
                    new Voiture("Seat", "leon", 1000, 150),
                    new Voiture("Renault", "megane", 1001,130),
                    new Voiture("Citroën", "c3", 1005, 140),
                    new Camion("Volkswagen","Transporter",1004,3000),
                    new Camion("Reanult","Truck",1002,3500),
                    new Camion("Iveco","Eurocargo",1003,1500)};

                using var stream = new FileStream("vehicules.xml", FileMode.Create, FileAccess.Write);

                var xmlSerializer = new XmlSerializer(typeof(List<Vehicule>));
                xmlSerializer.Serialize(stream, voitures);

                return voitures;
            }
            else
            {
                using var stream = new FileStream("vehicules.xml", FileMode.Open, FileAccess.Read);

                var xmlSerializer = new XmlSerializer(typeof(List<Vehicule>));

                return xmlSerializer.Deserialize(stream) as List<Vehicule>;
            }
        }
    }
}
