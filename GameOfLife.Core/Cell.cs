using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Core
{
    public class Cell 
    {
        public CellState State { get; private set; } = CellState.dead;
        
        public Cell()
        {
        }

        public Cell(CellState initialState)
        {
            State = initialState;
        }

        public void KillCell()
        {
            State = CellState.dead;
        }

        public void ReproduceCell()
        {
            State = CellState.alive;
        }

        public void SetCellState(CellState state)
        {
            State = state;
        }
    }
}
