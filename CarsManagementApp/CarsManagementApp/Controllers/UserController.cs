using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CarsManagementApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarsManagementApp.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> ShowUser()
        {

            //TODO: Move call to API to Service than use serivce to consume API
            //http[:]//localhost:5000/ must be as a variable

            List<User> userList = new List<User>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/user"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }

            return View(userList);
        }
    }
}