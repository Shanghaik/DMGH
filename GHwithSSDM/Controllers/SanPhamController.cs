using GHwithSSDM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GHwithSSDM.Controllers
{
    public class SanPhamController : Controller
    {
        AppDbContext context = new AppDbContext();
        // GET: SanPhamController
        public ActionResult Index()
        {
            var data = context.SanPhams.ToList();
            return View(data);
        }

        // GET: SanPhamController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SanPhamController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SanPhamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPham sp)
        {
            try
            {
                context.SanPhams.Add(sp);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SanPhamController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SanPhamController/Edit/5
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

        // GET: SanPhamController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SanPhamController/Delete/5
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
        public IActionResult AddToCart(Guid id, int amount)
        {
            var user = HttpContext.Session.GetString("user");
            // Đầu tiên Check xem trong Session có dữ liệu đăng nhập chưa?
            if (user == null)
            {
                //var dataSession = HttpContext.Session.GetString("ghSession");
                //var ghcts = JsonConvert.DeserializeObject<List<GHCT>>(dataSession);
                return Content("Chưa đăng nhập không có giỏ đâu");
            }
            else
            {
                var getUser = context.Users.FirstOrDefault(p => p.Name == user);
                var ghctSP = new GHCT
                {
                    Id = Guid.NewGuid(),
                    Amount = amount,
                    IdGH = getUser.Id,
                    IdSP = id
                };
                context.GHCTs.Add(ghctSP);
                context.SaveChanges();
                return RedirectToAction("Index", "GHCT");
            }
        }
    }
}
