using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public serverList ServerListMW;
        SettingsManager Settings;

        public MainWindow()
        {
            InitializeComponent();

            // Hide All &
            // Make Recent News The Default Slide
            this.HideAll();
            RecentNews.Visibility = System.Windows.Visibility.Visible;

            // Connect the Settings Manager
            this.Settings = new SettingsManager(this);

            ServerListMW = new serverList();
            serverListView.DataContext = ServerListMW.serverListItems;

        }

        /*
         * function HideAll
         * This is used to hide all UI Elements. Rather than hide everything in the button functions.
         */
        private void HideAll()
        {
            RecentNews.Visibility = System.Windows.Visibility.Hidden;
            ServerList.Visibility = System.Windows.Visibility.Hidden;
            Installer.Visibility = System.Windows.Visibility.Hidden;
            SettingsSlide.Visibility = System.Windows.Visibility.Hidden;
        }

        /*
         * function RecentNews_Btn_MouseDown
         * This is used to activate the recent news slide.
         */
        private void RecentNews_Btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.HideAll();
            RecentNews.Visibility = System.Windows.Visibility.Visible;
        }

        /*
         * function ServerList_Btn_MouseDown
         * This is used to activate the server list slide.
         */
        private void ServerList_Btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.HideAll();
            ServerList.Visibility = System.Windows.Visibility.Visible;
        }

        /*
         * function Installer_Btn_MouseDown
         * This is used to activate the installer slide.
         */
        private void Installer_Btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.HideAll();
            Installer.Visibility = System.Windows.Visibility.Visible;
        }

        /*
         * function Settings_Btn_MouseDown
         * This is used to activate the settings slide.
         */
        private void Settings_Btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.HideAll();
            SettingsSlide.Visibility = System.Windows.Visibility.Visible;
        }

        /*
         * function serverListView_Click
         * This connects the user to a server.
         */
        private void serverListView_Click(object sender, MouseButtonEventArgs e)
        {
            var _selectedItem = (serverListItem)serverListView.SelectedItems[0];
           // MessageBox.Show("Type is:" + firstSelectedItem.ServerName);
            var _gameIP = _selectedItem.IP;
            var _gamePort = _selectedItem.Port;
            string _gamePath = Settings.Arma3Path + @"\arma3.exe";
            string _args = "-connect=" + _gameIP + " -port=" + _gamePort + Settings.Arma3_Options+ " " + @"-mod=""@DayZA3_Chernarus;@CBA_A3;@AllInArma\ProductDummies;C:\Program Files (x86)\Steam\steamapps\common\Take On Helicopter;" + Settings.Arma2Path + ";" + Settings.Arma2OAPath + ";" + Settings.Arma2OAPath + @"\Expansion" + ";" + Settings.Arma3Path + ";" + @"@AllInArma\Core;@AllInArma\PostA3""";
            Console.WriteLine("GAME PATH:" + _gamePath);
            System.Diagnostics.Process.Start(_gamePath, _args);
        }

        /*
         * function ServerList_Refresh_MouseUp
         * This clears the items list, then generates a new list from XML data.
         */
        private void ServerList_Refresh_MouseUp(object sender, RoutedEventArgs e)
        {
            ServerListMW.Clear();
            serverListCreator list = new serverListCreator(this);
        }


        /*
         * function Arma2Path_Btn_Click
         * This sets the Arma2 Paths.
         */
        private void Arma2Path_Btn_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.FolderBrowserDialog();
            dlg.ShowNewFolderButton = true; //if you want new folders as well
            dlg.SelectedPath = @"C:\Program Files (x86)\Steam\SteamApps\common\Arma 2"; //where to start
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //ok user selected something
                Arma2Path_Box.Text = dlg.SelectedPath;
            }
        }

        /*
         * function Arma2OAPath_Btn_Click
         * This sets the Arma2 Operation Arrowhead Paths.
         */
        private void Arma2OAPath_Btn_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.FolderBrowserDialog();
            dlg.ShowNewFolderButton = true; //if you want new folders as well
            dlg.SelectedPath = @"C:\Program Files (x86)\Steam\SteamApps\common\Arma 2 Operation Arrowhead"; //where to start
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //ok user selected something
                Arma2OAPath_Box.Text = dlg.SelectedPath;
            }
        }

        /*
         * function Arma3Path_Btn_Click
         * This sets the Arma3 Paths.
         */
        private void Arma3Path_Btn_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new System.Windows.Forms.FolderBrowserDialog();
            dlg.ShowNewFolderButton = true; //if you want new folders as well
            dlg.SelectedPath = @"C:\Program Files (x86)\Steam\SteamApps\common\Arma 3"; //where to start
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //ok user selected something
                Arma3Path_Box.Text = dlg.SelectedPath;
            }
        }
    }
}
