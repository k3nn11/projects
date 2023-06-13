using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World
{
    internal class Safari_park<T> where T : Animal
    {
        public int _count = 0;
        public int _index = 0;
        private int _size;
        private Animal[] _animal;

        public Safari_park(int size)
        {
            _size = size;
            _animal = new Animal[_size];
        }

        public void AddAnimal(T animal)
        {
            if (!(animal is T))
            {
                throw new Exception("The animal is valid");
            }

            if (_index == _size)
            {
                throw new Exception("The park is full");
            }

            _animal[_index] = animal;
            _index++;
        }

        public int NumberofAnimals()
        {
            for (int i = 0; i < _animal.Length; i++)
            {
                if (_animal[i] != null)
                {
                    _count++;
                }
            }

            return _count;
        }

        public T[] SortAnimalsBySpecies(string species)
        {
            List<T> foundAnimals = new List<T>();
            foreach (T animal in _animal)
            {
                if (animal == null)
                {
                    break;
                }

                if (animal.Species == species)
                {
                    foundAnimals.Add(animal);
                }
            }

            if (foundAnimals.Count == 0)
            {
                throw new Exception("The species does not exist in the safari_park");
            }

            return foundAnimals.ToArray();
        }

        public string[] GetArrayOfSpecies(Animal[] animal)
        {
            List<string> species = new List<string>();
            for ( int i = 0; i < NumberofAnimals(); i++)
            {
                if (animal[i] == null)
                {
                    break;
                }

                if (!species.Contains(animal[i].Species))
                {
                    species.Add(animal[i].Species);
                }
            }

            return species.ToArray();
        }

        public Animal[] AnimalArray()
        {
            return _animal.ToArray();
        }
    }
}
