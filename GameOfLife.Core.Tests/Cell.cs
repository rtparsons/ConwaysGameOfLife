using System;
using Xunit;

namespace GameOfLife.Core.Tests
{
    public class Cell
    {
        [Fact]
        public void GivenAliveCell_WhenReproduces_IsStillAlive()
        {
            Core.Cell cell = new Core.Cell(CellState.alive);

            cell.ReproduceCell();

            Assert.True(cell.State == CellState.alive);
        }

        [Fact]
        public void GivenAliveCell_WhenKilled_IsDead()
        {
            Core.Cell cell = new Core.Cell(CellState.alive);

            cell.KillCell();

            Assert.True(cell.State == CellState.dead);
        }

        [Fact]
        public void GivenDeadCell_WhenReproduces_IsAlive()
        {
            Core.Cell cell = new Core.Cell(CellState.dead);

            cell.ReproduceCell();

            Assert.True(cell.State == CellState.alive);
        }

        [Fact]
        public void GivenDeadCell_WhenKilled_IsStillDead()
        {
            Core.Cell cell = new Core.Cell(CellState.dead);

            cell.KillCell();

            Assert.True(cell.State == CellState.dead);
        }
    }
}
