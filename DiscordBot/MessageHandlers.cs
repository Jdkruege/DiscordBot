using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data.SqlClient;

using Discord;

namespace DiscordBot
{
    class MessageHandler
    {
        private static XmlDocument _doc;
        private string[] _splitter = {" "};
        private List<string> _channels;
        private bool _pmFlag;

        private List<Tuple<string, Invite>> _invites;

        public MessageHandler(XmlDocument doc, List<string> channels, bool pmFlag)
        {
            _doc = doc;
            _channels = channels;
            _pmFlag = pmFlag;
            
            _invites = new List<Tuple<string, Invite>>();
        }

        /*
         *   
         */
        public void dispatcher(object sender, MessageEventArgs e)
        {
            Message msg = e.Message;
            string text = msg.Text;
            if (!msg.IsAuthor &&  true)
            {
                string command = text.Split(_splitter, StringSplitOptions.RemoveEmptyEntries)[0].ToLower();
                switch(command)
                {
                    case "!info":
                        Info(e.Channel);
                        break;
                    case "!help":
                        Help(e.Channel);
                        break;
                    case "!gear":
                        Gear(e.Channel, text);
                        break;
                    case "!boss":
                        Boss(e.Channel, text);
                        break;
                    case "!event":
                        Event(e.Channel, text);
                        break;
                    case "!activity":
                        Activity(e.Channel, text);
                        break;
                    case "!invite":
                        Invite(e.Channel);
                        break;
                    case "!feedback":
                        Feedback(e.Channel, text);
                        break;
                    default:
                        break;
                }
            }
        }
        
        /*
         * Provides information about the bot.
         * Needs a reference to the channel to talk in
         */
        private void Info(Channel ch)
        {
            StringBuilder infoStr = new StringBuilder();

            XmlNode owner = _doc.SelectSingleNode("/Info/Owner");

            infoStr.AppendLine("I am a bot. I am the master of this room.");
            infoStr.AppendLine("My owner is: " + owner.InnerText);

            ch.SendMessage(infoStr.ToString());
        }

        // Function that returns information on all the functions the bot can provide
        private void Help(Channel ch)
        {
            StringBuilder helpStr = new StringBuilder();

            helpStr.AppendLine("List of supported commands:");
            helpStr.Append("```");
            helpStr.AppendLine("!info      --  General info about this bot.");
            helpStr.AppendLine("!help      --  List of supported commands.");
            helpStr.AppendLine("!gear      --  Lookup, input, or modify gear of guildmates");
            helpStr.AppendLine("!boss      --  Update and search boss timers.");
            helpStr.AppendLine("!event     --  Lookup and register events.");
            helpStr.AppendLine("!activity  --  Lookup and register player participation");
            helpStr.AppendLine("!invite    --  Produces an invitation to the server.");
            helpStr.AppendLine("!feedback  --  File anonymous feedback.");
            helpStr.Append("```");
            helpStr.AppendLine("For a guide on command formatting or general command help, type \"!<command> --help\"");

            ch.SendMessage(helpStr.ToString());
        }

        // Function that deals with character gear information
        private void Gear(Channel ch, string text)
        {
            StringBuilder gearStr = new StringBuilder(); 

            if(text.Contains("--help"))
            {

            }
            else
            {

            }
        }

        // Function that deals with boss states
        private void Boss(Channel ch, string text)
        {
            StringBuilder bossStr = new StringBuilder();

            if (text.Contains("--help"))
            {

            }
            else
            {

            }
        }

        // Function that deals with events
        private void Event(Channel ch, string text)
        {
            StringBuilder eventStr = new StringBuilder();

            if (text.Contains("--help"))
            {

            }
            else
            {

            }
        }

        // Function that deals with player activity in events
        private void Activity(Channel ch, string text)
        {
            StringBuilder activityStr = new StringBuilder();

            if (text.Contains("--help"))
            {

            }
            else
            {

            }
        }

        /*
         * Returns an invite to this server we are operating on.
         * Pulls a still active invite if possible, generates a new invite if no current invite is available
        */
        private async void Invite(Channel ch)
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

            _invites.Add(new Tuple<string,Invite>(ch.Server.Name, inv));

            ch.SendMessage(inv.Url);
        }

        // Function in charge of filing anonymous complaints
        private void Feedback(Channel ch, string text)
        {
            StringBuilder eventStr = new StringBuilder();

            if (text.Contains("--help"))
            {

            }
            else
            {

            }
        }

    }
}
