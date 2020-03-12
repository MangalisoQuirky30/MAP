using SafeWayzMap2.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace SafeWayzMap2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPageCS : ContentPage
    {
        public MapPageCS()
        {
            InitializeComponent();

            /*Map myMap = new Map(
                MapSpan.FromCenterAndRadius(new Position(-33.9197365, 18.5616625),
                Distance.FromKilometers(100000)));
                */

            CustomMap myMap = new CustomMap
            {
                MapType = MapType.Street,
                WidthRequest = 1000,
                HeightRequest = 1000
            };

            var pin = new Pin
            {
                Type = PinType.Place,
                Position = new Position(-33.918861, 18.423300),
                Label = "cpt cpt",
                Address = "cpt"
            };
            myMap.Pins.Add(pin);

            var pin2 = new Pin
            {
                Type = PinType.Place,
                Position = new Position(38, -121),
                Label = "pin 2",
                Address = "394 Pacific Ave, San Francisco CA"
            };
            myMap.Pins.Add(pin2);

            var position = new Position(-33.918861, 18.423300);



            myMap.Circle = new CustomCircle
            {
                Position = position,
                Radius = 100000,
                StrokeColor = Color.Red,
                StrokeWidth = 100,
            };


            myMap.MoveToRegion(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(1.0)));


            // instantiate a polyline
            Polyline polyline = new Polyline
            {
                StrokeColor = Color.Blue,
                StrokeWidth = 100,
                Geopath =
                {
                    new Position(-33.918861 , 18.423300),
                    new Position(-33.918864 , 18.423306),
                    new Position(-33.918863 , 18.423307),
                    new Position(-33.918862 , 18.423308),
                    new Position(-33.918860 , 18.423308)
                }
            };

            // add the polyline to the map's MapElements collection
            myMap.MapElements.Add(polyline);

            
            Content = myMap;

            /*
            
            Polyline poli = new Polyline(pin.Position.Latitude, pin2.Position.Longitude);
            myMap.MapElements.Add(new Polyline());


            
          var position = new Position(37.79752, -122.40183);
          myMap.Circle = new CustomCircle
          {
              Position = position,
              Radius = 1000
          };
          myMap.MapElements.Add(new Circle());  
          myMap.Pins.Add(pin);

          Task<Position> pos = GetPosition("Cape Town");
          Debug.WriteLine(pos);*/
        }



        /*
        private async Task<Position> GetPosition(string address)
        {
            Position pos = await CustomMapRenderer.GetPosition(address);
            return pos;
        }
        */
    }
}