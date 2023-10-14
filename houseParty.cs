using System;
using System.Linq;

namespace softUniListsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> guestList = new List<string>();
            
            for(int i = 1; i <= n; i++)
            {
                string command = Console.ReadLine();
                string[] commandParts = command.Split().ToArray();
                string name = commandParts[0];

                if(command.Contains("not"))
                {
                    if(guestList.Contains(name)) guestList.Remove(name);
                    else Console.WriteLine($"{name} is not in the list!");
                }
                else
                {
                    if(!guestList.Contains(name)) guestList.Add(name);
                    else Console.WriteLine($"{name} is already in the list!");
                }
            }

            foreach(string guest in guestList)
            {
                Console.WriteLine(guest);
            }
        }
    }
}