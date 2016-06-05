using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;

namespace DiscordBot
{
    class CommandsList
    {
        private Dictionary<string, Action<Channel, string>> _dict;

        public CommandsList()
        {
            _dict = new Dictionary<string, Action<Channel, string>>();
        }

        public bool checkCommand(string command)
        {
            if (_dict.ContainsKey(command)) return true;
            else return false;
        }

        public Action<Channel, string> getCommand(string command) 
        {
            return _dict[command];
        }

        public void addCommand(string id, Action<Channel, string> act)
        {
            _dict.Add(id, act);
        }

    }
}
