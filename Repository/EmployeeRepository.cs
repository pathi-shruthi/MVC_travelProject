using Microsoft.EntityFrameworkCore;
using MVC_TravelProject.Models;
using MVC_TravelProject.Repository;
using static MVC_TravelProject.Repository.EmployeeRepository;

namespace MVC_TravelProject.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {


        private readonly travelRequestContext _context;

        public EmployeeRepository(travelRequestContext context)
            {
                _context = context;
            }
            public IEnumerable<Employee> GetEmployees()
            {
            return _context.Employees;
            }

            public void AddEmployee(Employee employee)
            {
                if (employee != null)
                {
                    _context.Employees.Add(employee);
                    _context.SaveChanges();
                }
            }

        
        
        public void DeleteEmployee(int EmployeeID)
        {
            Employee? emp = _context.Employees.FirstOrDefault(x => x.EmployeeId == EmployeeID);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
        }

        public Employee GetEmployeeById(int EmployeeId)
        {
            Employee? emp = _context.Employees.FirstOrDefault(x => x.EmployeeId == EmployeeId);
            return emp;
        }

        public void UpdateEmployee(Employee emp, int EmployeeId)
        {
            Employee? emp_old = _context.Employees.FirstOrDefault(x => x.EmployeeId == EmployeeId);
            if (emp_old != null)
            {
                emp_old.FirstName = emp.FirstName;
                emp_old.LastName = emp.LastName;
                emp_old.Contact = emp.Contact;
                emp_old.Dept = emp.Dept;
                emp_old.Address = emp.Address;
                emp_old.Dob = emp.Dob;

                _context.SaveChanges();

            }

        }
    }
}


