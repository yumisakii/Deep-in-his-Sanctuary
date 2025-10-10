
﻿namespace RoggyPerseus
{
    internal class Program
    {
        static async Task Main()
        {
            await MongoManager.InitServer();

            await Game.game();
        }
    }
}