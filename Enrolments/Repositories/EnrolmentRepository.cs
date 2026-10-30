using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Enrolments.Mappers;
using stefan_academy_vanilla_charp.Enrolments.Models;

namespace stefan_academy_vanilla_charp.Enrolments.Repositories
{
    public class EnrolmentRepository : Repository<Enrolment>
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

        public List<Guid> GetEnrolmentIdByStudentId(Guid studentId)
        {
            List<Guid> studentEnrolments = new();
            studentEnrolments.Capacity = Items.Count;

            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].StudentId == studentId)
                {
                    studentEnrolments.Add(Items[i].Id);
                }
            }

            return studentEnrolments;
        }

        public Guid GetEnrolmentIdByStudentAndCourseId(Guid studentId, Guid courseId)
        {
            foreach (Enrolment enr in Items)
            {
                if (enr.StudentId == studentId && enr.CourseId == courseId)
                {
                    return enr.Id;
                }
            }
            return Guid.Empty;
        }

        public List<Guid> GetCourseIdListByStudentId(Guid studentId)
        {
            List<Guid> courses = new();

            foreach (Enrolment enr in Items)
            {
                if (enr.StudentId == studentId)
                {
                    courses.Add(enr.CourseId);
                }
            }

            return courses;
        }

        public Dictionary<Guid, int> StudentsCountPerCourse()
        {
            Dictionary<Guid, int> d = new Dictionary<Guid, int>();
            foreach (Enrolment enr in Items)
            {
                if(d.TryGetValue(enr.CourseId, out int count))
                {
                    d[enr.CourseId] = count++;
                }
                else
                {
                    d.Add(enr.CourseId, 1);
                }
            }
            return d;
        }

        public HashSet<Guid> CourseIdsForStudent(Guid studentId)
        {
            HashSet<Guid> h = new HashSet<Guid>();
            foreach (Enrolment enr in Items)
            {
                
                if (!Guid.Equals(enr.StudentId, studentId))
                {
                    h.Add(enr.CourseId);
                }
            }
            return h;
        }
    }
}
