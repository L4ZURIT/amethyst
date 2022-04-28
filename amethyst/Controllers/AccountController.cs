using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using amethyst.ViewModels; // пространство имен моделей RegisterModel и LoginModel
using amethyst.Data.DataBase; // пространство имен UserContext и класса User
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AuthApp.Controllers
{
    public class AccountController : Controller
    {
        private DBContent db;
        private readonly IRegisterNewUser _registerNewUser;

        public AccountController(DBContent context, IRegisterNewUser iregNewUser)
        {
            db = context;
            _registerNewUser = iregNewUser;


        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AutorizationViewModel model)
        {
            if (ModelState.IsValid)
            {
                users user = await db.users.FirstOrDefaultAsync(u => u.login == model.login && u.password == model.password);
                if (user != null)
                {
                    await Authenticate(model.login); // аутентификация

                    bool truth = HttpContext.User.Identity.IsAuthenticated;

                    return RedirectToAction("Index", "Home");
                }
                ViewBag.msg = "Неверные Логин или Пароль";
            }
            return View(model);
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(NewAccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                users user = await db.users.FirstOrDefaultAsync(u => u.login == model.Login);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    try
                    {


                        db.users.Add(new users { login = model.Login, password = model.Password, admission_id = 1, person_id = db.employee.FirstOrDefault(e => e.uie == model.UIE).id });
                        await db.SaveChangesAsync();

                        await Authenticate(model.Login); // аутентификация

                        return RedirectToAction("Index", "Home");
                    }
                    catch (Exception ex)
                    {
                        ViewBag.msg = "Нет такого УИР";
                        return View(model);
                    }
                }
                else
                {
                    ViewBag.msg = "Нет такого УИР";
                }
                   
            }
            return View(model);
        }



        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(employee empl)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _registerNewUser.RegisterNewUser(empl);
                }
                catch (Exception ex)
                {
                    ViewBag.msg = "Такой идентификатор уже имеется";
                    return View(empl);
                }

                return RedirectToAction(nameof(Register));

            }

            return View(empl);

        }


        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Sad()
        {
            return View();
        }
    }
}