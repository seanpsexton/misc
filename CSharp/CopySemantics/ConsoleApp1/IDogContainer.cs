namespace ConsoleApp1
{
    public interface IDogContainer : IContainer<IDog<double>>
    {
        string DogContainerThing { get; set; }
    }
}