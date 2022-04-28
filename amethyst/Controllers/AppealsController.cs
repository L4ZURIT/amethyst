using amethyst.Data.DataBase;
using amethyst.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace amethyst.Controllers
{
    public class AppealsController : Controller
    {
        private readonly IAllAppeals _allAppeals;

        public AppealsController(IAllAppeals iAllAppeals)
        {
            _allAppeals = iAllAppeals;
        }

        public ViewResult res()
        {
            AppealsListViewModel obj = new AppealsListViewModel();
            obj.getAppeals = _allAppeals.Appeals;
            obj.hyu = "waidfhusefhuhsev";
            ViewBag.test = "wdwddw";
            ViewBag.Appeals = obj;
            return View(obj);
        }

    }
}
