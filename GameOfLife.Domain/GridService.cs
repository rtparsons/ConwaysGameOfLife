using System;
using System.Collections.Generic;
using System.Text;
using GameOfLife.Core;

namespace GameOfLife.Domain
{
    public class GridService : IGridService
    {
        private ICellService _cellService;

        public GridService(ICellService cellService)
        {
            _cellService = cellService;
        }

        public Grid SeedGrid(int height, int width, List<Tuple<int, int>> seedCoords)
        {
            Grid grid = CreateGrid(height, width);

            foreach(Tuple<int, int> coord in seedCoords)
            {
                grid.Cells[coord.Item1][coord.Item2].ReproduceCell();
            }

            return grid;
        }

        public Grid SeedGridWithRandom(int height, int width)
        {
            List<Tuple<int, int>> seeds = new List<Tuple<int, int>>();
            Random rand = new Random();

            for(int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if(rand.Next() % 2 == 1)
                    {
                        seeds.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            return SeedGrid(height, width, seeds);
        }

        public Grid PerformTick(Grid grid)
        {
            Grid newGrid = CreateGrid(grid.Height, grid.Width);

            for(int i = 0; i < grid.Height; i++)
            {
                for (int j = 0; j < grid.Width; j++)
                {
                    List<Cell> neighbours = GetCellNeighbours(grid, i, j);
                    CellState newState = _cellService.GetNewCellState(grid.Cells[i][j], neighbours.ToArray());
                    newGrid.Cells[i][j].SetCellState(newState);
                }
            }

            return newGrid;
        }

        private List<Cell> GetCellNeighbours(Grid grid, int xLoc, int yLoc)
        {
            //everybody needs good...
            List<Cell> neighbours = new List<Cell>();

            for (int i = xLoc - 1; i < xLoc + 2; i++)
            {
                for (int j = yLoc - 1; j < yLoc + 2; j++)
                {
                    if (i < 0 || j < 0) { continue; }
                    if (i > grid.Height - 1 || j > grid.Width - 1) { continue; }
                    if (i == xLoc && j == yLoc) { continue; }

                    neighbours.Add(grid.Cells[i][j]);
                }
            }

            return neighbours;
        }

        private Grid CreateGrid(int height, int width)
        {
            Cell[][] grid = new Cell[height][];

            for(int i = 0; i < height; i++)
            {
                Cell[] row = new Cell[width];
                
                for(int j = 0; j < width; j++)
                {
                    row[j] = new Cell();
                }

                grid[i] = row;
            }

            return new Grid(grid);
        }
    }
}
