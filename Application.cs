using System;
using System.Collections.Generic;

namespace SwinAd
{
    class Application
    {
        static public void Main()
        {
            Console.WriteLine("Enter your name: ");
            string playerName = Console.ReadLine();
            Console.WriteLine("How would you describe yourself... ");
            string playerDesc = Console.ReadLine();
            Player player = new Player(playerName, playerDesc);

            Item pencil = new Item(new[]{"pencil"}, "Pencil", "A fucking pencil...");
            Item coffee = new Item(new[]{"coffee"}, "Cup of Coffee", "When you need a pick me up...");

            player.inventory().Put(pencil);
            player.inventory().Put(coffee);

            Bag milk = new Bag(new[]{"milkBag"}, "Bag of Milk", "Ask Canadians...");
            player.inventory().Put(milk);

            Item dBShotgun = new Item(new[]{"dBShotgun"}, "Double-Barrel Shoutgun", "Groovy...");
            Console.WriteLine(milk.inventory().ItemList());
            milk.inventory().Put(dBShotgun);

            //loopCommands
            bool quit = false;
            string userCommand;
            LookCommand lookCommand = new LookCommand();
            do
            {
                Console.WriteLine("Enter command: \n");
                userCommand = Console.ReadLine();
                string[] userCommands = userCommand.Split(" ");
                Console.WriteLine(lookCommand.Execute(player, userCommands));
                quit = true;
            }
            while(!quit);

            Environment.Exit(0);
            return;
        }
    }
}
