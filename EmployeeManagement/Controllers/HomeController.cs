using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
	public class HomeController : Controller
	{
        private readonly IEmployeeRpository _employeeRepository;

        public HomeController(IEmployeeRpository employeeRpository)
        {
            _employeeRepository = employeeRpository;
        }

		public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }

        public ViewResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return View(model);
        }
	}
}

