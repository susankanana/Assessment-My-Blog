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
    internal class CommentServices : IComment
    {
        private readonly HttpClient _httpClient;
        private readonly string _URL = "https://jsonplaceholder.typicode.com/comments  ";
        public CommentServices()
        {
            _httpClient = new HttpClient();
        }
        public async Task<List<Comment>> GetAllComments()
        {
            try
            {
                var response = await _httpClient.GetAsync(_URL);
                var content = await response.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<List<Comment>>(content);

                if (response.IsSuccessStatusCode)
                {
                    return comments;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return new List<Comment>();
        }
        public async Task<Comment> GetCommentByPostId(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync(_URL + "/" + id);
                var content = await response.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<Comment>(content);

                if (response.IsSuccessStatusCode)
                {
                    return comments;
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }

            return new Comment();
        }
    }
}
