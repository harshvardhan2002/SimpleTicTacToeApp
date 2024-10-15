using SimpleTicTacToeApp.Exceptions;
using SimpleTicTacToeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicTacToeApp.Controller
{
    internal class GameManager
    {
        private Board board;
        private char currentPlayer;

        public GameManager()
        {
            board = new Board();
            currentPlayer = 'X'; //x will start first
        }

        public void MakeMove(int index)
        {
            if (index < 0 || index > 8)
            {
                throw new SlotOutOfRangeException("Slot number must be between 1 and 9.");
            }

            else if (board.GetCell(index) != ' ')
            {
                throw new SlotAlreadyFilledException("The selected slot is already filled, choose another slot.");
            }
            board.SetCell(index, currentPlayer);
        }

        public bool CheckWinner()
        {
            char symbol = currentPlayer;
            return (board.GetCell(0) == symbol && board.GetCell(1) == symbol && board.GetCell(2) == symbol) ||
                   (board.GetCell(3) == symbol && board.GetCell(4) == symbol && board.GetCell(5) == symbol) ||
                   (board.GetCell(6) == symbol && board.GetCell(7) == symbol && board.GetCell(8) == symbol) ||
                   (board.GetCell(0) == symbol && board.GetCell(3) == symbol && board.GetCell(6) == symbol) ||
                   (board.GetCell(1) == symbol && board.GetCell(4) == symbol && board.GetCell(7) == symbol) ||
                   (board.GetCell(2) == symbol && board.GetCell(5) == symbol && board.GetCell(8) == symbol) ||
                   (board.GetCell(0) == symbol && board.GetCell(4) == symbol && board.GetCell(8) == symbol) ||
                   (board.GetCell(2) == symbol && board.GetCell(4) == symbol && board.GetCell(6) == symbol);
        }

        public void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        public char CurrentPlayer
        {
            get { return currentPlayer; }
        }

        public bool IsBoardFull()
        {
            return board.IsFull();
        }

        public void ResetBoard()
        {
            board.Reset();
            currentPlayer = 'X';
        }

        public char GetCell(int index)
        {
            return board.GetCell(index);
        }
    }
}
