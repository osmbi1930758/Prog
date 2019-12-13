using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeuxdecouleurs
{
    class Program
    {
        static Random generateur = new Random();
        const int nbCouleurs = 4;
        const int nbCouleursMax = 6;
        const int titreX = 32, titreY = 1;
        const int reglageX = 30, reglageY = 4;
        const int amdX = 8, amdY = 7;
        const int repX = 54, repY = 25;
        const int tcX = 9, tcY = 5;
        const int essX = 9, essY = 8;
        const int evalX = 1, evalY = 23;
        const int bienX = 33, bienY = 9;
        const int malX = 50, malY = 9;
        const int gpX = 1, gpY = 23;
        const int numX = 8, numY = 9;
        const int repuX = 14, repuY = 9;
        const int evalOuiNonX = 20, evalOuiNonY = 23;
        const string evaluer = "Évaluer ? (O/N) : ";
        const string gagner = "Bravo, vous avez gagné !   :)";
        const string perdu = "Vous avez perdu !  :(";
        
        //Fontions
        static void AfficherMenu()
        {
            //Menu
            Console.SetCursorPosition(titreX, titreY);
            Console.Write("JEU DES COULEURS");
            Console.SetCursorPosition(reglageX, reglageY);
            Console.Write("Réglage de la partie");
            Console.SetCursorPosition(amdX, amdY);
            Console.Write("Activer le mode débogage O/N: ");
        }
        static void AfficherJeu()
        {
            //Mise en page
            Console.SetCursorPosition(titreX, titreY);
            Console.Write("JEU DES COULEURS");
            Console.SetCursorPosition(tcX, tcY);
            Console.Write("(R)ouge, (V)ert, (B)leu, (J)aune, (M)auve, (C)yan");
            Console.SetCursorPosition(essX, essY);
            Console.Write("#    Essais        Bien placée(s)    Mal placée(s)");
        }
        static bool GagnerPerdu(int bienPlace,int essaie, int NbrEssaistoto)
        {
            bool gagne = false;
            //Condition GAGNER et PERDU.
            if (bienPlace == nbCouleurs)
            {
                gagne = true;
                Console.SetCursorPosition(gpX, gpY);
                Console.Write(gagner);
                Console.ReadKey();
            }
            else if (essaie == NbrEssaistoto)
            {
                Console.SetCursorPosition(gpX, gpY);
                Console.Write(perdu);
                Console.ReadKey();
            }
            return gagne;
        }
        static void AfficherBienEtMalPlace(int bienPlace, int malPlace, int essaie)
        {
            Console.SetCursorPosition(bienX, bienY + essaie);//Affiche les bienplace.
            Console.Write(bienPlace);
            Console.SetCursorPosition(malX, malY + essaie);//Affiche les malPlace.
            Console.Write(malPlace);
        }
        static int VerificationMalPlace(bool[,] tabverification,int malPlace, char[] tabReponse, char[] essaiCouleurs)
        {
            for (int i = 0; i < nbCouleurs; i++)//Verifie les malPlace.
            {
                for (int j = 0; j < nbCouleurs; j++)
                {
                    if (!tabverification[0, i] && !tabverification[1, j] && tabReponse[i] == essaiCouleurs[j])
                    {
                        malPlace++;
                        tabverification[0, i] = tabverification[1, j] = true;
                    }
                }
            }
            return malPlace;
        }
        static int VerificationBienPlace(bool[,] tabverification, int bienPlace, char[] tabReponse, char[] essaiCouleurs)
        {
            for (int i = 0; i < nbCouleurs; i++)//Verifie les bienplace.
            {
                if (tabReponse[i] == essaiCouleurs[i])
                {
                    bienPlace++;
                    tabverification[0, i] = tabverification[1, i] = true;
                }
            }
            return bienPlace;
        }
        static void Main(string[] args)
        {
            char debogage = ' ';
            char debogageEnMajuscule = ' ';
            char evaluation = ' ';
            char evaluationEnMajuscule = ' ';
            char couleurs_utilisateur = ' ';
            char couleurs_utilisateurEnMajuscule = ' ';
            char[] tabCouleur = { 'R', 'V', 'B', 'M', 'J', 'C' };
            char[] tabReponse = new char[nbCouleurs];
            char[] essaiCouleurs = new char[nbCouleurs];
            int NbrEssaisMax = 11;
            int NbrEssaistoto = 10;
            int essaie = 1;
            int bienPlace = 0;
            int malPlace = 0;
            int nbCouleursEntrees = 0;
            int ligne = 2;
            bool gagne = false;
            bool eval = false;
            bool[,] tabverification = new bool[2, 4];

            //Page de démarage.
            while (debogageEnMajuscule != 'O' && debogageEnMajuscule != 'N')
            {
                AfficherMenu();
                debogage = Console.ReadKey(true).KeyChar;
                debogageEnMajuscule = char.ToUpper(debogage);
                Console.Write(debogageEnMajuscule);
            }
            // Si l'utilisateur choisie le Mode Debogage.
            if (debogageEnMajuscule == 'O')
            {
                Console.Clear();
                //Combinaison de couleurs Aléatoire.
                for (int i = 0; i < nbCouleurs; i++)
                {
                    tabReponse[i] = tabCouleur[generateur.Next(0, nbCouleursMax)];
                }
                //Mise en page
                AfficherJeu();
                //Affichage Code Secret.
                Console.SetCursorPosition(repX, repY);
                Console.Write(tabReponse[0] + " " + tabReponse[1] + " " + tabReponse[2] + " " + tabReponse[3]);
                
            }
            else if (debogageEnMajuscule == 'N')
            {
                Console.Clear();
                //Combinaison de couleurs Aléatoire.
                for (int i = 0; i < nbCouleurs; i++)
                {
                    tabReponse[i] = tabCouleur[generateur.Next(0, nbCouleursMax)];
                }
                //Mise en page
                AfficherJeu();
            }
            do
            {
                bienPlace = 0;
                malPlace = 0;

                do
                {
                    Console.SetCursorPosition(numX, numY + essaie);
                    Console.Write(essaie + ") ");
                    Console.SetCursorPosition(repuX, repuY + essaie);
                    Console.Write("\t\t");//Pour effacer si evaluation = N.
                    Console.SetCursorPosition(repuX, repuY + essaie);
                    nbCouleursEntrees = 0;
                    do
                    {
                        couleurs_utilisateur = Console.ReadKey(true).KeyChar;
                        couleurs_utilisateurEnMajuscule = char.ToUpper(couleurs_utilisateur);
                        // Saisis de l'utilisateur de 4 lettres.
                        if (couleurs_utilisateurEnMajuscule == 'R' || couleurs_utilisateurEnMajuscule == 'V' || couleurs_utilisateurEnMajuscule == 'B' || couleurs_utilisateurEnMajuscule == 'J' || couleurs_utilisateurEnMajuscule == 'M' || couleurs_utilisateurEnMajuscule == 'C')
                        {
                            essaiCouleurs[nbCouleursEntrees] = couleurs_utilisateurEnMajuscule;
                            Console.Write(couleurs_utilisateurEnMajuscule + " ");
                            nbCouleursEntrees++;
                        }
                    } while (nbCouleursEntrees < nbCouleurs);
                    // Evaluation OUI ou NON.
                    Console.SetCursorPosition(evalX, evalY);
                    Console.Write(evaluer);
                    do
                    {
                        Console.SetCursorPosition(evalOuiNonX, evalOuiNonY);
                        evaluation = Console.ReadKey(true).KeyChar;
                        evaluationEnMajuscule = char.ToUpper(evaluation);
                    } while (evaluationEnMajuscule != 'O' && evaluationEnMajuscule != 'N');
                    Console.Write(evaluationEnMajuscule);
                    if (evaluationEnMajuscule == 'O')
                        eval = true;
                    else if (evaluationEnMajuscule == 'N')
                        eval = false;
                } while (eval == false);
                /**************************************Trouver les bien places et mal places.*****************************************************/
                //Decalerer le tableau booleen a false.
                for (int i = 0; i < ligne; i++)
                {
                    for (int j = 0; j < nbCouleurs; j++)// Decalerer le tableau booleen a false.
                    {
                        tabverification[i, j] = false;
                    }
                }
                //Fonction Vérifie les biens placés
                bienPlace = VerificationBienPlace(tabverification, bienPlace, tabReponse, essaiCouleurs);
                //Fonction Vérifie les mals placés
                malPlace = VerificationMalPlace(tabverification, malPlace, tabReponse, essaiCouleurs);
                /**************************************Trouver les bien places et mal places.*****************************************************/
                //Fonction afficher les biens et mals placés
                AfficherBienEtMalPlace(bienPlace, malPlace, essaie);
                //Fonction condition GAGNER et PERDU.
                gagne =GagnerPerdu(bienPlace,  essaie,  NbrEssaistoto);
                essaie++;
            } while (!gagne && NbrEssaisMax != essaie);
        }
    }
}
