using System;
using initize_diet_size;
using Animalfunction;
using System.Collections.Generic;

namespace TrainFunction
{
    public class Train
    {
        public List<Animal> Animals { get; set; }
        
        public int CapacityofTrain { get; set; }


        public Train()
        {
            CapacityofTrain = 50;
            Animals = new List<Animal>();
        }
        public bool AddAnimal(Animal animal)
        {
            if(getTotalthings()+ animal.GetAnimalSize <= CapacityofTrain )
            {
                Animal.Add(animal);
                return true;

            }
            return false;
        }
        public int  getTotalthings()
        {
            return Animals.Sum(a => a.GetAnimalSize);
        }


    }
}

