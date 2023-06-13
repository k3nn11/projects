using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Safari_park<Animal> animal = new Safari_park<Animal>(20);

            Bird bird1 = new Bird();
            bird1.SetAnimal("House Sparrow", 2.1, "Passeridae", "Amazon");
            Bird bird2 = new Bird();
            bird2.SetAnimal("Great Horned Owl", 2.2, "Strigidae ", "Ice Land");
            Bird bird3 = new Bird();
            bird3.SetAnimal("Song Sparrow", 1.8, "Passeridae", "Carribean Islands");
            Bird bird4 = new Bird();
            bird4.SetAnimal("Rock Pigeon", 1.3, "Columbidae", "Himalayas");
            Bird bird5 = new Bird();
            bird5.SetAnimal("Merlin", 1.5, "Falconidae", "Savannah");
            Cat cat1 = new Cat();
            cat1.SetAnimal("Simba", 2.1, "lion", "Savannah");
            Cat cat2 = new Cat();
            cat2.SetAnimal("Bosko", 2.2, "wild Dog", "Rainforest");
            Cat cat3 = new Cat();
            cat3.SetAnimal("Nala", 1.5, "lion", "Savannah");
            Cat cat4 = new Cat();
            cat4.SetAnimal("Swifty", 2.5, "Cheetah", "Savannah");
            Cat cat5 = new Cat();
            cat5.SetAnimal("Ricky", 2.1, "Leopard", "Semi Arid");
            Cat cat6 = new Cat();
            cat6.SetAnimal("Rex", 3.1, "Puma", "North America");

            animal.AddAnimal(bird1);
            animal.AddAnimal(bird2);
            animal.AddAnimal(bird3);
            animal.AddAnimal(bird4);
            animal.AddAnimal(bird5);
            animal.AddAnimal(cat1);
            animal.AddAnimal(cat2);
            animal.AddAnimal(cat3);
            animal.AddAnimal(cat4);
            animal.AddAnimal(cat5);
            animal.AddAnimal(cat6);

            int animalNumber = animal.NumberofAnimals();
            int speciesNumber = animal.GetArrayOfSpecies(animal.AnimalArray()).Count();
            Console.WriteLine("There are {0} animals in the safaripark in total.\n", animalNumber);
            Console.WriteLine("Out of the {0} animals, we have {1} different types of species which are listed below: \n", animalNumber, speciesNumber);
            string[] speciesArray = animal.GetArrayOfSpecies(animal.AnimalArray());
            foreach (var a in speciesArray)
            {
                Console.WriteLine(a);
            }

            Console.Write("\nEnter name of species to get details of animals: ");
            
            string userEnteredSpecies = Console.ReadLine();
            if( )

            Animal[] sortedArray = animal.SortAnimalsBySpecies(userEnteredSpecies);
            foreach (Animal b in sortedArray)
            {
                Console.WriteLine("name: {0}, age: {1}, Species: {2}, Original habitat: {3}.", b.Name, b.Age, b.Species, b.OriginalHabitat);
            }
            
        }
    }
}
