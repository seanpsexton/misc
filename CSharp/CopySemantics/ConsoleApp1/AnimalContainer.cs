namespace ConsoleApp1
{
    public class AnimalContainer : Container<IAnimal<double>>, IAnimalContainer
    {
        public AnimalContainer(IAnimal<double> animal, string animalContainerThing)
        {
            Contained = animal;
            AnimalContainerThing = animalContainerThing;
        }
        
        public string AnimalContainerThing { get; set; }

        public override IContainer<IAnimal<double>> Copy()
        {
            return new AnimalContainer(Contained.Copy(), AnimalContainerThing);
        }
    }
}