using System;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace Operacje_na_bitach
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong sum = 3; //The two youngest active bits. Hamming distance.

            Stopwatch findTime = new Stopwatch();
            findTime.Start();

            //int value = 3;
            int nextValue = 5;
            for (int i = 1; i < 465; i++) //Number of permutations of two active bits out of 31.
            {
                sum += (ulong)nextValue;
                int a = nextValue & -nextValue;
                int b = nextValue + a;
                nextValue = (((b ^ nextValue) >> 2) / a) | b;
            }

            findTime.Stop();

            double ticks = findTime.ElapsedTicks;
            double milliseconds = (ticks / Stopwatch.Frequency) * 1000;
            Console.WriteLine("Time : " + milliseconds);
            Console.WriteLine("Sum: " + sum);
            Console.ReadKey();
        }
    }
}
