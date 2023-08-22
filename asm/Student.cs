using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams4.ams4
{
    public class Student
    {
        private static readonly object students;

        public int Id { get; set; }
        public object ID { get; internal set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public double MathScore { get; set; }
        public double PhysicsScore { get; set; }
        public double ChemistryScore { get; set; }
        public double AverageScore => (MathScore + PhysicsScore + ChemistryScore) / 3;
        public string AcademicPerformance
        {
            get
            {
                if (AverageScore >= 8)
                    return "Giỏi";
                else if (AverageScore >= 6.5)
                    return "Khá";
                else if (AverageScore >= 5)
                    return "Trung Bình";
                else
                    return "Yếu";
            }
        }
    }

    class Program
    {
        static List<Student> students = new List<Student>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("===== Quản Lý Sinh Viên =====");
                Console.WriteLine("1. Thêm sinh viên.");
                Console.WriteLine("2. Cập nhật thông tin sinh viên bởi ID.");
                Console.WriteLine("3. Xóa sinh viên bởi ID.");
                Console.WriteLine("4. Tìm kiếm sinh viên theo tên.");
                Console.WriteLine("5. Sắp xếp sinh viên theo điểm trung bình (GPA).");
                Console.WriteLine("6. Sắp xếp sinh viên theo tên.");
                Console.WriteLine("7. Sắp xếp sinh viên theo ID.");
                Console.WriteLine("8. Hiển thị danh sách sinh viên.");
                Console.WriteLine("0. Thoát.");
                Console.Write("Chọn chức năng: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent();
                        break;
                    case 2:
                        UpdateStudent();
                        break;
                    case 3:
                        DeleteStudent();
                        break;
                    case 4:
                        SearchByName();
                        break;
                    case 5:
                        SortByGPA();
                        break;
                    case 6:
                        SortByName();
                        break;
                    case 7:
                        SortById();
                        break;
                    case 8:
                        DisplayStudents();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
            }
        }

        static void AddStudent()
        {
            // Nhập thông tin sinh viên từ người dùng
            Student student = new Student();
            Console.Write("Nhập tên sinh viên: ");
            student.Name = Console.ReadLine();
            Console.Write("Nhập giới tính: ");
            student.Gender = Console.ReadLine();
            Console.Write("Nhập tuổi: ");
            student.Age = int.Parse(Console.ReadLine());
            Console.Write("Nhập điểm toán: ");
            student.MathScore = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm lý: ");
            student.PhysicsScore = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm hóa: ");
            student.ChemistryScore = double.Parse(Console.ReadLine());
            student.Id = students.Count + 1;

            students.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        static void UpdateStudent()
        {
            Console.Write("Nhập ID của sinh viên cần cập nhật: ");
            int id = int.Parse(Console.ReadLine());

            Student student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên với ID đã cho.");
                return;
            }

            Console.WriteLine("Thông tin sinh viên cần cập nhật:");
            Console.WriteLine($"Tên: {student.Name}, Giới tính: {student.Gender}, Tuổi: {student.Age}");
            Console.WriteLine($"Điểm toán: {student.MathScore}, Điểm lý: {student.PhysicsScore}, Điểm hóa: {student.ChemistryScore}");

            Console.Write("Nhập tên mới: ");
            student.Name = Console.ReadLine();
            Console.Write("Nhập giới tính mới: ");
            student.Gender = Console.ReadLine();
            Console.Write("Nhập tuổi mới: ");
            student.Age = int.Parse(Console.ReadLine());
            Console.Write("Nhập điểm toán mới: ");
            student.MathScore = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm lý mới: ");
            student.PhysicsScore = double.Parse(Console.ReadLine());
            Console.Write("Nhập điểm hóa mới: ");
            student.ChemistryScore = double.Parse(Console.ReadLine());

            Console.WriteLine("Cập nhật thông tin thành công!");
        }

        static void DeleteStudent()
        {
            Console.Write("Nhập ID của sinh viên cần xóa: ");
            int id = int.Parse(Console.ReadLine());

            Student student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên với ID đã cho.");
                return;
            }

            students.Remove(student);
            Console.WriteLine("Xóa sinh viên thành công!");
        }

        static void SearchByName()
        {
            Console.Write("Nhập tên sinh viên cần tìm: ");
            string name = Console.ReadLine();

            List<Student> searchResults = students.Where(s => s.Name.ToLower().Contains(name.ToLower())).ToList();

            if (searchResults.Count == 0)
            {
                Console.WriteLine("Không tìm thấy sinh viên với tên đã cho.");
                return;
            }

            Console.WriteLine("Kết quả tìm kiếm:");
            DisplayStudentList(searchResults);
        }

        static void SortByGPA()
        {
            List<Student> sortedList = students.OrderByDescending(s => s.AverageScore).ToList();
            Console.WriteLine("Danh sách sinh viên đã được sắp xếp theo điểm trung bình:");
            DisplayStudentList(sortedList);
        }

        static void SortByName()
        {
            List<Student> sortedList = students.OrderBy(s => s.Name).ToList();
            Console.WriteLine("Danh sách sinh viên đã được sắp xếp theo tên:");
            DisplayStudentList(sortedList);
        }

        static void SortById()
        {
            List<Student> sortedList = students.OrderBy(s => s.Id).ToList();
            Console.WriteLine("Danh sách sinh viên đã được sắp xếp theo ID:");
            DisplayStudentList(sortedList);
        }

        static void DisplayStudents()
        {
            Console.WriteLine("Danh sách sinh viên:");
            DisplayStudentList(students);
        }

        static void DisplayStudentList(List<Student> studentList)
        {
            foreach (var student in studentList)
            {
                Console.WriteLine($"ID: {student.ID}, Tên: {student.Name}, Tuổi: {student.Age}, Điểm Trung bình: {student.AverageScore}, Học lực: {student.AcademicPerformance}");
            }
        }
    }
}