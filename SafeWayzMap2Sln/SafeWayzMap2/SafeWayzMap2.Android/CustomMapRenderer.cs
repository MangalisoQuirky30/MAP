using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using MapOverlay;
using MapOverlay.Droid;
using SafeWayzMap2.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace MapOverlay.Droid
{
    public class CustomMapRenderer : MapRenderer
    {
        private CustomCircle circle;


        public ObservableCollection<Post> _posts { get; set; }
        public List<Position> _positions;
        public List<Pin> _pins;
        GoogleMap myMap;
        Position pos;
        public CustomMapRenderer(Context context) : base(context)
        {
        }
         
        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
               // NativeMap.InfoWindowClick -= OnInfoWindowClick;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                circle = formsMap.Circle;
            }
        }

        protected override void OnMapReady(Android.Gms.Maps.GoogleMap map)
        {
            //base.OnMapReady(map);

            myMap = map;
            Position pos = new Position();

            /*   // object of referemce is not se to an instance of an object
               pos = new Position(circle.Position.Latitude , circle.Position.Longitude);
               var circleOptions = new CircleOptions();
               circleOptions.InvokeCenter(new LatLng(pos.Latitude, pos.Longitude));
               circleOptions.InvokeRadius(circle.Radius);
               circleOptions.InvokeFillColor(0X66FF0000);
               circleOptions.InvokeStrokeColor(0X66FF0000);
               circleOptions.InvokeStrokeWidth(0);

               myMap.AddCircle(circleOptions);


               var position = new Position(37.79752, -122.40183);
             /*  myMap.AddCircle = new CustomCircle
               {
                   Position = position,
                   Radius = 1000
               };  */
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


                NativeMap.AddCircle(
                    new CircleOptions().InvokeCenter(new LatLng(_positions[x].Latitude, _positions[x].Longitude))
                    .InvokeRadius(50)
                    .InvokeStrokeColor(845249)
                    .InvokeFillColor(214682)
                    );

            }

            for (int p = 0; p < _pins.Count - 1; p++)
            {
                //NativeMap.Pins.Add(_pins[p]);
            }
        }
    }
}
