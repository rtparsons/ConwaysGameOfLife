using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameOfLife.Core;

namespace GameOfLife.Domain
{
    public class CellService : ICellService
    {
        public CellState GetNewCellState(Cell cell, Cell[] neighbours)
        {
            int liveNeighbours = GetLiveNeighbourCount(neighbours);

            if (cell.State == CellState.alive)
            {
                return GetNewAliveCellState(liveNeighbours);
            }

            return GetNewDeadCellState(liveNeighbours);
        }

        private CellState GetNewAliveCellState(int liveNeighbours)
        {
            if (new int[] { 2,3}.Contains(liveNeighbours))
            {
                return CellState.alive;
            }

            return CellState.dead;
        }

        private CellState GetNewDeadCellState(int liveNeighbours)
        {
            if (liveNeighbours == 3)
            {
                return CellState.alive;
            }

            return CellState.dead;
        }

        private int GetLiveNeighbourCount(Cell[] neighbours)
        {
            return neighbours.Count(x => x.State == CellState.alive);
        }
    }
}
