using RoggyPerseus;
using System.Threading;

class Run
{
    public static List<Monster> AllMonsters = new List<Monster>();
    public static List<Monster> monsters = new List<Monster>();

    public static List<Boss> AllBosses = new List<Boss>();
    public static Boss? boss;

    public static List<Weapon> AllWeapons = new List<Weapon>();
    public static List<Weapon> weapons = new List<Weapon>();
    public static Weapon currentWeapon = new Weapon();

    public static void NewRun()
    {
        Monster.InitAllMonsters();
        Boss.InitAllBosses();
        Weapon.InitAllWeapons();

        weapons.Add(new Weapon { Name = "Sword" });
        weapons.Add(new Weapon { Name = "MasterSword" });
        weapons.Add(new Weapon { Name = "GutsSword" });

        Console.WriteLine("You enter ROOM 1");
        CombatRoom.combatRoom();

        Console.WriteLine("You enter ROOM 2");
        CombatRoom.combatRoom();

        Console.WriteLine("You enter ROOM 3");
        ForgeRoom.forgeRoom();

        Console.WriteLine("You enter ROOM 4\n");
        BossRoom.bossRoom();
    }

    public static int MakeChoice(int num)
    {
        while (true)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            // Convertir la touche en nombre si c'est entre 1 et num
            int choice = 0;
            if (keyInfo.Key >= ConsoleKey.D1 && keyInfo.Key <= ConsoleKey.D9)
                choice = keyInfo.Key - ConsoleKey.D0;
            else if (keyInfo.Key >= ConsoleKey.NumPad1 && keyInfo.Key <= ConsoleKey.NumPad9)
                choice = keyInfo.Key - ConsoleKey.NumPad0;

            if (choice >= 1 && choice <= num)
                return choice;

            Console.WriteLine($"Choose a number between 1 and {num}, try again.\n");
        }
    }


}
