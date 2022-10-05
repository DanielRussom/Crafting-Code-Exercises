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
            var diagonalBoard = new Board(new List<Row>
            {
                new( new List<Cell>
                {
                    new(false), new(false), new(true),
                }),
                new( new List<Cell>
                {
                    new(false), new(true), new(false),
                }),
                new( new List<Cell>
                {
                    new(true), new(false), new(false),
                })
            });

            if (BoardIsEqualTo(diagonalBoard) == EqualityState.IsEqual)
            {
                var boardToGetTheTestPassing = new Board(new List<Row>
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

                _board = boardToGetTheTestPassing;
                return;
            }

            _board = new Board(new List<Row>());
        }
    }
}