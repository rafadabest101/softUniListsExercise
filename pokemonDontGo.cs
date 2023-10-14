using System;
using System.Linq;

namespace softUniListsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> distances = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            int sum = 0;
            while(distances.Count > 0)
            {
                int index = int.Parse(Console.ReadLine());
                int removedNumber;
                if(index < 0)
                {
                    removedNumber = distances[0];
                    distances.RemoveAt(0);
                    distances.Insert(0, distances[distances.Count - 1]);
                }
                else if(index >= distances.Count)
                {
                    removedNumber = distances[distances.Count - 1];
                    distances.Insert(distances.Count - 1, distances[0]);
                    distances.RemoveAt(distances.Count - 1);
                }
                else
                {
                    removedNumber = distances[index];
                    distances.RemoveAt(index);
                }
                for(int i = 0; i < distances.Count; i++)
                {
                    if(distances[i] > removedNumber) distances[i] -= removedNumber;
                    else distances[i] += removedNumber;
                }
                sum += removedNumber;
            }
            Console.WriteLine(sum);
        }
    }
}