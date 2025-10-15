using System;
using System.Text.Json;

class PreGame
{
    private static int data_id;

    public static ProfileDoc profile = new ProfileDoc();
    public static PlayerStats stats = new PlayerStats();
    public static SaveFile saveFile = new SaveFile();

    public static async Task preGame()
    {
        await Connexion();
    }

    private static async Task Connexion()
    {
        Console.Write(
        "\n--Connexion--" +
        "\n1 - Connexion" +
        "\n2 - Create Account" +
        "\n3 - Quit\n");

        int choice = MakeChoice();

        if (choice == 1)
        {
            //Connexion
            await AccountManager.LoadProfile();
            profile = AccountManager.CurrentProfile101;
            await GameMenu();
        }
        else if (choice == 2)
        {
            //Create Account
            await AccountManager.CreateNewProfile();
            await Connexion();
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
            await Connexion();
        }
    }

    public static async Task GameMenu()
    {
        Console.Write(
        "\n--MENU--" +
        $"\n-save {saveFile.localDataId}-" +
        "\n1 - Play" +
        "\n2 - Change Save" +
        "\n3 - Leaderboard" +
        "\n5 - Quit\n");

        int choice = MakeChoice();

        if (choice == 1)
        {
            //Play
            await Game.game();

        }
        else if (choice == 2)
        {
            //Change Save
            ChangeSave();

        }
        else if (choice == 3)
        {
            // Leaderboard
            var leaderboard = await MongoManager.GetLeaderboardProfiles();

            Console.WriteLine("\n--- LEADERBOARD ---");
            int rank = 1;
            foreach (var p in leaderboard)
            {
                Console.WriteLine($"{rank++}. {p.Username} - {p.Score}");
            }
            await GameMenu();
        }
        else if (choice == 4)
        {
            //Save
            //JsonSaveLoad.SaveGame(profile.Id, saveFile.localDataId, stats);
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
            await GameMenu();
        }
    }

    private static void AddOneCoin()
    {
        stats.Coins++;
    }

    private static void PlayGame()
    {
        var load = JsonSaveLoad.LoadGame(saveFile.localDataId);
        if (load != null)
        {
            saveFile = load;
            stats = saveFile.PlayerStats;
        }
        else
        {
            saveFile = new SaveFile();
            stats = saveFile.PlayerStats;
        }

        while (true)
        {
            Console.Write($"Coins : {stats.Coins}\n");
            Console.WriteLine("Press a button to add a coin, press Q to quit.\n");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.Q)
            {
                JsonSaveLoad.SaveGame(profile.Id, saveFile.localDataId, stats);
                GameMenu();
            }
            else { AddOneCoin(); }
        }
    }
    
    private static void ChangeSave()
    {
        Console.WriteLine("SAves veese svera");
        Console.WriteLine("--Saves--\n" +
                          "Save 1 : INFO SUR LA SAVE\n" +
                          "Save 2 : INFO SUR LA SAVE\n" +
                          "Save 3 : INFO SUR LA SAVE\n" +
                          "Choose a Save : ");
        int saveChoice = int.Parse(Console.ReadLine() ?? "");

        if (saveChoice == 1 || saveChoice == 2 || saveChoice == 3)
        {
            saveFile.localDataId = saveChoice;
            GameMenu();
        }
        else
        {
            Console.WriteLine("Choose a number between 1 and 3.");
            ChangeSave();
        }
    }

    private static int MakeChoice()
    {
        int choice;
        while (true)
        {
            Console.Write("Entrez un nombre : ");
            string? input = Console.ReadLine();

            if (int.TryParse(input, out choice))
                break;

            Console.WriteLine("Veuillez entrez un chiffre.");
        }
        return choice;
    }
}
