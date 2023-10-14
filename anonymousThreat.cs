using System;
using System.Linq;

namespace softUniListsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> strs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();
            while(command != "3:1")
            {
                string[] commandParts = command.Split(' ');
                if(commandParts[0] == "merge")
                {
                    int startIndex = int.Parse(commandParts[1]);
                    int endIndex = int.Parse(commandParts[2]);
                    strs = Merge(strs, startIndex, endIndex);
                }
                else if(commandParts[0] == "divide")
                {
                    int index = int.Parse(commandParts[1]);
                    int partitions = int.Parse(commandParts[2]);
                    strs = Divide(strs, index, partitions);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine(string.Join(' ', strs));
        }

        static List<string> Merge(List<string> strs, int startIndex, int endIndex)
        {
            string mergedStr = "";
            if(endIndex >= strs.Count) endIndex = strs.Count - 1;
            if(startIndex >= strs.Count) startIndex = strs.Count - 1;
            if(startIndex < 0) startIndex = 0;
            if(endIndex < 0) endIndex = 0;
            for(int i = startIndex; i <= endIndex; i++)
            {
                mergedStr += strs[startIndex];
                strs.RemoveAt(startIndex);
            }
            strs.Insert(startIndex, mergedStr);
            return strs;
        }

        static List<string> Divide(List<string> strs, int index, int partitions)
        {
            string substring = "";
            string origStr = strs[index];
            int substringLength = origStr.Length / partitions;
            int insertedSubstrings = 0;

            strs.RemoveAt(index);
            if(partitions <= origStr.Length)
            {
                for(int i = 0; i < partitions; i++)
                {
                    for(int p = 0; p < substringLength; p++)
                    {
                        substring += origStr[i * substringLength + p];
                        if(i == partitions - 1)
                        {
                            for(int mod = origStr.Length % partitions - 1; mod >= 0; mod--)
                            {
                                substring += origStr[origStr.Length - 1 - mod];
                            }
                        }
                    }
                    strs.Insert(index + insertedSubstrings, substring);
                    insertedSubstrings++;
                    substring = "";
                }
            }
            else strs.Insert(index + insertedSubstrings, origStr);
            return strs;
        }
    }
}