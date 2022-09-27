namespace ConsoleApp1
{
    public abstract class BaseAnimal<T> : IAnimal<T>
        where T : struct
    {
        protected BaseAnimal(string name)
        {
            Name = name;
        }
        
        public string Name { get; set; }
        public T Value { get; set; }

        public abstract IAnimal<T> Copy();
    }
}