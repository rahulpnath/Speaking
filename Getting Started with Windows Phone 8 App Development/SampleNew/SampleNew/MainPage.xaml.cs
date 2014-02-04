using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using SampleNew.Resources;
using System.Runtime.Serialization.Json;
using SampleNew.Model;

namespace SampleNew
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Text;

    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            this.LoadData();
            this.Photos.DataContext = PhotoStreams;
        }

        ObservableCollection<PhotoStream> PhotoStreams = new ObservableCollection<PhotoStream>();

        private string baseUrl = "https://api.500px.com/v1/photos?feature={0}&rpp=10&page=1&exclude=4&consumer_key=B23IPZehpma6Du0IemudU1NNHmVuyAC512z4UOfl";

        private static string[] streams = new string[] { "popular", "upcoming", "editors", "fresh_today" };

        private void LoadData()
        {
            foreach (var stream in streams)
            {
                string streamUrl = string.Format(baseUrl, stream);
                WebClient client = new WebClient();
                client.DownloadStringCompleted += client_DownloadStringCompleted;
                client.DownloadStringAsync(new Uri(streamUrl));
            }
        }

        void client_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PhotoStream));
            var stream = serializer.ReadObject(new MemoryStream(Encoding.Unicode.GetBytes(e.Result))) as PhotoStream;
            PhotoStreams.Add(stream);
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/SettingsPage.xaml", UriKind.Relative));
        }

        private void Image_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            FrameworkElement elem = sender as FrameworkElement;
            Photo ph = elem.DataContext as Photo;
            StandardTileData tile = new StandardTileData();
            tile.BackBackgroundImage = new Uri(ph.image_url);
            tile.Count = 10;
            ShellTile.ActiveTiles.First().Update(tile);
        }


    }
}