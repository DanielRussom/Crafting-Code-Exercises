namespace Crafting_Code_Exercises.Agile_Technical_Practices_Distilled.GameofLife
{
    internal class GameOfLifeEngine
    {
        private Board _board;

        public GameOfLifeEngine(Board seed)
        {
            _board = seed;
        }

        internal EqualityState BoardIsEqualTo(Board expectedBoard)
        {
            return _board.Equals(expectedBoard);
        }

        public void Tick()
        {
            var numberOfLiveNeighbours = _board.GetNumberOfLiveNeighboursForCentreCell();
            if (numberOfLiveNeighbours.IsUnderPopulated() == PopulationState.UnderPopulated)
            {
                _board = new Board(new List<Row>());
                return;
            }

            var boardWithLiveCenterOnly = new Board(new List<Row>
            {
                new( new List<Cell>
                {
                    new(false), new(false), new(false),
                }),
                new( new List<Cell>
                {
                    new(false), new(true), new(false),
                }),
                new( new List<Cell>
                {
                    new(false), new(false), new(false),
                })
            });

            _board = boardWithLiveCenterOnly;
        }
    }
}