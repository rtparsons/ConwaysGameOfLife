using GameOfLife.Core;
using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Collections.Generic.List <Tuple<int, int>>  seedCoords = new System.Collections.Generic.List<Tuple<int, int>>();
            seedCoords.Add(new Tuple<int, int>(1, 0));
            seedCoords.Add(new Tuple<int, int>(1, 1));
            seedCoords.Add(new Tuple<int, int>(1, 2));

            GameOfLife.Domain.GridService gridServ = new Domain.GridService(new Domain.CellService());
            Grid grid = gridServ.SeedGridWithRandom(20, 60);
            
            Console.WriteLine(grid.ToString());

            while(true)
            {
                System.Threading.Thread.Sleep(200);
                grid = gridServ.PerformTick(grid);
                Console.Clear();
                Console.WriteLine(grid.ToString());
            }
        }
    }
}
