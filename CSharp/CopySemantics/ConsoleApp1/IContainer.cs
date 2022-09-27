namespace ConsoleApp1
{
    public interface IContainer<out T> : ICopyable<IContainer<T>>
    {
        T Contained { get; }
        
        string ContainerThing { get; set; }
    }
}