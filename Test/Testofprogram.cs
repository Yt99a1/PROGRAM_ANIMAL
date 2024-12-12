using System;
using System.Collections.Generic;
using System.Linq;
using initize_diet_size;
using Xunit;

namespace AnimalTransportTest
{
    public class Animal
    {
        public string Name { get; }
        public int Size { get; }

        public Animal(string name, int size)
        {
            if (size < 0)
            {
                throw new ArgumentException("Sorry, Size cannot be negative");
            }

            Name = name;
            Size = size;
        }
    }

    public class Train
    {
        public List<Animal> Animals { get; } = new List<Animal>();
        public int Capacity { get; } = 50;

        public bool AddAnimal(Animal animal)
        {
            if (GetTotalSize() + animal.Size <= Capacity)
            {
                Animals.Add(animal);
                return true;
            }
            return false;
        }

        public int GetTotalSize()
        {
            return Animals.Sum(a => a.Size);
        }
    }

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
            
            animals = animals.OrderByDescending(a => a.Size).ToList();

            foreach (var animal in animals)
            {
                                bool added = false;
                foreach (var train in Trains)
                {
                    if (train.AddAnimal(animal))
                    {
                        added = true;
                        break; 
                    }
                }

                
                if (!added)
                {
                    var newTrain = new Train();
                    newTrain.AddAnimal(animal);
                    Trains.Add(newTrain);
                }
            }
        }
    }

        public class AnimalTests
    {
        [Fact]
        public void Animal_ValidInput_CreatesanAnimal()
        {
            
            var name = "Lion";
            var size = 10;

            
            var animal = new Animal(name, size);

            
            Assert.Equal(name, animal.Name);
            Assert.Equal(size, animal.Size);
        }

        [Fact]
        public void Animal_InvalidSize_throughsErrors()
        {
           
            var name = "Lion";
            var size = -1;

            
            Assert.Throws<ArgumentException>(() => new Animal(name, size));
        }
    }

    public class TrainTests
    {
        [Fact]
        public void AddAnimal_AddAnimalToTrain()
        {
            
            var train = new Train();
            var animal = new Animal("Lion", 10);

            
            var result = train.AddAnimal(animal);

            
            Assert.True(result);
            Assert.Single(train.Animals);
        }

        [Fact]
        public void AddAnimal_ExceedstheCapacity()
        {
            
            var train = new Train();
            var animal1 = new Animal("Lion", 30);
            var animal2 = new Animal("Elephant", 30);

            
            train.AddAnimal(animal1);
            var result = train.AddAnimal(animal2);

            Assert.False(result);
            Assert.Single(train.Animals);
        }

        [Fact]
        public void GetTotalSize_NoAnimals()
        {
            
            var train = new Train();

           
            var result = train.GetTotalSize();

            
            Assert.Equal(0, result);
        }

        [Fact]
        public void GetTotalSize_OneAnimal()
        {
            
            var train = new Train();
            var animal = new Animal("Lion", 10);

            
            train.AddAnimal(animal);
            var result = train.GetTotalSize();
            Assert.Equal(10, result);
        }
    }

    public class TrainDistributionTests
    {
        [Fact]
        public void AddAnimal_only_ValidAnimal_ToTrain()
        {
            
            var distribution = new TrainDistribution();
            var animal = new Animal("Lion", 10);
            distribution.AddAnimal(animal);

            
            Assert.Single(distribution.Trains);
            Assert.Single(distribution.Trains.First().Animals);
        }

        [Fact]
        public void DistributeAnimals_DistributesAnimalsAcrossTrains()
        {
            
            var distribution = new TrainDistribution();
            var animals = new List<Animal>
    {
        new Animal("Elephant", 30),    
        new Animal("Giraffe", 20),    
        new Animal("Rabbit", 1),       
        new Animal("Cheetah", 2),     
        new Animal("Tiger1", 3),       
        new Animal("Aligator", 3)       
    };

            
            distribution.DistributeAnimals(animals);

            
            Assert.Equal(2, distribution.Trains.Count); 
            Assert.Equal(50, distribution.Trains[0].GetTotalSize()); 
            Assert.Equal(9, distribution.Trains[1].GetTotalSize()); 
            Assert.Contains(distribution.Trains[0].Animals, a => a.Name == "Elephant"); 
            Assert.Contains(distribution.Trains[1].Animals, a => a.Name == "Cheetah"); 
            Assert.Contains(distribution.Trains[1].Animals, a => a.Name == "Tiger1"); 
            Assert.Contains(distribution.Trains[1].Animals, a => a.Name == "Aligator"); 
        }
    }
}