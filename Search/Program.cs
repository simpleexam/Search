using System.Diagnostics;

namespace Search
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = Search.GenerateArray(1_000_000);
            array[array.Length-1] = 2000; //гарантия единственности значения в массиве - массив заполняется значениями от 10 до 99


            Stopwatch timer = new Stopwatch();

            timer.Start();
            int ind = Search.SimpleSearch(2000, array);
            timer.Stop();

            Console.WriteLine($"простой перебор - {timer.ElapsedTicks} тактов\n" +
                $"индекс найденного элемента: {ind}\n");

            timer.Restart();
            ind = Search.SearchWithBarrier(2000, array);
            timer.Stop();

            Console.WriteLine($"перебор с барьером - {timer.ElapsedTicks} тактов\n" +
                $"индекс найденного элемента: {ind}\n");

            //предварительно отсортируем массив
            Array.Sort(array);

            timer.Restart();
            ind = Search.BynarySearch(2000, array);
            timer.Stop();

            Console.WriteLine($"бинарный поиск - {timer.ElapsedTicks}\n" +
                $"индекс найденного элемента: {ind}\n");

        }
    }
}