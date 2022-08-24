namespace Demo3.Dto
{
    public class CreateStudentDto
    {
        private string _name;
        private string _msv;
        private DateTime _dateofbirth;

        public string Name
        {
            get { return _name; }
            set { _name = value?.Trim(); }
        }
        public string Msv
        {
            get { return _msv; }
            set
            {
                _msv = value?.Trim();
            }
        }
        public DateTime DateOfBirth
        {
            get { return _dateofbirth; }
            set { _dateofbirth = value; }
        }
        public IFormFile Avatar { get; set; } //lấy file.
}
}
