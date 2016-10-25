using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    class StudentViewModel
    {
        public Guid Id { get; set; }
        public string RM { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        List<Student> Students
        {
            get
            {
                return new List<Student>()
                {
                    new Student() { Id = Guid.NewGuid(), Name = "Test", RM = "0121", Email = "a@a.com" },
                    new Student() { Id = Guid.NewGuid(), Name = "LOL", RM = "2222", Email = "b@b.com" },
                };
            }
        }

        public StudentViewModel()
        {
        }

        public StudentViewModel(Student student)
        {
            this.RM = student.RM;
            this.Name = student.Name;
            this.Email = student.Email;
        }

        public static Student GetStudent()
        {
            var student = new Student()
            {
                Id = Guid.NewGuid(),
                RM = "542621",
                Name = "Anderson Silva",
                Email = "anderson@ufc.com"
            };

            return student;
        }
    }
}
