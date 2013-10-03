using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Web;
using System.Net;
using System.Xml;
using System.Xml.Linq;

//using DayZ3_Launcher.serverListItem;


namespace DayZ3_Launcher
{
    class serverListCreator
    {
        /* http://arma3.swec.se/server/list.xml?country=&mquery=DayZ&nquery=&state_playing=1 */
        MainWindow window;

        public serverListCreator (MainWindow window){
            this.window = window;

            // Creates the XML Server List Path
            ComboBoxItem _gameType = (ComboBoxItem)window.ServerList_GameType.SelectedValue; //.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
            string Path = "http://arma3.swec.se/server/list.xml?country=&mquery=" + _gameType.Name.ToString().Replace("_", " ") +"&nquery=&state_playing=1";
            Console.WriteLine("Mission Path: " + Path);
            
            XDocument xdoc = XDocument.Load(Path);

            foreach (var server in xdoc.Descendants("server"))
            {
                try
                {
                    this.window.ServerListMW.AddItem(new serverListItem
                    {
                        Favorite = new CheckBox(),
                        ServerName = server.Element("name").Value,
                        Version = server.Element("version").Value,
                        Players = server.Element("players").Value,
                        Ping = "000",
                        GameType = server.Element("mission").Value,
                        Country = server.Element("country").Value,
                        IP = server.Element("host").Value,
                        Port = server.Element("port").Value,
                        Mods = server.Element("mod").Value,
                        Locked = server.Element("passworded").Value,
                        Mission = server.Element("mission").Value,
                    });
                }
                catch (NullReferenceException except)
                {
                    Console.WriteLine("Error Exception: {0}", except);
                }
            }
        }
    }
}
