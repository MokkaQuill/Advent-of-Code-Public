using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day_01
{
    /* The puzzle (Part 1): https://adventofcode.com/2022/day/1
     TLDR: Find the elf with the most calories, and work out what that is.

    FULL PUZZLE:

    As your boats approach land, the Elves begin taking inventory of their supplies. One important consideration is food - in particular, the number of Calories each Elf is carrying (your puzzle input).
    The Elves take turns writing down the number of Calories contained by the various meals, snacks, rations, etc. that they've brought with them, one item per line. Each Elf separates their own inventory from the previous Elf's inventory (if any) by a blank line.
    For example, suppose the Elves finish writing their items' Calories and end up with the following list:

        1000
        2000
        3000

        4000

        5000
        6000

        7000
        8000
        9000

        10000

    This list represents the Calories of the food carried by five Elves:

    The first Elf is carrying food with 1000, 2000, and 3000 Calories, a total of 6000 Calories.
    The second Elf is carrying one food item with 4000 Calories.
    The third Elf is carrying food with 5000 and 6000 Calories, a total of 11000 Calories.
    The fourth Elf is carrying food with 7000, 8000, and 9000 Calories, a total of 24000 Calories.
    The fifth Elf is carrying one food item with 10000 Calories.
    
    In case the Elves get hungry and need extra snacks, they need to know which Elf to ask: they'd like to know how many Calories are being carried by the Elf carrying the most Calories. In the example above, this is 24000 (carried by the fourth Elf).

    Find the Elf carrying the most Calories. How many total Calories is that Elf carrying? */

    class Day01
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        static void Part1()
        {
            // Read the raw data into a string array
            string[] calorieStrings = File.ReadAllLines(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Input.txt"));

            //Create an empty list for ints
            List<int> calorieInts = new List<int>();
            // Empty list for combined counts of each elf
            List<int> calorieTotals = new List<int>();

            int tempCount = 0;

            // Convert blank lines to 0 so we can read the data as an int list
            for (int i = 0; i < calorieStrings.Length; i++)
            {
                if (calorieStrings[i] == "")
                {
                    calorieStrings[i] = "0";
                }

            }

            // For each line in the string array, convert it to an int and add it to the calorieInts list
            for (int i = 0; i < calorieStrings.Length; i++)
            {
                calorieInts.Add(Convert.ToInt32(calorieStrings[i]));

            }

            // Add each int in the list to tempCount until it hits a 0. Then add that number the the calorieTotals list, and reset tempCount to 0.
            for (int i = 0; i < calorieInts.Count - 1; i++)
            {

                if (calorieInts[i] != 0)
                {
                    tempCount += calorieInts[i];
                }

                if (calorieInts[i] == 0)
                {
                    calorieTotals.Add(tempCount);
                    tempCount = 0;
                }
            }

            // Find the highest total and write it to the console
            int maxCals = calorieTotals.Max();
            Console.WriteLine("Part 1: The elf with the most calories has: " + maxCals + " calories.");
        }


/* PART 2 PUZZLE:

By the time you calculate the answer to the Elves' question, they've already realized that the Elf carrying the most Calories of food might eventually run out of snacks.
To avoid this unacceptable situation, the Elves would instead like to know the total Calories carried by the top three Elves carrying the most Calories. That way, even if one of those Elves runs out of snacks, they still have two backups.
In the example above, the top three Elves are the fourth Elf (with 24000 Calories), then the third Elf (with 11000 Calories), then the fifth Elf (with 10000 Calories). The sum of the Calories carried by these three elves is 45000.
Find the top three Elves carrying the most Calories. How many Calories are those Elves carrying in total? */


        static void Part2()
        {
            // Stick the raw data into a string array
            string[] calorieStrings = File.ReadAllLines(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Input.txt"));

            //Create an empty list for ints
            List<int> calorieInts = new List<int>();
            // Empty list for combined counts
            List<int> calorieTotals = new List<int>();

            int tempCount = 0;

            for (int i = 0; i < calorieStrings.Length; i++)
            {
                if (calorieStrings[i] == "")
                {
                    calorieStrings[i] = "0";
                }

            }


            for (int i = 0; i < calorieStrings.Length; i++)
            {
                calorieInts.Add(Convert.ToInt32(calorieStrings[i]));
            }

            for (int i = 0; i < calorieInts.Count - 1; i++)
            {

                if (calorieInts[i] != 0)
                {
                    tempCount += calorieInts[i];
                }

                if (calorieInts[i] == 0)
                {
                    calorieTotals.Add(tempCount);
                    tempCount = 0;
                }
            }

            calorieTotals.Sort();

            int topThree = calorieTotals[calorieTotals.Count-1] + calorieTotals[calorieTotals.Count-2] + calorieTotals[calorieTotals.Count-3];

            Console.WriteLine("Part 2: The total calories of the three elves carrying the most is: " + topThree + " calories.");



        }
    }
}
