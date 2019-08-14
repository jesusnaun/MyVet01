using Microsoft.AspNetCore.Mvc;
using MyVet01.Web.Helpers;
using MyVet01.Web.Controllers;
using MyVet01.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MyVet01.Web.Controllers
{

   
    public class AccountController : Controller
    {
        private readonly IUserHelper _userHelper; 

        public AccountController(IUserHelper userHelper)
        {
            _userHelper = userHelper; 
        }


        //Método LOgin
        //[HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        //POST
        //[HttpPost]
        //public IActionResult Login(LoginViewModel model)
        //{
        //   if (ModelState.IsValid)
        //    {
        //    }
        //    return View(model);
        //}
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Usuario o clave incorrecto.");
                model.Password = String.Empty;  
            }

             return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            //return  View();
            return RedirectToAction("Index", "Home");
        }




    }
}
