namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.TicTacToeGame.CalisthenicTicTacToe
{
    internal class MoveHistory
    {
        private List<Move> moveHistory = new();

        internal void AddMove(Move move)
        {
            moveHistory.Add(move);
        }

        internal bool CompareLastPlayer(Move move)
        {
            if (!moveHistory.Any())
            {
                return false;
            }

            var lastPlayer = moveHistory.Last();
            return lastPlayer.ComparePlayer(move);
        }

        internal bool HaveCoordinatesBeenUsed(Move move)
        {
            if (!moveHistory.Any())
            {
                return false;
            }

            return moveHistory.Any(x => x.CompareCoordinates(move));
        }

        internal bool IsPlayerWinner(Player player)
        {
            var loopCounter = 0;
            var isWinnerFound = false;

            while (loopCounter <= 2 && !isWinnerFound)
            {
                var matchingHorizontalCounters = moveHistory.Where(x => x.ComparePlayer(player)
                   && x.CompareYCoordinate(new Coordinate(-1, loopCounter))).Count();

                var matchingVerticalCounters = moveHistory.Where(x => x.ComparePlayer(player)
                   && x.CompareXCoordinate(new Coordinate(loopCounter, -1))).Count();

                isWinnerFound = matchingHorizontalCounters == 3 || matchingVerticalCounters == 3;
                loopCounter++;
            }

            return isWinnerFound;
        }
    }
}
