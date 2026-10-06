using stefan_academy_vanilla_charp.Common.Exceptions;
using stefan_academy_vanilla_charp.Courses.Models;
using stefan_academy_vanilla_charp.Enrolments.Dtos;
using stefan_academy_vanilla_charp.Enrolments.Mappers;
using stefan_academy_vanilla_charp.Enrolments.Models;
using stefan_academy_vanilla_charp.Enrolments.Repositories;

namespace stefan_academy_vanilla_charp.Enrolments.Services
{
    public class EnrolmentService
    {
        private readonly EnrolmentRepository repository;

        public EnrolmentService(EnrolmentRepository repository)
        {
            this.repository = repository;
        }

        public List<Guid> GetEnrolmentIdByStudentId(Guid studentId)
        {
            return repository.GetCourseIdListByStudentId(studentId);
        }

        public Enrolment GetEnrolment(Guid id)
        {
            return repository.FindById(id);
        }

        public Guid GetEnrolmentIdByStudentAndCourseId(Guid studentId, Guid courseId)
        {
            return repository.GetEnrolmentIdByStudentAndCourseId(studentId, courseId);
        }

        public List<Guid> GetCourseIdListByStudentId(Guid studentId)
        {
            return repository.GetCourseIdListByStudentId(studentId);
        }

        public int GetStudentsCountForCourseId(Guid courseId)
        {
            return repository.StudentsCountForCourseId(courseId);
        }

        public EnrolmentCreateResponse CreateEnrolment(EnrolmentCreateRequest request)
        {
            Enrolment newEnrolment = EnrolmentMapper.ToEnrolment(request);
            
            if (repository.GetEnrolmentIdByStudentAndCourseId(newEnrolment.StudentId, newEnrolment.CourseId) != Guid.Empty)
            {
                throw new DuplicateException("Enrolmentul", "id student " + newEnrolment.StudentId + " id curs " + newEnrolment.CourseId);
            }

            repository.Add(newEnrolment);

            return EnrolmentMapper.ToCreateResponse(newEnrolment);
        }

        public EnrolmentUpdateResponse UpdateEnrolment(Guid id, EnrolmentUpdateRequest request)
        {
            Enrolment enrolment = repository.FindById(id);

            if (enrolment == null) {
                throw new NotFoundException("Enrolmentul", id.ToString());
            }

            EnrolmentMapper.ApplyUpdate(enrolment, request);
            repository.Update(enrolment);
            return EnrolmentMapper.ToUpdateResponse(enrolment);
        }

        public void DeleteEnrolment(Guid id)
        {
            Enrolment enrolment = repository.FindById(id);

            if (enrolment == null) 
            {
                throw new NotFoundException("Enrolmentul", id.ToString());
            }

            repository.Remove(enrolment);
        }        
    }
}
