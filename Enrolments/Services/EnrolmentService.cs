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

        public EnrolmentService()
        {
            ReadEnrolments();
        }

        //Finders

        public Enrolment FindById(Guid id)
        {
            foreach (Enrolment enr in enrolments)
            {
                if (enr.Id == id) return enr;
            }
            return null;
        }

        public List<Guid> GetEnrolmentIdByStudentId(Guid studentId)
        {
            List<Guid> studentEnrolments = new List<Guid>();
            studentEnrolments.Capacity = enrolments.Count;

            for (int i = 0; i < enrolments.Count; i++)
            {
                if(enrolments[i].StudentId == studentId)
                {
                    studentEnrolments.Add(enrolments[i].Id);
                }
            }

            return studentEnrolments;
        }

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
            Enrolment newEnrolment = EnrolmentCreateRequestToEnrolment(request);
            if(FindById(newEnrolment.Id) != null)
            {
                throw new ArgumentException("Enrolmentul se afla deja in baza de date");
            }
            enrolments.Add(newEnrolment);

            return EnrolmentToEnrolmentCreateResponse(newEnrolment);
        }

        public EnrolmentUpdateResponse UpdateEnrolment(Guid id,EnrolmentUpdateRequest request)
        {
            Enrolment enrolment = FindById(id);
            if (enrolment == null) {
                throw new ArgumentException("Enrolmentul nu se afla in baza de date");
            }

            enrolment.StudentId = request.StudentId;
            enrolment.CourseId = request.CourseId;
            enrolment.CreatedAt = request.CreatedAt;

            return EnrolmentToEnrolmentUpdateRespone(enrolment);
        }

        public void DeleteEnrolment(Guid id)
        {
            for(int i = 0; i < enrolments.Count; i++)
            {
                if(enrolments[i].Id == id)
                {
                    enrolments.RemoveAt(i);
                    return;
                }
            }
        }

        public void ReadEnrolments()
        {
            string path = Path.Combine("..", "..", "..", "Data", "enrolments.txt");
            using (var reader = new StreamReader(path))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    enrolments.Add(new Enrolment(line));
                }
            }
        }

        public string EnrolmentsListToString()
        {
            string list = "";
            for(int i = 0; i < enrolments.Count; i++)
            {
                if(i + 1 == enrolments.Count)
                {
                   list+=enrolments[i].Id+","+enrolments[i].StudentId+","+enrolments[i].CourseId+","+enrolments[i].CreatedAt.ToString("yyyy-MM-dd");
                }
                else
                {
                   list += enrolments[i].Id+","+enrolments[i].StudentId+","+enrolments[i].CourseId+","+enrolments[i].CreatedAt.ToString("yyyy-MM-dd")+"\n";
                }
            }
            return list;
        }

        public void Save()
        {
            string path = Path.Combine("..", "..", "..", "Data", "enrolments.txt");
            using (var writer = new StreamWriter(path))
            {
                string list = EnrolmentsListToString();
                writer.Write(list);
            }
        }
    }
}
