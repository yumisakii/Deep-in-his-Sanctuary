using RoggyPerseus;
using System;
using System.Text.Json;

class PreGame
{
    public static ProfileDoc profile = new ProfileDoc();
    public static PlayerStats savedStats = new PlayerStats();
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

        int choice = UF.MakeChoice(3);

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
            Console.WriteLine("\nGoodbye.");
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
        Console.WriteLine(
        "\n--MENU--" +
        $"\n-Save {saveFile.localDataId}-" +
        "\n1 - Play" +
        "\n2 - Change Save" +
        "\n3 - Leaderboard" +
        "\n4 - Quit\n");

        int choice = UF.MakeChoice(5);

        if (choice == 1)
        {
            //Play
            await Game.game();

        }
        else if (choice == 2)
        {
            //Change Save
            await ChangeSave();

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
            //Quit
            Console.WriteLine("Goodbye.");
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("Choose a number between 1 and 5.");
            await GameMenu();
        }
    }
    
    private static async Task ChangeSave()
    {
        Console.WriteLine("--Saves--\n" +
                          $"Save 1 : Current room : {savedStats.currentRoom}\n" +
                          $"Save 2 : Current room : {savedStats.currentRoom}\n" +
                          $"Save 3 : Current room : {savedStats.currentRoom}\n" +
                          "Choose a Save : ");

        int saveChoice = UF.MakeChoice(3);

        saveFile.localDataId = saveChoice;
        await GameMenu();
    }
}
