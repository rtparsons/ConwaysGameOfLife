using GameOfLife.Core;
using System;
using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Domain.Tests
{
    public class CellService
    {
        [Fact]
        public void WhenGivenLiveCellWithTooFewNeighbours_UpdateCell_CellIsKilled()
        {
            Cell cell = new Cell(CellState.alive);
            Cell[] neighbours = GenerateNeighbours(1, 3);
            Domain.ICellService cellService = new Domain.CellService();

            CellState newState = cellService.GetNewCellState(cell, neighbours);

            Assert.True(newState == CellState.dead);
        }

        [Fact]
        public void WhenGivenLiveCellWithEnoughNeighbours_UpdateCell_CellRemainsAlive()
        {
            Cell cell = new Cell(CellState.alive);
            Cell[] neighbours = GenerateNeighbours(2, 3);
            Domain.ICellService cellService = new Domain.CellService();

            CellState newState = cellService.GetNewCellState(cell, neighbours);

            Assert.True(newState == CellState.alive);
        }

        [Fact]
        public void WhenGivenLiveCellWithTooManyNeighbours_UpdateCell_CellIsKilled()
        {
            Cell cell = new Cell(CellState.alive);
            Cell[] neighbours = GenerateNeighbours(4, 3);
            Domain.ICellService cellService = new Domain.CellService();

            CellState newState = cellService.GetNewCellState(cell, neighbours);

            Assert.True(newState == CellState.dead);
        }

        [Fact]
        public void WhenGivenDeadCellWithTooFewNeighbours_UpdateCell_CellRemainsDead()
        {
            Cell cell = new Cell(CellState.dead);
            Cell[] neighbours = GenerateNeighbours(2, 3);
            Domain.ICellService cellService = new Domain.CellService();

            CellState newState = cellService.GetNewCellState(cell, neighbours);

            Assert.True(newState == CellState.dead);
        }

        [Fact]
        public void WhenGivenDeadCellWithEnoughNeighbours_UpdateCell_CellBecomesAlive()
        {
            Cell cell = new Cell(CellState.dead);
            Cell[] neighbours = GenerateNeighbours(3, 3);
            Domain.ICellService cellService = new Domain.CellService();

            CellState newState = cellService.GetNewCellState(cell, neighbours);

            Assert.True(newState == CellState.alive);
        }

        private Cell[] GenerateNeighbours(int aliveCount, int deadCount)
        {
            List<Cell> neighbours = new List<Cell>();

            for (int i = 0; i < aliveCount; i++)
            {
                neighbours.Add(new Cell(CellState.alive));
            }

            for (int i = 0; i < deadCount; i++)
            {
                neighbours.Add(new Cell(CellState.dead));
            }

            return neighbours.ToArray();
        }
    }
}
