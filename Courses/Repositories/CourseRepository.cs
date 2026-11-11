using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Courses.Mappers;
using stefan_academy_vanilla_charp.Courses.Models;

namespace stefan_academy_vanilla_charp.Courses.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private static CourseRepository instance;

        public static CourseRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CourseRepository();
                }
                return instance;
            }
        }

        private CourseRepository() : base(new CourseTextMapper(), Path.Combine("..", "..", "..", "Data", "courses.txt")) { }

        public List<Course> Courses() => Items;

        public List<Course> GetCourseListByCourseId(List<Guid> coursesId) => Items.Where(c => coursesId.Contains(c.Id)).ToList();

        public Course FindByName(string name) => Items.FirstOrDefault(c => c.Name == name);

        public SortedDictionary<string, List<Course>> CoursesByDepartment() => new SortedDictionary<string,
            List<Course>>(Items.GroupBy(c => c.Department).ToDictionary(x => x.Key, x => x.ToList()));
    }
}
