using stefan_academy_vanilla_charp.Student.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Student.Models
{
    public class StudentService
    {
        private readonly List<Student> studenti;

        public StudentService()
        {
            studenti = new List<Student>
            {
                new Student("Stefan","Scarlat","stefanel.scarlat@gmail.com", 18),
                new Student("Alex","Bordei","alex.bordei@yahoo.com", 27),
                new Student("Stefan","Ognean","ogn@hotmail.com",61),
                new Student("Daniel","Popescu","123@gmail.com", 23)
            };
        }

        //Finders

        public Student FindById(Guid id)
        {
            foreach (Student s in studenti) { 
                if(s.Id.CompareTo(id) == 0)
                {
                    return s;
                }
            }
            return null; 
        }

        //Mappers
        private Student StudentCreateRequestToStudent(StudentCreateRequest request)
        {
            return new Student(request.FirstName, request.LastName, request.Email, request.Age);
        }

        private StudentCreateResponse StudentToStudentCreateResponse(Student student)
        {
            return new StudentCreateResponse()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Age = student.Age

            };
        }

        private Student StudentUpdateRequestToStudent(StudentUpdateRequest request)
        {
            return new Student(request.FirstName,request.LastName,request.Email, request.Age);
        }

        private StudentUpdateResponse StudentToStudentUpdateResponse(Student student)
        {
            return new StudentUpdateResponse()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                Age = student.Age
            };
        }

        public StudentCreateResponse AdaugareStudent(StudentCreateRequest request)
        {
            if (studenti.Count + 1 > studenti.Capacity)
            {
                throw new ArgumentException("Baza de date plina");
            }

            Student newStudent = StudentCreateRequestToStudent(request);
            if (FindById(newStudent.Id) != null)
            {
                throw new ArgumentException("Studentul se afla deja in baza de date");
            }
            studenti.Add(newStudent);

            return StudentToStudentCreateResponse(newStudent);
        }
    }
}
