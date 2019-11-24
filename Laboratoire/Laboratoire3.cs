using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Laboratoire3
{
    class Program
    {
        static Random generateur = new Random();
        /*
        Manque choix 3 de l'exercie 1 
        Aleatoire pour jeu de pendu
        */
        //function
        static void AfficherMenu()//Menu
        {
            Console.SetCursorPosition(29, 1);
            Console.WriteLine("********************Laboratoire 3********************");
            Console.SetCursorPosition(29, 2);
            Console.WriteLine("*                                                   *");
            Console.SetCursorPosition(29, 3);
            Console.WriteLine("*                                                   *");
            Console.SetCursorPosition(29, 4);
            Console.WriteLine("*                                                   *");
            Console.SetCursorPosition(29, 5);
            Console.WriteLine("*                                                   *");
            Console.SetCursorPosition(29, 6);
            Console.WriteLine("*                                                   *");
            Console.SetCursorPosition(29, 7);
            Console.WriteLine("*                                                   *");
            Console.SetCursorPosition(29, 8);
            Console.WriteLine("*                                                   *");
            Console.SetCursorPosition(29, 9);
            Console.WriteLine("*                                                   *");
            Console.SetCursorPosition(29, 10);
            Console.WriteLine("*                                                   *");
            Console.SetCursorPosition(29, 11);
            Console.WriteLine("*                                                   *");
            Console.SetCursorPosition(29, 12);
            Console.WriteLine("********************Laboratoire 3********************");
            Console.SetCursorPosition(35, 4);
            Console.WriteLine("1 - Exercice 1");
            Console.SetCursorPosition(35, 6);
            Console.WriteLine("2 - Exercice 2");
            Console.SetCursorPosition(35, 8);
            Console.WriteLine("3 - Exercice 3");
            Console.SetCursorPosition(35, 10);
            Console.WriteLine("4- Termine le programme");
        }
        static void AfficherMenuExercice1()//Menu
        {
            Console.WriteLine("1 - Afficher le nombre de mots contenu dans la phrase");
            Console.WriteLine("2 - Afficher combien de fois chaque lettre apparaît");
            Console.WriteLine("3 - Afficher la lettre qui apparaît le plus souvent");
            Console.WriteLine("4 - Encoder la phrase en utilisant une clé de +2 et afficher le résultat");
            Console.WriteLine("5- Termine le programme");
        }
        static void readAndClear()
        {
            Console.ReadKey();
            Console.Clear();
        }
        /******************************************************Fonctions Exercice1********************************************************/
        static void AfficherNbreMot(string phraseUser)//case 1
        {
            string[] tabMot = phraseUser.Split(' ');
            Console.WriteLine(tabMot.Length);
            readAndClear();
        }
        static void AfficherNbreFoisLettre(string phraseUser)//case 2
        {
            int[] tabLettre = new int[26];
            int valeurIndiceLettre = 0;
            char lettre;
            for (int i = 0; i < phraseUser.Length; i++)
            {
                valeurIndiceLettre = (int)(phraseUser[i] - 97);
                if (valeurIndiceLettre >= 0 && valeurIndiceLettre < 26)//Est ce une lettre
                    tabLettre[valeurIndiceLettre]++;
            }
            for (int i = 0; i < tabLettre.Length; i++)
            {
                lettre = (char)(i + 97);//lettre à afficher
                Console.WriteLine(lettre + " " + tabLettre[i]);
            }
            readAndClear();
        }
        static void AfficherLettrePlusSouvent(string phraseUser)//case 3
        {
            int[] tabLettre = new int[26];
            int valeurIndiceLettre = 0;
            char lettre;
            int max = 0;
            for (int i = 0; i < phraseUser.Length; i++)
            {
                valeurIndiceLettre = (int)(phraseUser[i] - 97);
                if (valeurIndiceLettre >= 0 && valeurIndiceLettre < 26)//Est ce une lettre
                    tabLettre[valeurIndiceLettre]++;
                if (valeurIndiceLettre > max)
                {
                    max = valeurIndiceLettre;
                }
            }
            for (int i = 0; i < tabLettre.Length; i++)
            {
                lettre = (char)(i + 97);//lettre à afficher
            }
            readAndClear();
        }
        static void PhraseCle(string phraseUser)//case 4
        {
            //string phraseUser = Convert.ToString(Console.ReadLine());
            string nouveauMessage = "";
            for (int cpt = 0; cpt < phraseUser.Length; cpt++)
            {
                int valeurASCII = (int)phraseUser[cpt];
                nouveauMessage += char.ConvertFromUtf32(valeurASCII + 2);//+1 autre méthode
                //Console.WriteLine(valeurASCII);
            }
            Console.WriteLine(nouveauMessage);
            readAndClear();
        }
        /**************************************************Fin Fonctions Exercice1********************************************************/
        static void Exercice1()
        {
            //Exercice1
            bool finProgramme1 = false;

            while (finProgramme1 == false)
            {
                Console.WriteLine("Entrez votre phrase:");
                string phrase = Console.ReadLine();
                AfficherMenuExercice1();
                int choixMenuExercice1 = Convert.ToInt32(Console.ReadLine());
                switch (choixMenuExercice1)
                {
                    case 1: AfficherNbreMot(phrase); break;
                    case 2: AfficherNbreFoisLettre(phrase); break;
                    case 3: AfficherLettrePlusSouvent(phrase); break;
                    case 4: PhraseCle(phrase); break;
                    case 5: finProgramme1 = true; Console.Clear(); ; break;
                    default: Console.WriteLine("Entrer un choix valide"); break;
                }
            }
        }
        /******************************************************Fonctions Exercice2********************************************************/
        static void AfficherPendu(int nbErreur)
        {
            switch (nbErreur)
            {
                case 0:
                    Console.SetCursorPosition(0, 9);
                    Console.WriteLine("     |--|     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("     ------   ");
                    break;

                case 1:
                    Console.SetCursorPosition(0, 9);
                    Console.WriteLine("     |--|     ");
                    Console.WriteLine("     O  |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("     ------   ");
                    break;

                case 2:
                    Console.SetCursorPosition(0, 9);
                    Console.WriteLine("     |--|     ");
                    Console.WriteLine("     O  |     ");
                    Console.WriteLine("    /|  |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("     ------   ");
                    break;

                case 3:
                    Console.SetCursorPosition(0, 9);
                    Console.WriteLine("     |--|     ");
                    Console.WriteLine("     O  |     ");
                    Console.WriteLine("    /|\\ |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("     ------   ");
                    break;

                case 4:
                    Console.SetCursorPosition(0, 9);
                    Console.WriteLine("     |--|     ");
                    Console.WriteLine("     O  |     ");
                    Console.WriteLine("    /|\\ |     ");
                    Console.WriteLine("     -  |     ");
                    Console.WriteLine("    /   |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("     ------   ");
                    break;

                case 5:
                    Console.SetCursorPosition(0, 9);
                    Console.WriteLine("     |--|     ");
                    Console.WriteLine("     O  |     ");
                    Console.WriteLine("    /|\\ |     ");
                    Console.WriteLine("     -  |     ");
                    Console.WriteLine("    / \\ |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("        |     ");
                    Console.WriteLine("     ------   ");
                    break;
            }
        }
        static void AffichageConsole(int trouve, int erreur)
        {
            Console.SetCursorPosition(15, 25);
            Console.Write("Trouver :" + trouve);
            Console.SetCursorPosition(15, 27);
            Console.Write("erreur :" + erreur);
        }

        /**************************************************Fin Fonctions Exercice2********************************************************/
        static void Exercice2()
        {
            //Exercice2
            int nbreEssaisMax = 5;
            int essai = 0;
            bool gagne = false;
            int trouve = 0;
            int erreur = 0;
            int probMots = generateur.Next(0, 10);

            string lettreUser;
            string lettreUserEnMajuscule;

            string[] tabMots = { "ALLO", "DELL", "CEGEP", "COCO", "PENDU", "PROG", "WEB", "C", "JAVA", "HTML" };
            string mot = tabMots[probMots];
            char[] tabLettre = new char[mot.Length];

            //Affichage
            Console.SetCursorPosition(32, 0);
            Console.WriteLine("Jeu de  pendu");
            Console.WriteLine("Trouvez le mot :");

            //Affichage underscores
            for (int cpt = 0; cpt < tabLettre.Length; cpt++)//Mettre des _ pour l'affichage 
            {
                tabLettre[cpt] = '_';
                Console.SetCursorPosition(17 + cpt + cpt, 1);
                Console.Write(tabLettre[cpt] + "  ");
            }
            //Afficher Pendu
            AfficherPendu(erreur);
            while (gagne == false && nbreEssaisMax != erreur)
            {
                trouve = 0;//Remise à zéro pour la vérification
                //Affiche le pendu 
                Console.SetCursorPosition(0, 3);
                lettreUser = Console.ReadLine();
                lettreUserEnMajuscule = lettreUser.ToUpper();

                for (int cpt = 0; cpt < tabLettre.Length; cpt++)//Verifie si la lettre de l'utilisateur existe
                {
                    if (lettreUserEnMajuscule[0] == mot[cpt])//Si la lettre existe on remplace les underscores par lettre trouvé
                    {
                        tabLettre[cpt] = mot[cpt];
                        Console.SetCursorPosition(17 + cpt + cpt, 1);
                        Console.Write(tabLettre[cpt]);
                    }
                }
                essai++;
                //Verifications

                //Si c'etait la bonne lettre
                for (int cpt = 0; cpt < tabLettre.Length; cpt++)
                {
                    if (tabLettre[cpt] == mot[cpt])//Si la lettre dans tabLettre a la position cpt est la meme que mot
                        trouve++;
                }
                // Si ce n'était PAS la bonne lettre
                if (mot.Contains(lettreUserEnMajuscule) == false)
                {
                    erreur++;
                    //Afficher Pendu
                    AfficherPendu(erreur);
                }
                //Affichage à la console
                AffichageConsole(trouve, erreur);

                //Affichage Gagner-Perdu
                if (trouve == mot.Length)
                {
                    gagne = true;
                    Console.SetCursorPosition(15, 19);
                    Console.WriteLine("GAGNER");
                    readAndClear();
                }

                else if (erreur >= nbreEssaisMax)
                {
                    Console.SetCursorPosition(15, 19);
                    Console.WriteLine("PENDU");
                    Console.SetCursorPosition(15, 20);
                    Console.Write("Le mot que vous cherchiez était " + mot);
                    readAndClear();
                }
            }
        }
        /******************************************************Fonctions Exercice3********************************************************/

        //Convertir Nombre
        static int ConvertirNombre(int nb)
        {
            int convertir = 0;
            switch (nb)
            {
                case 1:
                    convertir = 6;
                    break;
                case 2:
                    convertir = 7;
                    break;
                case 3:
                    convertir = 8;
                    break;
                case 4:
                    convertir = 3;
                    break;
                case 5:
                    convertir = 4;
                    break;
                case 6:
                    convertir = 5;
                    break;
                case 7:
                    convertir = 0;
                    break;
                case 8:
                    convertir = 1;
                    break;
                case 9:
                    convertir = 2;
                    break;
            }
            return convertir;
        }

        //Affiche la Grille
        static void AfficherGrille(char[] tabCase)
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", tabCase[0], tabCase[1], tabCase[2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", tabCase[3], tabCase[4], tabCase[5]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", tabCase[6], tabCase[7], tabCase[8]);
            Console.WriteLine("     |     |      ");
        }
        //Afficher erreur
        static void AfficherErreurPosition(int choix, char[] tabCase)
        {
            Console.WriteLine("Désolé cette case {0} est déjà marqué {1}", choix, tabCase[ConvertirNombre(choix)]);
            Console.WriteLine("Attendez 1s...");
            Thread.Sleep(1000);
        }

        //Vérification
        static int Verification(char[] tabCase)
        {
            int verif = 0;

            //Lignes:
            if (tabCase[0] == tabCase[1] && tabCase[1] == tabCase[2])
                verif = 1;
            else if (tabCase[3] == tabCase[4] && tabCase[4] == tabCase[5])
                verif = 1;
            else if (tabCase[6] == tabCase[7] && tabCase[7] == tabCase[8])
                verif = 1;

            //Colones
            else if (tabCase[0] == tabCase[3] && tabCase[3] == tabCase[6])
                verif = 1;
            else if (tabCase[1] == tabCase[4] && tabCase[4] == tabCase[7])
                verif = 1;
            else if (tabCase[2] == tabCase[5] && tabCase[5] == tabCase[8])
                verif = 1;

            //Diagonales
            else if (tabCase[0] == tabCase[4] && tabCase[4] == tabCase[8])
                verif = 1;
            else if (tabCase[2] == tabCase[4] && tabCase[4] == tabCase[6])
                verif = 1;

            //Match null
            else if (tabCase[0] != '7' && tabCase[1] != '8' && tabCase[2] != '9' && tabCase[3] != '4' && tabCase[4] != '5' && tabCase[5] != '6' && tabCase[6] != '1' && tabCase[7] != '2' && tabCase[8] != '3')
                verif = 2;
            return verif;
        }

        //Affichage Tour Joueur VS Joueur
        static int AfficherTourJoueur(int tour, char[] tabCase, int choix)
        {
            if (tour % 2 == 0)
            {
                Console.WriteLine("Tour Joueur 2");
                choix = Convert.ToInt32(Console.ReadLine());
                if (tabCase[ConvertirNombre(choix)] != 'O' && tabCase[ConvertirNombre(choix)] != 'X')
                {
                    tabCase[ConvertirNombre(choix)] = 'O';
                    tour++;
                }
                else
                {
                    AfficherErreurPosition(choix, tabCase);
                }

            }
            else
            {
                Console.WriteLine("Tour Joueur 1");
                choix = Convert.ToInt32(Console.ReadLine());
                if (tabCase[ConvertirNombre(choix)] != 'O' && tabCase[ConvertirNombre(choix)] != 'X')
                {
                    tabCase[ConvertirNombre(choix)] = 'X';
                    tour++;
                }
                else
                {
                    AfficherErreurPosition(choix, tabCase); ;
                }
            }
            return tour;
        }
        //Affichage Tour Joueur VS Ordinateur poche
        static int AfficherTourJoueurOrdiPoche(int tour, char[] tabCase, int choix)
        {
            if (tour % 2 == 0)
            {
                Console.WriteLine("Tour Ordinateur");
                choix = generateur.Next(1, 9);
                if (tabCase[ConvertirNombre(choix)] != 'O' && tabCase[ConvertirNombre(choix)] != 'X')
                {
                    tabCase[ConvertirNombre(choix)] = 'O';
                    tour++;
                }

            }
            else
            {
                Console.WriteLine("Tour Joueur 1");
                choix = Convert.ToInt32(Console.ReadLine());
                if (tabCase[ConvertirNombre(choix)] != 'O' && tabCase[ConvertirNombre(choix)] != 'X')
                {
                    tabCase[ConvertirNombre(choix)] = 'X';
                    tour++;
                }
                else
                {
                    AfficherErreurPosition(choix, tabCase); ;
                }
            }
            return tour;
        }
        //Affichage Tour Joueur VS Ordinateur 
        static int AfficherTourJoueurOrdi(int tour, char[] tabCase, int choix)
        {
            if (tour % 2 == 0)
            {
                Console.WriteLine("Tour Ordinateur");
                choix = generateur.Next(1, 9);
                if (tabCase[ConvertirNombre(choix)] != 'O' && tabCase[ConvertirNombre(choix)] != 'X')
                {
                    tabCase[ConvertirNombre(choix)] = 'O';
                    tour++;
                }
            }
            else
            {
                Console.WriteLine("Tour Joueur 1");
                choix = Convert.ToInt32(Console.ReadLine());
                if (tabCase[ConvertirNombre(choix)] != 'O' && tabCase[ConvertirNombre(choix)] != 'X')
                {
                    tabCase[ConvertirNombre(choix)] = 'X';
                    tour++;
                }
                else
                {
                    AfficherErreurPosition(choix, tabCase); ;
                }
            }
            return tour;
        }
        //Afficher winner ou looser
        static int AfficherEtatPartie(int tour, char[] tabCase, int choix)
        {
            int gagne = 0;
            if (Verification(tabCase) == 1 && tour % 2 != 0)
            {
                gagne = 1;
                Console.Clear();
                AfficherGrille(tabCase);
                Console.WriteLine("Joueur 2 a gagné");
                readAndClear();
            }
            else if (Verification(tabCase) == 1 && tour % 2 == 0)
            {
                gagne = 1;
                Console.Clear();
                AfficherGrille(tabCase);
                Console.WriteLine("Joueur 1 a gagné");
                readAndClear();
            }
            else if (Verification(tabCase) == 2)
            {
                gagne = 2;
                Console.Clear();
                AfficherGrille(tabCase);
                Console.WriteLine("Match Null");
                readAndClear();
            }
            return gagne;
        }
        //Afficher winner ou looser contre ORDI
        static int AfficherEtatPartieOrdi(int tour, char[] tabCase, int choix)
        {
            int gagne = 0;
            if (Verification(tabCase) == 1 && tour % 2 != 0)
            {
                gagne = 1;
                Console.Clear();
                AfficherGrille(tabCase);
                Console.WriteLine("Ordinateur a gagné");
                readAndClear();
            }
            else if (Verification(tabCase) == 1 && tour % 2 == 0)
            {
                gagne = 1;
                Console.Clear();
                AfficherGrille(tabCase);
                Console.WriteLine("Joueur 1 a gagné");
                readAndClear();
            }
            else if (Verification(tabCase) == 2)
            {
                gagne = 2;
                Console.Clear();
                AfficherGrille(tabCase);
                Console.WriteLine("Match Null");
                readAndClear();
            }
            return gagne;
        }
        //Afficher erreur
        static void AfficherChoixMode()
        {
            Console.WriteLine("Veuillez choisir le mode de jeu:");
            Console.WriteLine("1 - Joueur contre Joueur");
            Console.WriteLine("2 - Joueur contre Ordinateur poche");
            Console.WriteLine("3- Joueur contre Ordinateur");
            Console.WriteLine("4 - Termine le programmee");
        }
        static void JoueurvsJoueur()
        {
            bool gagne = false;
            bool partieNull = false;

            int tour = 1;
            int choix = 0;
            char[] tabCase = { '7', '8', '9', '4', '5', '6', '1', '2', '3' };


            while (gagne == false && partieNull == false)
            {
                AfficherGrille(tabCase);
                tour = AfficherTourJoueur(tour, tabCase, choix);
                if (AfficherEtatPartie(tour, tabCase, choix) == 1)
                    gagne = true;
                else if (AfficherEtatPartie(tour, tabCase, choix) == 2)
                    partieNull = true;
                Console.Clear();
            }
        }
        //Joueur vs ordi Poche
        static void JoueurvsOrdiPoche()
        {
            bool gagne = false;
            bool partieNull = false;
            int tour = 1;
            int choix = 0;
            char[] tabCase = { '7', '8', '9', '4', '5', '6', '1', '2', '3' };

            while (gagne == false && partieNull == false)
            {
                AfficherGrille(tabCase);
                tour = AfficherTourJoueurOrdiPoche(tour, tabCase, choix);
                if (AfficherEtatPartieOrdi(tour, tabCase, choix) == 1)
                    gagne = true;
                else if (AfficherEtatPartieOrdi(tour, tabCase, choix) == 2)
                    partieNull = true;
                Console.Clear();
            }
        }
        //Joueur vs ordi 
        static void JoueurvsOrdi()
        {
            bool gagne = false;
            bool partieNull = false;

            int tour = 1;
            int choix = 0;
            char[] tabCase = { '7', '8', '9', '4', '5', '6', '1', '2', '3' };


            while (gagne == false && partieNull == false)
            {
                AfficherGrille(tabCase);
                tour = AfficherTourJoueurOrdi(tour, tabCase, choix);
                if (AfficherEtatPartieOrdi(tour, tabCase, choix) == 1)
                    gagne = true;
                else if (AfficherEtatPartieOrdi(tour, tabCase, choix) == 2)
                    partieNull = true;
                Console.Clear();
            }
        }
        /**************************************************Fin Fonctions Exercice3********************************************************/
        static void Exercice3()
        {
            bool finProgramme = false;
            while (finProgramme == false)
            {
                AfficherChoixMode();
                int choixMode = Convert.ToInt32(Console.ReadLine());

                switch (choixMode)
                {
                    case 1: Console.Clear(); JoueurvsJoueur(); break;
                    case 2: Console.Clear(); JoueurvsOrdiPoche(); break;
                    case 3: Console.Clear(); JoueurvsOrdi(); break;
                    case 4: finProgramme = true; Console.Clear(); break;
                    default:
                        Console.SetCursorPosition(35, 16);
                        Console.WriteLine("Entrer un choix valide"); break;
                }
            }

        }
        /**************************************************       Main           ********************************************************/
        static void Main(string[] args)
        {
            //JoueurvsJoueur();
            bool finProgramme = false;

            while (finProgramme == false)
            {
                AfficherMenu();
                Console.SetCursorPosition(35, 14);
                Console.WriteLine("VOTRE CHOIX:");
                Console.SetCursorPosition(49, 14);
                int choixMenuExercice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (choixMenuExercice)
                {
                    case 1: Console.Clear(); Exercice1(); break;
                    case 2: Console.Clear(); Exercice2(); break;
                    case 3: Console.Clear(); Exercice3(); break;
                    case 4:
                        finProgramme = true;
                        Console.SetCursorPosition(50, 8);
                        Console.WriteLine("AU REVOIR");
                        Console.SetCursorPosition(60, 8);
                        Thread.Sleep(2000); ; break;
                    default:
                        Console.SetCursorPosition(35, 16);
                        Console.WriteLine("Entrer un choix valide"); break;
                }
            }

        }
        /**************************************************       Main           ********************************************************/
    }
}
