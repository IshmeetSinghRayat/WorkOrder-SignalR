using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkOrderCore.Infrastructure.Persistence.DataContext;

namespace WorkOrderCore.Services
{
    public interface IEmployeeService
    {
        Task<short> GetEmployeeType(string EmailId);
        Task<List<Employee>> GetAllRiders(short EmployeeType);
        Task<Employee> AddEmployee(string UserId, short EmployeeType);
        Task<bool> UpdateActivity(JobActivities model);

    }
    public class EmployeeService : IEmployeeService
    {
        private readonly WorkOrderDBContext _context;

        public EmployeeService(WorkOrderDBContext Context)
        {
            _context = Context;
        }
        public async Task<List<Employee>> GetAllRiders(short EmployeeType)
        {
            return await _context.Employee.Where(v => v.EmployeeType == EmployeeType).ToListAsync();
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
                Employee model = new Employee {
                UserId = UserId,
                    EmployeeType = EmployeeType,
                    NationalityId = "",
                    JoiningDate = DateTime.Now,
                    JobDescription = "",
                    PersonStatus = 1,
                    CreatedBy = "19ef8691-ba36-45e6-8fc9-4ac0e84a7249",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    UpdatedBy = "19ef8691-ba36-45e6-8fc9-4ac0e84a7249"
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
    }
}
