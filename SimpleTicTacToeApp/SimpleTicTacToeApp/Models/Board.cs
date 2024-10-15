using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicTacToeApp.Models
{
    internal class Board
    {
        private List<char> cells;

        public Board()
        {
            cells = new List<char>(new char[9] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' });
        }

        public char GetCell(int index)
        {
            return cells[index];
        }

        public void SetCell(int index, char symbol)
        {
            cells[index] = symbol;
        }

        public bool IsFull()
        {
            return !cells.Contains(' ');
        }

        public void Reset()
        {
            for (int i = 0; i < cells.Count; i++)
            {
                cells[i] = ' ';
            }
        }
    }
}
