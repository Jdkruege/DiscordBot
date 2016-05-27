using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Discord;

namespace DiscordBot
{
    class BotStarter
    {
        public static void Main(string[] args)
        {
            EventBot eBot = new EventBot();

            eBot.Start();
        }
    }
}
