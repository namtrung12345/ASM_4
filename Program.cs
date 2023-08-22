using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM4
{
    internal class Program
    {
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
    }
}
