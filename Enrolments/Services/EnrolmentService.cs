using stefan_academy_vanilla_charp.Enrolments.Dtos;
using stefan_academy_vanilla_charp.Enrolments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stefan_academy_vanilla_charp.Enrolments.Services
{
    public class EnrolmentService
    {
        private readonly List<Enrolment> enrolments = new List<Enrolment>();

        //Mappers

        public Enrolment EnrolmentCreateRequestToEnrolment(EnrolmentCreateRequest request)
        {
            return new Enrolment(request.StudentId, request.CourseId, request.CreatedAt);
        }

        public EnrolmentCreateResponse EnrolmentToEnrolmentCreateResponse(Enrolment enrolment)
        {
            return new EnrolmentCreateResponse
            {
                StudentId = enrolment.StudentId,
                CourseId = enrolment.CourseId,
                CreatedAt = enrolment.CreatedAt
            };
        }

        public Enrolment EnrolmentUpdateRequestToEnrolment(EnrolmentUpdateRequest request)
        {
            return new Enrolment(request.StudentId, request.CourseId, request.CreatedAt);
        }

        public EnrolmentUpdateResponse EnrolmentToEnrolmentUpdateRespone(Enrolment enrolment)
        {
            return new EnrolmentUpdateResponse
            {
                StudentId = enrolment.StudentId,
                CourseId = enrolment.CourseId,
                CreatedAt = enrolment.CreatedAt
            };
        }

        //Crud

        public List<Enrolment> Enrolments
        {
            get { return enrolments; }
        }

        public void AfisareEnrolments()
        {
            foreach(Enrolment e in enrolments){
                Console.WriteLine("StudentId: " + e.StudentId + ", CourseId: " + e.CourseId + ", Created at: " + e.CreatedAt.ToString("yyyy-MM-dd"));
            }
        }

        public EnrolmentCreateResponse CreateEnrolment(EnrolmentCreateRequest request)
        {
            if (enrolments.Count + 1 >= enrolments.Capacity)
            {
                throw new ArgumentException("Baza de date este plina");
            }

            Enrolment newEnrolment = EnrolmentCreateRequestToEnrolment(request);
            enrolments.Add(newEnrolment);

            return EnrolmentToEnrolmentCreateResponse(newEnrolment);
        }

        //public EnrolmentUpdateResponse UpdateEnrolment(EnrolmentUpdateRequest request)
        //{
        //}

        public void DeleteEnrolment() { }
    }
}
