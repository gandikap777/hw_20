using HomeWork_13;
using HomeWork_13.Models;
using homework_20.Models;
using homework_20.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace homework_20.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly DataManager dataManager;
        private readonly ILogger log;
        public AccountController(UserManager<User> userMgr, SignInManager<User> signinMgr, DataManager dataManager, ILogger log)
        {
            userManager = userMgr;
            signInManager = signinMgr;
            this.log = log;
            this.dataManager = dataManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                    if (result.Succeeded)
                    {
                        log.LogInformation($"Успешная атентификация. редирект: {returnUrl}");
                        return Redirect(returnUrl ?? "/");
                    }
                }
                ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            log.LogInformation($"Выход из аккаунта: {signInManager.ToString()}");
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View(new UserRegistration());
        }

        [HttpPost, ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserRegistration model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { UserName = model.Login, Email = model.Email };
                var createResult = await userManager.CreateAsync(user, model.Password);

                if (createResult.Succeeded)
                {
                    IClient newClient = ClientFactory.GetClient("Client", model.FirstName, model.LastName, DateTime.Parse(model.Birthday), DateTime.Now.Date, 1);
                    
                    dataManager.Clients.SaveClient(newClient);
                    user.Client = (Person)newClient;
                    await userManager.UpdateAsync(user);
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else//иначе
                {
                    foreach (var identityError in createResult.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                }
            }

            return View(model);
        }
    }

}    
