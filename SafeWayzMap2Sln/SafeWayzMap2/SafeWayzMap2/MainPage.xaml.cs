using MapApp;
using Newtonsoft.Json;
using SafeWayzMap2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
//using Xamarin.Forms.Maps;

namespace SafeWayzMap2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Post> _posts { get; set; }
        public List<Position> _positions;
        public MainPage()
        {
            InitializeComponent();
            
            Map map = new Map();
            myMap = map;
            myMap.MapType = MapType.Satellite;

            _posts = GetPosts();
            PlotPositions();
        }

        public ObservableCollection<Post> GetPosts()
        {
            return _posts = new ObservableCollection<Post> {
               new Post { Id = 0 , Address = "Eerste River", Incident = "Shooting" , IncidentDescription = "There was a shooting at Eerste River."} ,
               new Post { Id = 0 , Address = "Kuilsriver", Incident = "Shooting" , IncidentDescription = "There was a shooting at Eerste River."} ,
               new Post { Id = 0 , Address = "UWC bellville", Incident = "Shooting" , IncidentDescription = "There was a shooting at Eerste River."} ,
               new Post { Id = 0 , Address = "CPUT bellville", Incident = "Shooting" , IncidentDescription = "There was a shooting at Eerste River."} ,
               new Post { Id = 0 , Address = "Belhar Cape Town", Incident = "Shooting" , IncidentDescription = "There was a shooting at Eerste River."}
            };
        }

        public async Task<Position> GetPosition(string address)
        {
            Geocoder geoCoder = new Geocoder();
            IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync(address);
            Position position = approximateLocations.FirstOrDefault();
            string coordinates = $"{position.Latitude}, {position.Longitude}";

            return position;
        }


        public async void PlotPositions()
        {
            for (int i = 1; i <= _posts.Count; i++)
            {
                Position pos = await GetPosition(_posts[i].Address);
                var lat = pos.Latitude;
                var lng = pos.Longitude;
                _positions.Add(pos);
            }


           /* for (int x = 0; x < _positions.Count; x++)
            {
                Circle bounds =  myMap.AddCircle(
                    new CircleOptions);
            } */
        }

        

        


}
}