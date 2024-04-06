using GHwithSSDM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GHwithSSDM.Controllers
{
    public class UserController : Controller
    {
        AppDbContext context = new AppDbContext();
        // GET: UserController
        public ActionResult Index()
        {
            var users = context.Users.ToList();
            return View(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                context.Users.Add(user);
                var newGH = new GioHang()
                {
                    Id = user.Id,
                    Status = 1
                };
                context.GioHangs.Add(newGH);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string name, string password)
        {
            // Lấy ra user có thông tin trùng với username và password được nhập vào
            var user = context.Users.ToList().FirstOrDefault(p => p.Name == name && p.Pass == password);
            if (user != null)
            {
                // Thêm username vào session có key là user
                HttpContext.Session.SetString("user", name);
                return RedirectToAction("Index");
            }
            else return Content("Đăng nhập thất bại");
        }
    }
}
