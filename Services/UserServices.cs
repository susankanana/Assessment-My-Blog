using MyBlog.Models;
using MyBlog.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services
{
    internal class UserServices : IUser
    {
        private readonly HttpClient _httpClient;
        private readonly string _URL = "https://jsonplaceholder.typicode.com/users ";
        public UserServices()
        {
            _httpClient = new HttpClient();
        }
        

        public async Task<List<User>> GetAllUsers()
        {
            try
            {
                var response = await _httpClient.GetAsync(_URL);
                var content = await response.Content.ReadAsStringAsync();
                var users = JsonConvert.DeserializeObject<List<User>>(content);

                if (response.IsSuccessStatusCode)
                {
                    return users;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return new List<User>();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            try
            {
                var response = await _httpClient.GetAsync(_URL + "/" + username);
                var content = await response.Content.ReadAsStringAsync();
                var user = JsonConvert.DeserializeObject<User>(content);

                if (response.IsSuccessStatusCode)
                {
                    return user;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return new User();
        }
    }
}
