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
                new Employee() { Id = 1, Name = "Sina Ataei", Department = "RD", Email = "sina@sinaataei.ml" },
                new Employee() { Id = 1, Name = "Arash Rastegar", Department = "IT", Email = "arash@sinaataei.ml" },
                new Employee() { Id = 1, Name = "Ali Rastegar", Department = "MG", Email = "ali@sinaataei.ml" },
                new Employee() { Id = 1, Name = "Ehsan Ataei", Department = "HR", Email = "ehsan@sinaataei.ml" }
            };
		}

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(emp => emp.Id == Id);
        }
    }
}

