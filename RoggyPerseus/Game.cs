class Game
{
    public static void game()
    {
        gameIntro();

        lobby();

        upgradeCharacter();

        Run.newRun();
    }

    private static void gameIntro()
    {
        Console.WriteLine("Introduction du jeu.....");
    }

    private static void lobby()
    {
        Console.WriteLine("Vous êtes dans le lobby...");
    }

    private static void upgradeCharacter()
    {
        Console.WriteLine("Ameliorez votre personage");
    }
}