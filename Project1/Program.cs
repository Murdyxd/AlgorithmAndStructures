using System;

namespace _1
{
    internal class Program
    {
        // Запускает игру
        static void Main(string[] args)
        {
            // Переменные 
            int min = 0;
            int max = 0;
            int totalAttempts = 0;
            int gamesCount = 0;

            Random rnd = new Random();
            char answer = 'Y';

            // Основной цикл игры
            do
            {
                // Генерируем случайное число
                int secretNumber = GenerateNumber(rnd);

                // Играем один раунд и получаем количество попыток
                int attemptsInGame = PlayRound(secretNumber);

                // Обновляем статистику
                if (min == 0 || min > attemptsInGame) min = attemptsInGame;
                if (max < attemptsInGame) max = attemptsInGame;
                totalAttempts += attemptsInGame;
                gamesCount++;

                // повторная игра
                answer = PlayAgain();

            } while (answer == 'Y' || answer == 'y');

            // Показываем итоговую статистику
            ShowStatistics(min, max, totalAttempts, gamesCount);
        }

        // Генерирует случайное число от 0 до 100
        // Возвращает случайное число от 0 до 100
        static int GenerateNumber(Random random)
        {
            return random.Next(0, 101);
        }

        // Проводит один раунд игры
        // сравнивает с загаданным числом и дает подсказки ">" "<"
        // secretNumber - загаданное компьютером число
        static int PlayRound(int secretNumber)
        {
            int attempts = 0;

            while (true)
            {
                int userNumber = 0;

                // Цикл для ввода числа  (3 попытки)
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("Input number from [0;101]");

                    // Преобразовать ввод в число и проверяем диапазон
                    if (int.TryParse(Console.ReadLine(), out userNumber) && userNumber >= 0 && userNumber <= 100)
                    {
                        break; // Правильное число - выход из цикла ввода
                    }

                    Console.WriteLine("Wrong input. Try again.");


                    if (i == 2)
                    {
                        Console.WriteLine("You are stupid");
                        Environment.Exit(0); // Завершаем программу
                    }
                }

                attempts++; // Увеличиваем счетчик попыток

                // Сравниваем числа 
                if (secretNumber < userNumber)
                {
                    Console.WriteLine("You number is greater");
                }
                else if (secretNumber > userNumber)
                {
                    Console.WriteLine("Your number is less");
                }
                else
                {
                    Console.WriteLine("Your are win!");
                    return attempts; // Возвращаем количество попыток
                }
            }
        }

        // Спрашивает хочет ли пользов  сыграть еще раз
        static char PlayAgain()
        {
            Console.WriteLine("Do you want play again? (Y/N)");
            char answer = Console.ReadKey().KeyChar;
            Console.WriteLine(); // Переводим строку для красоты
            return answer;
        }

        // Выводит на экран итоговую статистику по всем сыгранным играм

        static void ShowStatistics(int min, int max, int total, int gamesCount)
        {
            Console.WriteLine($"\nmin = {min} max = {max} avg = {(double)total / gamesCount}");
        }
    }
}