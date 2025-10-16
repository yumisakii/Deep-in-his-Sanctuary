using RoggyPerseus;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Game
{
    public static async Task game()
    {
        LoadGame();

        GameIntro();

        await Lobby();

        UpgradeCharacter();
    }

    private static void GameIntro()
    {
        Console.WriteLine("Introduction du jeu.....");
    }

    public static async Task Lobby()
    {
        Console.WriteLine("You're in the lobby.\n");

        Console.WriteLine("what you wanna do ?\n" +
                          "1 - new run\n" +
                          "2 - upgrade character\n" +
                          "3 - menu\n");
        
        int choice = UF.MakeChoice(3);

        switch (choice)
        {
            case 1:
                while (Run.playerStats.Hp > 0)
                {
                    int roomToRun = ((PreGame.savedStats.currentRoom - 1) % 4) + 1; ;

                    if (Run.playerStats.currentRoom == 1)
                    {
                        await Run.NewRun();
                    }
                    else
                    {
                        await Run.PlayRun(roomToRun);
                    }
                }
                break;

            case 2:
                UpgradeCharacter();
                break;

            case 3:
                await PreGame.GameMenu();
                break;
        }
    }

    private static void UpgradeCharacter()
    {
        Console.WriteLine("Upgrade ur character");
    }

    private static void LoadGame()
    {
        var load = JsonSaveLoad.LoadGame(PreGame.saveFile.localDataId);

        if (load != null)
        {
            PreGame.saveFile = load;
            PreGame.savedStats = PreGame.saveFile.PlayerStats;
            Run.playerStats = PreGame.savedStats;
        }
        else
        {
            PreGame.saveFile = new SaveFile();
            PreGame.savedStats = PreGame.saveFile.PlayerStats;
            Run.playerStats = PreGame.savedStats;
        }
    }

    public static async Task SaveGame()
    {
        if (Run.playerStats.Score > Run.playerStats.BestScore)
        {
            Run.playerStats.BestScore = Run.playerStats.Score;
            await MongoManager.UpdateProfile(AccountManager.currentProfile.Username, Run.playerStats.BestScore);

        }
        JsonSaveLoad.SaveGame(PreGame.profile.Id, PreGame.saveFile.localDataId, Run.playerStats);
        Console.WriteLine("Game Saved.");
    }
}