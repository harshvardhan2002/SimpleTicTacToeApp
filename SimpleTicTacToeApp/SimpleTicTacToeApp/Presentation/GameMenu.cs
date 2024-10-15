using SimpleTicTacToeApp.Controller;
using SimpleTicTacToeApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTicTacToeApp.Presentation
{
    internal class GameMenu
    {
        private GameManager gameManager;

        public GameMenu()
        {
            gameManager = new GameManager();
        }

        public void DisplayBoard()
        {
            Console.WriteLine("Board:");
            for (int i = 0; i < 9; i += 3)
            {
                DisplayRow(i);
            }
        }

        private void DisplayRow(int i)
        {
            Console.WriteLine($" {gameManager.GetCell(i)} | {gameManager.GetCell(i + 1)} | {gameManager.GetCell(i + 2)} ");
            if (i < 6)
            {
                Console.WriteLine("---+---+---");
            }
        }

        public static void StartGame()
        {
            GameMenu gameMenu = new GameMenu();
            bool gameOngoing = true;
            while (gameOngoing)
            {
                gameMenu.DisplayBoard();
                gameMenu.HandlePlayerTurn(ref gameOngoing);
            }
            gameMenu.GameEnd();
        }

        private void HandlePlayerTurn(ref bool gameOngoing)
        {
            Console.WriteLine($"\n{gameManager.CurrentPlayer}'s turn. Pick slot (1-9):");
            int slot = GetValidSlot();
            try
            {
                gameManager.MakeMove(slot - 1);
            }
            catch (SlotAlreadyFilledException ex)
            {
                Console.WriteLine(ex.Message);
                HandlePlayerTurn(ref gameOngoing);
                return; 
            }
            catch (SlotOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                HandlePlayerTurn(ref gameOngoing); 
                return; 
            }

            if (gameManager.CheckWinner())
            {
                DisplayBoard();
                Console.WriteLine($"{gameManager.CurrentPlayer} has won!");
                gameOngoing = false;
            }
            else if (gameManager.IsBoardFull())
            {
                DisplayBoard();
                Console.WriteLine("It's a draw!");
                gameOngoing = false;
            }
            gameManager.SwitchPlayer();
        }

        public int GetValidSlot()
        {
            int slot = 0;
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Pick a slot (1-9):");
                string input = Console.ReadLine();

                try
                {
                    slot = Convert.ToInt32(input);
                    if (slot >= 1 && slot <= 9 && gameManager.GetCell(slot - 1) == ' ')
                    {
                        validInput = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid slot. Pick again:");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 9."); 
                }
                catch (SlotOutOfRangeException)
                {
                    Console.WriteLine("Number too large or too small. Please enter a number between 1 and 9."); 
                }
            }
            return slot;
        }

        public void GameEnd()
        {
            Console.WriteLine("Do you want to play again? input yes or no");
            string input = Console.ReadLine().ToLower();

            switch (input)
            {
                case "yes":
                    gameManager.ResetBoard();
                    StartGame();
                    break;
                case "no":
                    Console.WriteLine("Thanks for playing");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}
