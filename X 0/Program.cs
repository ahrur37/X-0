using System;
using System.Collections.Generic;

namespace practika___8
{
    internal class Program
    {
        static char[,] board = new char[3, 3];
        static char currentPlayer = 'X';
        static bool win = false;
        static void Main(string[] args)
        {
            InitializeGame();
            Print();
            while (win == false)
            {
                Console.WriteLine($"Ходит игрок {currentPlayer}");
                Console.WriteLine($"Введите номер строчки на которую хотите поставить {currentPlayer}");
                int stroc = int.Parse(Console.ReadLine());
                Console.WriteLine($"Введите номер столбеца на который хотите поставить {currentPlayer}");
                int stolb = int.Parse(Console.ReadLine());
                if (board[stroc - 1, stolb - 1] == 'N')
                    board[stroc - 1, stolb - 1] = currentPlayer;
                else
                {
                    Console.WriteLine("Нельзя поставить туда куда уже поставили");
                    Print();
                    continue;
                }
                ChekWin();
                Zamena();
                Print();
            }
            Console.WriteLine($"Победил {currentPlayer}");
            Console.ReadKey();
        }
        public static void Zamena()
        {
            if (currentPlayer == 'X' && win == false)
                currentPlayer = '0';
            else if (currentPlayer == '0' && win == false)
                currentPlayer = 'X';
        }
        public static void InitializeGame() // базовые настройки 
        {
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    board[i, j] = 'N';
                }
            }
        }
        public static void Print() // вывод
        {
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    Console.Write(board[i, j] + " ");
                    if (j == 2)
                        Console.WriteLine();
                }
            }
        }
        public static void ChekWin() // Проверка выигрыша
        {
            // Проверка строк и столбцов
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                {
                    win = true;
                }
                if (board[0, i] == currentPlayer && board[0, i] == board[1, i] && board[1, i] == board[2, i])
                {
                    win = true;
                }
            }
            // Проверка диагоналей
            if (board[0, 0] == currentPlayer && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                win = true;
            }
            if (board[0, 2] == currentPlayer && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                win = true;
            }
        }
    }
}
