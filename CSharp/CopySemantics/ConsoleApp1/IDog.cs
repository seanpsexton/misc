namespace ConsoleApp1
{

    public interface IDog<T> : IAnimal<T>
        where T : struct
    {
        string Breed { get; set; }
    }
}