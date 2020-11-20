using System;

namespace SAV_Task_07
{
    class Program
    {
        private static void Shuffle(int[] permutationmass)
        {
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                var rndInd1 = rand.Next(0, permutationmass.Length);
                var rndInd2 = rand.Next(0, permutationmass.Length);
                var temp = permutationmass[rndInd1];
                permutationmass[rndInd1] = permutationmass[rndInd2];
                permutationmass[rndInd2] = temp;
            }
        }

        private static void Main(string[] args)
        {
            int size;
            Console.Write("Введите размерность массива: ");
            size = Convert.ToInt32(Console.ReadLine());

            int[] mass1 = new int[size];

            Random rand = new Random();
            for (int y = 0; y < size; y++)
            {
                mass1[y] = rand.Next(1, 50);
            }

            int[] mass2 = mass1;

            Console.WriteLine("Изначальный массив:");
            Console.WriteLine(string.Join(" ", mass1));
            Shuffle(mass2);
            Console.WriteLine("Обработанный массив:");
            Console.WriteLine(string.Join(" ", mass2));
            Console.ReadKey();
        }
    }
}
