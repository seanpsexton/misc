namespace ConsoleApp1
{
    public interface IAnimalContainer : IContainer<IAnimal<double>>
    {
        string AnimalContainerThing { get; set; }
    }
}