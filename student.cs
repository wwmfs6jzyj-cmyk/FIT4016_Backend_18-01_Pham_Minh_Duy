using System;

namespace StudentManagementSystem
{
    public class Student
{
    public string StudentId { get; set; }
    public string Name { get; set; }
    public double Score { get; set; }

    // Constructor
    public Student(string id, string name, double score)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new Exception("StudentId không được rỗng");

        if (string.IsNullOrWhiteSpace(name))
            throw new Exception("Tên không được rỗng");

        if (score < 0 || score > 10)
            throw new Exception("Điểm phải từ 0 đến 10");

        StudentId = id;
        Name = name;
        Score = score;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {StudentId} | Tên: {Name} | Điểm: {Score}");
    }
}
}
