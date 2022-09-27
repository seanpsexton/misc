namespace ConsoleApp1
{
    public interface ICopyable<out T>
    {
        T Copy();
    }
}