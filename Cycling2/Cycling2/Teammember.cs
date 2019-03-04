using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycling2
{
    public class Teammember : Person
    {
        private int _strength = 0;
        private int _sprint = 0;
        private int _potential;
        private int _teamID;

        public Teammember() : base()
        {

        }

        public Teammember(int id, Random random) : base(id, random)
        {
            _potential = random.Next(0, 10);
        }

        public int Strength
        {
            get
            {
                return _strength;
            }
            set
            {
                _strength = value;
            }
        }

        public int GetSprint
        {
            get
            {
                return _sprint;
            }
            set
            {
                _sprint=value;
            }
        }

        public int GetPotential
        {
            get
            {
                return _potential;
            }
            set
            {

            }
        }
    }
}
