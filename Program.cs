using System;

namespace StudentManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentManager manager = new StudentManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n========== MENU ==========");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Xóa sinh viên");
                Console.WriteLine("3. Cap nhat điem");
                Console.WriteLine("4. In danh sách");
                Console.WriteLine("5. Tính điem trung bình");
                Console.WriteLine("6. Tìm điem cao nhat");
                Console.WriteLine("7. Tìm sinh viên");
                Console.WriteLine("0. Thoát");
                Console.WriteLine("========================");

                Console.Write("Chon chuc nang: ");
                string choice = Console.ReadLine() ?? string.Empty;

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("ID: ");
                            string? idInput = Console.ReadLine();
                            string id = idInput ?? string.Empty;    
                            Console.Write("Tên: ");
                            string? nameInput = Console.ReadLine();
                            string name = nameInput ?? string.Empty;
                            Console.Write("Điem: ");
                            string? scoreInput = Console.ReadLine();
                            double score;
                            if (!double.TryParse(scoreInput, out score))
                            {
                                Console.WriteLine("Điem khong hop le. Vui long nhap so.");
                                break;
                            }
                            manager.AddStudent(id, name, score);
                            break;

                        case "2":
                            Console.Write("Nhap ID can xoa: ");
                            manager.RemoveStudent(Console.ReadLine() ?? string.Empty);
                            break;

                        case "3":
                            Console.Write("ID: ");
                            string? uidInput = Console.ReadLine();
                            string uid = uidInput ?? string.Empty;
                            Console.Write("Điem moi: ");
                            string? newScoreInput = Console.ReadLine();
                            double newScore;
                            if (!double.TryParse(newScoreInput, out newScore))
                            {
                                Console.WriteLine("Điem không hop lệ. Vui long nhap so.");
                                break;
                            }
                            manager.UpdateScore(uid, newScore);
                            break;

                        case "4":
                            manager.DisplayAllStudents();
                            break;

                        case "5":
                            Console.WriteLine("Điem trung binh: " + manager.GetAverageScore());
                            break;

                        case "6":
                            Console.WriteLine("Điem cao nhat: " + manager.GetMaxScore());
                            break;

                        case "7":
                            Console.Write("Nhap ID: ");
                            string? findIdInput = Console.ReadLine();
                            string findId = findIdInput ?? string.Empty;
                            Student? st = manager.FindStudentById(findId);
                            if (st != null) st.Display();
                            else Console.WriteLine("Khong tim thay sinh vien");
                            break;

                        case "0":
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Lua chon khong hop le");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Loi: " + ex.Message);
                }
            }
        }
    }
}
