using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;
using StarterKitApp.Models;
using StarterKitApp.Services.Interfaces;

namespace StarterKitApp.Services
{
    public class JsonPlaceholderClient
    {
        private readonly IJsonPlaceholderClient _jsonPlaceholderClient;

        public JsonPlaceholderClient()
        {
            _jsonPlaceholderClient = RestService.For<IJsonPlaceholderClient>("https://jsonplaceholder.typicode.com");
        }

        public async Task<Foo[]> GetPosts()
        {
            return await _jsonPlaceholderClient.GetPosts();
        }

        public async Task<Foo> GetPost(int id)
        {
            return await _jsonPlaceholderClient.GetPost(id);
        }

        public async Task AddPost(Foo foo)
        {
            await _jsonPlaceholderClient.AddPost(foo);
        }
    }
}
