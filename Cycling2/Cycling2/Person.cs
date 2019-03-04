using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cycling2
{
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private string _name;
        private int _id;
        private int _age;

        public Person()
        {

        }

        public Person(int id,Random random)
        {
            GenerateName generateName = new GenerateName(random);

            _id = id;
            _firstName = generateName.GetFirstName;
            _lastName = generateName.GetLastName;
            _name = _firstName + " " + _lastName;
        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public int GetId
        {
            get
            {
                return _id;
            }
            set
            {

            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
        }
    }
}
