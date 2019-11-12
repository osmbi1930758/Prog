using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtelierConditionsString
{
    class Program
    {
        const string maPhrase = "SpiderMan est un adepte des jeux de mots.";
        //Fontions
        static void AfficherMenu()
        {
            Console.WriteLine("1- Permet d’afficher la longueur de la chaîne de caractères");
            Console.WriteLine("2- Permet de déterminer si la phrase contient « octopus »");
            Console.WriteLine("3- Permet de connaître la position du premier ‘e’ ( indice, IndexOf)");
            Console.WriteLine("4- Permet d’afficher une sous phrase");
            Console.WriteLine("5- Transforme la chaîne en majuscule puis l’affiche");
            Console.WriteLine("6- Transforme la chaîne en minuscule puis l’affiche");
            Console.WriteLine("7- Termine le programme");
        }
        static void AfficherLongueur()//case 1
        {
            Console.WriteLine(maPhrase.Length);
            Console.ReadKey();
            Console.Clear();
        }
        static void AfficherSiContient()//case 2
        {
            if (maPhrase.Contains("octopus") == true)
            {
                Console.WriteLine("Octopus existe");
            }
            else
            {
                Console.WriteLine("Octopus n'existe pas");
            }
            Console.ReadKey();
            Console.Clear();
        }
        static void AfficherPosition()//case 3
        {
            int premierE = maPhrase.IndexOf('e');
            Console.WriteLine("Ce trouve à la postion " + premierE);
            Console.ReadKey();
            Console.Clear();
        }
        static void AfficherSousPhrase()//case 4
        {
            string[] tabMot = maPhrase.Split(' ');
            Console.WriteLine(tabMot[3]);
            Console.ReadKey();
            Console.Clear();
        }
        static void AfficherPhraseMaj()//case 5
        {
            string messageEnMajuscule = maPhrase.ToUpper();
            Console.WriteLine(messageEnMajuscule);
            Console.ReadKey();
            Console.Clear();
        }
        static void AfficherPhraseMin()//case 6
        {
            string messageEnMinuscule = maPhrase.ToLower();
            Console.WriteLine(messageEnMinuscule);
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            bool finProgramme = false;

            while (finProgramme == false)
            {
                AfficherMenu();
                int choixMenu = Convert.ToInt32(Console.ReadLine());
                switch (choixMenu)
                {
                    case 1: AfficherLongueur(); break;
                    case 2: AfficherSiContient(); break;
                    case 3: AfficherPosition(); break;
                    case 4: AfficherSousPhrase(); break;
                    case 5: AfficherPhraseMaj(); break;
                    case 6: AfficherPhraseMin(); break;
                    case 7: finProgramme = true; ; break;
                    default: Console.WriteLine("Entrer un choix valide"); break;
                }
            }
        }
    }
}
