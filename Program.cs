using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using static CA12ConcurrencyAndParallelism.Program;

namespace CA12ConcurrencyAndParallelism
{
    class Program
    {
     static List<string> Tasks = new List<string>();
        static string filePath = Path.Combine(Environment.CurrentDirectory, "tasks.txt");

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my To Do List ");
            Console.WriteLine("---------------------------");

            LoadTasks();

            while (true) 
            {

                Console.WriteLine("Choose one of the following options :");
                Console.WriteLine("1. Add Task");
                Console.WriteLine("2. View All Tasks");
                Console.WriteLine("3. Mark Task As Completed");
                Console.WriteLine("4. Remove Task");
                Console.WriteLine("5. Exit");

                var ChosenOption = Console.ReadLine();

                switch(ChosenOption)
                {
                    case "1":
                        AddTask();
                        break;
                    case "2":
                        ViewTask();
                        break;
                    case "3":
                        MarkTaskAsCompleted();
                        break;
                    case "4":
                        RemoveTask();
                        break;
                    case "5":
                        SaveTasks();
                        Environment.Exit(0);
                        break;
                    default:
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                            break;
                }
                Console.WriteLine("---------------------------");

            }
        }
        private static void LoadTasks()
        {
            if (File.Exists(filePath))
            {
                Tasks = new List<string>(File.ReadAllLines(filePath));
                Console.WriteLine("Tasks loaded successfully.");
            }
            else
            {
                Console.WriteLine("No existing task file found. Starting fresh.");
            }
        }

        private static void SaveTasks()
        {
            File.WriteAllLines(filePath, Tasks);
            Console.WriteLine("Tasks saved successfully.");
        }

        private static void RemoveTask()
        {
           
            if (Tasks.Count == 0)
            {
                Console.WriteLine("The task list is empty.");
                return;
            }
            Console.WriteLine("Enter The Task Number");
            var Tasknumber = int.Parse(Console.ReadLine());
            if (Tasknumber <= Tasks.Count)
            {
                Tasks.RemoveAt(Tasknumber - 1);
                Console.WriteLine("The Task is Removed successfully");
            }
            else
            {
                Console.WriteLine("The Enteried Number doesn't exist");
            }
            SaveTasks();
        }

        private static void MarkTaskAsCompleted()
        {
            if (Tasks.Count == 0)
            {
                Console.WriteLine("The task list is empty.");
                return;
            }
           
            Console.WriteLine("Enter The Task Number");
            var Tasknumber = int.Parse(Console.ReadLine());
            if (Tasknumber <= Tasks.Count && Tasknumber > 0)
            {
                if (!Tasks[Tasknumber - 1].Contains("COMPLETED"))
                {
                    Tasks[Tasknumber - 1] += " -- COMPLETED";
                    Console.WriteLine("The Task is Marked As Completed successfully");
                }
                else
                    Console.WriteLine("The Task is already Completed");
            }

            else
            {
                Console.WriteLine("Invalid Task Number.");
            }
            SaveTasks();
        }
    private static void ViewTask()
        {
            var num = 1;
            Console.WriteLine("The To-do List :");
            foreach (var item in Tasks)
            {
                Console.Write(num++ + ". ");
                Console.WriteLine(item);
            }
        }

        private static void AddTask()
        {
            Console.WriteLine("Enter The Task Title");
            var TaskTitle = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(TaskTitle))
            {
                Console.WriteLine("Task title cannot be empty or whitespace.");
                return;
            }
            Tasks.Add(TaskTitle);
            Console.WriteLine($"Task \"{TaskTitle}\" was added successfully as task number {Tasks.Count}.");
            SaveTasks();
        }
    }
   
}