using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CarsManagementApp.Models;
using CarsManagementApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarsManagementApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<IActionResult> ShowListUser()
        {
            return View(await _userService.GetUserList());
        }


        [HttpGet]
        public async Task<IActionResult> ShowUser(int id)
        {
            var user = await _userService.GetUser(id);

            return View(user);

        }

        [HttpGet]
        public IActionResult PostUser()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> PostUser(User user)
        {
            if (!ModelState.IsValid)
                return View(user);

            if (user == null)
            {
                ModelState.AddModelError("", "Błąd dodawania użytkownika");
                return View(user);
            }

            await _userService.PostUser(user);

            return RedirectToAction("ShowListUser", "User");
        }


        [HttpGet]
        public IActionResult PutUser(int id)
        {
            var user = _userService.GetUser(id).Result;

            return View(user);
        }


        [HttpPost]
        public async Task<IActionResult> PutUser(User user)
        {
           var response = await _userService.PutUser(user);

            if (response != true)
                return BadRequest();
            
            return RedirectToAction("ShowListUser", "User");
        }


        [HttpGet]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _userService.DeleteUser(id);

            if (response != true)
                return BadRequest();

            return RedirectToAction("ShowListUser", "User");
        }
    }
}