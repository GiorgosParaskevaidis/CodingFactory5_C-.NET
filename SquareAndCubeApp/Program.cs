using System.Diagnostics;

namespace SquareAndCubeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;

            Console.WriteLine("Παρακαλώ εισάγεται έναν ακαίρεο: ");
            num = int.Parse(Console.ReadLine()!);

            Console.WriteLine($"Ο αριθμός που εισάγατε είναι {num} με τετράγωνο: {Math.Pow(num, 2)} και κύβο: {Math.Pow(num, 3)}");

        }
    }
}
