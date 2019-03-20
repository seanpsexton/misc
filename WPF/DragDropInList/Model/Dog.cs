using System;
using TestApp.Core;

namespace TestApp.Model
{
    public class Dog : INPCBase, IEquatable<Dog>
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetField(ref _name, value); }
        }

        private string _breed;
        public string Breed
        {
            get { return _breed; }
            set { SetField(ref _breed, value); }
        }

        private int _age;
        public int Age
        {
            get { return _age; }
            set { SetField(ref _age, value); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { SetField(ref _isSelected, value); }
        }

        public Dog(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public Dog(string name, int age, string breed) :this(name,age)
        {
            Breed = breed;
        }

        // 1 MB
        private byte[] _dogData = new byte[1048576];

        public override string ToString()
        {
            return string.Format("{0} ({1}) - {2}", Name, Age, Breed);
        }

        public static bool operator ==(Dog d1, Dog d2)
        {
            if (ReferenceEquals(d1, null))
            {
                return ReferenceEquals(d2, null) ? true : false;
            }

            return d1.Equals(d2);
        }

        public static bool operator !=(Dog d1, Dog d2)
        {
            return !(d1 == d2);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as Dog);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode() ^ Age.GetHashCode();
        }

        public bool Equals(Dog otherDog)
        {
            if (ReferenceEquals(otherDog, null))
                return false;

            return (Name == otherDog.Name) && (Age == otherDog.Age);
        }
    }
}
