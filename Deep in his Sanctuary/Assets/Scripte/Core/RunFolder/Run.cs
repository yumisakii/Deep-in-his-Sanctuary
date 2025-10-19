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
        await PlayRun(1);
    }

    public static async Task PlayRun(int roomNum)
    {
        InitRun();

        if (roomNum == 1 || playerStats.currentRoom == 1)
        {
            Console.WriteLine($"\nYou enter ROOM {playerStats.currentRoom}\n");
            await CombatRoom.combatRoom();
            playerStats.currentRoom += 1;
            Console.WriteLine($"Current room : {playerStats.currentRoom}");
            await Game.SaveGame();
        }

        if (roomNum == 2 || playerStats.currentRoom == 2)
        {
            Console.WriteLine($"\nYou enter ROOM {playerStats.currentRoom}\n");
            await CombatRoom.combatRoom();
            playerStats.currentRoom += 1;
            await Game.SaveGame();
        }

        if (roomNum == 3 || playerStats.currentRoom == 3)
        {
            Console.WriteLine($"\nYou enter ROOM {playerStats.currentRoom}\n");
            ForgeRoom.forgeRoom();
            playerStats.currentRoom += 1;
            await Game.SaveGame();
        }

        if (roomNum == 4 || playerStats.currentRoom == 4)
        {
            Console.WriteLine($"\nYou enter ROOM {playerStats.currentRoom}\n");
            await BossRoom.bossRoom();
            playerStats.currentRoom += 1;
            await Game.SaveGame();
        }
    }

    public static async Task YouDied()
    {
        UF.WriteInColor("You died.\n", ConsoleColor.Red);

        Console.Write($"scoreeee :  {playerStats.Score}");
        Console.Write($"bestoo scoreeee :  {playerStats.BestScore}");
        if (playerStats.Score > playerStats.BestScore)
        {
            playerStats.BestScore = playerStats.Score;
            Console.Write($"new best score {playerStats.BestScore}");
            await MongoManager.UpdateProfile(AccountManager.currentProfile.Username, playerStats.BestScore);
        }
            
        PlayerStats.InitPlayerStats(playerStats);
        
        await Game.SaveGame();
        await Game.Lobby();
    }

    private static void InitRun()
    {
        Monster.InitAllMonsters();
        Boss.InitAllBosses();
        Weapon.InitAllWeapons();
        weapons = playerStats.Inventory;
    }
}
