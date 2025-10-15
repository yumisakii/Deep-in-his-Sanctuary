class Game
{
    public static async Task game()
    {
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
        
        int choice = Run.MakeChoice(3);

        switch (choice)
        {
            case 1:
                await Run.NewRun();
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
        Console.WriteLine("Ameliorez votre personage");
    }
}