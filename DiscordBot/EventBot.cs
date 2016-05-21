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

        public EventBot()
        {
            bot = new DiscordClient();

            MessageHandlers.init();

            //bot.MessageReceived += getMessage;
            bot.MessageReceived += MessageHandlers.InfoHandler;
            bot.MessageReceived += MessageHandlers.HelpHandler;

            XmlDocument doc = new XmlDocument();

            doc.Load("Info.xml");

            XmlNode token = doc.DocumentElement.SelectSingleNode("/Info/Token");

            if (token != null)
                bot.Connect(token.InnerText);
        }


        ~EventBot()
        {
            bot.Disconnect();
        }

        public void start()
        {
            bot.Wait();
        }

        private void getMessage(object sender, MessageEventArgs e)
        {
            if(!e.Message.IsAuthor)
            {
                StringBuilder strB = new StringBuilder();

                strB.AppendLine("Server: " + e.Server.Name);
                strB.AppendLine("Channel: " + e.Channel.Name);
                strB.AppendLine("User: " + e.User.Name);
                strB.AppendLine("Message: \"" + e.Message.Text + "\"");

                e.Message.Delete();

                e.Channel.SendMessage(strB.ToString());
            }  
        }
    }
}
