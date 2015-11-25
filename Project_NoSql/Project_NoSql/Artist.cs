using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_NoSql
{
    public class Artist
    {
        Event birth = null;
        Event death = null;
        Place activePlace = null;

        private string fc = null;
        private string gender = null;
        private int id = 0;
        private int totalWorks = 0;
        private string url = null;

        public string Fc
        {
            get { return fc; }
            set { fc = value; }
        }

        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public int TotalWorks
        {
            get { return totalWorks; }
            set { totalWorks = value; }
        }

        public string Url
        {
            get { return url; }
            set { url = value; }
        }


        public Artist(string fc, string gender, int id, int totalWorks, string url, Event birth)
        {
            this.fc = fc;
            this.gender = gender;
            this.id = id;
            this.totalWorks = totalWorks;
            this.url = url;
            this.birth = birth;
        }

        public Artist(string fc, string gender, int id, int totalWorks, string url, Event birth, Place activePlace)
        {
            this.fc = fc;
            this.gender = gender;
            this.id = id;
            this.totalWorks = totalWorks;
            this.url = url;
            this.birth = birth;
            this.activePlace = activePlace;
        }

        public Artist(string fc, string gender, int id, int totalWorks, string url, Event birth, Event death)
        {
            this.fc = fc;
            this.gender = gender;
            this.id = id;
            this.totalWorks = totalWorks;
            this.url = url;
            this.birth = birth;
            this.death = death;
        }

        public override string ToString()
        {
            return fc + ", " + gender + ", " + id + ", " + totalWorks + ", " + url + ", " + birth.ToString() + ", " + activePlace.ToString() + ", " + death.ToString();
        }
    }
}
