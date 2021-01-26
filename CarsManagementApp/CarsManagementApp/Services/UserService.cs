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

namespace CarsManagementApp.Services
{
    public class UserService : IUserService
    {
        private string _host = "http://localhost:5000/api";
        private string _address = "user";


        public async Task<IList<User>> GetUserList()
        {
            //TODO: Move call to API to Service than use serivce to consume API
            //http[:]//localhost:5000/ must be as a variable

            List<User> userList = new List<User>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_host}/{_address}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userList = JsonConvert.DeserializeObject<List<User>>(apiResponse);
                }
            }

            return userList;
        }

        
        public async Task<User> GetUser(int id)
        {
            var user = new User();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_host}/{_address}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(apiResponse);
                }
            }

            return user;
        }

        public async Task<User> PostUser(User user)
        {

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync($"{_host}/{_address}/", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user = JsonConvert.DeserializeObject<User>(apiResponse);
                }
            }

            return user;
        }


        public async Task<bool> PutUser(User user)
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Put, $"{_host}/{_address}/{user.Id}")
            {
                Content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json")
            };

            var response = await httpClient.SendAsync(request);

            return response.IsSuccessStatusCode;
        }


        public async Task<bool> DeleteUser(int id)
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Delete, $"{_host}/{_address}/{id}");
            var response = await httpClient.SendAsync(request);

            return response.IsSuccessStatusCode;
        }
    }
}
