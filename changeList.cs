using System;
using System.Linq;

namespace softUniListsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = Console.ReadLine().Split().Select(int.Parse).ToList();

            string command = Console.ReadLine();
            while(command != "end")
            {
                string[] input = command.Split(' ');
                string deleteOrInsert = input[0];
                int element = int.Parse(input[1]);
                int position = int.Parse(input[input.Length - 1]);
                if(deleteOrInsert == "Delete")
                {
                    for(int i = 0; i < ints.Count; i++)
                    {
                        if (ints[i] == element) ints.Remove(element);
                    }
                }
                else ints.Insert(position, element);
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", ints));
        }
    }
}