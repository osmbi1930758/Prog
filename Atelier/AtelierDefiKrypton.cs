using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtelierDefiKrypton
{
    class Program
    {
        //Fonctions
        static void AfficherMenu()
        {
            Console.WriteLine("1- Affiche le décriptage du Message de Superman: Mb`qsph`d`ftu`m(gvo");
            Console.WriteLine("2- Encrypter un message");
            Console.WriteLine("3- Décrypter un message");
            Console.WriteLine("4- Termine le programme");
        }
        static void DecrypterMessageSuperman()//case1
        {
            string messageEncrypter = "Mb`qsph`d`ftu`m(gvo";
            string nouveauMessage = "";
            Console.WriteLine("Message encrypté: Mb`qsph`d`ftu`m(gvo");
            Console.WriteLine("Afficher le message décrypté:");
            for (int cpt = 0; cpt < messageEncrypter.Length; cpt++)
            {
                int valeurASCII = (int)messageEncrypter[cpt];
                valeurASCII = valeurASCII - 1;
                nouveauMessage += char.ConvertFromUtf32(valeurASCII);
                //Console.WriteLine(valeurASCII);
            }
            Console.WriteLine(nouveauMessage);
            Console.ReadKey();
            Console.Clear();
        }
        static void EncrypterMessage()//case 2
        {
            Console.WriteLine("Afficher le message à encrypté:");
            string messageAEncrypter = Convert.ToString(Console.ReadLine());
            string nouveauMessage = "";
            for (int cpt = 0; cpt < messageAEncrypter.Length; cpt++)
            {
                int valeurASCII = (int)messageAEncrypter[cpt];
                nouveauMessage += char.ConvertFromUtf32(valeurASCII + 1);//+1 autre méthode
                //Console.WriteLine(valeurASCII);
            }
            Console.WriteLine(nouveauMessage);
            Console.ReadKey();
            Console.Clear();
        }
        static void DecrypterMessage()//case 3
        {
            Console.WriteLine("Afficher le message à décrypté:");
            string messageADecrypter = Convert.ToString(Console.ReadLine());
            string nouveauMessage = "";
            for (int cpt = 0; cpt < messageADecrypter.Length; cpt++)
            {
                int valeurASCII = (int)messageADecrypter[cpt];
                nouveauMessage += char.ConvertFromUtf32(valeurASCII - 1);
            }
            Console.WriteLine(nouveauMessage);
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
                    case 1: DecrypterMessageSuperman(); break;
                    case 2: EncrypterMessage(); break;
                    case 3: DecrypterMessage(); break;
                    case 4: finProgramme = true; ; break;
                    default: Console.WriteLine("Entrer un choix valide"); break;
                }
            }
        }
    }
}
