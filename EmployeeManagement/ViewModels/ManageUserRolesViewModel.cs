using System.Collections.Generic;

namespace EmployeeManagement.ViewModels
{
    public class ManageUserRolesViewModel
    {
        public ManageUserRolesViewModel()
        {
            UserRoles = new List<UserRole>();
        }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }

    public class UserRole
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
    }
}