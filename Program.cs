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

        //Niveau difficulté de l'IA
        static int SaisieModeDifficulteIA()
        {
            Console.WriteLine("Veuillez choisir le mode de difficulté, \n" +
                                "1) Mode aléatoire \n" +
                                "2) Mode défenssif \n" +
                                "3) Mode offenssif \n");

            string modeIA = Console.ReadLine();
            

            while (modeIA.Length >= 1)
            {
                if (modeIA == "1")
                {
                    return 1;
                }
                else if (modeIA == "2")
                {
                    return 2;
                }
                else if (modeIA == "3")
                {
                    return 3;
                }

                Console.WriteLine("Veuillez entrer 1 caractères max, difficulté 1, 2 ou 3");
                modeIA = Console.ReadLine();
            }
            return 0;
        }
        static void ExeModeIA(int niveau_difficulte, ref char[,] mytab)
        {
            switch (niveau_difficulte)
            {
                case 1:
                    ActionIAJoueRandom(ref mytab);
                    break;
                case 2:
                    ActionOrdiJoueDef(ref mytab);
                    break;
                case 3:
                    ActionOrdiJoueOff(ref mytab);
                    break;
            }
        }
        //Recupère l'emplacement ou l'IA doit jouer
        static string EmplacementGagnant(char[,] mytab, char symbole)
        {
            //Check horizontal
            //Première ligne
            if (mytab[0, 0] == symbole && mytab[0, 1] == symbole && mytab[0, 2] == '.')
            {
                return "02";
            }
            if (mytab[0, 2] == symbole && mytab[0, 1] == symbole && mytab[0, 0] == '.')
            {
                return "00";
            }
            if (mytab[0, 0] == symbole && mytab[0, 2] == symbole && mytab[0, 1] == '.')
            {
                return "01";
            }
            //Deuxième ligne
            if (mytab[1, 0] == symbole && mytab[1, 1] == symbole && mytab[1, 2] == '.')
            {
                return "12";
            }
            if (mytab[1, 2] == symbole && mytab[1, 1] == symbole && mytab[1, 0] == '.')
            {
                return "10";
            }
            if (mytab[1, 0] == symbole && mytab[1, 2] == symbole && mytab[1, 1] == '.')
            {
                return "11";
            }
            //Troisième ligne
            if (mytab[2, 0] == symbole && mytab[2, 1] == symbole && mytab[2, 2] == '.')
            {
                return "22";
            }
            if (mytab[2, 2] == symbole && mytab[2, 1] == symbole && mytab[2, 0] == '.')
            {
                return "20";
            }
            if (mytab[2, 0] == symbole && mytab[2, 2] == symbole && mytab[2, 1] == '.')
            {
                return "21";
            }

            //Check vertical
            //Première colonne
            if (mytab[0, 0] == symbole && mytab[1, 0] == symbole && mytab[2, 0] == '.')
            {
                return "20";
            }
            if (mytab[0, 0] == symbole && mytab[2, 0] == symbole && mytab[1, 0] == '.')
            {
                return "10";
            }
            if (mytab[2, 0] == symbole && mytab[1, 0] == symbole && mytab[0, 0] == '.')
            {
                return "00";
            }
            //Deuxième colonne
            if (mytab[0, 1] == symbole && mytab[1, 1] == symbole && mytab[2, 1] == '.')
            {
                return "21";
            }
            if (mytab[0, 1] == symbole && mytab[2, 1] == symbole && mytab[1, 1] == '.')
            {
                return "11";
            }
            if (mytab[2, 1] == symbole && mytab[1, 1] == symbole && mytab[0, 1] == '.')
            {
                return "01";
            }
            //Troisième colonne
            if (mytab[0, 2] == symbole && mytab[1, 2] == symbole && mytab[2, 2] == '.')
            {
                return "22";
            }
            if (mytab[0, 2] == symbole && mytab[2, 2] == symbole && mytab[1, 2] == '.')
            {
                return "12";
            }
            if (mytab[2, 2] == symbole && mytab[1, 2] == symbole && mytab[0, 2] == '.')
            {
                return "02";
            }

            //Check diagonal
            //Diagonal 00 11 22
            if (mytab[0, 0] == symbole && mytab[1, 1] == symbole && mytab[2, 2] == '.')
            {
                return "22";
            }
            if (mytab[2, 2] == symbole && mytab[1, 1] == symbole && mytab[0, 0] == '.')
            {
                return "00";
            }
            if (mytab[0, 0] == symbole && mytab[2, 2] == symbole && mytab[1, 1] == '.')
            {
                return "11";
            }
            //Diagonal 02 11 20
            if (mytab[0, 2] == symbole && mytab[1, 1] == symbole && mytab[2, 0] == '.')
            {
                return "20";
            }
            if (mytab[2, 0] == symbole && mytab[1, 1] == symbole && mytab[0, 2] == '.')
            {
                return "02";
            }
            if (mytab[0, 2] == symbole && mytab[2, 0] == symbole && mytab[1, 1] == '.')
            {
                return "11";
            }

            return "pas_de_coup_gagnant";
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
        // IA Empêche le joueur de gagner
        static void ActionOrdiJoueDef(ref char[,] mytab)
        {
            string coupIA = EmplacementGagnant(mytab, 'o');

            if (coupIA == "pas_de_coup_gagnant")
            {
                ActionIAJoueRandom(ref mytab);
            }
            else
            {
                int ligne = (int)Char.GetNumericValue(coupIA[0]);
                int colonne = (int)Char.GetNumericValue(coupIA[1]);
                mytab[ligne, colonne] = 'x';
            }
        }
        // IA Cherche a gagner a tout prix
        static void ActionOrdiJoueOff(ref char[,] mytab)
        {
            string joueurGagne = EmplacementGagnant(mytab, 'o');
            string iaGagne = EmplacementGagnant(mytab, 'x');

            if (mytab[1,1] == '.')
            {
                mytab[1, 1] = 'x';
            }
            else if (joueurGagne != "pas_de_coup_gagnant")
            {
                int ligne = (int)Char.GetNumericValue(joueurGagne[0]);
                int colonne = (int)Char.GetNumericValue(joueurGagne[1]);
                mytab[ligne, colonne] = 'x';
            }
            else if (iaGagne != "pas_de_coup_gagnant")
            {
                int ligne = (int)Char.GetNumericValue(iaGagne[0]);
                int colonne = (int)Char.GetNumericValue(iaGagne[1]);
                mytab[ligne, colonne] = 'x';
            }
            else
            {
                ActionIAJoueRandom(ref mytab);
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
            //Variable du mode IA
            int difficulteIA = 0;

            while (fin_de_jeux == false)
            {
                //Choix du mode de l'IA
                if (difficulteIA == 0)
                {
                    difficulteIA = SaisieModeDifficulteIA();
                }
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
                        difficulteIA = 0;
                    }
                    else break;
                }
                //Action BOT___________________________________________
                else
                {
                    Console.WriteLine("Ordinateur joue ...");
                    ExeModeIA(difficulteIA, ref plateau);
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
                            difficulteIA = 0;
                        }
                        else break;
                    }
                }
            }
            Console.WriteLine("Appuyez sur n'importe qu'elle touche pour quitter");
            Console.ReadKey();

        }
    }
}
