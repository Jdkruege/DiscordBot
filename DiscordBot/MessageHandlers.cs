using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Discord;

namespace DiscordBot
{
    class MessageHandlers
    {
        private static XmlDocument doc;

        public static void init()
        {
            doc = new XmlDocument();

            doc.Load("Info.xml");
        }

        internal static void InfoHandler(object sender, MessageEventArgs e)
        {
            Message msg = e.Message;
            String text = msg.Text;
            if (isValidMessage(msg) && text.StartsWith("!info", StringComparison.CurrentCultureIgnoreCase))
            {
                XmlNode owner = doc.SelectSingleNode("/Info/Owner");

                StringBuilder info = new StringBuilder();

                info.AppendLine("I am a bot. I am the master of this room.");
                info.AppendLine("My owner is: " + owner.InnerText);

                e.Channel.SendMessage(info.ToString());
            }
        }

        internal static void HelpHandler(object sender, MessageEventArgs e)
        {
            Message msg = e.Message;
            String text = msg.Text;
            if (isValidMessage(msg) && text.StartsWith("!help", StringComparison.CurrentCultureIgnoreCase))
            {
                StringBuilder help = new StringBuilder();

                help.AppendLine("List of supported commands:");
                help.AppendLine("```!info      --  General info about this bot.");
                help.AppendLine("!help      --  List of supported commands.");
                help.AppendLine("!gear      --  Lookup, input, or modify gear of guildmates");
                help.AppendLine("!boss      --  Update and search boss timers.");
                help.AppendLine("!event     --  Lookup and register events.");
                help.AppendLine("!invite    --  Produces an invitation to the server.");
                help.AppendLine("!feedback  --  Files anonymous feedback.```");
                help.AppendLine("For a guide on command formatting or general command help, type \"help\" after the command.");

                e.Channel.SendMessage(help.ToString());
            }
        }

        internal static void GearHandler(object sender, MessageEventArgs e)
        {
            Message msg = e.Message;
            String text = msg.Text;
            if (isValidMessage(msg) && text.StartsWith("!gear", StringComparison.CurrentCultureIgnoreCase))
            {
            }
        }

        internal static void BossHandler(object sender, MessageEventArgs e)
        {
            Message msg = e.Message;
            String text = msg.Text;
            if (isValidMessage(msg) && text.StartsWith("!gear", StringComparison.CurrentCultureIgnoreCase))
            {
            }
        }

        internal static void EventHandler(object sender, MessageEventArgs e)
        {
            Message msg = e.Message;
            String text = msg.Text;
            if (isValidMessage(msg) && text.StartsWith("!gear", StringComparison.CurrentCultureIgnoreCase))
            {
            }
        }

        internal static void InviteHandler(object sender, MessageEventArgs e)
        {
            Message msg = e.Message;
            String text = msg.Text;
            if (isValidMessage(msg) && text.StartsWith("!gear", StringComparison.CurrentCultureIgnoreCase))
            {
            }
        }

        internal static void FeedbackHandler(object sender, MessageEventArgs e)
        {
            Message msg = e.Message;
            String text = msg.Text;
            if (isValidMessage(msg) && text.StartsWith("!gear", StringComparison.CurrentCultureIgnoreCase))
            {
            }
        }

        private static bool isValidMessage(Message msg)
        {
            if (msg.Channel.Name.CompareTo("bot") == 0 && !msg.IsAuthor) return true;
            else return false;
        }
    }
}
