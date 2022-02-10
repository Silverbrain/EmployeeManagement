using System.Collections.Generic;
using EmployeeManagement.Models;

namespace EmployeeManagement.ViewModels
{
    public class EditUserRoleViewModel
    {
        public EditUserRoleViewModel()
        {
            Users = new List<UserInRole>();
        }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public List<UserInRole> Users { get; set; }
    }

    public class UserInRole
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}