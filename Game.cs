public class Game
{
    private Grid _grid;
    private Player _player1;
    private Player _player2;
    private int _numTurns;

    public Game(Player player1, Player player2)
    {
        _grid = new Grid();
        _player1 = player1;
        _player2 = player2;
        _numTurns = 0;
    }

    // Kiểm tra xem có người thắng hay không
    public bool CheckVictory()
    {
        bool row1 = _grid.grid[0] == _grid.grid[1] && _grid.grid[1] == _grid.grid[2];
        bool row2 = _grid.grid[3] == _grid.grid[4] && _grid.grid[4] == _grid.grid[5];
        bool row3 = _grid.grid[6] == _grid.grid[7] && _grid.grid[7] == _grid.grid[8];
        bool col1 = _grid.grid[0] == _grid.grid[3] && _grid.grid[3] == _grid.grid[6];
        bool col2 = _grid.grid[1] == _grid.grid[4] && _grid.grid[4] == _grid.grid[7];
        bool col3 = _grid.grid[2] == _grid.grid[5] && _grid.grid[5] == _grid.grid[8];
        bool diagDown = _grid.grid[0] == _grid.grid[4] && _grid.grid[4] == _grid.grid[8];
        bool diagUp = _grid.grid[6] == _grid.grid[4] && _grid.grid[4] == _grid.grid[2];

        return row1 || row2 || row3 || col1 || col2 || col3 || diagDown || diagUp;
    }

    // Thực hiện lượt chơi của người chơi
    public void PlayTurn(Player player)
    {
        try
        {
            _grid.PrintGrid();
            Console.WriteLine($"{player.Name}'s turn ({player.Symbol})");

            string? choice = Console.ReadLine();

            if (!_grid.UpdateGrid(choice, player.Symbol))
            {
                Console.WriteLine("Invalid input! Please choose a valid number.");
            }
            else
            {
                _numTurns++; // Đếm số lượt đi
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("Input was not a number. Please enter a valid number.");
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Invalid choice. Please choose a number between 1 and 9.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred: {ex.Message}");
        }
    }

    // Kiểm tra hoà
    public bool IsTie()
    {
        return _numTurns == 9;
    }

    // Bắt đầu trò chơi
        public void Start()
    {
        try
        {
            Player currentPlayer = _player1;
            while (!CheckVictory() && !IsTie())
            {
                PlayTurn(currentPlayer);
                if (CheckVictory()) // Kiểm tra thắng ngay sau lượt đi
                {
                    Console.WriteLine($"We have a winner: {currentPlayer.Name}!");
                    return; // Kết thúc trò chơi
                }
                currentPlayer = currentPlayer == _player1 ? _player2 : _player1; // Chuyển lượt
            }

            if (IsTie())
                Console.WriteLine("It's a Tie!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred during the game: {ex.Message}");
        }
    }
}