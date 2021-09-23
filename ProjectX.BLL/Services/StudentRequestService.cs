using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectX.BLL.Enums;
using ProjectX.BLL.Interfaces;
using ProjectX.BLL.Models;
using ProjectX.DAL.Interfaces;

namespace ProjectX.BLL.Services
{
    public class StudentRequestService : EntityService<StudentRequest>, IStudentRequestService
    {
        private IStudentService _studentService;
        private IGroupService _groupService;
        

        public StudentRequestService(IRepository<StudentRequest> repository, IStudentService studentService, IGroupService groupService) : base(repository)
        {
            _studentService = studentService;
            _groupService = groupService;
        }

        public void AssignRequestToGroups(IEnumerable<StudentRequest> requests, int groupId)
        {

            foreach (var request in requests)
            {
                //create Student
                var student = new Student()
                {
                    FirstName = request.FirstName, LastName = request.LastName,
                    Email = request.Email, Phone = request.Phone, Type = request.Type, GroupId = groupId
                };
                _studentService.Create(student);
                _repository.Delete(request.Id);
            }
        }
    }
}
