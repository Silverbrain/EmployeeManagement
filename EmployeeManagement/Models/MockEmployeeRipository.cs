using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement.Models
{
	public class MockEmployeeRipository : IEmployeeRpository
	{
        private List<Employee> _employeeList;

		public MockEmployeeRipository()
		{
            _employeeList = new List<Employee>()
            {
                new Employee() { Id = 1, Name = "Sina Ataei", Department = Departments.RD, Email = "sina@sinaataei.ml" },
                new Employee() { Id = 2, Name = "Arash Rastegar", Department = Departments.IT, Email = "arash@sinaataei.ml" },
                new Employee() { Id = 3, Name = "Ali Rastegar", Department = Departments.MG, Email = "ali@sinaataei.ml" },
                new Employee() { Id = 4, Name = "Ehsan Ataei", Department = Departments.HR, Email = "ehsan@sinaataei.ml" }
            };
		}

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(emp => emp.Id == Id);
        }
    }
}

