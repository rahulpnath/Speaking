using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Samples.PCL
{
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Runtime.Serialization.Json;

    using Samples.Models;
    using System.Net.Http;

    public class PhotoStreamVM
    {
        private string dataUrl =
            "https://api.500px.com/v1/photos?feature={0}&rpp=10&page=1&exclude=4&consumer_key=B23IPZehpma6Du0IemudU1NNHmVuyAC512z4UOfl";

        private static string[] streams = new string[] { "popular", "upcoming", "editors" };

        public  ObservableCollection<PhotoStream> PhotoStreams { get; set; }

        public PhotoStreamVM()
        {
            PhotoStreams = new ObservableCollection<PhotoStream>();
            this.LoadData();
        }

        private async void LoadData()
        {
            try
            {
                foreach (var stream in streams)
                {
                    var streamUrl = string.Format(dataUrl, stream);
                    HttpClient client = new HttpClient();
                    string response = await client.GetStringAsync(streamUrl);

                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(PhotoStream));
                    var photoStream =
                        serializer.ReadObject(new MemoryStream(Encoding.Unicode.GetBytes(response))) as PhotoStream;
                    PhotoStreams.Add(photoStream);
                }
            }
            catch (Exception)
            {
                
            }
        }
    }
}
