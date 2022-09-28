namespace ConsoleApp1
{
    public class DogContainer : Container<IDog<double>>, IDogContainer
    {
        public DogContainer(IDog<double> dog, string dogContainerThing)
        {
            Contained = dog;
            DogContainerThing = dogContainerThing;
        }

        public string DogContainerThing { get; set; }
        
        // public override IContainer<IDog<double>> Copy()
        // {
        //     var dogCopy = Contained.Copy() as IDog<double>;
        //     return new DogContainer(dogCopy, DogContainerThing);
        // }
        public override IContainer<IDog<double>> Copy()
        {
            var dogCopy = Contained.Copy();
            return new DogContainer(dogCopy, DogContainerThing);
        }
    }
}