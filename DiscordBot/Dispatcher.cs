using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord;

namespace DiscordBot
{
    static class Dispatcher
    {
        private static string[] _splitter = { " " };
        private static List<string> _channels;
        private static bool _pmFlag;

        private static CommandsList _cList;

        public static void Setup(List<String> channels, bool pmFlag, CommandsList cList)
        {
            _channels = channels;
            _pmFlag = pmFlag;
            _cList = cList;
        }

         /*
         * In charge of processing commands and handing off the task to the correct method.
         * This method is built for extendability and least use of resources.
         * A new method can be easily added to the switch case as needed.
         */
        public static void MessageReceived(object sender, MessageEventArgs e)
        {
            Message msg = e.Message;
            string text = msg.Text;
            if (!msg.IsAuthor &&  (_channels.Contains(msg.Channel.Name) || (msg.Channel.IsPrivate && _pmFlag)))
            {
                msg.Channel.SendIsTyping();
                string command = text.Split(_splitter, StringSplitOptions.RemoveEmptyEntries)[0].ToLower();
                if (_cList.checkCommand(command)) _cList.getCommand(command).Invoke(msg.Channel, text);
                else msg.Channel.SendMessage("Command not recognized. Use !help for a list of commands I recognize.");
            }
        }
    }
}
