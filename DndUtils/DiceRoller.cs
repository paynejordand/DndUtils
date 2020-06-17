using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace DndUtils
{
    static class DiceRoller
    {
        private static int RandomNumber()
        {
            var rand = new Random();
            return rand.Next(1,7);
        }

        private static int FindMax(int num1, int num2, int num3, int num4, int num5, int num6)
        {
            int maxStat = Math.Max(num1, num2);
            maxStat = Math.Max(maxStat, num3);
            maxStat = Math.Max(maxStat, num4);
            maxStat = Math.Max(maxStat, num5);
            maxStat = Math.Max(maxStat, num6);
            return maxStat;
        }

        public static List<int> RollStats()
        {
            int totalSum = 0, sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0, sum5 = 0, sum6 = 0, maxStat = 0;

            List<int> stat1 = new List<int>();
            List<int> stat2 = new List<int>();
            List<int> stat3 = new List<int>();
            List<int> stat4 = new List<int>();
            List<int> stat5 = new List<int>();
            List<int> stat6 = new List<int>();

            while(totalSum < 70 || maxStat < 15)
            {
                stat1.Clear();
                stat2.Clear();
                stat3.Clear();
                stat4.Clear();
                stat5.Clear();
                stat6.Clear();

                for(int i = 0; i < 4; i++)
                {
                    stat1.Add(RandomNumber());
                    stat2.Add(RandomNumber());
                    stat3.Add(RandomNumber());
                    stat4.Add(RandomNumber());
                    stat5.Add(RandomNumber());
                    stat6.Add(RandomNumber());
                }
                stat1.Sort();
                stat2.Sort();
                stat3.Sort();
                stat4.Sort();
                stat5.Sort();
                stat6.Sort();

                stat1.RemoveAt(0);
                stat2.RemoveAt(0);
                stat3.RemoveAt(0);
                stat4.RemoveAt(0);
                stat5.RemoveAt(0);
                stat6.RemoveAt(0);

                sum1 = stat1.Sum();
                sum2 = stat2.Sum();
                sum3 = stat3.Sum();
                sum4 = stat4.Sum();
                sum5 = stat5.Sum();
                sum6 = stat6.Sum();

                totalSum = sum1 + sum2 + sum3 + sum4 + sum5 + sum6;
                maxStat = FindMax(sum1, sum2, sum3, sum4, sum5, sum6);
            }
            List<int> output = new List<int> { sum1, sum2, sum3, sum4, sum5, sum6 };
            output.Sort();
            output.Reverse();
            return output;
        }

        public static int RollDie(int maxValue)
        {
            var rand = new Random();
            return rand.Next(1, maxValue + 1);
        }
    }
}
