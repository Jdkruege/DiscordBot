using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Discord;

namespace DiscordBot
{
    static class Commands
    {
        private static XmlDocument _doc;

        private static List<Tuple<string, Invite>> _invites;

        public static CommandsList Setup(XmlDocument doc)
        {
            _doc = doc;
            
            _invites = new List<Tuple<string, Invite>>();

            CommandsList cList = new CommandsList();

            cList.addCommand("!info", Info);
            cList.addCommand("!help", Help);
            cList.addCommand("!event", Event);
            cList.addCommand("!activity", Activity);
            cList.addCommand("!invite", Invite);
            cList.addCommand("!feedback", Feedback);

            return cList;
        }

        /* 
                 * Region contains all supported commands
                 * Channels are required to be passed so the bot know where to respond
                 * Text is required in some functions to fruther parse what the user is looking to do
                 */
        #region Commands

        // Information about the bot and owner
        private static void Info(Channel ch, string text)
        {
            StringBuilder infoStr = new StringBuilder();

            XmlNode owner = _doc.SelectSingleNode("/Info/Owner");

            infoStr.AppendLine("I am a bot. I am the master of this room.");
            infoStr.AppendLine("My owner is: " + owner.InnerText);

            ch.SendMessage(infoStr.ToString());
        }

        // Reference for all supported commands
        private static void Help(Channel ch, string text)
        {
            StringBuilder helpStr = new StringBuilder();

            helpStr.AppendLine("List of supported commands:");
            helpStr.Append("```");
            helpStr.AppendLine("!info      --  General info about this bot.");
            helpStr.AppendLine("!help      --  List of supported commands.");
            helpStr.AppendLine("!event     --  Lookup and register events.");
            helpStr.AppendLine("!activity  --  Lookup and register player participation");
            helpStr.AppendLine("!invite    --  Produces an invitation to the server.");
            helpStr.AppendLine("!feedback  --  File anonymous feedback.");
            helpStr.Append("```");
            helpStr.AppendLine("For a guide on command formatting or general command help, type \"!<command> --help\"");

            ch.SendMessage(helpStr.ToString());
        }

        // Query and update boss statuses
        private static void Boss(Channel ch, string text)
        {
            StringBuilder bossStr = new StringBuilder();

            if (text.Contains("--help"))
            {

            }
            else
            {

            }
        }

        // Track and plan events
        private static void Event(Channel ch, string text)
        {
            StringBuilder eventStr = new StringBuilder();

            if (text.Contains("--help"))
            {

            }
            else
            {

            }
        }

        // Log player participation in events
        private static void Activity(Channel ch, string text)
        {
            StringBuilder activityStr = new StringBuilder();

            if (text.Contains("--help"))
            {

            }
            else
            {

            }
        }

        // Produces an invite to the discord channel
        private static async void Invite(Channel ch, string text)
        {
            // Lock to prevent multiple threads from altering data at once.
            lock (_invites)
            {
                foreach (Tuple<string, Invite> t in _invites)
                {
                    if (t.Item2.IsRevoked)
                    {
                        _invites.Remove(t);
                        break;
                    }

                    if (t.Item1.Equals(ch.Server.Name))
                    {
                        ch.SendMessage(t.Item2.Url);
                        return;
                    }
                }
            }

            // If no invite has been made before, or our previous invite expired we make a new invite
            Invite inv = await ch.Server.CreateInvite(1800, null, false, false);

            _invites.Add(new Tuple<string, Invite>(ch.Server.Name, inv));

            ch.SendMessage(inv.Url);
        }

        // Submission location for anonymous feedback
        private static void Feedback(Channel ch, string text)
        {
            StringBuilder eventStr = new StringBuilder();

            if (text.Contains("--help"))
            {

            }
            else
            {

            }
        }

        #endregion
    }
}
