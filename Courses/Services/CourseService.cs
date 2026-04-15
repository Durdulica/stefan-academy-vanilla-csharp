using stefan_academy_vanilla_charp.Courses.Dtos;
using stefan_academy_vanilla_charp.Courses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Courses.Services
{
    public class CourseService
    {
        private readonly List<Course> courses = new List<Course>();

        public CourseService()
        {
            ReadCourses();
        }

        //Finders

        Course FindById(Guid id)
        {
            foreach (Course c in courses)
            {
                if (id.CompareTo(c.Id) == 0)
                {
                    return c;
                }
            }
            return null;
        }

        //Mappers

        public Course CourseCreateRequestToCourse(CourseCreateRequest request)
        {
            return new Course(request.Name, request.Department);
        }

        public CourseCreateResponse CourseToCourseCreateResponse(Course course)
        {
            return new CourseCreateResponse
            {
                Name = course.Name,
                Department = course.Department,
            };
        }

        public Course CourseUpdateRequestToCourse(CourseUpdateRequest request)
        {
            return new Course(request.Name, request.Department);
        }

        public CourseUpdateResponse CourseToCourseUpdateResponse(Course course)
        {
            return new CourseUpdateResponse
            {
                Name = course.Name,
                Department = course.Department,
            };
        }

        //Afisare

        public void AfisareCourses()
        {
            foreach (Course c in courses)
            {
                Console.WriteLine("nume: " + c.Name + ", departament: " + c.Department);
            }
        }

        //CRUD

        public List<Course> Courses
        {
            get { return courses; }
        }

        public CourseCreateResponse CreateCourse(CourseCreateRequest request)
        {
            Course newCourse = CourseCreateRequestToCourse(request);

            if (FindById(newCourse.Id) != null)
            {
                throw new ArgumentException("Cursul se afla deja in baza de date");
            }
            courses.Add(newCourse);

            return CourseToCourseCreateResponse(newCourse);
        }

        public CourseUpdateResponse UpdateCourse(Guid id, CourseUpdateRequest request)
        {
            Course course = FindById(id);
            if (course == null)
            {
                throw new ArgumentException("Cursul nu exista in baza de date");
            }

            course.Name = request.Name;
            course.Department = request.Department;

            return CourseToCourseUpdateResponse(course);
        }

        public void DeleteCourse(Guid id)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (id.CompareTo(courses[i].Id) == 0)
                {
                    courses.RemoveAt(i);
                    return;
                }
            }
        }

        public void ReadCourses()
        {
            string path = Path.Combine("..", "..", "..", "Data", "courses.txt");

            using (var reader = new StreamReader(path))
            {
                string list = "";
                while ((list = reader.ReadLine()) != null)
                {
                    courses.Add(new Course(list));
                }
            };
        }

        public string CoursesListToString()
        {
            string list = "";
            for(int i = 0; i < courses.Count; i++)
            {
                if (i + 1 == courses.Count)
                {
                    list += courses[i].Name + "," + courses[i].Department;
                }
                else
                {
                    list += courses[i].Name + "," + courses[i].Department + ",\n";
                }
            }
            return list;
        }

        public void Save()
        {
            string path = Path.Combine("..", "..", "..", "Data", "courses.txt");
            using (StreamWriter writer = new StreamWriter(path))
            {
                string list = CoursesListToString();
                writer.Write(list);
            }
        }
    }
}
