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
        public MainWindow()
        {
            InitializeComponent();
            this.HideAll();
            RecentNews.Visibility = System.Windows.Visibility.Visible;

            //serverListItems list = new serverListItems();
            //serverListItem item1 = new serverListItem(true, "1", "2", "3", "4", "5");
            //list.Add(item1);
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
            Settings.Visibility = System.Windows.Visibility.Hidden;
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
            Settings.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
