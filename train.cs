using System;
using System.Linq;

namespace softUniListsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacity = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            while(command != "end")
            {
                string[] input = command.Split(' ');
                int passengers = int.Parse(input[input.Length - 1]);
                if(input[0] == "Add") wagons.Add(passengers);
                else
                {
                    for(int i = 0; i < wagons.Count; i++)
                    {
                        if(wagons[i] + passengers <= maxCapacity)
                        {
                            wagons[i] += passengers;
                            break;
                        }
                    }
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", wagons));
        }
    }
}