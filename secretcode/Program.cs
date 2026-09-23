/******************************************************************************
** PROGRAMME  Program.cs                                                     **
**                                                                           **
** Lieu      : ETML - section informatique                                   **
** Auteur    : PT74BSX                                                       **
** Date      : 28.08.2025  |  30.10.2025                                     **
**                                                                           **
** Modifications                                                             **
**   Auteur  :                                                               **
**   Version : X.X                                                           **
**   Date    :                                                               **
**   Raisons :                                                               **
**                                                                           **
**                                                                           **
******************************************************************************/

/******************************************************************************
** DESCRIPTION                                                               **
** Petit programme permettant de deviner un code secret de 4 chiffres en	 **     
** mode console avec plusieurs niveaux de difficultées.             	     **
**                                                                           **
******************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace secretcode_pt74bsx
{
    internal class Program
    {   /* ____________________________________________________________________________________________________________________________________
           |___________________________________________________ Déclarations des constantes __________________________________________________|                                                                                                                                                         */
        // CONSTANTES DE PARAMÈTRE                               
        const int MAX_TRIES = 10;                           // Nombre d'essais maximum
        const int CODE_LENGTH = 4;                          // Longueur du code || ⚠ NE PAS MODIFIER LE PROGRAMME EST PRÉVU QUE POUR UNE LONGUEUR DE 4 CHIFFRES
        const int ADMIN_PASSWORD = 1111;                    // Code du mode admin 
        const string PROGRAM_NAME = "Secret Code";          // Nom du programme
        // Constantes niveau 1 et 2
        const int LV1_LV2_MIN = 1;                          // Chiffre minimum dans le code secret
        const int LV1_LV2_MAX = 6;                          // Chiffre maximum dans le code secret 
        // Constantes niveau 3                              
        const int LV3_MIN = 1;
        const int LV3_MAX = 8;
        // Constantes niveau 4                              
        const int LV4_MIN = 1;
        const int LV4_MAX = 9;

        static async Task Main(string[] args)
        {   /* _______________________________________________________________________________________________________________________
               |__________________________________________________ Déclarations des variables _______________________________________|                                                                                                                                                                     */
            // VARIABLES AUTOMATIQUE 
            int choice = 0;                                                                                             // Stocke le niveau sélectionné
            int numberTry = 1;                                                                                          // Stocke le nombre d’essais
            int randomCodeOne = 1111, randomCodeTwo = 1111, randomCodeLv3 = 1111, randomCodeLv4 = 1111;
            bool choiceValide = false;                                                                                  // Permet d’accéder à la suite quand la variable passe à true
            char restartAnswer = 'X';                                                                                   // Gère l’état du relancement du programme

            /* __________________________________________________________________________________________________________________________
               |__________________________________________________ Configuration de la fenêtre _________________________________________|                                                                                                                                                                  */
            Console.Title = PROGRAM_NAME;                                                   // Titre de la fenêtre
            Console.SetWindowSize(100, 30);                                                 // Taille de la fenêtre
            /* __________________________________________________________________________________________________________________________
               |__________________________________________________ Programme principal _________________________________________________|                                                                                                                                                                     */
            do
            {   /*  _________________________________________________________________________________
                   |  Déclaration des variables qui doivent être reset à chaque restart du programme | 
                    ---------------------------------------------------------------------------------                                                                                                                                                                                                      */
                // Gestion du mode admin 
                bool adminMode = true;                              // Mode admin 
                bool showCode = false;                              // Gère l'affichage du code secret

                // Accueil 
                Console.Clear();
                Console.WriteLine(" ╔══════════════════ PT74BSX ═══════════════╗");
                Console.WriteLine(" ║                                          ║");
                Console.WriteLine(" ║    Bienvenue dans le jeu : " + PROGRAM_NAME + "   ║");
                Console.WriteLine(" ║                                          ║");
                Console.WriteLine(" ╚══════════════════════════════════════════╝");

                // Explication des règles du programme
                Console.WriteLine("\n Un code secret composé de " + CODE_LENGTH + " chiffres est généré." +
                    "\n À toi de le découvrir en " + MAX_TRIES + " essais maximum !" +
                    "\n\n À chaque essai, tu reçois un indice selon le niveau choisi.");

                // Explication du niveau 1 et 3
                Console.WriteLine(" Pour les niveaux 1 et 3 avec indices visibles :");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n ■");
                Console.ResetColor();
                Console.Write(" : chiffre bien placé");

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\n ■");
                Console.ResetColor();
                Console.Write(" : chiffre correct mais mal placé");

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\n ■");
                Console.ResetColor();
                Console.Write(" : chiffre absent");
                Console.WriteLine("");

                Console.Write("\n Exemple : " +
                    "\n Code secret : 1234 (caché) " +
                    "\n Votre essai : 1325 " +
                    "\n Indice      :");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("\n ■");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" ■");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(" ■");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(" ■");
                Console.ResetColor();

                Console.Write("  (1 bien placé, 2 mal placés, 1 absent)");
                Console.WriteLine("");

                // Explication du niveau 2 et 4
                Console.WriteLine("");
                Console.WriteLine(" Pour les niveaux 2 et 4 avec indices discrets :" +
                    "\n Exemple :" +
                    "\n Code secret : 5413 (caché)" +
                    "\n Votre essai : 1234" +
                    "\n Indice :");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("  → 0 bien placé(s), 3 mal placé(s)");
                Console.WriteLine("");
                Console.ResetColor();
                Console.WriteLine("");

                Console.WriteLine("");
                Console.WriteLine(" Creat by PT74BSX - https://github.com/Pt74bsx");
                Console.WriteLine("");

                // Accéder à la sélection du niveau 
                Console.WriteLine(" Appuie sur une touche pour commencer...");
                Console.ReadKey(true);
                Console.Clear();

                /* __________________________________________________________________________________________________________________________
                   |__________________________________________________ Selection du mode de jeux ___________________________________________|                                                                                                                                                                                                                                                                               */
                Console.WriteLine(" === " + PROGRAM_NAME + " ===\n");
                Console.WriteLine(" Choisi un niveau : ");
                Console.WriteLine(" 1. Débutant      (" + LV1_LV2_MIN + " à " + LV1_LV2_MAX + ", sans doublons, indices visibles)");
                Console.WriteLine(" 2. Intermédiaire (" + LV1_LV2_MIN + " à " + LV1_LV2_MAX + ", sans doublons, indices discrets)");
                Console.WriteLine(" 3. Avancé        (" + LV3_MIN + " à " + LV3_MAX + ", avec doublons, indices visibles)");
                Console.WriteLine(" 4. Expert        (" + LV4_MIN + " à " + LV4_MAX + ", avec doublons, indices discrets)\n");

                // Tant que le choix n’est pas valide, on répète
                while (!choiceValide)
                {
                    Console.Write(" Votre choix (1-4) : ");
                    string inputChoice = Console.ReadLine();

                    // Si la conversion réussit
                    if (int.TryParse(inputChoice, out choice))
                    {
                        // Si l'entrée du joueur est plus grande ou égale à 1 et plus petite ou égale à 4
                        if (choice >= 1 && choice <= 4)
                        {
                            choiceValide = true;                                                                // On valide le choix 
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;                                         // Couleur rouge
                            Console.WriteLine("\n [ERREUR] Veuillez entrer un chiffre entre 1 et 4.\n");        // Message d'erreur
                            Console.ResetColor();                                                               // Retour à la couleur de base
                        }
                    }
                    // Si la conversion a échoué
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n [ERREUR] Veuillez entrer un chiffre et non une lettre.\n");
                        Console.ResetColor();
                    }
                }

                /* __________________________________________________________________________________________________________________________
                  |__________________________________________________ Niveau _______________________________________________________________|                                                                                                                                                                                                                                                                            */
                switch (choice)
                {
                    // ---------------------------------------------- Niveau Débutant --------------------------------------------------
                    case 1:
                        Console.WriteLine(" Vous avez choisi Débutant !");
                        await Task.Delay(1000);                                                                                         // Attend 1 seconde
                        Console.Clear();                                                                                                // Console effacée

                        int[] tblSecretDigitsLv1;                                                                                       // Déclaration d'un tableau
                        // Génération du code avec la méthode
                        randomCodeOne = GenerateSecretCode(LV1_LV2_MIN, LV1_LV2_MAX, false, out tblSecretDigitsLv1);
                        // Créer une liste de tentatives
                        List<int> attempts = new List<int>();
                        bool codeFound = false;                                                                                         // Remet le code en pas trouvé

                        // Jeux 
                        for (numberTry = 1; numberTry <= MAX_TRIES; numberTry++)                                                        // Boucle qui se répète tant que le nombre de tentatives est plus petit ou égal au nombre d’essais maximum
                        {
                            Console.Clear();
                            Console.WriteLine(" === SECRET CODE Niveau 1 ===\n");
                            // Appelle de la métode du mode admin
                            showCode = AdminMode(showCode, adminMode, 1, randomCodeOne, randomCodeTwo, randomCodeLv3, randomCodeLv4);
                            adminMode = false;
                            // Appelle de la métode qui affiche les tentatives
                            DisplayAttempts(attempts, tblSecretDigitsLv1, true);


                            Console.WriteLine($" Essai {numberTry}/{MAX_TRIES} :");
                            Console.Write($"\n Entre {CODE_LENGTH} chiffres différents entre {LV1_LV2_MIN} et {LV1_LV2_MAX} (ex: 1234) : ");
                            string input = Console.ReadLine();

                            // Si la métode "IsValidInput" ne réussis pas 
                            if (!IsValidInput(input, LV1_LV2_MIN, LV1_LV2_MAX))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\n [ERREUR] Entrée invalide : chiffres uniques entre {LV1_LV2_MIN} et {LV1_LV2_MAX}.\n");           // Message d'erreur
                                await Task.Delay(1500);                                                                                                 // Pause de 1,50sec
                                Console.ResetColor();

                                numberTry--;                                                                                                            // On enlève 1 aux tentatives
                                continue;
                            }

                            int intUserInput = int.Parse(input);
                            attempts.Add(intUserInput);                                                                                                 // Ajoute l'entrée du joueur aux tentatives

                            // Si l'entrée de l'utilisateur est égale au code secret
                            if (intUserInput == randomCodeOne)
                            {
                                Console.Clear();
                                Console.WriteLine(" === SECRET CODE Niveau 1 ===\n");
                                // Affichage du code si le mode admin est actif
                                showCode = AdminMode(showCode, adminMode, 1, randomCodeOne, randomCodeTwo, randomCodeLv3, randomCodeLv4);
                                // Affiche les tentatives
                                DisplayAttempts(attempts, tblSecretDigitsLv1, true);

                                // Message de bravo
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($" Bravo ! Tu as trouvé le code en {numberTry} essai(s) !");
                                Console.ResetColor();

                                // Appelle de la métode pour relancer le programme 
                                restartAnswer = RestartProgramme(restartAnswer);
                                codeFound = true;
                                break;
                            }
                        }

                        // Si le code n'est pas trouvé
                        if (!codeFound)
                        {
                            Console.Clear();
                            Console.WriteLine(" === SECRET CODE Niveau 1 ===\n");
                            // Affichage du code si le mode admin est actif 
                            showCode = AdminMode(showCode, adminMode, 1, randomCodeOne, randomCodeTwo, randomCodeLv3, randomCodeLv4);
                            // Affiche les tentatives
                            DisplayAttempts(attempts, tblSecretDigitsLv1, true);

                            // Message d'écheque 
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\n Perdu ! Le code était : {randomCodeOne}");
                            Console.ResetColor();

                            // Appelle la métode pour relancer le programme 
                            restartAnswer = RestartProgramme(restartAnswer);
                        }

                        // Remet les variables de base 
                        choiceValide = false;
                        numberTry = 1;
                        break;

                    // ----------------------------------------------------------- Niveau Intermédiaire ---------------------------------------------------------
                    case 2:
                        Console.WriteLine(" Vous avez choisi Intermédiaire !");
                        await Task.Delay(1000);                                                                                                 // Pause de 1sec
                        Console.Clear();

                        // Génération du code secret sans doublons
                        int[] tblSecretDigitsLv2;
                        randomCodeTwo = GenerateSecretCode(LV1_LV2_MIN, LV1_LV2_MAX, false, out tblSecretDigitsLv2);
                        // Création d'une liste pour les tentatives
                        List<int> attemptsLv2 = new List<int>();
                        bool codeFoundLv2 = false;

                        for (numberTry = 1; numberTry <= MAX_TRIES; numberTry++)
                        {
                            Console.Clear();
                            Console.WriteLine(" === SECRET CODE Niveau 2 ===\n");
                            showCode = AdminMode(showCode, adminMode, 2, randomCodeOne, randomCodeTwo, randomCodeLv3, randomCodeLv4);
                            adminMode = false;
                            Console.WriteLine(" Essais :\n");

                            // Affiche toutes les tentatives avec leurs indices
                            DisplayAttempts(attemptsLv2, tblSecretDigitsLv2, false);
                            Console.WriteLine(" Essai " + numberTry + "/" + MAX_TRIES + " :");
                            Console.Write($"\n Entre {CODE_LENGTH} chiffres différents entre {LV1_LV2_MIN} et {LV1_LV2_MAX} (ex: 1234) : ");
                            string input = Console.ReadLine();

                            if (IsValidInput(input, LV1_LV2_MIN, LV1_LV2_MAX) && int.TryParse(input, out int tryTwo))
                            {
                                attemptsLv2.Add(tryTwo);

                                if (tryTwo == randomCodeTwo)
                                {
                                    Console.Clear();
                                    Console.WriteLine(" === SECRET CODE Niveau 2 ===\n");
                                    showCode = AdminMode(showCode, adminMode, 2, randomCodeOne, randomCodeTwo, randomCodeLv3, randomCodeLv4);
                                    Console.WriteLine(" Essais :\n");

                                    // Affichage des essais
                                    for (int i = 0; i < attemptsLv2.Count; i++)
                                    {
                                        Console.WriteLine($" {i + 1}: {attemptsLv2[i]}");
                                        if (i == attemptsLv2.Count - 1)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.WriteLine("    → 4 bien placé(s), 0 mal placé(s)");
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            DisplayHint(attemptsLv2[i], tblSecretDigitsLv2, false);
                                        }
                                    }

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($" Bravo ! Tu as trouvé le code en {numberTry} essai(s) !");
                                    Console.ResetColor();

                                    restartAnswer = RestartProgramme(restartAnswer);
                                    codeFoundLv2 = true;
                                    break;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\n [ERREUR] Veuillez entrer un nombre à {CODE_LENGTH} chiffres valide, sans doublons, entre {LV1_LV2_MIN} et {LV1_LV2_MAX}.\n");
                                await Task.Delay(1500);
                                Console.ResetColor();
                                numberTry--;
                            }
                        }

                        if (!codeFoundLv2)
                        {
                            Console.Clear();
                            Console.WriteLine(" === SECRET CODE Niveau 2 ===\n");
                            showCode = AdminMode(showCode, adminMode, 2, randomCodeOne, randomCodeTwo, randomCodeLv3, randomCodeLv4);
                            Console.WriteLine(" Essais :");

                            for (int i = 0; i < attemptsLv2.Count; i++)
                            {
                                Console.WriteLine($" {i + 1}: {attemptsLv2[i]}");
                                DisplayHint(attemptsLv2[i], tblSecretDigitsLv2, false);
                            }

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\n Perdu ! Le code était : {randomCodeTwo}");
                            Console.ResetColor();

                            restartAnswer = RestartProgramme(restartAnswer);
                        }

                        choiceValide = false;
                        numberTry = 1;
                        break;

                    // ------------------------------------------------------ Niveau Avancé --------------------------------------------------------
                    case 3:
                        Console.WriteLine(" Vous avez choisi Avancé !");
                        await Task.Delay(1000);
                        Console.Clear();

                        // Génération du code avec doublons autorisés
                        int[] tblSecretDigitsLv3;
                        randomCodeLv3 = GenerateSecretCode(LV3_MIN, LV3_MAX, true, out tblSecretDigitsLv3);
                        List<int> attemptsLv3 = new List<int>();
                        bool codeFoundLv3 = false;

                        for (numberTry = 1; numberTry <= MAX_TRIES; numberTry++)
                        {
                            Console.Clear();
                            Console.WriteLine(" === SECRET CODE Niveau 3 ===\n");
                            showCode = AdminMode(showCode, adminMode, 3, randomCodeOne, randomCodeTwo, randomCodeLv3, randomCodeLv4);
                            adminMode = false;
                            Console.WriteLine(" Essais :\n");

                            // Affiche toutes les tentatives précédentes
                            DisplayAttempts(attemptsLv3, tblSecretDigitsLv3, true);

                            Console.WriteLine($" Essai {numberTry}/{MAX_TRIES} :");
                            Console.Write($"\n Entre {CODE_LENGTH} chiffres entre {LV3_MIN} et {LV3_MAX} (ex: 1234) : ");

                            string inputLv3 = Console.ReadLine();

                            if (IsValidInput(inputLv3, LV3_MIN, LV3_MAX, allowDuplicates: true) && int.TryParse(inputLv3, out int tryLv3))
                            {
                                attemptsLv3.Add(tryLv3);

                                if (tryLv3 == randomCodeLv3)
                                {
                                    Console.Clear();
                                    Console.WriteLine(" === SECRET CODE Niveau 3 ===\n");
                                    showCode = AdminMode(showCode, adminMode, 3, randomCodeOne, randomCodeTwo, randomCodeLv3, randomCodeLv4);
                                    Console.WriteLine(" Essais :\n");

                                    for (int i = 0; i < attemptsLv3.Count; i++)
                                    {
                                        Console.WriteLine($" {i + 1}: {attemptsLv3[i]}");
                                        if (i == attemptsLv3.Count - 1)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine("    ■■■■");
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            DisplayHint(attemptsLv3[i], tblSecretDigitsLv3, true);
                                        }
                                    }

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($" Bravo ! Tu as trouvé le code en {numberTry} essai(s) !");
                                    Console.ResetColor();

                                    restartAnswer = RestartProgramme(restartAnswer);
                                    codeFoundLv3 = true;
                                    break;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\n [ERREUR] Entrée invalide, entre {CODE_LENGTH} chiffres valides entre {LV3_MIN} et {LV3_MAX}.\n");
                                await Task.Delay(1500);
                                Console.ResetColor();
                                numberTry--;
                            }
                        }

                        if (!codeFoundLv3)
                        {
                            Console.Clear();
                            Console.WriteLine(" === SECRET CODE Niveau 3 ===\n");
                            showCode = AdminMode(showCode, adminMode, 3, randomCodeOne, randomCodeTwo, randomCodeLv3, randomCodeLv4);
                            Console.WriteLine(" Essais :\n");

                            for (int i = 0; i < attemptsLv3.Count; i++)
                            {
                                Console.WriteLine($" {i + 1}: {attemptsLv3[i]}");
                                DisplayHint(attemptsLv3[i], tblSecretDigitsLv3, true);
                            }

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\n Perdu ! Le code était : {randomCodeLv3}");
                            Console.ResetColor();

                            restartAnswer = RestartProgramme(restartAnswer);
                        }

                        choiceValide = false;
                        numberTry = 1;
                        break;


                    // ----------------------------------------------------- Niveau Expert --------------------------------------------------
                    case 4:
                        Console.WriteLine(" Vous avez choisi Expert !");
                        await Task.Delay(1000);
                        Console.Clear();

                        // Génération du code secret avec doublons autorisés (chiffres entre LV4_MIN et LV4_MAX)
                        int[] tblSecretDigitsLv4;
                        randomCodeLv4 = GenerateSecretCode(LV4_MIN, LV4_MAX, true, out tblSecretDigitsLv4);
                        List<int> attemptsLv4 = new List<int>();
                        bool codeFoundLv4 = false;

                        for (numberTry = 1; numberTry <= MAX_TRIES; numberTry++)
                        {
                            Console.Clear();
                            Console.WriteLine(" === SECRET CODE Niveau 4 ===\n");
                            showCode = AdminMode(showCode, adminMode, 4, randomCodeOne, randomCodeTwo, randomCodeLv3, randomCodeLv4);
                            adminMode = false;
                            Console.WriteLine("\n Essais :\n");
                            DisplayAttempts(attemptsLv4, tblSecretDigitsLv4, false);

                            Console.WriteLine("\n Essai " + numberTry + "/" + MAX_TRIES + " :");
                            Console.Write($" Entre {CODE_LENGTH} chiffres entre {LV4_MIN} et {LV4_MAX} (ex: 1234) : ");

                            string inputLv4 = Console.ReadLine();

                            // Utilisation de IsValidInput avec doublons autorisés
                            if (IsValidInputLevel4(inputLv4, LV4_MIN, LV4_MAX))
                            {
                                int tryLv4 = int.Parse(inputLv4);

                                attemptsLv4.Add(tryLv4);

                                if (tryLv4 == randomCodeLv4)
                                {
                                    Console.Clear();
                                    Console.WriteLine(" === SECRET CODE Niveau 4 ===\n");
                                    showCode = AdminMode(showCode, adminMode, 4, randomCodeOne, randomCodeTwo, randomCodeLv3, randomCodeLv4);
                                    Console.WriteLine(" Essais :\n");

                                    for (int i = 0; i < attemptsLv4.Count; i++)
                                    {
                                        Console.WriteLine(" " + (i + 1) + ": " + attemptsLv4[i]);
                                        if (i == attemptsLv4.Count - 1)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.WriteLine("    → 4 bien placé(s), 0 mal placé(s)");
                                            Console.ResetColor();
                                        }
                                        else
                                        {
                                            DisplayHint(attemptsLv4[i], tblSecretDigitsLv4, false);
                                        }
                                    }

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("\n Bravo ! Tu as trouvé le code en " + numberTry + " essai(s) !");
                                    Console.ResetColor();

                                    restartAnswer = RestartProgramme(restartAnswer);
                                    codeFoundLv4 = true;
                                    break;
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"\n [ERREUR] Veuillez entrer un nombre à {CODE_LENGTH} chiffres valides entre {LV4_MIN} et {LV4_MAX}.\n");
                                await Task.Delay(1500);
                                Console.ResetColor();
                                numberTry--;
                            }
                        }

                        if (!codeFoundLv4)
                        {
                            Console.Clear();
                            Console.WriteLine(" === SECRET CODE Niveau 4 ===\n");
                            showCode = AdminMode(showCode, adminMode, 4, randomCodeOne, randomCodeTwo, randomCodeLv3, randomCodeLv4);
                            Console.WriteLine(" Essais :");

                            DisplayAttempts(attemptsLv4, tblSecretDigitsLv4, false);

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n Perdu ! Le code était : " + randomCodeLv4);
                            Console.ResetColor();

                            restartAnswer = RestartProgramme(restartAnswer);
                        }

                        choiceValide = false;
                        numberTry = 1;
                        break;
                }

            } while (restartAnswer == 'o' || restartAnswer == 'O');

        }
        // -------------------------------------------------- Méthodes ------------------------------------------
        /// <summary>
        /// Méthode pour générer le code secret
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="allowDuplicates"></param>
        /// <param name="digits"></param>
        /// <returns></returns>
        static int GenerateSecretCode(int min, int max, bool allowDuplicates, out int[] digits)
        {
            Random rdm = new Random();
            digits = new int[4];

            if (allowDuplicates)
            {
                // Pour niveaux 3 et 4 (avec doublons)
                for (int i = 0; i < 4; i++)
                {
                    digits[i] = rdm.Next(min, max + 1);
                }
            }
            else
            {
                // Pour niveaux 1 et 2 (sans doublons)
                digits[0] = rdm.Next(min, max + 1);

                do { digits[1] = rdm.Next(min, max + 1); }
                while (digits[1] == digits[0]);

                do { digits[2] = rdm.Next(min, max + 1); }
                while (digits[2] == digits[0] || digits[2] == digits[1]);

                do { digits[3] = rdm.Next(min, max + 1); }
                while (digits[3] == digits[0] || digits[3] == digits[1] || digits[3] == digits[2]);
            }

            return digits[0] * 1000 + digits[1] * 100 + digits[2] * 10 + digits[3];
        }

        /// <summary>
        /// Méthode pour afficher les indices
        /// </summary>
        /// <param name="attempt"></param>
        /// <param name="secretDigits"></param>
        /// <param name="visualMode"></param>
        static void DisplayHint(int attempt, int[] secretDigits, bool visualMode)
        {
            int[] attemptDigits = {
                attempt / 1000,
                (attempt / 100) % 10,
                (attempt / 10) % 10,
                attempt % 10
            };

            if (visualMode)
            {
                bool[] secretUsed = new bool[4];
                bool[] attemptUsed = new bool[4];
                Console.Write("    ");

                // Première passe : bien placés (bleus)
                for (int i = 0; i < 4; i++)
                {
                    if (attemptDigits[i] == secretDigits[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("■");
                        Console.ResetColor();
                        secretUsed[i] = true;
                        attemptUsed[i] = true;
                    }
                    else
                    {
                        // On laisse un placeholder pour la deuxième passe
                        Console.Write(" ");
                    }
                }

                // Seconde passe : mal placés (verts) et absents (gris)
                for (int i = 0; i < 4; i++)
                {
                    if (attemptUsed[i]) continue; // déjà bien placé

                    bool found = false;
                    for (int j = 0; j < 4; j++)
                    {
                        if (!secretUsed[j] && attemptDigits[i] == secretDigits[j])
                        {
                            found = true;
                            secretUsed[j] = true;
                            break;
                        }
                    }
                    Console.SetCursorPosition(4 + i, Console.CursorTop); // revenir à la bonne position
                    if (found)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("■");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write("■");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();
            }
            else
            {
                // Mode textuel (niveaux 2 et 4) - inchangé
                int bienPlaces = 0;
                int malPlaces = 0;
                bool[] secretUsed = new bool[4];
                bool[] attemptUsed = new bool[4];

                // Compter les bien placés
                for (int i = 0; i < 4; i++)
                {
                    if (attemptDigits[i] == secretDigits[i])
                    {
                        bienPlaces++;
                        secretUsed[i] = true;
                        attemptUsed[i] = true;
                    }
                }

                // Compter les mal placés
                for (int i = 0; i < 4; i++)
                {
                    if (!attemptUsed[i])
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (!secretUsed[j] && attemptDigits[i] == secretDigits[j])
                            {
                                malPlaces++;
                                secretUsed[j] = true;
                                break;
                            }
                        }
                    }
                }

                // Afficher le résultat
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("    → ");
                Console.Write($"{bienPlaces} bien placé(s)");
                Console.ResetColor();
                Console.Write(", ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{malPlaces} mal placé(s)");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Méthode pour recommencer le programme
        /// </summary>
        /// <param name="restartAnswer"></param>
        /// <returns></returns>
        static char RestartProgramme(char restartAnswer)
        {
            bool validAnswer = false;
            while (!validAnswer)
            {
                Console.Write("\n Veux-tu recommencer ? (o / n) : ");
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);
                char inputChar = keyInfo.KeyChar;

                if (inputChar == 'o' || inputChar == 'O' || inputChar == 'n' || inputChar == 'N')
                {
                    restartAnswer = inputChar;
                    validAnswer = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n [ERREUR] Saisi 'o' pour recommencer ou 'n' pour quitter.\n");
                    System.Threading.Thread.Sleep(1500);
                    Console.ResetColor();
                }
                if (inputChar == 'n' || inputChar == 'N')
                {
                    Console.WriteLine("\n Merci d'avoir utilisé le programme");
                }
            }
            return restartAnswer;
        }

        /// <summary>
        /// Metode qui vérifie si l'entrée de l'utilisatuer est correct
        /// </summary>
        /// <param name="input"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="allowDuplicates"></param>
        /// <returns></returns>
        static bool IsValidInput(string input, int min, int max, bool allowDuplicates = false)
        {
            if (input.Length != 4 || !int.TryParse(input, out _))                                   // Si l'entrée est de 4 de longeur ou que la conversion ne réussis pas
                return false;                                                                       // Il retourne faux

            int[] digits = new int[4];                                                              // Tableau
            for (int i = 0; i < input.Length; i++)
            {
                digits[i] = input[i] - '0';
            }

            if (!allowDuplicates)
            {
                // Vérifier doublons
                for (int i = 0; i < digits.Length; i++)
                {
                    for (int j = i + 1; j < digits.Length; j++)
                    {
                        if (digits[i] == digits[j])
                            return false;
                    }
                }
            }
            // Vérifier plage
            foreach (var d in digits)
            {
                if (d < min || d > max)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Affichage des essaye
        /// </summary>
        /// <param name="attempts"></param>
        /// <param name="secretDigits"></param>
        /// <param name="visualMode"></param>
        static void DisplayAttempts(List<int> attempts, int[] secretDigits, bool visualMode)
        {
            //Console.WriteLine(" Essais :\n");
            for (int i = 0; i < attempts.Count; i++)
            {
                Console.WriteLine($" {(i + 1)}: {attempts[i]}");
                DisplayHint(attempts[i], secretDigits, visualMode);
            }
        }

        /// <summary>
        /// Métode pour vérifier que l'entrée de l'utilisateur est correct
        /// </summary>
        /// <param name="input"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        static bool IsValidInputLevel4(string input, int min, int max)
        {
            if (input.Length != 4 || !int.TryParse(input, out _))               // Si l'entrée fais 4 chiffres ou que la conversion ne réussis pas
                return false;

            foreach (char c in input)                                           // Boucle qui fais que une execution 
            {
                int digit = c - '0';
                if (digit < min || digit > max)                                 // Si chaque chiffre est plus petit que le minimum ou plus grand que le maximum
                    return false;                                               // Il retourne faux
            }
            return true;                                                        // Si la boucle a rien retournée il renvois vrai
        }

        /// <summary>
        /// Metode qui permet de vérifier et afficher le code si le mode admin est activé
        /// </summary>
        /// <param name="adminMode"></param>
        /// <param name="randomCodeLv4"></param>
        /// <returns></returns>
        static bool AdminMode(bool showCode, bool adminMode, int niveau, int randomCodeOne, int randomCodeTwo, int randomCodeLv3, int randomCodeLv4)
        {
            if (adminMode && !showCode)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" !!MOT DE PASSE POUR ACTIVER LE MODE ADMIN : ");
                if (int.TryParse(Console.ReadLine(), out int inputMdpAdmin) && inputMdpAdmin == ADMIN_PASSWORD)
                {
                    Console.Clear();
                    Console.ResetColor();
                    showCode = true;
                    Console.WriteLine($" === SECRET CODE Niveau {niveau} ===\n");
                }
                else
                {
                    Console.WriteLine("\n Invalide mode admin lock !");
                    Thread.Sleep(1500);
                    showCode = false;
                    Console.Clear();
                    Console.ResetColor();
                    Console.WriteLine($" === SECRET CODE Niveau {niveau} ===\n");
                }
                Console.ResetColor();
            }
            if (showCode)
            {
                Console.Write(" Code secret -> ");
                Console.ForegroundColor = ConsoleColor.Green;

                switch (niveau)
                {
                    case 1:
                        Console.Write(randomCodeOne + "\n");
                        break;
                    case 2:
                        Console.Write(randomCodeTwo + "\n");
                        break;
                    case 3:
                        Console.Write(randomCodeLv3 + "\n");
                        break;
                    case 4:
                        Console.Write(randomCodeLv4 + "\n");
                        break;
                }
                Console.ResetColor();
            }
            return showCode;
        }
    }
}
/*
                             *   ________) _____ __     __) 
                          (, /      (, /  (, /|  /    
                            /___,     /     / | /     
                         ) /      ___/__ ) /  |/      
                        (_/     (__ /   (_/   '       

*/
