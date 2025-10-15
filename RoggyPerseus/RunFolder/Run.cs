using RoggyPerseus;
using RoggyPerseus.RunFolder;
using System.Threading;
using static System.Runtime.InteropServices.JavaScript.JSType;

class Run
{
    public static PlayerStats playerStats = new PlayerStats();

    public static List<Monster> AllMonsters = new List<Monster>();
    public static List<Monster> monsters = new List<Monster>();

    public static List<Boss> AllBosses = new List<Boss>();
    public static Boss boss = new Boss();

    public static List<Weapon> AllWeapons = new List<Weapon>();
    public static List<Weapon> weapons = new List<Weapon>();
    public static Weapon currentWeapon = new Weapon();

    public static async Task NewRun()
    {
        PlayerStats.InitPlayerStats(playerStats);
        Monster.InitAllMonsters();
        Boss.InitAllBosses();
        Weapon.InitAllWeapons();

        Console.WriteLine("You enter ROOM 1");
        await CombatRoom.combatRoom();

        Console.WriteLine("You enter ROOM 2");
        await CombatRoom.combatRoom();

        Console.WriteLine("You enter ROOM 3");
        ForgeRoom.forgeRoom();

        Console.WriteLine("You enter ROOM 4\n");
        await BossRoom.bossRoom();
    }

    public static async Task YouDied()
    {
        UF.WriteInColor("You died.\n", ConsoleColor.Red);

        if (playerStats.Score > playerStats.BestScore)
            playerStats.BestScore = playerStats.Score;

        await Game.Lobby();
    }


}
