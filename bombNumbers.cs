using System;
using System.Linq;

namespace softUniListsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = Console.ReadLine().Split().Select(int.Parse).ToList();
            int[] bombInts = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int bombNumber = bombInts[0];
            int bombPower = bombInts[1];

            while(ints.Contains(bombNumber))
            {
                List<int> indexes = new List<int>();
                int bombNumberIndex = ints.IndexOf(bombNumber);
                for(int i = 1; i <= bombPower; i++)
                {
                    if(bombNumberIndex + i < ints.Count && bombNumberIndex + i >= 0) indexes.Add(bombNumberIndex + i);
                    if(bombNumberIndex - i < ints.Count && bombNumberIndex - i >= 0) indexes.Add(bombNumberIndex - i);
                }
                indexes.Sort();
                indexes.Reverse();
                foreach(int index in indexes)
                {
                    ints.RemoveAt(index);
                }
                ints.Remove(bombNumber);
            }

            int sum = 0;
            foreach(int n in ints)
            {
                sum += n;
            }
            Console.WriteLine(sum);
        }
    }
}