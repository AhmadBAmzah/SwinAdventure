using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    class Program
    {
        static void Main(string[] args)
        {
            Player newPlayer = new Player("Hero", "Hi...");
            Item Sword = new Item(new[] {"sword", "blade"}, "Sword", "The Hero's Sword...");
            Item Hamster = new Item(new[] {"hamster", "food"}, "Hamster", "Tasty...");
            Item Shield = new Item(new[] { "shield", "board" }, "Shield", "The Hero's Shield...");
            Bag Sock = new Bag(new[] { "sock", "bag" }, "Sock", "There's a hole in it...");
            Location Starting = new Location(new[] {"start"}, "Start", "Starting point...");
            Location Mountain = new Location(new[] {"mountain"}, "Mountain", "A Giant...");
            Path North = new Path(new[] {"north"}, Mountain, false);

            newPlayer.Location = Starting;
            Sock.Inventory.Put(Hamster);
            newPlayer.Inventory.Put(Sock);
            Starting.AddPath(North);
            Starting.Inventory.Put(Sword);
            Mountain.Inventory.Put(Shield);

            CommandProcessor Command = new CommandProcessor();
            string Commands;
            string[] SplitCommand;
            while(true)
            {
                Console.WriteLine("Enter command: ");
                Commands = Console.ReadLine();
                SplitCommand = Commands.Split(" ");
                Console.WriteLine(Command.ExecuteCommand(newPlayer, SplitCommand));
            }
        }
    }
}
