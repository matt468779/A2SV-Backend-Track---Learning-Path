// See https://aka.ms/new-console-template for more information
using Task;
using System.Text.Json;

string fileName = "data.json";
string jsonString = File.ReadAllText(fileName);
StudentList<Student>? students =
JsonSerializer.Deserialize<StudentList<Student>>(jsonString);
students = students == null ? students : new StudentList<Student>();

Console.WriteLine("Hello, World!");
students.Add(new Student(1, "Matt", 22, "C-"));

var searchResultByName = StudentQuery.searchByName(students, "Matt");
StudentQuery.PrintStudents(searchResultByName);

var searchResultById = StudentQuery.searchById(students, 1);
StudentQuery.PrintStudents(searchResultById);


jsonString = JsonSerializer.Serialize(students);
File.WriteAllText(fileName, jsonString);
