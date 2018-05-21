using GameOfLife.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Domain
{
    public interface ICellService
    {
        CellState GetNewCellState(Cell cell, Cell[] neighbours);
    }
}
