namespace ConsoleApp1

{

    public interface IAnimal<T> : ICopyable<IAnimal<T>>
        where T : struct
    {
        string Name { get; set; }
        T Value { get; set; }
    }
}