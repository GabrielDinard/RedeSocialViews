using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.Domain.Account;
using RedeSocial.Services.Account;
using RedeSocial.Web.ViewModel.Account;

namespace RedeSocial.Web.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService AccountService { get; set; }
        private IAccountIdentityManager AccountIdentityManager { get; set; }

        public AccountController(IAccountService accountService, IAccountIdentityManager accountIdentityManager)
        {
            this.AccountService = accountService;
            this.AccountIdentityManager = accountIdentityManager;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account user)
        {
            try
            {
                
                CancellationToken token = new CancellationToken();
                this.AccountService.save(user, token);
                return RedirectToAction(nameof(Login));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Account user)
        {
            try
            {
                CancellationToken token = new CancellationToken();
                this.AccountService.edit(user, token);
                return RedirectToAction(nameof(Perfil));
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Perfil(string userId, Domain.Account.Account user)
        {
            try
            {
                CancellationToken token = new CancellationToken();
                this.AccountService.detailsGetId(user, token);
                this.AccountService.detailsFindId(userId, token);            
                return View(userId);
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Login(string returnUrl = "")
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            
            try
            {
                var result = await this.AccountIdentityManager.Login(model.UserName, model.Password);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError(string.Empty, "Login ou senha inválidos");
                    return View(model);
                }

                if (!String.IsNullOrWhiteSpace(returnUrl))
                    return Redirect(returnUrl);

                return Redirect("/");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Ocorreu um erro, por favor tente mais tarde.");
                return View(model);
            }
            
        }




    }
}
