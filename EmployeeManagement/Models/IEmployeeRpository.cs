using System;
using System.Collections.Generic;

namespace EmployeeManagement.Models
{
	public interface IEmployeeRpository
	{
		Employee GetEmployee(int Id);
		IEnumerable<Employee> GetAllEmployees();
		Employee Add(Employee employee);
		Employee Update(Employee employeeChanges);
		Employee Delete(int Id);
	}
}

