using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Day_02
{
    /* The puzzle (Part 1): https://adventofcode.com/2022/day/2
      TLDR: You're cheating at Rock, Paper, Scissors by following a guide. Each hand you can play scores you points, as does winning, drawing and losing. How many points will you get from following the guide?

FULL PUZZLE:

The Elves begin to set up camp on the beach. To decide whose tent gets to be closest to the snack storage, a giant Rock Paper Scissors tournament is already in progress.

Rock Paper Scissors is a game between two players. Each game contains many rounds; in each round, the players each simultaneously choose one of Rock, Paper, or Scissors using a hand shape. Then, a winner for that round is selected: Rock defeats Scissors, Scissors defeats Paper, and Paper defeats Rock. If both players choose the same shape, the round instead ends in a draw.

Appreciative of your help yesterday, one Elf gives you an encrypted strategy guide (your puzzle input) that they say will be sure to help you win. "The first column is what your opponent is going to play: A for Rock, B for Paper, and C for Scissors. The second column--" Suddenly, the Elf is called away to help with someone's tent.

The second column, you reason, must be what you should play in response: X for Rock, Y for Paper, and Z for Scissors. Winning every time would be suspicious, so the responses must have been carefully chosen.

The winner of the whole tournament is the player with the highest score. Your total score is the sum of your scores for each round. The score for a single round is the score for the shape you selected (1 for Rock, 2 for Paper, and 3 for Scissors) plus the score for the outcome of the round (0 if you lost, 3 if the round was a draw, and 6 if you won).

Since you can't be sure if the Elf is trying to help you or trick you, you should calculate the score you would get if you were to follow the strategy guide.

For example, suppose you were given the following strategy guide:

A Y
B X
C Z
This strategy guide predicts and recommends the following:

In the first round, your opponent will choose Rock (A), and you should choose Paper (Y). This ends in a win for you with a score of 8 (2 because you chose Paper + 6 because you won).
In the second round, your opponent will choose Paper (B), and you should choose Rock (X). This ends in a loss for you with a score of 1 (1 + 0).
The third round is a draw with both players choosing Scissors, giving you a score of 3 + 3 = 6.
In this example, if you were to follow the strategy guide, you would get a total score of 15 (8 + 1 + 6).

What would your total score be if everything goes exactly according to your strategy guide? */

    class Program
     {
         static void Main(string[] args)
         {
             Day02Part1();
             Day02Part2();
         }

         static void Day02Part1()
         {
             // Read the input and convert to a string
             string puzzleInput = File.ReadAllText(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Input.txt"));
             // Remove all line breaks and spaces
             string[] tempArray = puzzleInput.Split(System.Environment.NewLine);
             puzzleInput = string.Join("", tempArray);
             puzzleInput = puzzleInput.Replace(" ", "");
            // Console.WriteLine(puzzleInput);

             //--------------------------------

             // Create a multidimensional array of chars from the string
             char[,] cheatBook = new char[(puzzleInput.Length / 2), 2];

             for (int i = 0; i < (puzzleInput.Length); i++)
             {
                // If i is an even number, take that char and assign it to the multidimensional array in row k, column 0. k will increase by one after every two inputs
                 if (i % 2 == 0)
                 {
                     char j = puzzleInput[i];
                     int k = i / 2;
                     cheatBook[k, 0] = j;
                 }
                 // If i is an odd number, take the char and assign it to row k, column 1.
                 else
                 {
                     char j = puzzleInput[i];
                     int k = i / 2;
                     cheatBook[k, 1] = j;
                 }

             }

             //--------------------------------

             // Point values of each variable and game outcome according to the rules
             int score = 0;
             int aRock = 1;
             int bPaper = 2;
             int cScissors = 3;
             int draw = 3;
             int win = 6;

            // Compare the first player to the second player (both on the same row of the multidimensional array) and calculate the point result
             for (int i = 0; i < cheatBook.Length / 2; i++)
             {
                 // ------------ A -----------------
                 if (cheatBook[i, 0] == 'A')
                 {
                     if (cheatBook[i, 1] == 'X')
                     {
                         score += aRock + draw;
                     }
                 }
                 if (cheatBook[i, 0] == 'A')
                 {
                     if (cheatBook[i, 1] == 'Y')
                     {

                         score += bPaper + win;
                     }
                 }
                 if (cheatBook[i, 0] == 'A')
                 {
                     if (cheatBook[i, 1] == 'Z')
                     {
                         score += cScissors;
                     }
                 }

                 // ------------ B -----------------
                 if (cheatBook[i, 0] == 'B')
                 {
                     if (cheatBook[i, 1] == 'X')
                     {
                         score += aRock;
                     }
                 }
                 if (cheatBook[i, 0] == 'B')
                 {
                     if (cheatBook[i, 1] == 'Y')
                     {
                         score += bPaper + draw;
                     }
                 }
                 if (cheatBook[i, 0] == 'B')
                 {
                     if (cheatBook[i, 1] == 'Z')
                     {
                         score += cScissors + win;
                     }
                 }

                 // ------------ C -----------------
                 if (cheatBook[i, 0] == 'C')
                 {
                     if (cheatBook[i, 1] == 'X')
                     {
                         score += aRock + win;
                     }
                 }
                 if (cheatBook[i, 0] == 'C')
                 {
                     if (cheatBook[i, 1] == 'Y')
                     {
                         score += bPaper;
                     }
                 }
                 if (cheatBook[i, 0] == 'C')
                 {
                     if (cheatBook[i, 1] == 'Z')
                     {
                         score += cScissors + draw;
                     }
                 }

                 /* Debugging Tests
                 Console.WriteLine("Loop No: " + i);
                 Console.WriteLine("Array: " + cheatBook[i, 0] + cheatBook[i, 1]);
                 Console.WriteLine("Score = " + score);
                 */
             }
                Console.WriteLine("The score you get from playing by this cheatbook is = " + score);
        }

        /* PART 2 PUZZLE:
         
The Elf finishes helping with the tent and sneaks back over to you. "Anyway, the second column says how the round needs to end: X means you need to lose, Y means you need to end the round in a draw, and Z means you need to win. Good luck!"

The total score is still calculated in the same way, but now you need to figure out what shape to choose so the round ends as indicated. The example above now goes like this:

In the first round, your opponent will choose Rock (A), and you need the round to end in a draw (Y), so you also choose Rock. This gives you a score of 1 + 3 = 4.
In the second round, your opponent will choose Paper (B), and you choose Rock so you lose (X) with a score of 1 + 0 = 1.
In the third round, you will defeat your opponent's Scissors with Rock for a score of 1 + 6 = 7.
Now that you're correctly decrypting the ultra top secret strategy guide, you would get a total score of 12.

Following the Elf's instructions for the second column, what would your total score be if everything goes exactly according to your strategy guide? */


        static void Day02Part2()
        {
            string puzzleInput = File.ReadAllText(Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Input.txt"));
            string[] tempArray = puzzleInput.Split(System.Environment.NewLine);
            puzzleInput = string.Join("", tempArray);
            puzzleInput = puzzleInput.Replace(" ", "");

            char[,] cheatBook = new char[(puzzleInput.Length / 2), 2];

            for (int i = 0; i < (puzzleInput.Length); i++)
            {
                if (i % 2 == 0)
                {
                    char j = puzzleInput[i];
                    int k = i / 2;
                    cheatBook[k, 0] = j;
                }
                else
                {
                    char j = puzzleInput[i];
                    int k = i / 2;
                    cheatBook[k, 1] = j;
                }

            }

            int score = 0;
            int aRock = 1;
            int bPaper = 2;
            int cScissors = 3;
            int draw = 3;
            int win = 6;

            for (int i = 0; i < cheatBook.Length / 2; i++)
            {
                // ------------ A -----------------
                if (cheatBook[i, 0] == 'A')
                {
                    if (cheatBook[i, 1] == 'X')
                    {
                        score += cScissors;
                    }
                }
                if (cheatBook[i, 0] == 'A')
                {
                    if (cheatBook[i, 1] == 'Y')
                    {

                        score += aRock + draw;
                    }
                }
                if (cheatBook[i, 0] == 'A')
                {
                    if (cheatBook[i, 1] == 'Z')
                    {
                        score += bPaper + win;
                    }
                }

                // ------------ B -----------------
                if (cheatBook[i, 0] == 'B')
                {
                    if (cheatBook[i, 1] == 'X')
                    {
                        score += aRock;
                    }
                }
                if (cheatBook[i, 0] == 'B')
                {
                    if (cheatBook[i, 1] == 'Y')
                    {
                        score += bPaper + draw;
                    }
                }
                if (cheatBook[i, 0] == 'B')
                {
                    if (cheatBook[i, 1] == 'Z')
                    {
                        score += cScissors + win;
                    }
                }

                // ------------ C -----------------
                if (cheatBook[i, 0] == 'C')
                {
                    if (cheatBook[i, 1] == 'X')
                    {
                        score += bPaper;
                    }
                }
                if (cheatBook[i, 0] == 'C')
                {
                    if (cheatBook[i, 1] == 'Y')
                    {
                        score += cScissors + draw;
                    }
                }
                if (cheatBook[i, 0] == 'C')
                {
                    if (cheatBook[i, 1] == 'Z')
                    {
                        score += aRock + win;
                    }
                }

            }
            Console.WriteLine("For Part 2, the new score is = " + score);
        }

    }
}
