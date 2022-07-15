using ACC.MVC.Infrastructure.Persistence;
using ACC.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ACC.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserCredentials credentials)
        {

            try
            {
                if (ModelState.IsValid)
                {
                   var user = _context
                        .Users
                        .Include(x => x.UserRoles)
                        .ThenInclude( x => x.Role)
                        .FirstOrDefault(x => x.Email == credentials.Email && x.Password == credentials.Password);

                    if (user is null)
                    {
                        ModelState.AddModelError("", "Email or Password is not valid");
                        return View(credentials);
                    }

                    if(user.UserRoles.Any(x=> x.Role.Name.Equals("Admin")))
                    {
                        return RedirectToAction("Create", "User");
                    }

                    if (user.UserRoles.Any(x => x.Role.Name.Equals("Visitor")))
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(credentials);

        }
    }
}
