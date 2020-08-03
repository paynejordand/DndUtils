using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace DndUtils
{
    static class DiceRoller
    {
        public static List<int> RollStats()
        {
            //?? Sums
            List<int> sums = new List<int>();


            //?? Loops, Certain Values
            do
            {
                // Clear all sums. 
                sums.Clear();

                // Loop over each stat
                for (int i = 0; i < 6; i++)
                {
                    List<int> stat = new List<int>();

                    // generate 4 values.
                    for (int x = 0; x < 4; x++)
                    {
                        stat.Add(DiceRoller.RollDie(6));
                    }

                    // Sort
                    stat.Sort();

                    // Remove Lowest Element
                    stat.RemoveAt(0);

                    // Add to the list of sums.
                    sums.Add(stat.Sum());
                }
            } while (sums.Sum() < 70 || sums.Max() < 15);

            return (from sum in sums orderby sum descending select sum).ToList();
        }

        public static int RollDie(int maxValue)
        {
            var rand = new Random();
            return rand.Next(1, maxValue);
        }
    }
}
