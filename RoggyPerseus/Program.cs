
﻿namespace RoggyPerseus
{
    class Program
    {
        static async Task Main()
        {
            await MongoManager.InitServer();

            await PreGame.preGame();
            //await Game.game();
        }
    }
}