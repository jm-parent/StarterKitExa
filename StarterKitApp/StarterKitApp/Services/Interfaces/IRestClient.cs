using System.Threading.Tasks;
using Refit;
using StarterKitApp.Models;

namespace StarterKitApp.Services.Interfaces
{
        public interface IRestClient
        {
            [Get("/posts")]
            Task<Foo[]> GetPosts();

            [Get("/posts/{id}")]
            Task<Foo> GetPost(int id);

            [Post("/posts")]
            Task AddPost(Foo foo);
        }
}