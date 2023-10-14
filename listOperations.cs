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
            while(command != "End")
            {
                string[] commandParts = command.Split().ToArray();
                string commandType = commandParts[0];

                if (commandType == "Add") ints.Add(int.Parse(commandParts[1]));
                else if(commandType == "Insert")
                {
                    int element = int.Parse(commandParts[1]);
                    int index = int.Parse(commandParts[2]);
                    if(index < 0 || index > ints.Count - 1) Console.WriteLine("Invalid index");
                    else ints.Insert(index, int.Parse(commandParts[1]));
                }
                else if(commandType == "Remove")
                {
                    int index = int.Parse(commandParts[1]);
                    if(index < 0 || index > ints.Count - 1) Console.WriteLine("Invalid index");
                    else ints.RemoveAt(index);
                }
                else if(commandType == "Shift")
                {
                    if(commandParts.Contains("left"))
                    {
                        for(int i = 0; i < int.Parse(commandParts[2]); i++)
                        {
                            ints.Add(ints[0]);
                            ints.RemoveAt(0);
                        }
                    }
                    else if(commandParts.Contains("right"))
                    {
                        for(int i = 0; i < int.Parse(commandParts[2]); i++)
                        {
                            ints.Insert(0, ints[ints.Count - 1]);
                            ints.RemoveAt(ints.Count - 1);
                        }
                    }
                };
                    command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', ints));
        }
    }
}