using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {id} could not be found";
                return View("NotFound");
            }

            var model = new EditRoleViewModel()
            {
                Id = role.Id,
                RoleName = role.Name
            };
            foreach(var user in userManager.Users)
            {
                if(await userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                var role = await roleManager.FindByIdAsync(model.Id);

                if(role == null)
                {
                    ViewBag.ErrorMessage = $"Role with Id = {model.Id} could not be found";
                    return View("NotFound");
                }
                else
                {
                    role.Name = model.RoleName;
                    var result = await roleManager.UpdateAsync(role);

                    if(result.Succeeded)
                    {
                        return RedirectToAction("ListRoles");
                    }
                    else
                    {
                        foreach(var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if(ModelState.IsValid)
            {
                var role = new IdentityRole(model.Name);
                var result = await roleManager.CreateAsync(role);

                if(result.Succeeded)
                {
                    return RedirectToAction("listroles", "administration");
                }

                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with id {roleId} could not be found";
                return View("NotFound");
            }
            else
            {
                var model = new EditUserRoleViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                foreach(var user in userManager.Users)
                {
                    var userRole = new UserInRole()
                    {
                        UserId = user.Id,
                        UserName = user.UserName
                    };

                    if(await userManager.IsInRoleAsync(user, role.Name))
                    {
                        userRole.IsSelected = true;
                    }
                    else
                    {
                        userRole.IsSelected = false;
                    }

                    model.Users.Add(userRole);
                }
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(EditUserRoleViewModel model)
        {
            var role = await roleManager.FindByIdAsync(model.RoleId);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with id = {model.RoleId} could not be found";
                return View("NotFound");
            }
            
            foreach(var modelUser in model.Users)
            {
                var user = await userManager.FindByIdAsync(modelUser.UserId);

                IdentityResult result = null;

                if(modelUser.IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await userManager.AddToRoleAsync(user, role.Name);
                }
                else if(!modelUser.IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }
            }

            return RedirectToAction("EditRole", new { id = role.Id });
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = userManager.Users;

            return View(users);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {Id} cannot be found";
                return View("NotFound");
            }

            var roles = await userManager.GetRolesAsync(user);
            var claims = await userManager.GetClaimsAsync(user);

            var model = new EditUserViewModel()
            {
                Id = user.Id,
                Email = user.Email,
                Username = user.UserName,
                City = user.City,
                Roles = roles.ToList(),
                Claims = claims.Select(c => c.Value).ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);

            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return View("NotFound");
            }

            user.Email = model.Email;
            user.UserName = model.Username;
            user.City = model.City;

            var result = await userManager.UpdateAsync(user);

            if(result.Succeeded)
            {
                return RedirectToAction("ListUsers");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);

            if(user == null)
            {
                ViewBag.ErrorMessage = $"User with Id = {Id} could not be found";
                return View("NotFound");
            }

            IdentityResult result = await userManager.DeleteAsync(user);

            if(result.Succeeded)
            {
                return RedirectToAction("ListUsers");
            }

            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View("ListUsers");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);

            if(role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {Id} could not be found";
                return View("NotFound");
            }

            IdentityResult result = await roleManager.DeleteAsync(role);

            if(result.Succeeded)
            {
                return RedirectToAction("ListRoles");
            }

            foreach(var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
            return View("ListRoles");
        }
    }
}