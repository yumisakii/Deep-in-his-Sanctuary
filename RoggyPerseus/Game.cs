using System;
using System.Text.Json;

class Game
{
    private static int coin;

    static void Main()
    {
        Connexion();
        //Menu();
    }

    private static void Connexion()
    {
        Console.Write(
        "\n--Connexion--" +
        "\n1 - Connexion" +
        "\n2 - Create Account" +
        "\n3 - Quit\n");

        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            //Connexion
        }
        else if (choice == 2)
        {
            //Create Account
        }
        else if (choice == 3)
        {
            //Quit
            Console.WriteLine("\nBye byeee <3");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Choose a number between 1 and 3.");
            Connexion();
        }
    }

    private static void Menu()
    {
        Console.Write(
        "\n--MENU--" +
        "\n1 - New Game" +
        "\n2 - Continue" +
        "\n4 - Save" +
        "\n5 - Quit\n");

        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            //Start New game
            PlayGame();

        }
        else if (choice == 2)
        {
            //Continue
            PlayGame();
        }
        else if (choice == 3)
        {
            //Stats
            Console.WriteLine($"You have {coin} coins.\n");
            Menu();

        }
        else if (choice == 4)
        {
            //Save

        }
        else if (choice == 5)
        {
            //Quit
            Console.WriteLine("Bye byeee <3");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Choose a number between 1 and 5.");
            Menu();
        }
    }

    private static void AddOneCoin()
    {
        coin++;
    }

    private static void PlayGame()
    {
        while (true)
        {
            Console.Write($"Coins : {coin}\n");
            Console.WriteLine("Press a button to add a coin, press S to save and Q to quit.\n");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.S)
            {

            }
            else if (key.Key == ConsoleKey.Q)
            {
                Menu();
            }
            else { AddOneCoin(); }
        }
    }

}
