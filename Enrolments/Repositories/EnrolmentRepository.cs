using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Enrolments.Mappers;
using stefan_academy_vanilla_charp.Enrolments.Models;

namespace stefan_academy_vanilla_charp.Enrolments.Repositories
{
    public class EnrolmentRepository : Repository<Enrolment>, IEnrolmentRepository
    {
        private static EnrolmentRepository instance;
        
        public static EnrolmentRepository Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new EnrolmentRepository();
                }

                return instance;
            }
        }

        private EnrolmentRepository() : base(new EnrolmentTextMapper(), Path.Combine("..", "..", "..", "Data", "enrolments.txt")) { }

        public List<Guid> EnrolmentIdByStudentId(Guid studentId)
        {
            return Items.Where(e => e.StudentId == studentId)
                .Select(e => e.Id).ToList();
        }

        public Guid EnrolmentIdByStudentAndCourseId(Guid studentId, Guid courseId)
        {
            return Items.Where(e => e.CourseId == courseId && e.StudentId == studentId)
                .Select(e => e.Id).FirstOrDefault();              
        }

        public List<Guid> CourseIdByStudentId(Guid studentId)
        {
            return Items.Where(e => e.StudentId == studentId)
                .Select (e => e.CourseId).ToList();
        }

        public Dictionary<Guid, int> StudentsCountPerCourse() => Items.GroupBy(e => e.CourseId).ToDictionary(g => g.Key, g => g.Count());

        public HashSet<Guid> CourseIdsForStudent(Guid studentId) => Items.Where(e => e.StudentId == studentId).Select(e => e.CourseId).ToHashSet();

        public HashSet<Guid> StudentIdsForCourse(Guid courseId)
        {
            HashSet<Guid> l = new();
            foreach(Enrolment enr in Items)
            {
                if (enr.CourseId.Equals(courseId)) 
                {
                    l.Add(enr.StudentId);
                }
            }

            return l;
        }
    }
}
