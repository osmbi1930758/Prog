using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices; //for P/Invoke DLLImport


namespace Projet
{

    class Program
    {

        class App
        {
            static public Timer timer;
            static public Player player;
            static public Ennemi[] tabEnnemis;
            static public Tire tire;
            static public bool isPlayerMoving;
            static public bool isEnnemiMoving;
            static public bool isTireMoving;
            static public long time;
            static public int nbEnnemiAfficher = 0;
            /****************************************************************************/
            /// <summary>
            /// Contains native methods imported as unmanaged code.
            /// </summary>
            internal static class DllImports
            {
                [StructLayout(LayoutKind.Sequential)]
                public struct COORD
                {

                    public short X;
                    public short Y;
                    public COORD(short x, short y)
                    {
                        this.X = x;
                        this.Y = y;
                    }

                }
                [DllImport("kernel32.dll")]
                public static extern IntPtr GetStdHandle(int handle);
                [DllImport("kernel32.dll", SetLastError = true)]
                public static extern bool SetConsoleDisplayMode(
                    IntPtr ConsoleOutput
                    , uint Flags
                    , out COORD NewScreenBufferDimensions
                    );
            }
            /// Main App's Entry point
            /****************************************************************************/

            /**************************************************************************/
            public struct Player
            {
                public int posX;
                public int posY;
                public int oldPosX;
                public int oldPosY;
                public int speed;

                public Player(int _posX, int _posY) : this()
                {
                    posX = _posX;
                    posY = _posY;
                    oldPosX = 0;
                    oldPosY = 0;
                    speed = 3;
                }
            }
            /**************************************************************************/
            public struct Ennemi
            {
                public int posX;
                public int posY;
                public int oldPosX;
                public int oldPosY;
                public int speed;
                public int direction;

                public Ennemi(int _posX, int _posY) : this()
                {
                    posX = _posX;
                    posY = _posY;
                    oldPosX = 0;
                    oldPosY = 0;
                    speed = 7;
                    direction = 1;
                }
            }
            /**************************************************************************/
            public struct Tire
            {
                public int posX;
                public int posY;
                public int oldPosX;
                public int oldPosY;
                public int speed;
                public int direction;

                public Tire(int _posX, int _posY) : this()
                {
                    posX = _posX;
                    posY = _posY;
                    oldPosX = 0;
                    oldPosY = 0;
                    speed = 7;
                    direction = 1;
                }
            }
            /**************************************************************************/
            static void Limites()
            {
                int limiteMax = 69;
                Console.SetCursorPosition(75, 3);
                Console.WriteLine("_____________________________________________________________________________________________________________________________________");//top
                Console.SetCursorPosition(75, 69);
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------");//bottom
                for (int i = 4; i < limiteMax; i++)
                {
                    Console.SetCursorPosition(75, i);
                    Console.WriteLine("|                                                                                                                                   |");
                }
                //limit top 3 ; limite bottom 69 ; limit left 75 ; limit right 201 ; 
            }
            /**************************************************************************/
            static void UpdateTime(Object o)
            {
                time += 100;
            }
            static void Update()
            {
                int xLimiteGauche = 77;
                int xLimiteDroite = 198;

                if (time > 1000)
                {
                    UpdateSpawn();
                    UpdateEnnemi();
                    for (int i = 0; i < nbEnnemiAfficher; i++)
                    {
                        if (tabEnnemis[i].posX >= xLimiteDroite)
                        {
                            tabEnnemis[i].posX = xLimiteDroite - 2;
                            tabEnnemis[i].posY += 3;
                            if (tabEnnemis[i].direction > 0)
                                tabEnnemis[i].direction = -1;
                            else
                                tabEnnemis[i].direction = 1;
                        }
                        else if (tabEnnemis[i].posX <= xLimiteGauche)
                        {
                            tabEnnemis[i].posX = xLimiteGauche + 7;
                            tabEnnemis[i].posY += 3;
                            if (tabEnnemis[i].direction > 0)
                                tabEnnemis[i].direction = -1;
                            else
                                tabEnnemis[i].direction = 1;
                        }
                    }
                }
            }
            static void UpdateSpawn()
            {
                if (nbEnnemiAfficher < tabEnnemis.Length)
                {
                    tabEnnemis[nbEnnemiAfficher] = new Ennemi(76, 4);
                    nbEnnemiAfficher++;
                }
            }
            static void UpdateEnnemi()
            {
                for (int i = 0; i < nbEnnemiAfficher; i++)
                {
                    tabEnnemis[i].posX += tabEnnemis[i].direction * tabEnnemis[i].speed;
                    isEnnemiMoving = true;
                    time = 0;
                }
            }
            static void UpdateVaisseau()
            {
                int limiteGauche = 75;
                int limiteDroite = 193;
                while (Console.KeyAvailable)
                {
                    ConsoleKey Input = Console.ReadKey(true).Key;

                    if (Input == ConsoleKey.A || Input == ConsoleKey.LeftArrow)//gauche
                    {
                        player.posX -= player.speed * 1;
                        if (player.posX <= limiteGauche)
                        {
                            player.posX = 76;
                        }
                    }
                    else if (Input == ConsoleKey.D || Input == ConsoleKey.RightArrow)//droite
                    {
                        player.posX += player.speed * 1;
                        if (player.posX >= limiteDroite)
                        {
                            player.posX = 192;
                        }
                    }
                    isPlayerMoving = true;
                }
            }
            static void UpTire()
            {
                int limiteTop = 3;

                if (time > 1000)
                {
                    UpdateTire();
                    if (tire.posY >= limiteTop)
                        tire.posY -= 3;
                }
            }
            static void UpdateTire()
            {
                ConsoleKey Input = Console.ReadKey(true).Key;

                if (Input == ConsoleKey.Spacebar)
                {
                    tire.posY += tire.speed * 1;
                    isTireMoving = true;
                    time = 0;
                }
            }
            /**************************************************************************/
            static void ClearVaisseau(Player player)
            {
                Console.SetCursorPosition(player.oldPosX, player.oldPosY);
                Console.Write("        ");
                Console.SetCursorPosition(player.oldPosX, player.oldPosY + 1);
                Console.Write("         ");
                Console.SetCursorPosition(player.oldPosX, player.oldPosY + 2);
                Console.Write(@"            ");
                Console.SetCursorPosition(player.oldPosX, player.oldPosY + 3);
                Console.Write(@"               ");
                Console.SetCursorPosition(player.oldPosX, player.oldPosY + 4);
                Console.Write(@"          ");
            }
            static void AfficherVaisseau(Player player)
            {
                Console.SetCursorPosition(player.posX, player.posY);
                Console.Write("       A");
                Console.SetCursorPosition(player.posX, player.posY + 1);
                Console.Write("      |O|");
                Console.SetCursorPosition(player.posX, player.posY + 2);
                Console.Write(@"   //\\O//\\");
                Console.SetCursorPosition(player.posX, player.posY + 3);
                Console.Write(@"<////\\O//\\\\>");
                Console.SetCursorPosition(player.posX, player.posY + 4);
                Console.Write(@"     </O\>");
            }
            /**************************************************************************/
            static void AfficherEnnemi(Ennemi ennemi)
            {
                Console.SetCursorPosition(ennemi.posX, ennemi.posY);
                Console.Write(" __");
                Console.SetCursorPosition(ennemi.posX, ennemi.posY + 1);
                Console.Write("|__|");
                Console.SetCursorPosition(ennemi.posX, ennemi.posY + 2);
                Console.Write(@"/  \");
            }
            static void ClearEnnemi(Ennemi ennemi)
            {
                Console.SetCursorPosition(ennemi.oldPosX, ennemi.oldPosY);
                Console.Write("   ");
                Console.SetCursorPosition(ennemi.oldPosX, ennemi.oldPosY + 1);
                Console.Write("    ");
                Console.SetCursorPosition(ennemi.oldPosX, ennemi.oldPosY + 2);
                Console.Write(@"    ");
            }
            /**************************************************************************/
            static void ClearTireVaisseau(Tire tire)
            {
                Console.SetCursorPosition(tire.oldPosX, tire.oldPosY);
                Console.Write(" ");
            }
            static void AfficherTireVaisseau(Tire tire)
            {
                Console.SetCursorPosition(player.posX, player.posY - 1);
                Console.Write("       |   ");
            }
            /**************************************************************************/
            static void InitialiseGame(Player player)
            {
                Console.SetCursorPosition(0, 0);
                Limites();
                AfficherVaisseau(player);
                for (int i = 0; i < nbEnnemiAfficher; i++)
                {
                    AfficherEnnemi(tabEnnemis[i]);
                }

            }
            public static void Main(string[] args)
            {
                /***************************************************************************************/
                IntPtr hConsole = DllImports.GetStdHandle(-11);   // get console handle
                DllImports.COORD xy = new DllImports.COORD(100, 100);
                DllImports.SetConsoleDisplayMode(hConsole, 1, out xy); // set the console to fullscreen
                //SetConsoleDisplayMode(hConsole, 2);   // set the console to windowed
                /***************************************************************************************/

                player = new Player(136, 64);
                tabEnnemis = new Ennemi[15];

                tabEnnemis[nbEnnemiAfficher] = new Ennemi(76, 4);
                nbEnnemiAfficher++;
                bool finJeu = false;
                InitialiseGame(player);

                Timer timer = new Timer(UpdateTime, null, 0, 100);
                isEnnemiMoving = false;
                isPlayerMoving = false;

                Console.CursorVisible = false;

                while (!finJeu)
                {
                    player.oldPosX = player.posX;
                    player.oldPosY = player.posY;
                    for (int i = 0; i < nbEnnemiAfficher; i++)
                    {
                        tabEnnemis[i].oldPosX = tabEnnemis[i].posX;
                        tabEnnemis[i].oldPosY = tabEnnemis[i].posY;
                    }
                    UpdateVaisseau();
                    Update();
                    UpTire();
                    if (isPlayerMoving || isEnnemiMoving)
                    {
                        ClearVaisseau(player);
                        AfficherVaisseau(player);
                        //AfficherTireVaisseau(tire);
                        //ClearTireVaisseau(tire);
                        for (int i = 0; i < nbEnnemiAfficher; i++)
                        {
                            ClearEnnemi(tabEnnemis[i]);
                            AfficherEnnemi(tabEnnemis[i]);
                        }
                        isPlayerMoving = false;
                        isEnnemiMoving = false;
                        //isTireMoving = false;
                    }

                }

            }
        }

    }
}