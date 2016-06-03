using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Discord;

namespace DiscordBot
{
    class EventBot
    {
        private DiscordClient bot;
        private MessageHandler handler;

        public EventBot()
        {
            bot = new DiscordClient();

            XmlDocument doc = new XmlDocument();

            doc.Load("Info.xml");

            Console.WriteLine("-- Pulling startup information.");
            // Get the token needed to log in
            XmlNode token = doc.DocumentElement.SelectSingleNode("/Info/Token");

            // Get a list of approved channels and make a list of their names
            XmlNodeList chanList = doc.DocumentElement.SelectNodes("//Channel");
            List<string> appChans = new List<string>();

            foreach (XmlNode node in chanList)
            {
                appChans.Add(node.InnerText);
            }

            // Get the flag indicating if the bot should respond to private messages
            string usePMs = doc.DocumentElement.SelectSingleNode("/Info/UsePMs").InnerText;
            bool pmFlag = (usePMs.Equals("true", StringComparison.CurrentCultureIgnoreCase) ? true : false);

            handler = new MessageHandler(doc, appChans, pmFlag);

            bot.MessageReceived += handler.dispatcher;

            Console.WriteLine("-- Attempting to log in.");
            if (token != null)
            {
                bot.Connect(token.InnerText);
                Console.WriteLine(" -- Log in successful.");
            }
            else
            {
                Console.WriteLine(" -- Token not found. Check Info.xml to ensure a token is set.");
            }    
        }

        ~EventBot()
        {
            bot.Disconnect();
        }

        public void Start()
        {
            Console.WriteLine("-- Bot is now in control.");
            bot.Wait();
        }
    }
}
