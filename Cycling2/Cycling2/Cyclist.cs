using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycling2
{
    
    public class Cyclist : Teammember
    {
        private int _position = 0;
        private int _sprintPosition = 0;
        public int Group { get; set; }
        public int Points = 0;
        public bool first = false;
        

        public Cyclist() : base()
        {

        }

        public Cyclist(int id, Random random) : base(id, random)
        {

        }


        public int Position
        {
            get
            {
                return _position;
            }
            set
            {
              _position = value;
            }
        }



        public int SprintPosition
        {
            get
            {
                return _sprintPosition;
            }
            set
            {
                _sprintPosition = value;
            }
        }
    }
}
