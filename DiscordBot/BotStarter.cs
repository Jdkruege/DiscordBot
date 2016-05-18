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

            Thread th1 = new Thread(new ThreadStart(eBot.start));

            th1.Start();

            while (!(Console.ReadLine().CompareTo("Stop") == 0));

            th1.Abort();

            th1.Join();

            Console.WriteLine("Closing");
        }
    }
}
