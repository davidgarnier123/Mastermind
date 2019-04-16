using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
    class Program
    {
        public static ConsoleKey[] joueurUn = new ConsoleKey[5];
        public static ConsoleKey[] joueurDeux = new ConsoleKey[5];
        static Boolean premierJoueurSaisi(ConsoleKeyInfo saisi)
        {
            if (saisi.Key == ConsoleKey.B || saisi.Key == ConsoleKey.R || saisi.Key == ConsoleKey.N || saisi.Key == ConsoleKey.V || saisi.Key == ConsoleKey.J || saisi.Key == ConsoleKey.O || saisi.Key == ConsoleKey.G) {
                return true;
            }
            else { return false; }

        }
        static Boolean DeuxiemeJoueurSaisi(ConsoleKey saisi, ref int bienplace, ref int malplace)
        {
            for (int i = 0; i < 5; i++) {
                if (joueurDeux[i] == joueurUn[i]) {
                    bienplace++;
                }
                if (saisi == joueurUn[i] && joueurDeux[i] != joueurUn[i])
                {
                    malplace++;
                }

            }

            return true;
        }
        static void Main(string[] args)
        {
          
          ////// debut premier joueur 
                Console.Write("Joueur 1 : ");
                // exemple de positionnement du curseur ligne 1 colonne 10
                Console.SetCursorPosition(20, 0);
                Console.Write("_");
                Console.SetCursorPosition(25, 0);
                Console.Write("_");
                Console.SetCursorPosition(30, 0);
                Console.Write("_");
                Console.SetCursorPosition(35, 0);
                Console.Write("_");
                Console.SetCursorPosition(40, 0);
                Console.Write("_");
                Console.SetCursorPosition(10, 5);
                Console.Write("Les differentes couleurs sont : B / R / N / V / J / O / G");

                ConsoleKeyInfo saisi;
                int iTableau = 0;
                for (int i = 20; i < 45; i = i + 5) {

                    Console.SetCursorPosition(i, 0);
                    saisi = Console.ReadKey();
                    premierJoueurSaisi(saisi);
                    if (premierJoueurSaisi(saisi) == false)
                    {
                        Console.SetCursorPosition(i, 0);
                        Console.Write("_");
                        i = i - 5; //si la saisi n'est pas valable on annule l'iteration +5 pour retourner à la meme etape de la boucle

                    }
                    else
                    {


                        joueurUn[iTableau] = saisi.Key; //saisi des valeurs dans le tableau du premier joueur
                        iTableau = iTableau + 1;



                    }

                }
                Console.Clear();
                /////// end premier joueur 
                ///


                ///début deuxime joueur
                ///
                int ligne = 4; //ligne de depart à incrementer
                int essai = 1;
                /////// debut premier joueur 
                Console.Write("Joueur 2 : ");
                // exemple de positionnement du curseur ligne 1 colonne 10
                Console.SetCursorPosition(20, ligne);
                Console.Write("_");
                Console.SetCursorPosition(25, ligne);
                Console.Write("_");
                Console.SetCursorPosition(30, ligne);
                Console.Write("_");
                Console.SetCursorPosition(35, ligne);
                Console.Write("_");
                Console.SetCursorPosition(40, ligne);
                Console.Write("_");
                Console.SetCursorPosition(0, ligne);
                Console.Write("Essai numero -> " + essai);
                Console.SetCursorPosition(73, 0);
                Console.Write("B / R / N / V / J / O / G");
                Console.SetCursorPosition(73, 1);
                Console.Write("*************************");
                Console.SetCursorPosition(70, 3);
                Console.Write("Bien placé");
                Console.SetCursorPosition(90, 3);
                Console.Write("Mal placé");

                int bienplace = 0;
                int malplace = 0;
                Boolean victoire = false;
                do
                {


                    // exemple de positionnement du curseur ligne 1 colonne 10
                    Console.SetCursorPosition(20, ligne);
                    Console.Write("_");
                    Console.SetCursorPosition(25, ligne);
                    Console.Write("_");
                    Console.SetCursorPosition(30, ligne);
                    Console.Write("_");
                    Console.SetCursorPosition(35, ligne);
                    Console.Write("_");
                    Console.SetCursorPosition(40, ligne);
                    Console.Write("_");
                    Console.SetCursorPosition(0, ligne);
                    Console.Write("Essai numero -> " + essai);
                    iTableau = 0;
                    for (int i = 20; i < 45; i = i + 5)
                    {

                        Console.SetCursorPosition(i, ligne);
                        saisi = Console.ReadKey();
                        premierJoueurSaisi(saisi);
                        if (premierJoueurSaisi(saisi) == false)
                        {
                            Console.SetCursorPosition(i, ligne);
                            Console.Write("_");
                            i = i - 5; //si la saisi n'est pas valable on annule l'iteration +5 pour retourner à la meme etape de la boucle

                        }
                        else
                        {


                            joueurDeux[iTableau] = saisi.Key; //saisi des valeurs dans le tableau du deuxieme joueur
                            iTableau = iTableau + 1;



                        }


                    }
                    bienplace = 0;
                    malplace = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        DeuxiemeJoueurSaisi(joueurDeux[i], ref bienplace, ref malplace);
                    }


                    if (bienplace == 25)
                    {
                        Console.SetCursorPosition(25, (ligne + 5));
                        Console.WriteLine("victoire en " + essai + " essai(s)");
                    if (essai <= 5) { Console.WriteLine("Formidable, tres fort ! ;)"); }
                    if (essai > 5 && essai < 15) { Console.WriteLine("Pas mal du tout ! ;)"); }
                    if (essai >= 15) { Console.WriteLine("Il te faut encore un peu d'entrainement... :("); }
                    victoire = true;
                    }
                    else
                    {
                        Console.SetCursorPosition(75, ligne);
                        Console.WriteLine((bienplace / 5));
                        Console.SetCursorPosition(94, ligne);
                        Console.WriteLine(malplace);
                        essai++;
                        ligne++;
                    }
                } while (victoire == false);
                ////Fin deuxieme joueur
                ///
                Console.Read();
             
               
    }
    }
}