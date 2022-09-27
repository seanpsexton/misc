// See https://aka.ms/new-console-template for more information

using System;
using ConsoleApp1;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Basic copy semantics
            var a1 = new Animal("A1");
            var a2 = a1.Copy();
            var d1 = new Dog("Fido","Terrier");
            var d2 = d1.Copy();

            // Copy through interfaces - still works as expected
            var iAnimal1 = (IAnimal<double>)a1;
            var iDog1 = (IDog<double>)d1;
            var iAnimal2 = iAnimal1.Copy();
            var iDog2 = iDog1.Copy();

            // Without polymorphism, using base interface results in wrong Copy
            IAnimal<double> iAnimal3 = d1;
            var d3 = iAnimal3.Copy();
            
            // Create containers
            var animalCont = new AnimalContainer(new Animal("Bessie"), "animContThing");
            var dogCont = new DogContainer(new Dog("Rufus", "Spaniel"), "dogContThing");
            
            // Copy containers with objects in them
            var animalCont2 = animalCont.Copy();
            var dogCont2 = dogCont.Copy();

            Console.ReadLine();
        }
    }
}