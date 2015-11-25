using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_NoSql
{
    public class Event
    {
        private int year;
        Place placeEvent;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public Place PlaceEvent
        {
            get { return placeEvent; }
            set { placeEvent = value; }
        }

        public Event(int year, Place placeEvent)
        {
            this.year = year;
            this.placeEvent = placeEvent;
        }

        public override string ToString()
        {
            return year.ToString() + ", " + placeEvent.ToString();
        }
    }
}
