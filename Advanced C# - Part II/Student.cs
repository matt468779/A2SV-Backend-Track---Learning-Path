
namespace Task
{
    class Student
    {
        public int RollNumber { get; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Grade { get; set; }

        public Student(int rollNumber, string name, int age, string grade)
        {
            RollNumber = rollNumber;
            Name = name;
            Age = age;
            Grade = grade;
        }

        public override string ToString()
        {
            return $"{RollNumber}  {Name}  {Age}  {Grade}";
        }

    }

    public class StudentList<T>
    {
        public List<T> Students { get; set; }

        public StudentList()
        {
            Students = new();
        }

        public List<T> get()
        {
            return Students;
        }

        public void Add(T student)
        {
            Students.Add(student);
        }

        public void Remove(T student)
        {
            Students.Remove(student);
        }
    }

    class StudentQuery
    {
        public static IEnumerable<Student> searchByName(StudentList<Student> students, string Name)
        {
            IEnumerable<Student> searchQuery =
                from student in students.Students
                where student.Name == Name
                select student;

            return searchQuery;
        }

        public static IEnumerable<Student> searchById(StudentList<Student> students, int Id)
        {
            IEnumerable<Student> searchQuery =
                from student in students.Students
                where student.RollNumber == Id
                select student;

            return searchQuery;
        }

        public static void PrintStudents(IEnumerable<Student> students)
        {
            foreach (Student s in students)
            {
                Console.WriteLine(s);
            }
        }
    }
}