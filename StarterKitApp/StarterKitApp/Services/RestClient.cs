using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Refit;
using StarterKitApp.Models;
using StarterKitApp.Services.Interfaces;

namespace StarterKitApp.Services
{
    public class RestClient
    {
        private readonly IRestClient _restClient;

        public RestClient()
        {
            _restClient = RestService.For<IRestClient>("https://jsonplaceholder.typicode.com");
        }

        public async Task<Foo[]> GetPosts()
        {
            return await _restClient.GetPosts();
        }

        public async Task<Foo> GetPost(int id)
        {
            return await _restClient.GetPost(id);
        }

        public async Task AddPost(Foo foo)
        {
            await _restClient.AddPost(foo);
        }
    }
}
