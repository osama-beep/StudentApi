using System;

namespace StudentApi.DTOs
{
    public class StudentProfileDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FiscalCode { get; set; }
        public DateTime BirthDate { get; set; }
        public int StudentId { get; set; }
    }

    public class CreateStudentProfileDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FiscalCode { get; set; }
        public DateTime BirthDate { get; set; }
        public int StudentId { get; set; }
    }
}