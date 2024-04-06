using GHwithSSDM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GHwithSSDM.Controllers
{
    public class GHCTController : Controller
    {
        // GET: GioHangController
        AppDbContext context = new AppDbContext();
        public ActionResult Index()
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
                var getUser = context.Users.FirstOrDefault(p=>p.Name == user);
                var GHCTdata = context.GHCTs.Where(p=>p.IdGH == getUser.Id).ToList();
                return View(GHCTdata);
            }
        }

        // GET: GioHangController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GioHangController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GioHangController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: GioHangController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GioHangController/Edit/5
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

        // GET: GioHangController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GioHangController/Delete/5
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
    }
}
