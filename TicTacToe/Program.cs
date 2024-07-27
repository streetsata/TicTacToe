using System.Text;

namespace TicTacToe
{
    internal class Program
    {
        static char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int currentPlayer = 1; // 1 - хрестики, 2 - нулики
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;
            int choice;
            bool validInput;

            do
            {
                Console.Clear();
                DrawBoard();

                Console.WriteLine($"Гравець {currentPlayer}, введіть номер комірки:");

                // Перевіряємо коректність введення: число від 1 до 9, і комірка не повинна бути зайнята
                validInput = int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 9 && board[choice - 1] != 'X' && board[choice - 1] != 'O';

                if (validInput)
                {
                    // Заповнюємо комірку поточним символом (X або O)
                    board[choice - 1] = (currentPlayer == 1) ? 'X' : 'O';

                    // Перевіряємо на наявність виграшної комбінації
                    if (CheckForWin())
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine($"Переміг гравець {currentPlayer}!");
                        break;
                    }

                    // Перевіряємо на наступ нічиєї
                    if (CheckForDraw())
                    {
                        Console.Clear();
                        DrawBoard();
                        Console.WriteLine("Нічия!");
                        break;
                    }

                    // Змінюємо поточного гравця
                    currentPlayer = (currentPlayer == 1) ? 2 : 1;
                }
                else
                    Console.WriteLine("Некоректне введення. Спробуйте знову.");

            } while (true);
        }

        // Виводимо поточний стан ігрового поля
        static void DrawBoard()
        {
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("-----------");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
        }

        // Перевіряємо на виграш
        static bool CheckForWin()
        {
            return (board[0] == board[1] && board[1] == board[2]) ||
                (board[3] == board[4] && board[4] == board[5]) ||
                (board[6] == board[7] && board[7] == board[8]) ||
                (board[0] == board[3] && board[3] == board[6]) ||
                (board[1] == board[4] && board[4] == board[7]) ||
                (board[2] == board[5] && board[5] == board[8]) ||
                (board[0] == board[4] && board[4] == board[8]) ||
                (board[2] == board[4] && board[4] == board[6]);
        }

        // Перевіряємо на нічию
        static bool CheckForDraw()
        {
            // Перевіряємо, чи залишилися вільні комірки
            foreach (char cell in board)
            {
                if (cell != 'X' && cell != 'O')
                    return false;
            }
            return true;
        }
    }
}
