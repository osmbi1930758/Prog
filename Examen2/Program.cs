using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2
{
    class Program
    {
        //Générateur de nombre aléatoire
        static Random generateur = new Random();
        //Strucutures
        public enum RareteVaisseau 
        {
            Commun = 1,
            Rare = 2,
            Epique = 3,
            Legandaire = 4
        }
        public struct Vaisseau
        {
            public string nom;
            public int attaque;
            public int vie;
            public int prix;

            public Vaisseau[] tabVaisseau;

            public Vaisseau(int _attaque, int _vie, int _prix) : this()
            {
                attaque = _attaque;
                vie = _vie;
                prix = _prix;
            }
            public Vaisseau(string _nom) : this()
            {
                tabVaisseau = new Vaisseau[20];
                nom = _nom;
                for (int i = 0; i < tabVaisseau.Length; i++)
                {
                    tabVaisseau[i] = new Vaisseau(generateur.Next(10, 111), generateur.Next(100, 2001), generateur.Next(2000, 20001));
                }
            }
        }
        //Fonctions
        static void AfficherMenu()
        {
            Console.SetCursorPosition(40, 0);
            Console.WriteLine("****Les Gardiens De La Galaxie****");
            Console.WriteLine("\n\nVeuillez choisir l'une des options suivantes : ");
            Console.WriteLine("1- Afficher les vaisseaux avec toutes les caractéristiques ");
            Console.WriteLine("2- Vérifier si un vaisseau légendaire éxiste ");
            Console.WriteLine("3- Trouver le vaisseau avec le plus d'attaque ");
            Console.WriteLine("4- Afficher la moyenne des prix"); ;
            Console.WriteLine("5- Quitter le programme");

        }
        static void Rarete() //rareté
        {

        }
        static void AfficherListeVaisseau(ref Vaisseau[] tabVaisseau) //case 1
        {
            for (int i = 0; i < tabVaisseau.Length; i++)
            {
                Console.WriteLine("Vaisseau " + (i + 1) + " Attaque : " + tabVaisseau[i].attaque +
                    " Vie: " + tabVaisseau[i].vie + " Prix : " + tabVaisseau[i].prix);
            }
        }
        static void AfficherSiVaisseauExiste(ref Vaisseau[] tabVaisseau)//case2
        {
            bool vaisseauExiste = false;
            int cpt = 0;
            int valeurAtt = 90;
            while (vaisseauExiste == false && cpt < tabVaisseau.Length)
            {
                if (tabVaisseau[cpt].attaque > valeurAtt)
                    vaisseauExiste = true;
                else
                    cpt++;
            }

            if (vaisseauExiste)
            {
                Console.WriteLine("Il existe un vaisseau ayant légendaire");
            }

            else
                Console.WriteLine("Vaisseau Légendaire non existant ");
        }
        static void AfficherAttaqueEleve(ref Vaisseau[] tabVaisseau)//case3
        {
            int plusAttaqe = 0;
            int pos = 0;
            for (int i = 0; i < tabVaisseau.Length; i++)
            {
                if (tabVaisseau[i].attaque > plusAttaqe)
                {
                    plusAttaqe = tabVaisseau[i].attaque;
                    pos = i;
                }
            }
            Console.WriteLine("Le vaisseau ayant le plus d'attaque est no "
                + (pos + 1) + " avec " + plusAttaqe + " d'attaque");
        }
        static void AfficherMoyennePrix(ref Vaisseau[] tabVaisseau)//case 4
        {
            int moy = 0, tot = 0;
            for (int i = 0; i < tabVaisseau.Length; i++)
            {
                tot += tabVaisseau[i].prix;
            }

            moy = tot / tabVaisseau.Length;
            Console.WriteLine("La moyenne est de " + moy);
        }
        static void Main(string[] args)
        {
            int choixMenu = 0;
            bool finProgramme = false;
            string nom = "";
            Console.SetCursorPosition(40, 0);
            Console.WriteLine("****Les Gardiens De La Galaxie****");
            Console.WriteLine("Veuillez entrer le nom de votre Vaisseau: ");
            nom = Console.ReadLine();
            Vaisseau monVaisseau = new Vaisseau(nom);
            while (finProgramme == false)
            {
                AfficherMenu();
                choixMenu = Convert.ToInt32(Console.ReadLine());
                switch (choixMenu)
                {
                    case 1: AfficherListeVaisseau(ref monVaisseau.tabVaisseau); break;
                    case 2: AfficherSiVaisseauExiste(ref monVaisseau.tabVaisseau); break;
                    case 3: AfficherAttaqueEleve(ref monVaisseau.tabVaisseau); break;
                    case 4: AfficherMoyennePrix(ref monVaisseau.tabVaisseau); break;
                    case 5: finProgramme = true; break;

                }
            }
        }
    }
}
