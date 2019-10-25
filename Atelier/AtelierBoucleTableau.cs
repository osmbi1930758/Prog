using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtelierBoucleTableaux
{
    class Program
    {
        static void Main(string[] args)
        {
            /*******************VARIABLES**********************
            int compteurFor;
            int compteurWhile = 1;
            **************************************************/

            /*************************************************
            //Compteur Boucle for
            for (compteurFor = 1; compteurFor <= 10; compteurFor++)
            {
                Console.WriteLine("Compteur C# For"+compteurFor);
            }

            //Compteur Boucle While
            while (compteurWhile <= 10)
            {
                Console.WriteLine("Compteur C# While" + compteurWhile);
                compteurWhile++;
            }
            
            //Tableau lorsque l on connnait les valeurs à mettre dans le tableau
            int[] tabAge={15,18,17,16,18};
            Console.WriteLine(tabAge[0]);
            Console.WriteLine(tabAge[1]);
            Console.WriteLine(tabAge[2]);
            Console.WriteLine(tabAge[3]);
            Console.WriteLine(tabAge[4]);
            
            //Tableau lorsque l on connait la taille exemple 5 cases
            int[] tabAge= new int [5];
            tabAge[0] = 15; //Ajouter à la position 0 la valeur 15
            Console.WriteLine(tabAge[0]);
            Console.WriteLine(tabAge[1]);
            Console.WriteLine(tabAge[2]);
            Console.WriteLine(tabAge[3]);
            Console.WriteLine(tabAge[4]);
            Console.WriteLine("La longueur du tableau est " + tabAge.Length); //Pour avoir la longueur du tableau

            int nb =0;
            Random generateurNb = new Random();
            //genere un nombre entre 1 et 13, le 14 est exclus
            nb = (int)generateurNb.Next(1, 14);

            
            int[] tabNombre = new int[4];
            int i;
            Console.WriteLine("Choisir 4 nombres: ");
            for ( i=0;i <4;i++)
            {
                tabNombre[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Clear();
            Console.WriteLine(tabNombre[0]);
            Console.WriteLine(tabNombre[1]);
            Console.WriteLine(tabNombre[2]);
            Console.WriteLine(tabNombre[3]);

            int[] tabAge = new int[4];
            Console.WriteLine("Veuilliez rentrer 4 ages: ");
            tabNombre[0] = Convert.ToInt32(Console.ReadLine());
            tabNombre[1] = Convert.ToInt32(Console.ReadLine());
            tabNombre[2] = Convert.ToInt32(Console.ReadLine());
            tabNombre[3] = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            Console.WriteLine(tabNombre[0]);
            Console.WriteLine(tabNombre[1]);
            Console.WriteLine(tabNombre[2]);
            Console.WriteLine(tabNombre[3]);

            static int TrouverMax(int nb1, int nb2, int nb3)
        {
            int max1= Math.Max(nb1,nb2);
            int max = Math.Max(max1, nb3);
            return max;
        }
            **************************************************/
            /*Exercice 1*/
            int nbSaisie = 0;
            int vFact = 1;
            int compteurWhile = 1;

            Console.WriteLine("/*Exercice 1*/");
            Console.WriteLine("Choisir une valeur: ");
            nbSaisie = Convert.ToInt32(Console.ReadLine());
            while (compteurWhile <= nbSaisie)
            {
                vFact = vFact * compteurWhile;
                compteurWhile++;
            }
            Console.WriteLine("La valeur Factorielle est " + vFact);
            /*Exercice 2*/
            int nb = 0;
            int[] tabNombre = new int[300];
            int i;
            int max = tabNombre[0];
            int min = 10000;
            int valeurSaisi = 0;
            bool valeurVerifier = false;
            bool valeurNonVerifier = false;
            int moyenne = 0;
            int nombreAddition = 0;
            int choix = 0;
            Console.WriteLine("/*Exercice 2*/");
            Random generateurNb = new Random();
            for (i = 0; i < 300; i++)
            {
                tabNombre[i] = (int)generateurNb.Next(1, 10001); //genere un nombre entre 1 et 10 000, le 10 001 est exclus
                if (tabNombre[i] > max) //trouve la plus grande valeur
                {
                    max = tabNombre[i];
                }
                if (tabNombre[i] < min) //trouve la plus petite valeur
                {
                    min = tabNombre[i];
                }
            }
            Console.WriteLine("Menu");
            Console.WriteLine("Choisir un choix");
            Console.WriteLine("1.Trouvez le plus grand nombre");
            Console.WriteLine("2.Trouvez le plus petit nombre");
            Console.WriteLine("3.Verifier si le nombre saisi existe dans le tableau " + tabNombre[3]);
            Console.WriteLine("4.Faire la moyenne");
            choix = Convert.ToInt32(Console.ReadLine());
            switch (choix)
            {
                case 1:Console.WriteLine(max);
                    break;
                case 2: Console.WriteLine(min);
                    break;
                case 3:
                    Console.WriteLine("Saisir une valeur: ");
                    valeurSaisi = Convert.ToInt32(Console.ReadLine());
                    for (i = 0; i < 300; i++)
                    {
                        if (tabNombre[i] == valeurSaisi) //verifie si la valeur saisi existe
                        {
                            valeurVerifier = true;
                            Console.WriteLine("La valeur saisi existe ");
                        }

                    }
                    if (valeurVerifier == false) //si la valeur saisi n existe pas
                    {
                        valeurNonVerifier = true;
                        Console.WriteLine("La valeur saisi n existe pas ");
                    }
                    break;
                case 4:
                    for (i = 0; i < 300; i++)
                    {
                        nombreAddition = nombreAddition + tabNombre[i];
                    }
                    moyenne = nombreAddition / 300;
                    Console.WriteLine("La moyenne saisi est: " + moyenne);
                    break;

            }
            Console.WriteLine("Veuillez appuyer sur une touche pour quitter");
            Console.ReadKey(true);
        }
    }
}
