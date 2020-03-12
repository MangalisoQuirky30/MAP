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
        public List<Pin> _pins;

        public MainPage()
        {
            InitializeComponent();

            Map map = new Map();
            myMap = map;
            myMap.MapType = MapType.Satellite;



            var pin1 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(37, -122),
                Label = "Xamarin San Francisco Office",
                Address = "394 Pacific Ave, San Francisco CA"
            };

            myMap.Pins.Add(pin1);


            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(38, -121),
                Label = "Xamarin San Francisco Office",
                Address = "394 Pacific Ave, San Francisco CA"
            };

            myMap.Pins.Add(pin2);

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

            Position pos = new Position();
            pos = approximateLocations.FirstOrDefault();

            return pos;
        }


        public async void PlotPositions()
        {
            _positions = new List<Position>();

            for (int i = 0; i <= _posts.Count - 1; i++)
            {
                Position pos = new Position();
                pos = await GetPosition(_posts[i].Address);
                var lat = pos.Latitude;
                var lng = pos.Longitude;
                _positions.Add(pos);
            }

            _pins = new List<Pin>();

            for (int x = 0; x < _positions.Count - 1; x++)
            {
                Pin pin = new Pin
                {
                    Label = "[incident]",
                    Address = "[incident description]",
                    Type = PinType.Place,
                    Position = _positions[x]
                };
                _pins.Add(pin);

            }

            for (int p = 0; p < _pins.Count - 1; p++)
            {
                myMap.Pins.Add(_pins[p]);
            }
        }
    }
}
 