using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycling2
{
    class RaceDatabase
    {
        private List<Cyclist> _allCyclist = new List<Cyclist>();
        private char[] _raceGround;

        public RaceDatabase(Database database, Raceground race)
        {
            _allCyclist = database.getDatabase;
            _raceGround = race.getRaceground;
        }

        public List<Cyclist> getCyclistList
        {
            get
            {
                return _allCyclist;
            }
            set
            {
                ;
            }
        }
        public int getRaceLength
        {
            get
            {
                return _raceGround.Length;
            }
            set
            {
                ;
            }
        }
        public char[] getRaceground
        {
            get
            {
                return _raceGround;
            }
            set
            {

            }
        }
    }
}
