// See https://aka.ms/new-console-template for more information
using AdvancedI;

await TaskManager.LoadCSV();

MyTask task1 = new() { Name = "task1", Category = TaskCategory.Personal, Description = "desc1", IsCompleted = false };
MyTask task2 = new() { Name = "task2", Category = TaskCategory.Personal, Description = "desc2", IsCompleted = false };

TaskManager.AddTask(task1);
TaskManager.AddTask(task2);

await TaskManager.SaveCSV();