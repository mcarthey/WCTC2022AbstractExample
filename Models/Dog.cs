using System;

namespace AbstractExample.Models
{
    public class Dog : Animal
    {
        public Dog(string name)
        {
            Name = name;
        }

        public Dog()
        {
            Name = "Spot";
        }

        public override void MakeNoise()
        {
            Console.WriteLine($"{Name} says bark bark");
        }
    }
}
