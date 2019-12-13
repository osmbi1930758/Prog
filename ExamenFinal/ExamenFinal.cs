using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal_BILLY_OSMONT
{
    class Program
    {
        //Structure 1
        public struct TypeMetaux
        {
            public string metaux;
            public double resistance;
            public double pointDeFusion;
            public double poids;
            public double conductivite;
            public double score;
            public double valeur;
            public TypeMetaux(string _metaux, double _resistance, double _pointDeFusion, double _poids, double _conductivite, double _valeur) : this()
            {
                metaux = _metaux;
                resistance = _resistance;
                pointDeFusion = _pointDeFusion;
                poids = _poids;
                conductivite = _conductivite;
                valeur = _valeur;
                score = (resistance + pointDeFusion + poids + conductivite) / 4;
            }
        }
        //Structure 2
        public struct NouvelAlliage
        {
            public string metaux;
            public double resistance;
            public double pointDeFusion;
            public double poids;
            public double conductivite;
            public double score;
            public double valeur;
            public NouvelAlliage(string _metaux, double _resistance, double _pointDeFusion, double _poids, double _conductivite, double _valeur) : this()
            {
                metaux = _metaux;
                resistance = _resistance;
                pointDeFusion = _pointDeFusion;
                poids = _poids;
                conductivite = _conductivite;
                valeur = _valeur;
                score = (resistance + pointDeFusion + poids + conductivite) / 4;
            }
        }
        //Affiche le Menu
        static void AfficherMenu()
        {
            Console.WriteLine("Veuillez choisir l'une des options suivantes : ");
            Console.WriteLine("1- Connaitre le métal avec la meilleure résistance");
            Console.WriteLine("2- Connaitre le metal avec le meilleur score(moyenne de tous les cotes)");
            Console.WriteLine("3- Savoir si un métal avec une conductivité de plus de 6 existe");
            Console.WriteLine("4- Crée un nouvel alliage");
            Console.WriteLine("5- Quitter le programme");
        }
        //CASE 1
        static void AfficherMeilleurResist(ref TypeMetaux[] tabMetaux)
        {
            double meilleurResist = 0;
            string nomMetaux = "";
            for (int i = 0; i < tabMetaux.Length; i++)
            {
                if (tabMetaux[i].resistance > meilleurResist)
                {
                    meilleurResist = tabMetaux[i].resistance;
                    nomMetaux = tabMetaux[i].metaux;
                }
            }
            Console.WriteLine("Le métal ayant le plus de résistance est " + nomMetaux + " avec " + meilleurResist + " de resistance.");
            Console.ReadKey();
            Console.Clear();
        }
        //CASE 2
        static void AfficherMeilleurScore(ref TypeMetaux[] tabMetaux)
        {
            double meilleurScore = 0;
            string nomMetaux = "";
            for (int i = 0; i < tabMetaux.Length; i++)
            {
                if (tabMetaux[i].score > meilleurScore)
                {
                    meilleurScore = tabMetaux[i].score;
                    nomMetaux = tabMetaux[i].metaux;
                }
            }
            Console.WriteLine("Le métal ayant le plus de score est " + nomMetaux + " avec " + meilleurScore + " de score.");
            Console.ReadKey();
            Console.Clear();
        }
        //CASE 3
        static void AfficherSiMetauxConductSup(ref TypeMetaux[] tabMetaux)
        {
            bool metauxConductSupExiste = false;
            int cpt = 0;
            while (metauxConductSupExiste == false && cpt < tabMetaux.Length)
            {
                if (tabMetaux[cpt].conductivite > 6)
                    metauxConductSupExiste = true;
                else
                    cpt++;
            }

            if (metauxConductSupExiste)
                Console.WriteLine("Oui un métal existe avec une conductivité supérieure à 6");
            else
                Console.WriteLine("Non aucun métal existe avec une conductivité supérieure à 6");

            Console.ReadKey();
            Console.Clear();
        }
        //CASE 4
        static void AfficherNouvelAlliage(ref TypeMetaux[] tabMetaux)
        {
            int choix1=0;
            int choix2=0;
            double valeurMetal1;
            double valeurMetal2;
            double total=0;
            bool choixValide=false;
            string nomChoix1;
            string nomChoix2;
            string nomNouvelAlliage= "";
            while (choixValide == false)
            {
                Console.WriteLine("Veuillez choisir l'une des options suivantes : ");
                Console.WriteLine("(1)Fer, (2)Cuivre, (3)Plomb, (4)Zinc ");
                Console.WriteLine("Choix n*1 : ");
                choix1 = Convert.ToInt32(Console.ReadLine());
                valeurMetal1 = tabMetaux[(choix1-1)].valeur;
                nomChoix1= tabMetaux[(choix1 - 1)].metaux;
                Console.WriteLine("Choix n*2 : ");
                choix2 = Convert.ToInt32(Console.ReadLine());
                valeurMetal2 = tabMetaux[(choix2 - 1)].valeur;
                nomChoix2 = tabMetaux[(choix2 - 1)].metaux;
                nomNouvelAlliage = nomChoix1 + nomChoix2[0];
                //Calcul total
                total = (valeurMetal1 + valeurMetal2) * 100;
                //Condition de validation
                if (total == 100)
                {
                    choixValide = true;
                    Console.WriteLine(nomChoix1+ " " + valeurMetal1*100 + "% et " + nomChoix2 + " " + valeurMetal2*100 + " % total " + total+ " -> "+ nomNouvelAlliage);
                }
                else if(total > 100)
                    Console.WriteLine(nomChoix1 + " " + valeurMetal1 * 100 + "% et " + nomChoix2 + " " + valeurMetal2 * 100 + " % total supérieur à 100 \n");
                else if (total < 100)
                    Console.WriteLine(nomChoix1 + " " + valeurMetal1 * 100 + "% et " + nomChoix2 + " " + valeurMetal2 * 100 + " % total inférieur à 100 \n");

            }
            NouvelAlliage nouvelAliage = new NouvelAlliage();
            //Nom nouvelAliage
            nouvelAliage.metaux = nomNouvelAlliage;
            Console.WriteLine("Nom du nouvel Alliage: " + nouvelAliage.metaux);
            //Résistance nouvelAliage
            nouvelAliage.resistance = (tabMetaux[(choix1 - 1)].resistance* tabMetaux[(choix1 - 1)].valeur )+ (tabMetaux[(choix2 - 1)].resistance* tabMetaux[(choix2 - 1)].valeur);
            Console.WriteLine("Résistance: " + nouvelAliage.resistance);
            //Point de fusion nouvelAliage
            nouvelAliage.pointDeFusion = (tabMetaux[(choix1 - 1)].pointDeFusion * tabMetaux[(choix1 - 1)].valeur) + (tabMetaux[(choix2 - 1)].pointDeFusion * tabMetaux[(choix2 - 1)].valeur);
            Console.WriteLine("Point de fusion: " + nouvelAliage.pointDeFusion);
            //Poids nouvelAliage
            nouvelAliage.poids = (tabMetaux[(choix1 - 1)].poids * tabMetaux[(choix1 - 1)].valeur) + (tabMetaux[(choix2 - 1)].poids * tabMetaux[(choix2 - 1)].valeur);
            Console.WriteLine("Poids: " + nouvelAliage.poids);
            //Conductivité nouvelAliage
            nouvelAliage.conductivite = (tabMetaux[(choix1 - 1)].conductivite * tabMetaux[(choix1 - 1)].valeur) + (tabMetaux[(choix2 - 1)].conductivite * tabMetaux[(choix2 - 1)].valeur);
            Console.WriteLine("Conductivité: " + nouvelAliage.conductivite);
            
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            bool finProgramme = false;
            TypeMetaux[] tabMetaux = new TypeMetaux[4];
            tabMetaux[0] = new TypeMetaux("Fer", 7, 9, 4, 3, 0.15);
            tabMetaux[1] = new TypeMetaux("Cuivre", 4, 8, 8, 2, 0.85);
            tabMetaux[2] = new TypeMetaux("Plomb", 1, 3, 7, 2, 0.35);
            tabMetaux[3] = new TypeMetaux("Zinc", 2, 5, 3, 6, 0.65);

            while (finProgramme == false)
            {
                AfficherMenu();
                int choixMenu = Convert.ToInt32(Console.ReadLine());
                switch (choixMenu)
                {
                    case 1: AfficherMeilleurResist(ref tabMetaux); break;
                    case 2: AfficherMeilleurScore(ref tabMetaux); break;
                    case 3: AfficherSiMetauxConductSup(ref tabMetaux); break;
                    case 4: AfficherNouvelAlliage(ref tabMetaux); break;
                    case 5: finProgramme = true; break;
                    default: Console.WriteLine("Entrer un choix valide"); break;
                }
            }

        }
    }
}
