using Models = User.Microservice.Application.Models;

namespace User.Microservice.Infrastructure.Repositories
{
    public interface IDummyJsonRepository
    {
        Task<List<Models.Post>> GetAllPosts();
        Task<List<Models.Todo>> GetAllTodos();
        Task<List<Models.User>> GetAllUsers();
    }
}