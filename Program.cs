using System;

namespace morpion
{
    class Program
    {
        //Fonctions de saisie utilisateur
        static bool Check_emplacement(char[,] mytab, string emplacement)
        {
            int ligne = (int)Char.GetNumericValue(emplacement[0]);
            int colonne = (int)Char.GetNumericValue(emplacement[1]);

            char test = mytab[ligne, colonne];

            if (mytab[ligne, colonne] != '.')
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static void Place_pion(ref char[,] mytab, string emplacement)
        {
            int ligne = (int)Char.GetNumericValue(emplacement[0]);
            int colonne = (int)Char.GetNumericValue(emplacement[1]);

            mytab[ligne, colonne] = 'o';
        }
        static string Saisie()
        {
            string saisie = "";
            saisie = Console.ReadLine();

            while (saisie.Length != 2)
            {
                Console.WriteLine("Veuillez entrer 2 caractères max, Coordonnée de Ligne et de Colonne");
                saisie = Console.ReadLine();
            }

            return saisie;
        }

        //Init et affiche tableau
        static void Remplitab(ref char[,] mytab)
        {
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    mytab[i, j] = '.';
                }
            }
        }
        static void Affichetab(char[,] mytab)
        {
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    Console.Write(mytab[i, j] + " ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("\n");
        }


        //Génère une coordonnée aléatoire vide et place le coup de l'IA
        static void ActionIAJoueRandom(ref char[,] mytab)
        {
            Random aleatoire = new Random();
            int ligne = aleatoire.Next(0, 3);
            int colonne = aleatoire.Next(0, 3);

            while (mytab[ligne, colonne] != '.')
            {
                ligne = aleatoire.Next(0, 3);
                colonne = aleatoire.Next(0, 3);
            }

            mytab[ligne, colonne] = 'x';
        }
        // IA Empêche le joueur de gagner ou gagne à tout prix
        static void ActionOrdiJoueDef(ref char[,] mytab)
        {
            Console.WriteLine("Ordinateur joue ... \n");

            if (mytab[1, 1] == '_')
            {
                mytab[1, 1] = 'x';
            }
            else if (mytab[1, 1] == '_')
            {

            }
            else if (mytab[0, 0] == 'o' && mytab[0, 1] == 'o')
            {
                mytab[0, 2] = 'x';
            }
            else if (mytab[0, 2] == 'o' && mytab[0, 1] == 'o')
            {
                mytab[0, 0] = 'x';
            }

            else if (mytab[1, 0] == 'o' && mytab[1, 1] == 'o')
            {
                mytab[1, 2] = 'x';
            }
            else if (mytab[1, 2] == 'o' && mytab[1, 1] == 'o')
            {
                mytab[1, 0] = 'x';
            }

            else if (mytab[2, 0] == 'o' && mytab[2, 1] == 'o')
            {
                mytab[2, 2] = 'x';
            }
            else if (mytab[2, 2] == 'o' && mytab[2, 1] == 'o')
            {
                mytab[2, 0] = 'x';
            }

            else if (mytab[0, 0] == 'o' && mytab[0, 2] == 'o')
            {
                mytab[0, 1] = 'x';
            }
            else if (mytab[1, 0] == 'o' && mytab[1, 2] == 'o')
            {
                mytab[2, 0] = 'x';
            }
            else if (mytab[2, 0] == 'o' && mytab[2, 2] == 'o')
            {
                mytab[2, 1] = 'x';
            }

            else if (mytab[0, 0] == 'o' && mytab[2, 0] == 'o')
            {
                mytab[1, 0] = 'x';
            }
            else if (mytab[0, 1] == 'o' && mytab[2, 1] == 'o')
            {
                mytab[1, 1] = 'x';
            }
            else if (mytab[2, 2] == 'o' && mytab[0, 2] == 'o')
            {
                mytab[1, 2] = 'x';
            }


        }


        //Fonctions de gestion du jeu
        static bool CheckGagne(char[,] mytab, char symbole)
        {
            bool GG = false;
            //Check horizontal
            if (mytab[0, 0] == symbole && mytab[0, 1] == symbole && mytab[0, 2] == symbole)
            {
                GG = true;
            }
            if (mytab[1, 0] == symbole && mytab[1, 1] == symbole && mytab[1, 2] == symbole)
            {
                GG = true;
            }
            if (mytab[2, 0] == symbole && mytab[2, 1] == symbole && mytab[2, 2] == symbole)
            {
                GG = true;
            }

            //Check vertical
            if (mytab[0, 0] == symbole && mytab[1, 0] == symbole && mytab[2, 0] == symbole)
            {
                GG = true;
            }
            if (mytab[0, 1] == symbole && mytab[1, 1] == symbole && mytab[2, 1] == symbole)
            {
                GG = true;
            }
            if (mytab[0, 2] == symbole && mytab[1, 2] == symbole && mytab[2, 2] == symbole)
            {
                GG = true;
            }

            //Check diagonal
            if (mytab[0, 0] == symbole && mytab[1, 1] == symbole && mytab[2, 2] == symbole)
            {
                GG = true;
            }
            if (mytab[0, 2] == symbole && mytab[1, 1] == symbole && mytab[2, 0] == symbole)
            {
                GG = true;
            }

            return GG;
        }
        static bool ChoixRejouer()
        {
            Console.WriteLine("Voulez-vous rejouer ? y/n");
            string choix = Console.ReadLine();
            bool ok = false;
            while (!ok)
            {
                if (choix == "y")
                    return true;
                else if (choix == "n")
                    return false;
                else
                {
                    Console.WriteLine("Veuillez entrer 1 caractères max, y ou n");
                    choix = Console.ReadLine();
                }
            }
            return false;
        }

        public static void Main(string[] args)
        {
            //Création table 3x3
            char[,] plateau = new char[3, 3];
            Remplitab(ref plateau);


            //Variable fin de partie
            bool fin_de_jeux = false;



            while (fin_de_jeux == false)
            {
                //Action Joueur___________________________________________
                Console.WriteLine("A votre tour de jouer");
                Console.WriteLine("Veuillez entrer coordonnée de Ligne et de Colonne");

                Affichetab(plateau);
                string emplacement = Saisie();

                if (!Check_emplacement(plateau,emplacement))
                {
                    Console.WriteLine("Réessayer");
                    emplacement = Saisie();
                    Check_emplacement(plateau, emplacement);
                }
                else
                    Place_pion(ref plateau, emplacement);
               
                //Check recommencer
                if(CheckGagne(plateau, 'o'))
                {
                    Console.WriteLine("Vous avez gagner !");
                    Affichetab(plateau);
                    if (ChoixRejouer())
                    {
                        Console.Clear();
                        Remplitab(ref plateau);
                    }
                    else break;
                }
                //Action BOT___________________________________________
                else
                {
                    Console.WriteLine("Ordinateur joue ...");
                    ActionIAJoueRandom(ref plateau);
                    Affichetab(plateau);
                    //Check recommencer
                    if (CheckGagne(plateau, 'x'))
                    {
                        Console.WriteLine("Ordinateur a gagner ");
                        Affichetab(plateau);

                        if (ChoixRejouer())
                        {
                            Console.Clear();
                            Remplitab(ref plateau);
                        }
                        else break;
                    }
                }
            }

            Console.ReadKey();

        }
    }
}
