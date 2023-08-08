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

            Assert.Empty(user.Posts);
        }
    }
}