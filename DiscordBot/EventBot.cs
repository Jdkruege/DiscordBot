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

            XmlNode token = doc.DocumentElement.SelectSingleNode("/Info/Token");

            handler = new MessageHandler(doc);

            bot.MessageReceived += handler.dispatcher;

            if (token != null)
                bot.Connect(token.InnerText);
        }

        ~EventBot()
        {
            bot.Disconnect();
        }

        public void Start()
        {
            bot.Wait();
        }
    }
}
