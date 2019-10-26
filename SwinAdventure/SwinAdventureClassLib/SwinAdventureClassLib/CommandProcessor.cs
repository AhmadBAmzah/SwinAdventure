using System;

namespace SwinAdventure
{
    public class CommandProcessor
    {
        private Command _Command;

        public CommandProcessor()
        {
            Command.RegisterCommand("look", typeof(LookCommand));
            Command.RegisterCommand("move", typeof(MoveCommand));
            Command.RegisterCommand("go", typeof(MoveCommand));
            Command.RegisterCommand("head", typeof(MoveCommand));
            Command.RegisterCommand("leave", typeof(MoveCommand));
            Command.RegisterCommand("take", typeof(TakeCommand));
            Command.RegisterCommand("put", typeof(PutCommand));
        }

        public string ExecuteCommand(Player p, string[] text)
        {
            if (Command.CheckCommand(text[0]))
            {
                _Command = Command.CreateCommandInstance(text[0]);
                return _Command.Execute(p, text);
            }
            return "I don't know how to execute this command.";
        }
    }
}
