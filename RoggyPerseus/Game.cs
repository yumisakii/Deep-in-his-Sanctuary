class Game
{
    public static void game()
    {
        GameIntro();

        Lobby();

        UpgradeCharacter();

        Run.NewRun();
    }

    private static void GameIntro()
    {
        Console.WriteLine("Introduction du jeu.....");
    }

    private static void Lobby()
    {
        Console.WriteLine("Vous êtes dans le lobby...");
    }

    private static void UpgradeCharacter()
    {
        Console.WriteLine("Ameliorez votre personage");
    }
}