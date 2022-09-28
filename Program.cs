using System;
using AbstractExample.Models;
using NLog.Web;

namespace AbstractExample
{
    using NLog.Web;

    internal class Program
    {
        private static void Main(string[] args)
        {
    /*        Console.WriteLine("Which animal do you want to hear?");
            var choice = Console.ReadLine();

            Animal animal = null;

            if (choice == "1")
            {
                animal = new Pig();
            }
            else if (choice == "2")
            {
                animal = new Dog();
            }

            else
            {
                {
                    animal = new Horse();
                }
            }


            animal?.MakeNoise();
            animal?.Sleep();*/


            Console.WriteLine("What media type would you like? \n1-Movie\n2-Show\n3-Video");
            var choice = Console.ReadLine();

            Media media = null;

            switch (choice)
            {
                case "1-Movie":
                    media = new Movie();
                    media.Read();
                    break;
                
                case "2-Show":
                    media = new Show();
                    media.Read();
                    break;

                case "3-Video":
                    media = new Video();
                    media.Read();
                    break;
                default:
                    Console.WriteLine("Enter a number 1-3");
                    break;

            }


            media?.Display(); // polymorphism
            media?.Read();
           
        }
    }
}
