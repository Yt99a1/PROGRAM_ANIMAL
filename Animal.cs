using System;
using initize_diet_size;

namespace Animalfunction
{
    public class Animal
    {
        public string Name { get; set; }
        public Diet Diet { get; set; }
        public Size Size { get; set; }

        public int GetAnimalSize
        {
            get
            {
                switch (Size)
                {
                    case Size.Small: return 1;
                    case Size.Medium: return 2;
                    case Size.Large: return 3;
                    default: throw new InvalidOperationException("This size is not valid, please check again");
                }
            }
        }

       
        public Animal(string name, Diet diet, Size size)
        {
            Name = name;
            Diet = diet;
            Size = size;
        }
    }
}