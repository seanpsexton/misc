using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Dog : ViewModelBase
    {
        public Dog() { }

        ~Dog()
        {
        }

        public Dog(string name, int age)
        {
            Name = name;
            Age = age;
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value); }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { SetField(ref _age, value); }
        }

        private Dog _friend;
        public Dog Friend
        {
            get { return _friend; }
            set { SetField(ref _friend, value); }
        }

        public string FancyName => $"{Name} - aged {Age}";

        public string BColumn1 => "B col 1";
        public string BColumn2 => "B col 2";
        public string CColumn1 => "C col 1";
        public string CColumn2 => "C col 2";

        public override string ToString()
        {
            return $"{Name} ({Age})";
        }
    }
}
