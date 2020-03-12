using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace SafeWayzMap2.Model
{
    public class CustomCircle
    {
        public Position Position { get; set; }
        
        public Color StrokeColor { get; set; }
        public int StrokeWidth { get; set; }
        public double Radius { get; set; }
    }
}
