using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_NoSql
{
    public class Place
    {
        private string name;
        private string placeName;
        private string placeType;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string PlaceName
        {
            get { return placeName; }
            set { placeName = value; }
        }

        public string PlaceType
        {
            get { return placeType; }
            set { placeType = value; }
        }

        public Place(string name, string placeName, string placeType)
        {
            this.name = name;
            this.placeName = placeName;
            this.placeType = placeType;
        }

        public override string ToString()
        {
            return name + ", " + placeName + ", " + placeType;
        }
    }
}
