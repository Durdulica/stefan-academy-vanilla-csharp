using stefan_academy_vanilla_charp.Common.Exceptions;
using stefan_academy_vanilla_charp.Enrolments.Dtos;
using stefan_academy_vanilla_charp.Enrolments.Mappers;
using stefan_academy_vanilla_charp.Enrolments.Models;
using stefan_academy_vanilla_charp.Enrolments.Repositories;

namespace stefan_academy_vanilla_charp.Enrolments.Services.Command
{
    public class EnrolmentCommandService : IEnrolmentCommandService
    {
        private readonly IEnrolmentRepository repository;

        public EnrolmentCommandService(IEnrolmentRepository repository)
        {
            this.repository = repository;
        }

        public EnrolmentCreateResponse CreateEnrolment(EnrolmentCreateRequest request)
        {
            Enrolment newEnrolment = EnrolmentMapper.ToEnrolment(request);
            
            if (repository.EnrolmentIdByStudentAndCourseId(newEnrolment.StudentId, newEnrolment.CourseId) != Guid.Empty)
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
