using System;
using System.Linq;

namespace softUniListsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lessonTitles = Console.ReadLine().Split(", ").ToList();

            string command = Console.ReadLine();
            while(command != "course start")
            {
                string[] commandParts = command.Split(':');
                string commandType = commandParts[0];

                if (commandType == "Add")
                {
                    string lessonTitle = commandParts[1];
                    if (!lessonTitles.Contains(lessonTitle)) lessonTitles.Add(lessonTitle);
                }
                else if (commandType == "Insert")
                {
                    string lessonTitle = commandParts[1];
                    int insertIndex = int.Parse(commandParts[2]);
                    if (!lessonTitles.Contains(lessonTitle)) lessonTitles.Insert(insertIndex, lessonTitle);
                }
                else if (commandType == "Remove")
                {
                    string lessonTitle = commandParts[1];
                    lessonTitles.Remove(lessonTitle);
                    if (lessonTitles.Contains($"{lessonTitle}-Exercise")) lessonTitles.Remove($"{lessonTitle}-Exercise");
                }
                else if (commandType == "Swap")
                {
                    string lessonTitle1 = commandParts[1];
                    string lessonTitle2 = commandParts[2];
                    if (lessonTitles.Contains(lessonTitle1) && lessonTitles.Contains(lessonTitle2))
                    {
                        lessonTitles = Swap(lessonTitles, lessonTitle1, lessonTitle2);
                    }

                    if(lessonTitles.Contains($"{lessonTitle1}-Exercise") && lessonTitles.Contains($"{lessonTitle2}-Exercise"))
                    {
                        lessonTitles = Swap(lessonTitles, $"{lessonTitle1}-Exercise", $"{lessonTitle2}-Exercise");
                    }
                    else if(lessonTitles.Contains($"{lessonTitle1}-Exercise"))
                    {
                        lessonTitles.Remove($"{lessonTitle1}-Exercise");
                        lessonTitles.Insert(lessonTitles.IndexOf(lessonTitle1) + 1, $"{lessonTitle1}-Exercise");
                    }
                    else if(lessonTitles.Contains($"{lessonTitle2}-Exercise"))
                    {
                        lessonTitles.Remove($"{lessonTitle2}-Exercise");
                        lessonTitles.Insert(lessonTitles.IndexOf(lessonTitle2) + 1, $"{lessonTitle2}-Exercise");
                    }
                }
                else if (commandType == "Exercise")
                {
                    string lessonTitle = commandParts[1];
                    lessonTitles = AddExercise(lessonTitles, lessonTitle);
                }
                
                command = Console.ReadLine();
            }

            for(int i = 0; i < lessonTitles.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{lessonTitles[i]}");
            }
        }

        static List<string> Swap(List<string> lessonTitles, string lessonTitle1, string lessonTitle2)
        {
            int origLT1Index = lessonTitles.IndexOf(lessonTitle1);
            int origLT2Index = lessonTitles.IndexOf(lessonTitle2);
            lessonTitles.Insert(origLT2Index, lessonTitle1);
            lessonTitles.Insert(origLT1Index, lessonTitle2);
            lessonTitles.RemoveAt(origLT1Index + 1);
            lessonTitles.RemoveAt(origLT2Index + 1);
            return lessonTitles;
        }

        static List<string> AddExercise(List<string> lessonTitles, string lessonTitle)
        {
            if(lessonTitles.Contains(lessonTitle))
            {
                lessonTitles.Insert(lessonTitles.IndexOf(lessonTitle) + 1, $"{lessonTitle}-Exercise");
            }
            else
            {
                lessonTitles.Add(lessonTitle);
                lessonTitles.Add($"{lessonTitle}-Exercise");
            }
            return lessonTitles;
        }
    }
}