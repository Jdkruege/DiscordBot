using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using Discord;

namespace DiscordBot
{
    class MessageHandler
    {
        private static XmlDocument _doc;
        private string[] _splitter = {" "};

        private List<Tuple<String, Invite>> _invites;

        public MessageHandler(XmlDocument doc)
        {
            _doc = doc;
            _invites = new List<Tuple<string, Invite>>();
        }

        public void dispatcher(object sender, MessageEventArgs e)
        {
            Message msg = e.Message;
            String text = msg.Text;
            String channel = msg.Channel.Name;
            if (!msg.IsAuthor && channel.Contains("bot"))
            {
                String command = text.Split(_splitter, StringSplitOptions.RemoveEmptyEntries)[0].ToLower();
                switch(command)
                {
                    case "!info":
                        Info(e.Channel);
                        break;
                    case "!help":
                        if (channel.Contains("admin")) ;
                        else Help(e.Channel);;
                        break;
                    case "!gear":
                        Gear(e.Channel, text);
                        break;
                    case "!boss":
                        Boss(e.Channel, text);
                        break;
                    case "!event":
                        if (channel.Contains("admin")) ;
                        else Event(e.Channel, text);
                        break;
                    case "!activity":
                        if (channel.Contains("admin")) ;
                        else Activity(e.Channel, text);
                        break;
                    case "!invite":
                        Invite(e.Channel);
                        break;
                    case "!feedback":
                        if (channel.Contains("admin")) ;
                        else Feedback(e.Channel, text);
                        break;
                    default:
                        break;

                }
            }
        }
        
        private void Info(Channel ch)
        {
                XmlNode owner = _doc.SelectSingleNode("/Info/Owner");

                StringBuilder info = new StringBuilder();

                info.AppendLine("I am a bot. I am the master of this room.");
                info.AppendLine("My owner is: " + owner.InnerText);

                ch.SendMessage(info.ToString());
        }

        private void Help(Channel ch)
        {
                StringBuilder help = new StringBuilder();

                help.AppendLine("List of supported commands:");
                help.Append("```");
                help.AppendLine("!info      --  General info about this bot.");
                help.AppendLine("!help      --  List of supported commands.");
                help.AppendLine("!gear      --  Lookup, input, or modify gear of guildmates");
                help.AppendLine("!boss      --  Update and search boss timers.");
                help.AppendLine("!event     --  Lookup and register events.");
                help.AppendLine("!activity  --  Lookup and register player participation");
                help.AppendLine("!invite    --  Produces an invitation to the server.");
                help.AppendLine("!feedback  --  File anonymous feedback.");
                help.Append("```");
                help.AppendLine("For a guide on command formatting or general command help, type \"!<command> --help\"");

               ch.SendMessage(help.ToString());
        }

        private void Gear(Channel ch, String text)
        {
            if(text.Contains("--help"))
            {

            }
            else
            {

            }
        }

        private void Boss(Channel ch, String text)
        {
            if (text.Contains("--help"))
            {

            }
            else
            {

            }
        }

        private void Event(Channel ch, String text)
        {
            if (text.Contains("--help"))
            {

            }
            else
            {

            }
        }

        private void Activity(Channel ch, String text)
        {
            if (text.Contains("--help"))
            {

            }
            else
            {

            }
        }

        private async void Invite(Channel ch)
        {
            // Lock to prevent multiple threads from altering data at once.
            lock (_invites)
            {
                foreach (Tuple<String, Invite> t in _invites)
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

            _invites.Add(new Tuple<String,Invite>(ch.Server.Name, inv));

            ch.SendMessage(inv.Url);
        }

        private void Feedback(Channel ch, String text)
        {
            if (text.Contains("--help"))
            {

            }
            else
            {

            }
        }

    }
}
