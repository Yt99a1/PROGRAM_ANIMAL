using System;
using System.Collections.Generic;
using System.Linq;
using Animalfunction;

namespace TrainFunction
{
    public class Train
    {
        public List<Animal> Animals { get; set; }
        public int Capacity { get; set; }

        public Train()
        {
            Capacity = 50;
            Animals = new List<Animal>();
        }


        public bool AddAnimal(Animal animal)
        {

            if (GetTotalSize() + animal.GetAnimalSize <= Capacity)
            {
                Animals.Add(animal);
                return true;
            }
            return false;
        }


        public int GetTotalSize()
        {
            return Animals.Sum(a => a.GetAnimalSize);
        }
    }
}