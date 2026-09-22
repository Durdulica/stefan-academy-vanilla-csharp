using stefan_academy_vanilla_charp.Common;
using stefan_academy_vanilla_charp.Enrolments.Mappers;
using stefan_academy_vanilla_charp.Enrolments.Models;

namespace stefan_academy_vanilla_charp.Enrolments.Repositories
{
    public class EnrolmentRepository : Repository<Enrolment>
    {
        public EnrolmentRepository() : base(new EnrolmentTextMapper(), Path.Combine("..", "..", "..", "Data", "enrolments.txt")) { }

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

        public int StudentsCountForCourseId(Guid courseId)
        {
            int index = 0;
            foreach (Enrolment enr in Items)
            {
                if (enr.CourseId == courseId)
                {
                    index++;
                }
            }

            return index;
        }
    }
}