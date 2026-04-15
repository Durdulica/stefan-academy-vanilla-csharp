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
        private readonly List<Student> students;

        public StudentService()
        {
            students = new List<Student>
            {
                new Student("Stefan","Scarlat","stefanel.scarlat@gmail.com", 18),
                new Student("Alex","Bordei","alex.bordei@yahoo.com", 27),
                new Student("Stefan","Ognean","ogn@hotmail.com",61),
                new Student("Daniel","Popescu","123@gmail.com", 23)
            };
            students.Capacity = 10;
        }

        //Finders

        public Student FindById(Guid id)
        {
            foreach (Student s in students) { 
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

        //Afisare

        public void AfisareStudenti()
        {
            foreach (Student s in students)
            {
                Console.WriteLine(s.FirstName + " " + s.LastName + ", email: " + s.Email + ", varsta: " + s.Age);
            }
        }

        //CRUD

        public List<Student> Studenti
        {
            get { return students; }
        }

        public StudentCreateResponse CreateStudent(StudentCreateRequest request)
        {
            if (students.Count + 1 > students.Capacity)
            {
                throw new ArgumentException("Baza de date plina");
            }

            Student newStudent = StudentCreateRequestToStudent(request);
            if (FindById(newStudent.Id) != null)
            {
                throw new ArgumentException("Studentul se afla deja in baza de date");
            }
            students.Add(newStudent);

            return StudentToStudentCreateResponse(newStudent);
        }

        public StudentUpdateResponse UpdateStudent(Guid id, StudentUpdateRequest request)
        {
            Student student = FindById(id);
            if (student == null)
            {
                throw new ArgumentException("Studentul nu exista in baza de date");
            }

            student.FirstName = request.FirstName;
            student.LastName = request.LastName;
            student.Email = request.Email;
            student.Age = request.Age;

            return StudentToStudentUpdateResponse(student);
        }

        public void DeleteStudent(Guid id)
        {
            for (int i = 0; i < students.Count; i++) {
                if (id.CompareTo(students[i].Id) == 0) { 
                    students.RemoveAt(i);
                    return;
                }
            }
        }

        public void ReadStudents()
        {
            string path = Path.Combine("..","..","..","Data","students.txt");

            using (var reader = new StreamReader(path))
            {
                string list = "";
                while ((list = reader.ReadLine()) != null) { 
                    students.Add(new Student(list));
                }
            };
        }

        public string StudentListToString()
        {
            string list = "";
            for (int i = 0; i < students.Count; i++)
            {
                if (i + 1 == students.Count)
                {
                    list += students[i].FirstName + "," + students[i].LastName + "," + students[i].Email + "," + students[i].Age;
                }
                else
                {
                    list += students[i].FirstName + "," + students[i].LastName + "," + students[i].Email + "," + students[i].Age + ",\n";
                }
            }
            return list;
        }

        public void Save()
        {
            string path = Path.Combine("..", "..", "..", "Data", "students.txt");
            using (var writer = new StreamWriter(path))
            {
                string list = StudentListToString();
                writer.Write(list);
            }
        }
    }
}
