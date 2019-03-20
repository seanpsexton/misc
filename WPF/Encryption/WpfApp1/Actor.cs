using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Actor
    {
        public Actor(string first, string last, int? birth, int? death = null)
        {
            FirstName = first;
            LastName = last;
            BirthYear = birth;
            DeathYear = death;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? BirthYear { get; set; }
        public int? DeathYear { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName} ({BirthYear}-{DeathYear})";
        }
    }
}
