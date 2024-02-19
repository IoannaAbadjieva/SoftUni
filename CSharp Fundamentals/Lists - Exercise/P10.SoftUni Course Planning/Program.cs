namespace P10.SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] separators = { ", ", ":" };

            List<string> schedule = Console.ReadLine()
                .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command;
            while ((command = Console.ReadLine()) != "course start")
            {
                string[] cmdArgs = command
                    .Split(separators, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string cmdType = cmdArgs[0];

                if (cmdType == "Add")
                {
                    string lesson = cmdArgs[1];

                    if (schedule.Contains(lesson))
                    {
                        continue;
                    }

                    schedule.Add(lesson);
                }
                else if (cmdType == "Insert")
                {
                    string lesson = cmdArgs[1];
                    int insertIndex = int.Parse(cmdArgs[2]);

                    if (schedule.Contains(lesson))
                    {
                        continue;
                    }

                    schedule.Insert(insertIndex, lesson);
                }
                else if (cmdType == "Remove")
                {
                    string lesson = cmdArgs[1];

                    if (!schedule.Contains(lesson))
                    {
                        continue;
                    }

                    schedule.RemoveAll(x => x.Contains(lesson));
                }
                else if (cmdType == "Swap")
                {
                    string firstLesson = cmdArgs[1];
                    string secondLesson = cmdArgs[2];

                    if (!schedule.Contains(firstLesson) || !schedule.Contains(secondLesson))
                    {
                        continue;
                    }

                    SwapElements(schedule, firstLesson, secondLesson);
                }
                else if (cmdType == "Exercise")
                {
                    string lesson = cmdArgs[1];

                    if (schedule.Contains($"{lesson}-Exercise"))
                    {
                        continue;
                    }

                    if (schedule.Contains(lesson))
                    {

                        int lessonIndex = schedule.IndexOf(lesson);
                        schedule.Insert(lessonIndex + 1, $"{lesson}-Exercise");
                    }
                    else
                    {
                        schedule.Add(lesson);
                        schedule.Add($"{lesson}-Exercise");
                    }
                }
            }
            PrintElementsOnNewLine(schedule);
        }
        static void SwapElements(List<string> schedule, string firstLesson, string secondLesson)
        {
            int firstLessonIndex = schedule.IndexOf(firstLesson);
            int secondLessonIndex = schedule.IndexOf(secondLesson);

            schedule[firstLessonIndex] = secondLesson;
            schedule[secondLessonIndex] = firstLesson;

            if (schedule.Contains($"{firstLesson}-Exercise"))
            {
                schedule.Insert(schedule.IndexOf(firstLesson) + 1, $"{firstLesson}-Exercise");
                schedule.RemoveAt(schedule.IndexOf(secondLesson) + 1);

            }
            if (schedule.Contains($"{secondLesson}-Exercise"))
            {
                schedule.Insert(schedule.IndexOf(secondLesson) + 1, $"{secondLesson}-Exercise");
                schedule.RemoveAt(schedule.IndexOf(firstLesson) + 1);
            }
        }

        static void PrintElementsOnNewLine(List<string> scedule)
        {
            for (int index = 0; index < scedule.Count; index++)
            {
                Console.WriteLine($"{index + 1}.{scedule[index]}");
            }
        }
    }
}
