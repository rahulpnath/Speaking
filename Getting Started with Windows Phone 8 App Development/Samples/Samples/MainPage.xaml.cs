using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Samples.Resources;
using System.Collections.ObjectModel;

namespace Samples
{
    using System.IO;

    using Samples.Models;
    using System.Runtime.Serialization.Json;
    using System.Text;

    public partial class MainPage : PhoneApplicationPage
    {
        
        private string dataUrl = "https://api.500px.com/v1/photos?feature={0}&rpp=10&page=1&exclude=4&consumer_key=B23IPZehpma6Du0IemudU1NNHmVuyAC512z4UOfl";

        private static string[] streams = new string[] { "popular", "upcoming", "editors" };

        ObservableCollection<PhotoStream> photoStreams = new ObservableCollection<PhotoStream>();


        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.DataContext = photoStreams;

            this.LoadData();
        }

        private void LoadData()
        {
            foreach (var stream in streams)
            {
                var streamUrl = string.Format(dataUrl, stream);
                WebClient client = new WebClient();
                client.DownloadStringCompleted += client_DownloadStringCompleted;
                client.DownloadStringAsync(new Uri(streamUrl));
            }   
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PhotoStream));
            var stream = serializer.ReadObject(new MemoryStream(Encoding.Unicode.GetBytes(e.Result))) as PhotoStream;
            photoStreams.Add(stream);
        }



        private void Settings_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.Relative));
        }
    }
}