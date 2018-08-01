

namespace HelloWorld
{
    public class Dog : INPCBase
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

        public Dog(string name, int age, string breed) 
        {
            Name = name;
            Age = age;
            Breed = breed;
        }

        public override string ToString()
        {
            return string.Format("{0} ({1} yrs)", Name, Age);
        }

    }
}
