using MyBlog.Models;
using MyBlog.Services.IServices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Services
{
    internal class PostServices : IPost
    {
        private readonly HttpClient _httpClient;
        private readonly string _URL = "https://jsonplaceholder.typicode.com/posts ";
        public PostServices()
        {
            _httpClient = new HttpClient();
        }
        

        public async Task<List<Post>> GetAllPosts()
        {
            try
            {
                var response = await _httpClient.GetAsync(_URL);
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<List<Post>>(content);

                if (response.IsSuccessStatusCode)
                {
                    return posts;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return new List<Post>();
        }

        public async Task<Post> GetPostByUserId(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync(_URL + "/" + id);
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<Post>(content);

                if (response.IsSuccessStatusCode)
                {
                    return posts;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return new Post();
        }
        


    }
}

