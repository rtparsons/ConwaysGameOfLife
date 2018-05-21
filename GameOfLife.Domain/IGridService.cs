using System;
using System.Collections.Generic;
using System.Text;
using GameOfLife.Core;

namespace GameOfLife.Domain
{
    public interface IGridService
    {
        Grid SeedGrid(int height, int Width, List<Tuple<int,int>> seedCoords);
        Grid PerformTick(Grid grid);
    }
}
