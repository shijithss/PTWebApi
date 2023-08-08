using Newtonsoft.Json;
using Models = User.Microservice.Application.Models;

namespace User.Microservice.Infrastructure.Repositories
{
    public class DummyJsonRepository : IDummyJsonRepository
    {
        public DummyJsonRepository()
        {
        }

        public async Task<List<Models.User>> GetAllUsers()
        {
            var result = new List<Models.User>();
            using (var client = new HttpClient())
            {
                string url = string.Format("https://dummyjson.com/users");
                var response = client.GetAsync(url).Result;

                string responseAsString = await response.Content.ReadAsStringAsync();
                var rootResult = JsonConvert.DeserializeObject <Models.RootUser >(responseAsString);
                result = rootResult.users;
            }

            return await Task.FromResult(result);
        }

        public async Task<List<Models.Post>> GetAllPosts()
        {
            var result = new List<Models.Post>();
            using (var client = new HttpClient())
            {
                string url = string.Format("https://dummyjson.com/posts");
                var response = client.GetAsync(url).Result;

                string responseAsString = await response.Content.ReadAsStringAsync();
                
                    var rootResult = JsonConvert.DeserializeObject<Models.RootPost> (responseAsString);
                    result = rootResult.posts;
               
                
            }
            return await Task.FromResult(result);
        }

        public async Task<List<Models.Todo>> GetAllTodos()
        {
            var result = new List<Models.Todo>();
            using (var client = new HttpClient())
            {
                string url = string.Format("https://dummyjson.com/todos");
                var response = client.GetAsync(url).Result;

                string responseAsString = await response.Content.ReadAsStringAsync();
                var rootResult = JsonConvert.DeserializeObject<Models.RootTodo>(responseAsString);
                result = rootResult.todos;
            }
            return await Task.FromResult(result);

        }
    }

}
