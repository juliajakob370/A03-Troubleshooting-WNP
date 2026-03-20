/*
 * FILE             : A03-Q1 > Program.cs
 * PROJECT          : A03-Q1
 * PROGRAMMER       : Julia Jakob, Bibi Murwared Enayat Zada, Mohammad Mehdi Ebrahimzadeh
 * FIRST VERSION    : 2026-03-17
 * DESCRIPTION      : This is the our code solution for question 1 of Assignment 3 Troubleshooting
 */
using System.Diagnostics;

namespace A03_Q1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                InitialCode();
                BetterCode();
            }

            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
        }

        static void InitialCode()
        {
            int temp = 0; 
            Random rand = new Random();
            int LOOPCOUNT = 100000000;

            Stopwatch sw = new Stopwatch(); // define stopwatch object
            sw.Start(); // start the stopwatch just before the loop

            for (int counter = 0; counter < LOOPCOUNT; counter++)
            {
                float randomFloat = rand.NextSingle();
                if (randomFloat < .10)
                {
                    temp = 1;
                }
                if (randomFloat >= .10 && randomFloat < .30)
                {
                    temp = 2;
                }
                if (randomFloat >= .3)
                {
                    temp = 3;
                }
            }

            sw.Stop(); // stop the stopwatch after the loop

            Console.WriteLine($"InitialCode total time: {sw.ElapsedMilliseconds} ms"); // print result of the timer
        }

        static void BetterCode()
        {
            int temp = 0;
            Random rand = new Random();
            int LOOPCOUNT = 100000000;

            Stopwatch sw = new Stopwatch(); // define stopwatch object
            sw.Start(); // start the stopwatch just before the loop

            for (int counter = 0; counter < LOOPCOUNT; counter++)
            {
                float randomFloat = rand.NextSingle();
                if (randomFloat < .10)
                {
                    temp = 1;
                }
                if (randomFloat >= .10 && randomFloat < .30)
                {
                    temp = 2;
                }
                if (randomFloat >= .3)
                {
                    temp = 3;
                }
            }

            sw.Stop(); // stop the stopwatch after the loop

            Console.WriteLine($"BetterCode total time: {sw.ElapsedMilliseconds} ms"); // print result of the timer
        }
    }
}
