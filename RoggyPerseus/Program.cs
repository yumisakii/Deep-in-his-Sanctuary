namespace RoggyPerseus
{
    internal class Program
    {
        static PlayerProfile? currentProfile;
        static string currentPassword = "";

        static async Task Main(string[] args)
        {
            bool isRunning = true;

            await MongoManager.InitServer();

            while (isRunning)
            {
                Console.WriteLine("===MENU===");
                Console.WriteLine("1. Nouvelle Partie");
                Console.WriteLine("2. Charger");
                Console.WriteLine("3. Jouer (SPACE)");
                Console.WriteLine("4. Sauvegarder");
                Console.WriteLine("5. Supprimer le profil");
                Console.WriteLine("6. Quitter\n");

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        await CreateNewProfile();
                        break;
                    
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        await MongoManager.LoadProfile("Alice", "test");
                        break;

                    default:
                        Console.WriteLine("Choix invalide.\n");
                        break;
                }
            }
        }

        static async Task CreateNewProfile()
        {
            Console.Write("Nom du joueur : ");
            string name = Console.ReadLine() ?? "";

            Console.Write("Mot de passe : ");
            string pwd = Console.ReadLine() ?? "";

            currentProfile = new PlayerProfile { Name = name};
            currentPassword = pwd;

            await MongoManager.CreateProfile(name, pwd);
        }

        public class PlayerProfile
        {
            public string Name { get; set; } = "";
        }
    }
}