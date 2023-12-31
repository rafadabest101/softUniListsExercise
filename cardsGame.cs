using System;
using System.Linq;

namespace softUniListsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> cards1 = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> cards2 = Console.ReadLine().Split().Select(int.Parse).ToList();
            
            while(cards1.Count > 0 && cards2.Count > 0)
            {
                for(int i = 0; i < Math.Min(cards1.Count, cards2.Count); i++)
                {
                    if(cards1[0] > cards2[0])
                    {
                        cards1.Add(cards1[0]);
                        cards1.Add(cards2[0]);
                        cards1.RemoveAt(0);
                        cards2.RemoveAt(0);
                    }
                    else if(cards1[0] < cards2[0])
                    {
                        cards2.Add(cards2[0]);
                        cards2.Add(cards1[0]);
                        cards1.RemoveAt(0);
                        cards2.RemoveAt(0);
                    }
                    else
                    {
                        cards1.RemoveAt(0);
                        cards2.RemoveAt(0);
                    }
                }
            }
            int sum = 0;
            if(cards1.Count > 0)
            {
                foreach (int card in cards1) { sum += card; }
                Console.WriteLine($"First player wins! Sum: {sum}");
            }
            else
            {
                foreach (int card in cards2) { sum += card; }
                Console.WriteLine($"Second player wins! Sum: {sum}");
            }
        }
    }
}