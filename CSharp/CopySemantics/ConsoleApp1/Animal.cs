namespace ConsoleApp1
{

    public class Animal : BaseAnimal<double>
    {
        public Animal(string name) : base(name)
        {
            
        }
        
        public override IAnimal<double> Copy()
        {
            return new Animal(Name);
        }
    }
}