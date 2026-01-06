using System;

namespace StudentManagementSystem
{
    public class StudentManager
    {
        private Student?[] students = new Student[50];
        private int count = 0;

        public void AddStudent(string id, string name, double score)
        {
            if (count >= 50)
                throw new Exception("Danh sách sinh viên đã đầy");

            if (FindStudentById(id) != null)
                throw new Exception("ID sinh viên đã tồn tại");

            students[count++] = new Student(id, name, score);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        public void RemoveStudent(string id)
        {
            for (int i = 0; i < count; i++)
            {
                if (students[i] != null && students[i]!.StudentId == id)
                {
                    for (int j = i; j < count - 1; j++)
                        students[j] = students[j + 1];

                    students[--count] = null;
                    Console.WriteLine("Xóa sinh viên thành công!");
                    return;
                }
            }
            throw new Exception("Không tìm thấy sinh viên");
        }

        public void UpdateScore(string id, double newScore)
        {
            if (newScore < 0 || newScore > 10)
                throw new Exception("Điểm phải từ 0 đến 10");

            Student? st = FindStudentById(id);
            if (st == null)
                throw new Exception("Không tìm thấy sinh viên");

            st.Score = newScore;
            Console.WriteLine("Cập nhật điểm thành công!");
        }

        public double GetAverageScore()
        {
            if (count == 0) return 0;
            double sum = 0;
            for (int i = 0; i < count; i++)
                if (students[i] != null)
                    sum += students[i]!.Score;
            return sum / count;
        }

        public double GetMaxScore()
        {
            if (count == 0)
                throw new Exception("Danh sách rỗng");

            int firstNonNullIndex = -1;
            for (int i = 0; i < count; i++)
            {
                if (students[i] != null)
                {
                    firstNonNullIndex = i;
                    break;
                }
            }
            if (firstNonNullIndex == -1)
                throw new Exception("Không có sinh viên hợp lệ trong danh sách");

            double max = students[firstNonNullIndex]!.Score;
            for (int i = firstNonNullIndex + 1; i < count; i++)
                if (students[i] != null && students[i]!.Score > max)
                    max = students[i]!.Score;
            return max;
        }

        public Student? FindStudentById(string id)
        {
            for (int i = 0; i < count; i++)
                if (students[i] != null && students[i]!.StudentId == id)
                    return students[i]!;
            return null;
        }

        public void DisplayAllStudents()
        {
            if (count == 0)
            {
                Console.WriteLine("Danh sách trống");
                return;
            }

            for (int i = 0; i < count; i++)
                if (students[i] != null)
                    students[i]!.Display();
        }
    }
}
