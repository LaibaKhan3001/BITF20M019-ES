using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1
{
    internal class Location
    {
        // Attributes
        public float Latitude { get; set; }
        public float Longitude { get; set; }

        // Constructor
        public Location(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        // Function to set the location
        public void SetLocation(float latitude, float longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
