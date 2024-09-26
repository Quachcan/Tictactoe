namespace Tictactoe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // Khởi tạo người chơi
                Player player1 = new Player("Player 1", "X");
                Player player2 = new Player("Player 2", "O");

                // Khởi tạo trò chơi
                Game game = new Game(player1, player2);

                // Bắt đầu trò chơi
                game.Start();
            }
            catch (Exception ex)
            {
                // Xử lý các lỗi bất ngờ
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}