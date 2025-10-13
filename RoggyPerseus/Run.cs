using RoggyPerseus;
using System.Threading;

class Run
{
    private static List<Monster> monsters = new List<Monster>();

    public static void newRun()
    {
        CombatFunc.InitAllMonsters();


        Console.WriteLine("You enter ROOM 1");
        combatRoom();

        Console.WriteLine("You enter ROOM 2");
        combatRoom();

        Console.WriteLine("You enter ROOM 3");
        forgeRoom();

        Console.WriteLine("You enter ROOM 4");
        bossRoom();
    }

    private static void combatRoom()
    {

        //A RANDOMISER
        monsters.Clear();
        monsters.Add(CombatFunc.GetRandomMonster());
        monsters.Add(CombatFunc.GetRandomMonster());
        monsters.Add(CombatFunc.GetRandomMonster());

        while (monsters.Count > 0)
        {
            Console.WriteLine($"You're facing {monsters.Count} monsters.\n" +
                               "1 - Attack\n" +
                               "2 - Use Skill\n" +
                               "3 - Use Item\n");

            int choice = MakeChoice(3);

            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Choose who to attack :");
                    for (int i = 0; i < monsters.Count; i++)
                    {
                        Console.WriteLine($"{i+1} - {monsters[i].Name}");
                    }

                    int target = MakeChoice(3);

                    CombatFunc.Attack(monsters[target - 1]);
                    break;

                case 2:
                    CombatFunc.UseSkill();
                    break;

                case 3:
                    CombatFunc.UseItem();
                    break;
            }

            for (int i = monsters.Count - 1; i >= 0; i--)
            {
                if (monsters[i].hp <= 0)
                {
                    Console.WriteLine($"You defeated {monsters[i].Name}!");
                    monsters.RemoveAt(i);
                }
            }
        }
    }

    private static void bossRoom()
    {

    }

    private static void forgeRoom()
    {

    }




    private static int MakeChoice(int num)
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
