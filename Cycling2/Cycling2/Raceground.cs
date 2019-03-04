using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycling2
{
    class Raceground
    {
        private char[] _raceGround;

        public Raceground()
        {
            Console.WriteLine("How long is the race?");
            var input = Console.ReadLine();
            if (input == "")
            {
                _raceGround = new char[200];
            }
            else
            {
                _raceGround = new char[Convert.ToInt32(input)];
            }
            Console.Clear();
        }

        public int getLength
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
