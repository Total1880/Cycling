using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycling2
{
    public class GenerateName
    {
        private DbName _firstName = new DbName();
        private DbName _lastName = new DbName();
        private Random _random;

        public GenerateName()
        {
            
        }
        public GenerateName(Random random)
        {
            _random = random;
        }

        public string GetFirstName
        {
            get
            {
                return _firstName.firstName[_random.Next(0, (_firstName.firstName.Count))];
            }
        }

        public string GetLastName
        {
            get
            {
                return _lastName.lastName[_random.Next(0, (_lastName.lastName.Count))];
            }
        }
    }
}
