using Demo3.Dto;
using Demo3.Entities;

namespace Demo3.Services
{
    public interface IStudentService
    {
        void CreateStudent(CreateStudentDto input);
        void DeleteById(int id);
        List<Student> GetAll();
        object GetById(int Id);
        object UpdateStudent(UpdateStudentDto input);





    }
}
