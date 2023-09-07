namespace Task
{
    class Task1
    {
        public void DoTask()
        {
            Console.Write("Please input your name: ");
            string? name = Console.ReadLine();

            Console.Write("Please input the number of subjects you've taken: ");
            int no_of_subjects = Convert.ToInt32(Console.ReadLine());

            Dictionary<string, double> subject_grade_dict = new Dictionary<string, double>();

            for (int i = 0; i < no_of_subjects; i++)
            {
                Console.Write("Please input the subject: ");
                string? subject = Console.ReadLine();
                while (subject == null)
                {
                    Console.Write("!Empty Subject!, Please input the subject: ");
                    subject = Console.ReadLine();
                }

                Console.Write("Please input the grade of " + subject + ": ");
                string? input = Console.ReadLine();
                double grade = 0;
                while (!double.TryParse(input, out grade) || (grade < 0 || grade > 100))
                {
                    Console.Write("!Invalid grade!, Please input in the range [0, 100]: ");
                    Console.Write("Please input the grade of " + subject + ": ");
                    input = Console.ReadLine();
                }
                subject_grade_dict.Add(subject, grade);
                Console.WriteLine();
            }

            double average = CalculateAverage(subject_grade_dict);
            this.DisplayInfo(name, subject_grade_dict, average);
        }

        public double CalculateAverage(Dictionary<string, double> dict)
        {
            double average = 0;
            foreach (var item in dict)
            {
                average += item.Value;
            }

            return average / dict.Count();
        }

        public void DisplayInfo(string name, Dictionary<string, double> grades_dict, double average)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Number of subjects taken: {grades_dict.Count()}\n");
            Console.WriteLine($"Here are you grades:");
            foreach (var item in grades_dict)
            {
                Console.WriteLine($"   {item.Key} = {item.Value}");
            }
            Console.WriteLine($"\nAverage = {average}");
        }
    }
}