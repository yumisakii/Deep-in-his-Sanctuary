using RoggyPerseus;
using RoggyPerseus.RunFolder;
using System.Threading;

class Run
{
    public static List<Monster> AllMonsters = new List<Monster>();
    public static List<Monster> monsters = new List<Monster>();

    public static List<Boss> AllBosses = new List<Boss>();
    public static Boss? boss;

    public static PlayerStats playerStats = new PlayerStats();

    public static List<Weapon> AllWeapons = new List<Weapon>();
    public static List<Weapon> weapons = new List<Weapon>();
    public static Weapon currentWeapon = new Weapon();

    public static async Task NewRun()
    {
        Monster.InitAllMonsters();
        Boss.InitAllBosses();
        Weapon.InitAllWeapons();

        playerStats.Score = 0;

        Console.WriteLine("You enter ROOM 1");
        await CombatRoom.combatRoom();

        Console.WriteLine("You enter ROOM 2");
        await CombatRoom.combatRoom();

        Console.WriteLine("You enter ROOM 3");
        ForgeRoom.forgeRoom();

        Console.WriteLine("You enter ROOM 4\n");
        BossRoom.bossRoom();
    }

    public static async Task YouDied()
    {
        UF.WriteInColor("You died.\n", ConsoleColor.Red);

        if (playerStats.Score > playerStats.BestScore)
            playerStats.BestScore = playerStats.Score;

        await Game.Lobby();
    }


}
