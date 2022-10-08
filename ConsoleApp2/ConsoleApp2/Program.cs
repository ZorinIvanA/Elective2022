using System;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа через запятую");
            var input = Console.ReadLine();
            var numbers = input.Split(',');

            foreach (var s in numbers)
            {
                int result = 0;
                if (!int.TryParse(s, out result))
                {
                    Console.WriteLine("Ошибка, введите целые числа");
                }

                Console.WriteLine(result);
            }
            Console.ReadLine();
        }
    }
}
