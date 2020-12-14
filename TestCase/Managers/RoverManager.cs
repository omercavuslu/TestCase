using System;
using System.Linq;
using TestCase.Managers.Abstracts;
using TestCase.Models;
using TestCase.Models.Enums;

namespace TestCase.Managers
{
    public class RoverManager : IRoverManager
    {
        public Rover[,] Plateau { get; set; }

        public void PrepareEnvironment()
        {
            //1.Rover Bilgilerini iste
            var Rover1 = Console.ReadLine().Split(" ");

            // Roverı Oluştur
            if (Rover1[0] == "stop")
                Environment.Exit(1);
            var x = int.Parse(Rover1[0]);
            var y = int.Parse(Rover1[1]);
            var direction = Rover1[2];

            Plateau[x, y] = new Rover()
            {
                Direction = (Directions)Enum.Parse(typeof(Directions), direction, true)
            };

            //Roverın routunu al
            var path = Console.ReadLine().ToCharArray();

            ChangePosition(x, y, path);
        }

        public void ChangePosition(int x, int y, char[] path)
        {
            var p = Plateau[x, y].Direction;
            foreach (var item in path)
            {
                var _directions = Enum.GetValues(typeof(Directions)).Cast<Directions>();
                Directions val;
                switch (Char.ToLowerInvariant(item))
                {
                    //+1
                    case 'r':
                        var t = _directions.SkipWhile(e => e != p);

                        if (t.Count() == 1)
                            val = Enum.GetValues(typeof(Directions)).Cast<Directions>().FirstOrDefault();
                        else
                            val = t.Skip(1).First();
                        p = val;
                        break;
                    //-1
                    case 'l':
                        var l = _directions.Reverse().SkipWhile(e => e != p);

                        if (l.Count() == 1)
                            val = _directions.Reverse().FirstOrDefault();
                        else
                            //+1
                            val = l.Skip(1).First();

                        p = val;
                        break;
                    case 'm':
                        if (p == Directions.W)
                        {
                            Plateau[x - 1, y] = Plateau[x, y];
                            Plateau[x, y] = null;
                            x -= 1;
                        }
                        else if (p == Directions.E)
                        {
                            Plateau[x + 1, y] = Plateau[x, y];
                            Plateau[x, y] = null;
                            x += 1;
                        }
                        else if (p == Directions.N)
                        {
                            Plateau[x, y + 1] = Plateau[x, y];
                            Plateau[x, y] = null;
                            y += 1;
                        }
                        else if (p == Directions.S)
                        {
                            Plateau[x, y - 1] = Plateau[x, y];
                            Plateau[x, y] = null;
                            y -= 1;
                        }
                        break;
                    default:
                        break;
                }

            }
            Console.WriteLine($"Output: {x} {y} {p}");
        }
    }
}
