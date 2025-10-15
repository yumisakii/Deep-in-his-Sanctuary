using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoggyPerseus
{
    internal class UF // Useful Functions
    {
        public static void WriteInColor(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static int MakeChoice(int num)
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                // Convertir la touche en nombre si c'est entre 1 et num
                int choice = 0;
                if (keyInfo.Key >= ConsoleKey.D1 && keyInfo.Key <= ConsoleKey.D9)
                    choice = keyInfo.Key - ConsoleKey.D0;
                else if (keyInfo.Key >= ConsoleKey.NumPad1 && keyInfo.Key <= ConsoleKey.NumPad9)
                    choice = keyInfo.Key - ConsoleKey.NumPad0;

                if (choice >= 1 && choice <= num)
                    return choice;

                Console.WriteLine($"Choose a number between 1 and {num}, try again.\n");
            }
        }
    }
}
