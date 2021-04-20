using System;

namespace MesClasses.Autres
{
    public static class Outils
    {
        public static int GetInt(string question = "valeur : ", int min = int.MinValue, int max = int.MaxValue)
        {
            int unEntier;
            var valeur = GetString(question);
            while (!int.TryParse(valeur, out unEntier) || !(unEntier >= min && unEntier <= max))
            {
                string control;
                if (unEntier < min) control = $"Le numéro doit être superior à {min}.";
                else if (unEntier > max) control = $"Le numéro doit être inferieur à {max}.";
                else control = "La saisie n'est pas valide.";

                valeur = GetString($"{control}\n{question}");
            }
            return unEntier;
        }

        public static string GetString(string question = "Valeur : ")
        {
            Console.Write(question);
            string reponse = Console.ReadLine();
            while (String.IsNullOrWhiteSpace(reponse))
            {
                Console.WriteLine("La saisie n'est pas valide");
                reponse = Console.ReadLine();
            }
            return reponse;
        }
    }
}
