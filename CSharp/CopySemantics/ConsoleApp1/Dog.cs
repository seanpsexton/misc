namespace ConsoleApp1
{

    public class Dog : Animal, IDog<double>
    {
        public Dog(string name, string breed) : base(name)
        {
            Breed = breed;
        }
        
        public string Breed { get; set; }

        public override IAnimal<double> Copy()
        {
            var newDog = new Dog(Name, Breed);
            return newDog;
        }
    }
}