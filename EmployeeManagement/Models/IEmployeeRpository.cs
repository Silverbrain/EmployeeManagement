using System;
namespace EmployeeManagement.Models
{
	public interface IEmployeeRpository
	{
		Employee GetEmployee(int Id);
	}
}

