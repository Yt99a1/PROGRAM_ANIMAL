using System;
using initize_diet_size;
using Animalfunction;
using System.Collections.Generic;
using TrainFunction;

namespace TrainDistFunction
{
    public class TrainDistribution
    {
        public List<Train> Trains { get; set; }

        public TrainDistribution()
        {
            Trains = new List<Train>();
        }

        public void AddAnimal(Animal animal)
        {
            
            foreach (var Train in Trains)
            {
                if (Train.AddAnimal(animal))
                {
                    return;
                }
            }

            
            var newTrain = new Train();
            newTrain.AddAnimal(animal);
            Trains.Add(newTrain);
        }

        public void DistributeAnimals(List<Animal> animals)
        {
            
            animals = animals.OrderByDescending(a => a.Size).ToList();

            
            var meatEaters = animals.Where(a => a.Diet == Diet.Meat).ToList();
            var plantEaters = animals.Where(a => a.Diet == Diet.Plant).ToList();

            
            foreach (var animal in meatEaters)
            {
                AddAnimal(animal);
            }

          
            foreach (var animal in plantEaters)
            {
                AddAnimal(animal);
            }
        }
    }
}