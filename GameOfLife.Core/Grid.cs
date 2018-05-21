using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife.Core
{
    public class Grid
    {
        public int Height { get; private set; }

        public int Width { get; private set; }

        public Cell[][] Cells { get; private set; }

        public Grid(Cell[][] cells)
        {
            Height = cells.Length;
            Width = cells[0].Length;
            Cells = cells;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Cells.Length; i++)
            {
                for (int j = 0; j < Cells[i].Length; j++)
                {
                    sb.Append(Cells[i][j].State == CellState.alive ? "x" : ".");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
