using System.IO;
using System.Windows.Markup;
namespace AdvancedI
{
    enum TaskCategory { Personal, Work, Misc }
    class MyTask
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public TaskCategory Category { get; set; }
        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            return $"{Name},{Description},{Category},{IsCompleted}\n";
        }
    }

    class TaskManager
    {
        public static List<MyTask> Tasks = new();
        readonly static string FilePath = "task.csv";
        public static void AddTask(MyTask task)
        {
            Tasks.Add(task);
        }

        public static List<MyTask> FilterByCategory(TaskCategory category)
        {
            return Tasks.FindAll((MyTask task) => task.Category == category);
        }

        public static MyTask? ToTask(string task)
        {
            string[] Splitted = task.Split(',');
            TaskCategory category;
            bool isCompleted;
            if (Splitted.Length != 4 ||
                !Enum.TryParse<TaskCategory>(Splitted[2], out category) ||
                !bool.TryParse(Splitted[3], out isCompleted))
            {
                return null;
            }
            MyTask taskObj = new()
            {
                Name = Splitted[0],
                Description = Splitted[1],
                Category = category,
                IsCompleted = isCompleted
            };
            return taskObj;
        }

        public static async Task LoadCSV()
        {
            try
            {
                string[] allLines = await File.ReadAllLinesAsync(FilePath);
                foreach (string line in allLines)
                {
                    MyTask? task = ToTask(line);
                    if (task != null)
                    {
                        Tasks.Add(task);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }

        public static async Task SaveCSV()
        {
            try
            {
                foreach (MyTask task in Tasks)
                {
                    await File.AppendAllTextAsync(FilePath, task.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}