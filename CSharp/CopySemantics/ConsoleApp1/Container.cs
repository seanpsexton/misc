namespace ConsoleApp1
{
    public abstract class Container<T> : IContainer<T>
        where T : class, IAnimal<double>
    {
        protected Container()
        {
            Contained = null;
        }
        
        public T Contained { get; protected set; }
        
        public string ContainerThing { get; set; }
        
        public abstract IContainer<T> Copy();
    }
}