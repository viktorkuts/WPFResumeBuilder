using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFResumeBuilder
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public List<string> Phones { get; set; }
        public List<string> Education { get; set; }
        public List<string> Work { get; set; }
        public string _created;
        public string _modified;
        public string Created {
            get
            {
                return $"Created at: {_created}";
            }
            set
            {
                _created = value;
            }
        }
        public string Modified {
            get
            {
                return $"Modified at: {_modified}";
            }
            set
            {
                _modified = value;
            }
        }
        public User(string firstName, string lastName, string address, List<string> phones, string created, string modified, List<string> education, List<string> work)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phones = phones;
            Created = created;
            Modified = modified;
            Education = education;
            Work = work;
        }
    }
}
