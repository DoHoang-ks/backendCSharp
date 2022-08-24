using Demo3.Dto;
using Demo3.Entities;
using Demo3.Controllers;

namespace Demo3.Services
{
    public class StudentService : IStudentService
    {
        private static int Id = 0;
        private static List<Student> _students = new();
        private readonly ILogger _logger;

        public StudentService(ILogger<StudentService> logger)
        {
            _logger = logger;
            _logger.LogInformation("vào đây");
        }

        //thêm
        public void CreateStudent(CreateStudentDto input)
        {
            _students.Add(new Student
            {
                Id = ++StudentService.Id,
                Name = input.Name,
                StudentCode = input.Msv,
                DateOfBirth = input.DateOfBirth
            });
        }
        public List<Student> GetAllStudent(StudentFilterDto input)
        {
            var students = _students;
            if (input.KeyWord != null)
            {
                students = _students
                //Kiem tra neu Name khac null, neu Name co chua ky tu trong keyword
                .Where(s => s.Name != null && s.Name.Contains(input.KeyWord))
                .ToList();
            }

            //chia trang 
            students =students
                .Skip(input.PageSize *(input.PageIndex - 1))
                .Take(input.PageSize)
                .ToList();
            return students;
        }

        //

        //sửa

        public object UpdateStudent(UpdateStudentDto input)
        {
            var studentfind = _students.Find(x => x.Id == input._id);
            if (studentfind != null)
            {
                studentfind.StudentCode = input.Msv;
                studentfind.DateOfBirth = input.DateOfBirth;
                studentfind.Name = input.Name;
            }
            return studentfind;
        }

        //Xóa
        public void DeleteById(int id)
        {
            var studentfind = _students.FirstOrDefault(x => x.Id == id);
            _students.Remove(studentfind);
        }
        public List<Student> GetAll()
        {
            return _students;
        }

         //xem chi tiết
        public object GetById(int Id)
        {
            var studentfind = _students.Find(x => x.Id == Id);
            return studentfind;
        }



       
    }
}
