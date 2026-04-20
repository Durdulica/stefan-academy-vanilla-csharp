using stefan_academy_vanilla_charp.Students.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Students.Models
{
    public class StudentService
    {
        private readonly List<Student> students = new List<Student>();

        public StudentService()
        {
            ReadStudents();
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
            for (int i = 0; i < students.Count; i++)
            {
                if (id.CompareTo(students[i].Id) == 0)
                {
                    students.RemoveAt(i);
                    return;
                }
            }
        }

        private void ReadStudents()
        {
            string path = Path.Combine("..","..","..","Data","students.txt");

            using (var reader = new StreamReader(path))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null) { 
                    students.Add(new Student(line));
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
                    list += students[i].Id + "," + students[i].FirstName + "," + students[i].LastName + "," + students[i].Email + "," + students[i].Age;
                }
                else
                {
                    list += students[i].Id + "," + students[i].FirstName + "," + students[i].LastName + "," + students[i].Email + "," + students[i].Age + "\n";
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
