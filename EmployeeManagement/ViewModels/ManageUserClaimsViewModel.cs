using System.Collections.Generic;

namespace EmployeeManagement.ViewModels
{
    public class ManageUserClaimsViewModel
    {
        public ManageUserClaimsViewModel()
        {
            Claims = new List<UserClaim>();
        }

        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<UserClaim> Claims { get; set; }
    }

    public class UserClaim
    {
        public string ClaimType { get; set; }
        public bool IsSelected { get; set; }
    }
}