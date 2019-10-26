using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public abstract class Command : IdentifiableObject
    {
        private static Dictionary<string, Type> _CommandRegistry = _CommandRegistry = new Dictionary<string, Type>();

        public Command(string[] ids) : base(ids) { }

        public static bool CheckCommand(string command)
        {
            return _CommandRegistry.ContainsKey(command);
        }

        public static void RegisterCommand(string name, Type t)
        {
            _CommandRegistry[name] = t;
        }

        public static Command CreateCommandInstance(string name)
        {
            return (Command)Activator.CreateInstance(_CommandRegistry[name]);
        }

        public abstract string Execute(Player p, string[] text);
    }
}
