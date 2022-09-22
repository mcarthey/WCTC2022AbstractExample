using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractExample.Models
{
    public  class Horse : Animal
    {
        public Horse(string name)
        {
            Name = name;
        }

        public Horse()
        {
            Name = "Pegasus";
        }

        public override void MakeNoise()
        {
            Console.WriteLine($"{Name} says Neiiigh!!");
        }

        public override void Sleep()
        {
            Console.WriteLine($"{Name} Snores...zzz");
        }
    }
}
