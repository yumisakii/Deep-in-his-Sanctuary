using static RoggyPerseus.Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class AccountManager
{
    public static ProfileDoc? CurrentProfile101 { get; private set; }
    public static PlayerProfile? currentProfile;
    static string currentPassword = "";

    public static async Task CreateNewProfile()
    {
        Console.Write("Nom du joueur : ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Mot de passe : ");
        string pwd = Console.ReadLine() ?? "";

        currentProfile = new PlayerProfile { Username = name };
        currentPassword = pwd;

        await MongoManager.CreateProfile(name, pwd);
    }

    public static async Task LoadProfile()
    {
        Console.Write("Player name : ");
        string name = Console.ReadLine() ?? "";

        Console.Write("Password : ");
        string pwd = Console.ReadLine() ?? "";

        var profileDoc = await MongoManager.LoadProfile(name, pwd);
        if (profileDoc != null)
        {
            currentProfile = new PlayerProfile { Username = profileDoc.Username };
            currentPassword = pwd;
            CurrentProfile101 = profileDoc;
            Console.WriteLine($"Profil {name} loaded !");
        }
        else
        {
            Console.WriteLine("Username or password incorrect.\n");
            await LoadProfile();
        }
    }
}

public class PlayerProfile
{
    public string Username { get; set; } = "";
}