using Entities=User.Microservice.Domain.Entities;
namespace UnitTest.WebAPI
{
    public class UnitTestUserAggregate
    {
        [Fact]
        public void WhenPostAdded_ThenPostNotEmpty()
        {
            Entities.User user = new();
            user.AddPost(new List<Entities.Post>());
            Assert.NotEmpty(user.Posts);
        }

        [Fact]
        public void WhenTodoAdded_ThenTodoNotEmpty()
        {
            Entities.User user = new();
            user.AddTodo(new List<Entities.Todo>());
            Assert.NotEmpty(user.Todos);
        }

        [Fact]
        public void WhenTodotoUserQueryAdded_ThenTodosNotEmpty()
        {
            Entities.UserQuery user = new();
            user.AddTodo(new List<Entities.Todo>());
            Assert.NotEmpty(user.Todos);
        }

        [Fact]
        public void WhenPostQuerytoUserQueryAdded_ThenPostsNotEmpty()
        {
            Entities.UserQuery user = new();
            user.AddPostQuery(new List<Entities.PostQuery>());
            Assert.NotEmpty(user.Posts);
        }

        [Fact]
        public void WhenFrenchTagPresent_ThenPostQueryHasFrenchTag_IsTrue()
        {
            Entities.UserQuery user = new();
            user.AddPostQuery(new List<Entities.PostQuery>());
            Assert.True(user.Posts.FirstOrDefault()?.hasFrenchTag);
        }

        [Fact]
        public void WhenFrenchTagPresent_ThenPostQueryHasFictionTag_IsTrue()
        {
            Entities.UserQuery user = new();
            user.AddPostQuery(new List<Entities.PostQuery>());
            Assert.True(user.Posts.FirstOrDefault()?.hasFictionTag);
        }

        [Fact]
        public void WhenFrenchTagPresent_ThenPostQueryHasMorethanTwoReactions_IsTrue()
        {
            Entities.UserQuery user = new();
            user.AddPostQuery(new List<Entities.PostQuery>());
            Assert.True(user.Posts.FirstOrDefault()?.hasMorethanTwoReactions);
        }
    }
}