﻿namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame.CalisthenicTicTacToe
{
    internal class TicTacToeObjectCalisthenics
    {
        internal void PlaceCounter(Coordinate coordinate, Player player)
        {
            if(player.Equals(new Player("X"))){
                return;
            }
            
            throw new InvalidMoveException();
        }
    }
}