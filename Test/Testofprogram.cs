using System;
using System.Collections.Generic;
using Xunit;



public class Testofprogram
{
    [Fact]
    public void Test_AddAnimalTrain()
    {
        var Train = new Train();
        var animal = new Animal { Size = Size.Small, Diet = Diet.Plant };

        Assert.True(Train.AddAnimal(animal));
        Assert.Equal(1, Train.getTotalthings());
    }

    [Fact]
    public void Test_AddMultipleAnimals()
    {
        var Train = new Train();
        var animal1 = new Animal { Size = Size.Small, Diet = Diet.Plant };
        var animal2 = new Animal { Size = Size.Small, Diet = Diet.Plant };

        Assert.True(wagon.AddAnimal(animal1));
        Assert.True(wagon.AddAnimal(animal2));
        Assert.Equal(2, wagon.GetTotalPoints());
    }

    [Fact]
    public void TestAddAnimalToWagonExceedsCapacity()
    {
        var wagon = new Wagon();
        var animal1 = new Animal { Size = Size.Large, Diet = Diet.Plant };
        var animal2 = new Animal { Size = Size.Large, Diet = Diet.Plant };

        Assert.True(wagon.AddAnimal(animal1));
        Assert.False(wagon.AddAnimal(animal2));
    }

    [Fact]
    public void TestDistributeAnimals()
    {
        var distribution = new WagonDistribution();
        var animals = new List<Animal>
        {
            new Animal { Name = "Lion", Size = Size.Large, Diet = Diet.Meat },
            new Animal { Name = "Giraffe", Size = Size.Large, Diet = Diet.Plant },
            new Animal { Name = "Monkey", Size = Size.Small, Diet = Diet.Plant },
            new Animal { Name = "Tiger", Size = Size.Large, Diet = Diet.Meat },
            new Animal { Name = "Zebra", Size = Size.Medium, Diet = Diet.Plant },
        };

        distribution.DistributeAnimals(animals);

        Assert.Equal(3, distribution.Wagons.Count);
    }
}


