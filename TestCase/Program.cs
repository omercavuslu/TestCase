using TestCase;
using TestCase.Models;
using System;
using System.Linq;
using TestCase.Managers.Abstracts;
using TestCase.Managers;

namespace TestCase
{
    class Program
    {
        static void Main(string[] args)
        {
            IRoverManager roverController = new RoverManager();

            var integers = Console.ReadLine().Split().Select(s => int.Parse(s)).ToArray();
            roverController.Plateau = new Rover[integers[0] + 1, integers[1] + 1];

            while (true)
            {
                roverController.PrepareEnvironment();
            }
        }
    }
}
