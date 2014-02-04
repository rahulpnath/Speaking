using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;

namespace Samples
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            if (IsolatedStorageSettings.ApplicationSettings.Contains("CheckSetting"))
            {
                this.checkSetting.IsChecked = IsolatedStorageSettings.ApplicationSettings["CheckSetting"] as bool?;
            }
        }

        private void CheckSetting_Checked(object sender, RoutedEventArgs e)
        {
            // SystemTray.ProgressIndicator.IsVisible = checkSetting.IsChecked.Value;

            string checksetting = "CheckSetting";

            if (!IsolatedStorageSettings.ApplicationSettings.Contains(checksetting))
            {
                IsolatedStorageSettings.ApplicationSettings.Add(checksetting, checkSetting.IsChecked);
            }
            else
            {
                IsolatedStorageSettings.ApplicationSettings[checksetting] = checkSetting.IsChecked;
            }
        }

        private void toggleSetting_Clicked(object sender, RoutedEventArgs e)
        {
            StandardTileData tileData = new StandardTileData();
            tileData.BackContent = toggleSetting.IsChecked.ToString();
            tileData.Count = 10;
            ShellTile.ActiveTiles.First().Update(tileData);
        }
    }
}