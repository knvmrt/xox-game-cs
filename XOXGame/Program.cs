using System;

class Program
{
    static string[,] gameBoard = new string[3, 3]
    {
        { " ", " ", " " },
        { " ", " ", " " },
        { " ", " ", " " }
    };

    static bool playerX = true;

    static void Main()
    {
        bool gameEnded = false;
        int movesCount = 0;

        while (!gameEnded)
        {
            Console.Clear();
            DrawBoard();

            if (playerX)
                Console.WriteLine("Player X, enter your move (row [1-3] and column [1-3]):");
            else
                Console.WriteLine("Player O, enter your move (row [1-3] and column [1-3]):");

            int row = GetCoordinate("row");
            int col = GetCoordinate("column");

            if (gameBoard[row - 1, col - 1] == " ")
            {
                gameBoard[row - 1, col - 1] = playerX ? "X" : "O";
                movesCount++;
            }
            else
            {
                Console.WriteLine("Invalid move! That cell is already taken.");
                Console.ReadLine();
                continue;
            }

            gameEnded = CheckWin() || movesCount == 9;

            playerX = !playerX;
        }

        Console.Clear();
        DrawBoard();

        if (movesCount == 9)
            Console.WriteLine("It's a draw!");
        else
            Console.WriteLine("Player " + (playerX ? "O" : "X") + " wins!");

        Console.ReadLine();
    }

    static int GetCoordinate(string coordinate)
    {
        int value;
        bool validInput = false;

        do
        {
            Console.Write("Enter " + coordinate + " [1-3]: ");
            string input = Console.ReadLine();

            validInput = int.TryParse(input, out value) && value >= 1 && value <= 3;

            if (!validInput)
                Console.WriteLine("Invalid input! Please enter a number between 1 and 3.");

        } while (!validInput);

        return value;
    }

    static void DrawBoard()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine(" " + gameBoard[i, 0] + " | " + gameBoard[i, 1] + " | " + gameBoard[i, 2]);
            if (i < 2)
                Console.WriteLine("---+---+---");
        }
    }

    static bool CheckWin()
    {
        for (int i = 0; i < 3; i++)
        {
            if (gameBoard[i, 0] == gameBoard[i, 1] && gameBoard[i, 1] == gameBoard[i, 2] && gameBoard[i, 0] != " ")
                return true;
        }

        for (int j = 0; j < 3; j++)
        {
            if (gameBoard[0, j] == gameBoard[1, j] && gameBoard[1, j] == gameBoard[2, j] && gameBoard[0, j] != " ")
                return true;
        }

        if (gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 2] && gameBoard[0, 0] != " ")
            return true;

        if (gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 0] && gameBoard[0, 2] != " ")
            return true;

        return false;
    }
}
