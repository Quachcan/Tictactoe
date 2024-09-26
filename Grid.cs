public class Grid
{
    public string[] grid = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

    // In lưới ra màn hình
    public void PrintGrid()
    {
        try
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(grid[i * 3 + j] + "|");
                }
                Console.WriteLine();
                Console.WriteLine("------");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error printing grid: " + ex.Message);
        }
    }

    // Cập nhật ô trong lưới
    public bool UpdateGrid(string choice, string symbol)
    {
        if (grid.Contains(choice) && choice != "X" && choice != "O")
        {
            int gridIndex = Convert.ToInt32(choice) - 1;
            grid[gridIndex] = symbol;
            return true;
        }
        return false;
    }
}