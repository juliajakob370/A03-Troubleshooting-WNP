/*
 * FILE             : A03-Q1 > Program.cs
 * PROJECT          : A03-Q1
 * PROGRAMMER       : Julia Jakob, Bibi Murwared Enayat Zada, Mohammad Mehdi Ebrahimzadeh
 * FIRST VERSION    : 2026-03-17
 * DESCRIPTION      : This program measures and compares the execution time
 *                    of the original code and the optimized code for Assignment 3 Question 1
 */

using System;
using System.Diagnostics;

namespace A03_Q1
{
    /*
     * CLASS NAME     : Program
     * DESCRIPTION    : This class contains the main entry point and the
     *                  methods used to measure and compare loop performance
     */
    internal class Program
    {
        /*
         * FUNCTION     : Main()
         * DESCRIPTION  : Runs both methods 10 times, displays each run result, and prints a final summary.
         * PARAMETERS   : string[] args : Command line arguments
         * RETURNS      : void
         */
        static void Main(string[] args)
        {
            long initialTotal = 0;
            long betterTotal = 0;
            long initialTime = 0;
            long betterTime = 0;
            double initialAverage = 0.0;
            double betterAverage = 0.0;
            double difference = 0.0;
            double improvementPercent = 0.0;
            int runCount = 10;

            // Warm up run to reduce the effect of JIT compilation on timing results
            // these runs are not included in the final measurements
            InitialCode();
            BetterCode();

            // run both methods multiple times to get more reliable results
            for (int i = 0; i < runCount; i++)
            {
                initialTime = InitialCode();
                betterTime = BetterCode();

                // add each run time to the total for summary calculations
                initialTotal += initialTime;
                betterTotal += betterTime;
            }

            //calculate average time for both methods
            initialAverage = (double)initialTotal / runCount;
            betterAverage = (double)betterTotal / runCount;
            difference = initialAverage - betterAverage;

            // calculate percentage improvement
            if (initialAverage > 0)
            {
                improvementPercent = (difference / initialAverage) * 100.0;
            }

            Console.WriteLine();
            Console.WriteLine("===== Summary =====");
            Console.WriteLine("InitialCode average: {0:F1} ms", initialAverage);
            Console.WriteLine("BetterCode average: {0:F1} ms", betterAverage);
            Console.WriteLine("Difference: {0:F1} ms", difference);
            Console.WriteLine("BetterCode improvement: {0:F2}%", improvementPercent);

            Console.WriteLine();
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();

            return;
        }

        /*
         * FUNCTION     : InitialCode()
         * DESCRIPTION  : Runs the original code as given and measures the execution time of the loop using stopwatch
         * PARAMETERS   : void
         * RETURNS      : long: elapsed time in milliseconds
         */
        static long InitialCode()
        {
            int temp = 0;
            Random rand = new Random();
            int LOOPCOUNT = 100000000;
            long elapsedTime = 0;

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
            elapsedTime = sw.ElapsedMilliseconds;

            Console.WriteLine("InitialCode total time: {0} ms", elapsedTime);

            return elapsedTime;
        }

        /*
         * FUNCTION     : BetterCode()
         * DESCRIPTION  : Runs the optimized version of the code and measures
         *                the execution time of the loop using Stopwatch.
         * PARAMETERS   : void
         * RETURNS      : long : elapsed time in milliseconds
         */
        static long BetterCode()
        {
            int temp = 0;
            Random rand = new Random();
            int LOOPCOUNT = 100000000;
            long elapsedTime = 0;

            Stopwatch sw = new Stopwatch(); // define stopwatch object
            sw.Start(); // start the stopwatch just before the loop

            for (int counter = 0; counter < LOOPCOUNT; counter++)
            {

                float randomFloat = rand.NextSingle();

                // Improved logic: once one condition is true, the rest are skipped
                if (randomFloat < .10)
                {
                    temp = 1;
                }
                else if (randomFloat < .30)
                {
                    temp = 2;
                }
                else
                {
                    temp = 3;
                }
            }

            sw.Stop(); // stop the stopwatch after the loop
            elapsedTime = sw.ElapsedMilliseconds;

            Console.WriteLine("BetterCode total time: {0} ms", elapsedTime);

            return elapsedTime;
        }
    }
}