using Demo3.Dto;

namespace Demo3.Entities
{
    public class Student : CreateStudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StudentCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Avatar { get; set; }// lay duong dan luu vao truong sinh vien
    }

}
