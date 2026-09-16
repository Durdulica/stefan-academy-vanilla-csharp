using stefan_academy_vanilla_charp.Courses.Dtos;
using stefan_academy_vanilla_charp.Courses.Mappers;
using stefan_academy_vanilla_charp.Courses.Models;
using stefan_academy_vanilla_charp.Courses.Repositories;

namespace stefan_academy_vanilla_charp.Courses.Services
{
    public class CourseService
    {
        private readonly CourseRepository repository;

        public CourseService(CourseRepository repository)
        {
            this.repository = repository;
        }

        //Afisare

        //public void AfisareCourses()
        //{
        //    foreach (Course c in courses)
        //    {
        //        Console.WriteLine("nume: " + c.Name + ", departament: " + c.Department);
        //    }
        //}

        //CRUD

        public List<Course> GetCourses()
        {
            return repository.Courses();
        }

        public Course GetByName(string name)
        {
            return repository.FindByName(name);
        }

        public List<Course> GetCourseListByCourseId(List<Guid> coursesId)
        {
            return repository.GetCourseListByCourseId(coursesId);
        }

        public CourseCreateResponse CreateCourse(CourseCreateRequest request)
        {
            Course newCourse = CourseMapper.ToCourse(request);

            if (repository.FindById(newCourse.Id) != null)
            {
                throw new ArgumentException("Cursul se afla deja in baza de date");
            }

            repository.Add(newCourse);

            return CourseMapper.ToCreateResponse(newCourse);
        }

        public CourseUpdateResponse UpdateCourse(Guid id, CourseUpdateRequest request)
        {
            Course course = repository.FindById(id);
            if (course == null)
            {
                throw new ArgumentException("Cursul nu exista in baza de date");
            }

            CourseMapper.ApplyUpdate(course, request);

            return CourseMapper.ToUpdateResponse(course);
        }

        public void DeleteCourse(Guid id)
        {
            Course course = repository.FindById(id);

            if (course == null)
            {
                throw new ArgumentException("Cursul nu exista in baza de date");
            }

            repository.Remove(course);
        }
    }
}