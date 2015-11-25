using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_NoSql
{
    public class Movements
    {
        private int id;
        private string movementName;
        private string era;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string MovementName
        {
            get { return movementName; }
            set { movementName = value; }
        }

        public string Era
        {
            get { return era; }
            set { era = value; }
        }

        public override string ToString()
        {
            return id.ToString() + ", " + movementName + ", " + era;
        }
    }
}
