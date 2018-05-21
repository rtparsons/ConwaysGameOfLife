using GameOfLife.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GameOfLife.Domain.Tests
{
    public class GridService
    {
        [Fact]
        public void WhenGivenHeightAndWidth_SeedGrid_CreatesGridWithCorrectDimensions()
        {
            int height = 10;
            int width = 8;
            List<Tuple<int, int>> seedCoords = new List<Tuple<int, int>>();
            Domain.IGridService gridService = new Domain.GridService(new Moq.Mock<ICellService>().Object);

            Grid grid = gridService.SeedGrid(height, width, seedCoords);

            Assert.True(grid.Height == height && grid.Width == width);
        }

        [Fact]
        public void WhenGivenNoSeedCoords_SeedGrid_CreatesGridWithAllDeadCells()
        {
            List<Tuple<int, int>> seedCoords = new List<Tuple<int, int>>();
            Domain.IGridService gridService = new Domain.GridService(new Moq.Mock<ICellService>().Object);

            Grid grid = gridService.SeedGrid(10, 10, seedCoords);

            int totalAliveCells = grid.Cells.Sum(x => x.Count(y => y.State == CellState.alive));
            Assert.True(totalAliveCells == 0);
        }

        [Fact]
        public void WhenGivenOneSeedCoord_SeedGrid_CreatesGridWithCorrectCellAlive()
        {
            int xCoord = 3;
            int yCoord = 2;
            List<Tuple<int, int>> seedCoords = new List<Tuple<int, int>>();
            seedCoords.Add(new Tuple<int, int>(xCoord, yCoord));
            Domain.IGridService gridService = new Domain.GridService(new Moq.Mock<ICellService>().Object);

            Grid grid = gridService.SeedGrid(10, 10, seedCoords);

            int totalAliveCells = grid.Cells.Sum(x => x.Count(y => y.State == CellState.alive));
            Assert.True(totalAliveCells == 1 && 
                        grid.Cells[xCoord][yCoord].State == CellState.alive);
        }

        [Fact]
        public void WhenGivenGrid_PerformTick_NewGridHasUpdatedCells()
        {
            Cell[][] cells = new Cell[][]
            {
                new Cell[] { new Cell(CellState.dead), new Cell(CellState.dead) },
                new Cell[] { new Cell(CellState.dead), new Cell(CellState.dead) }
            };
            Grid initGrid = new Grid(cells);
            Moq.Mock<ICellService> cellService = new Moq.Mock<ICellService>();
            cellService.Setup(x => x.GetNewCellState(Moq.It.IsAny<Cell>(), Moq.It.IsAny<Cell[]>())).Returns(CellState.alive);
            Domain.IGridService gridService = new Domain.GridService(cellService.Object);

            Grid resultGrid = gridService.PerformTick(initGrid);

            int totalAliveCells = resultGrid.Cells.Sum(x => x.Count(y => y.State == CellState.alive));
            Assert.True(totalAliveCells == 4);
        }
    }
}
