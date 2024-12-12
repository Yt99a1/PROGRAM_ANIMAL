using System;
using System.Collections.Generic;
using System.Linq;
using Animalfunction;
using TrainFunction;

namespace TrainDistFunction
{
    public class TrainDistribution
    {
        public List<Train> Trains { get; } = new List<Train>();

        public void AddAnimal(Animal animal)
        {

            foreach (var train in Trains)
            {
                if (train.AddAnimal(animal))
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

            animals = animals.OrderByDescending(a => a.GetAnimalSize).ToList();

            foreach (var animal in animals)
            {
                AddAnimal(animal);
            }
        }
    }
}