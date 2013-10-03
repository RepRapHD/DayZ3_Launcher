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

//using DayZ3_Launcher.serverListItem;


namespace DayZ3_Launcher
{
    class serverListCreator
    {
        /* http://arma3.swec.se/server/list.xml?country=&mquery=DayZ&nquery=&state_playing=1 */

        public serverListCreator (MainWindow window){
            WebClient client = new WebClient();
            Stream data = client.OpenRead("http://arma3.swec.se/server/list.xml?country=&mquery=DayZ&nquery=&state_playing=1");
            StreamReader reader = new StreamReader(data);
            string xml = reader.ReadToEnd();

            data.Close();
            reader.Close();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);

            XmlNode node = xmlDoc.SelectSingleNode("//servers/server/country/text()");
            MessageBox.Show("STRING:" +node.Value);
            
            
            window.ServerListMW.Add(new serverListItem { Favorite = new CheckBox(), ServerName = "1", Version = "2", Players = "3", Ping = "4", GameType = "5" });
            //window.ServerListMW.Add(new serverListItem { Favorite = new CheckBox(), ServerName = "1", Version = "2", Players = "3", Ping = "4", GameType = "5" });
            //window.ServerListMW.Add(new serverListItem { Favorite = new CheckBox(), ServerName = "1", Version = "2", Players = "3", Ping = "4", GameType = "5" });
            //window.ServerListMW.Add(new serverListItem { Favorite = new CheckBox(), ServerName = "1", Version = "2", Players = "3", Ping = "4", GameType = "5" });
            
        }
    }
}
