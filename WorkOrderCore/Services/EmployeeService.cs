using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrderCore.Infrastructure.Persistence.DataContext;
using WorkOrderCore.Model;

namespace WorkOrderCore.Services
{
    public interface IEmployeeService
    {
        Task<UserDetailsViewModel> GetEmployeeDetails(string EmailId);
        Task<short> GetEmployeeType(string EmailId);
        Task<List<UserDetailsViewModel>> GetAllRiders(short EmployeeType);
        Task<Employee> AddEmployee(string UserId, short EmployeeType);
        Task<bool> UpdateActivity(JobActivities model);

    }
    public class EmployeeService : BaseService,IEmployeeService
    {
        public EmployeeService(WorkOrderDBContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task<List<UserDetailsViewModel>> GetAllRiders(short EmployeeType)
        {
            var employeeNames = await (from a in _context.Employee
                                       join b in _context.AspNetUsers on a.UserId equals b.Id
                                       where a.EmployeeType == EmployeeType
                                       select new UserDetailsViewModel
                                       {
                                           EmployeeId = a.Id,
                                           UserId = b.Id,
                                           FullName = b.Firstname + " " + b.LastName,
                                           EmployeeType = a.EmployeeType,
                                           NationalityId = a.NationalityId,
                                           JoiningDate = a.JoiningDate,
                                           JobDescription = a.JobDescription,
                                           PersonStatus = a.PersonStatus
                                       }).ToListAsync();
            return employeeNames;
        }
        public Task<short> GetEmployeeType(string EmailId)
        {
            var employeeType = (from a in _context.Employee
                                join b in _context.AspNetUsers on a.UserId equals b.Id
                                where b.Email == EmailId
                                select a.EmployeeType);
            return employeeType.FirstOrDefaultAsync();
        }
        public async Task<Employee> AddEmployee(string UserId, short EmployeeType)
        {
            try
            {
                Employee model = new Employee
                {
                    UserId = UserId,
                    EmployeeType = EmployeeType,
                    NationalityId = "",
                    JoiningDate = DateTime.Now,
                    JobDescription = "",
                    PersonStatus = 1,
                    CreatedBy = UserId,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = UserId
                };
                _context.Employee.Add(model);
                _context.SaveChanges();

                return model;
            }
            catch (Exception es)
            {
                throw;
            }
        }

        public async Task<bool> UpdateActivity(JobActivities model)
        {
            //model.UpdatedBy = "19ef8691-ba36-45e6-8fc9-4ac0e84a7249";
            _context.JobActivities.Update(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<UserDetailsViewModel> GetEmployeeDetails(string EmailId)
        {
            var UserDetailsViewModel = await (from a in _context.Employee
                                        join b in _context.AspNetUsers on a.UserId equals b.Id
                                        where b.Email == EmailId
                                        select new UserDetailsViewModel
                                        {
                                            EmployeeId = a.Id,
                                            UserId = b.Id,
                                            FullName = b.Firstname + " " + b.LastName,
                                            LastName = b.LastName,
                                            Firstname = b.Firstname,
                                            EmployeeType = a.EmployeeType,
                                            NationalityId = a.NationalityId,
                                            JoiningDate = a.JoiningDate,
                                            JobDescription = a.JobDescription,
                                            PersonStatus = a.PersonStatus
                                        }).FirstOrDefaultAsync();
            return UserDetailsViewModel;
        }
    }
}
