using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SwinAdventure;

namespace SwinAdventureGUI
{
    public partial class Form1 : Form
    {
        Player newPlayer;
        Item Sword;
        Item Hamster;
        Item Shield;
        Bag Sock;
        Location Starting;
        Location Mountain;
        Path North;
        CommandProcessor Command;
        string Commands;
        string[] SplitCommand;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AcceptButton = button1;

            newPlayer = new Player("Hero", "Hi...");
            Sword = new Item(new[] { "sword", "blade" }, "Sword", "The Hero's Sword...");
            Hamster = new Item(new[] { "hamster", "food" }, "Hamster", "Tasty...");
            Shield = new Item(new[] { "shield", "board" }, "Shield", "The Hero's Shield...");
            Sock = new Bag(new[] { "sock", "bag" }, "Sock", "There's a hole in it...");
            Starting = new Location(new[] { "start" }, "Start", "Starting point...");
            Mountain = new Location(new[] { "mountain" }, "Mountain", "A Giant...");
            North = new Path(new[] { "north" }, Mountain, false);
            Command = new CommandProcessor();

            newPlayer.Location = Starting;
            Sock.Inventory.Put(Hamster);
            newPlayer.Inventory.Put(Sock);
            Starting.AddPath(North);
            Starting.Inventory.Put(Sword);
            Mountain.Inventory.Put(Shield);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Commands = textBox2.Text;
            textBox2.Clear();
            SplitCommand = Commands.Split(' ');
            textBox1.Text += $"{Command.ExecuteCommand(newPlayer, SplitCommand)}" + Environment.NewLine;
        }
    }
}
