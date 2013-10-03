using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DayZ3_Launcher
{
    public class serverListItem
    {
        
        public string ServerName { get; set; }
        public string Version { get; set; }
        public string Players { get; set; }
        public string Ping { get; set; }
        public string GameType { get; set; }
        public string Country { get; set; }
        public string IP { get; set; }
        public string Port { get; set; }
        public string Island { get; set; }
        public string Mods { get; set; }
        public string Locked { get; set; }
        public string Mission { get; set; }

        public CheckBox Favorite { get; set; }

    }

    public class serverList : ObservableCollection<serverListItem>
    {
        ObservableCollection<serverListItem> _serverListItems = new ObservableCollection<serverListItem>();

        public ObservableCollection<serverListItem> serverListItems
        {
            get { return this._serverListItems; }
            set { this._serverListItems = value; }
        }

        /*
         * function AddItem
         * Public function used to add servers to the list.
         */
        public void AddItem(serverListItem item){
            serverListItems.Add(item);
        }

        /*
         * function Clear
         * We're overwriting the native function of clear.
         * We do this so we can clear the internal ListItems
         */
        public void Clear()
        {
            this.ClearItems();
            _serverListItems.Clear();
        }


        public serverList()
            : base()
        {
            
        }
    }

}
