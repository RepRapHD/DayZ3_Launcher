using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DayZ3_Launcher
{
    class SettingsManager
    {
        MainWindow window;

        //List of Settings
        public string Arma2Path;
        public string Arma2OAPath;
        public string Arma3Path;
        public string Arma2_Options;
        public string Arma3_Options;
        public string Windowed;
        public string Direct3D_9;


        /*
         * Class SettingsManager
         * This is used to load the settings file and set the initial settings values.
         * This is also used to set/write the individual settings.
         */
        public SettingsManager(MainWindow window)
        {
            this.window = window;
            XDocument xdoc = XDocument.Load("Settings.xml");
            foreach (var setting in xdoc.Descendants("Settings"))
            {
                try
                {
                    this.Arma2Path = setting.Element("Arma2Path").Value;
                    window.Arma2Path_Box.Text = this.Arma2Path;

                    this.Arma2OAPath = setting.Element("Arma2OAPath").Value;
                    window.Arma2OAPath_Box.Text = this.Arma2OAPath;

                    this.Arma3Path = setting.Element("Arma3Path").Value;
                    window.Arma3Path_Box.Text = this.Arma3Path;

                    this.Arma2_Options = setting.Element("Arma2_Options").Value;
                    window.Settings_Arma2Options.Text = this.Arma2_Options;

                    this.Arma3_Options = setting.Element("Arma3_Options").Value;
                    window.Settings_Arma3Options.Text = this.Arma3_Options;

                    this.Direct3D_9 = setting.Element("Direct3D9").Value;
                    if (this.Direct3D_9 == "true")
                    {
                        window.Setting_ForceD3D.IsChecked = true;
                    }
                    this.Windowed = setting.Element("Windowed").Value;
                    if (this.Windowed == "true")
                    {
                        window.Setting_Windowed.IsChecked = true;
                    }
                }
                catch (NullReferenceException except)
                {
                    Console.WriteLine("Error Exception: {0}", except);
                }
            }
        }
    }
}
