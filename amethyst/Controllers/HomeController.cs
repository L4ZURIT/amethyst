using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using amethyst.ViewModels;
using amethyst.Data.DataBase;
using Microsoft.AspNetCore.Authorization;

namespace amethyst.Controllers
{



    public class HomeController : Controller
    {

        private readonly IAllAppeals _allAppeals;
        private readonly IAllUsers _allUsers;

        public HomeController(IAllAppeals iAllAppeals, IAllUsers iAllUsers)
        {
            _allAppeals = iAllAppeals;
            _allUsers = iAllUsers;

        }
        // GET: HomeController
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        

        // POST: HomeController/Create
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

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
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

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
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
