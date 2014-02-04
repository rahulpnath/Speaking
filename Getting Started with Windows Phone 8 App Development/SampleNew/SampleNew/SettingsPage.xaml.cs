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

namespace SampleNew
{
    public partial class SettingsPage : PhoneApplicationPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            if (IsolatedStorageSettings.ApplicationSettings.Contains("CheckSetting"))
            {
                checkSetting.IsChecked = IsolatedStorageSettings.ApplicationSettings["CheckSetting"] as bool?;
            }
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (!IsolatedStorageSettings.ApplicationSettings.Contains("CheckSetting"))
            {
                IsolatedStorageSettings.ApplicationSettings.Add("CheckSetting", checkSetting.IsChecked);
            }
            else
            {
                IsolatedStorageSettings.ApplicationSettings["CheckSetting"] = checkSetting.IsChecked;
            }
        }


    }
}