﻿namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame
{
    internal class TicTacToe
    {
        private int _moveNumber = 0;
        private string _lastPlayer = string.Empty;
        private string[,] _board = new string[3, 3];

        internal string Winner { get; private set; } = "";

        internal bool PlaceCounter(string player, int xCoordinate, int yCoordinate)
        {
            if (_lastPlayer == player)
            {
                return false;
            }

            if (_board[xCoordinate, yCoordinate] != null)
            {
                return false;
            }

            if (player == "O" && _moveNumber == 0)
            {
                return false;
            };

            _board[xCoordinate, yCoordinate] = player;
            _lastPlayer = player;
            _moveNumber++;

            for(int yPosition = 0; yPosition <= 2; yPosition++)
            {
                var matchingPlayerCount = 0;
                for(int xPosition = 0; xPosition <= 2; xPosition++)
                {
                    if (_board[xPosition, yPosition] == player)
                    {
                        matchingPlayerCount++;
                    }
                }

                if (matchingPlayerCount == 3) {
                    Winner = player;
                }
            }

            for (int xPosition = 0; xPosition <= 2; xPosition++)
            {
                var matchingPlayerCount = 0;
                for (int yPosition = 0; yPosition <= 2; yPosition++)
                {
                    if (_board[xPosition, yPosition] == "X")
                    {
                        matchingPlayerCount++;
                    }
                }

                if (matchingPlayerCount == 3)
                {
                    Winner = "X";
                }
            }

            if(_board[0, 0] == "X" && _board[1, 1] == "X" && _board[2, 2] == "X")
            {
                Winner = "X";
            }

            if (_board[0, 2] == "X" && _board[1, 1] == "X" && _board[2, 0] == "X")
            {
                Winner = "X";
            }

            return true;
        }
    }
}