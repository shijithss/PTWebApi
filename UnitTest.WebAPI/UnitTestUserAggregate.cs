using AutoMapper;
using Microsoft.EntityFrameworkCore.Infrastructure;
using User.Microservice.Application.Models;
using User.Microservice.Infrastructure.Mapper;
using Entities=User.Microservice.Domain.Entities;
namespace UnitTest.WebAPI
{
    public class UnitTestUserAggregate
    {
        private Mapper _mapper;
       
        [Fact]
        public void WhenPostAddedWithNoReaction_ThenPostisEmpty()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new UserProfile()));
           
            _mapper = new Mapper(configuration);
            //Assign
            Post p1Model= new Post() { tags=new List<string>() { "french"} };
            var p1Entity=_mapper.Map<Post, Entities.Post>(p1Model);
            Entities.User user = new();
            //Act
            user.AddPost(new List<Entities.Post>() { p1Entity});
            //Assert
            Assert.Empty(user.Posts);
        }

        [Fact]
        public void WhenPostAddedWithReactionandHistory_ThenPostNotEmpty()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new UserProfile()));

            _mapper = new Mapper(configuration);
            //Assign
            Post p1Model = new Post() { tags = new List<string>() { "history" }, reactions=1 };

            var p1Entity = _mapper.Map<Post, Entities.Post>(p1Model);
            Entities.User user = new();
            //Act
            user.AddPost(new List<Entities.Post>() { p1Entity });
            //Assert
            Assert.NotEmpty(user.Posts);
        }

        [Fact]
        public void WhenTodoAdded_ThenTodoNotEmpty()
        {
            Entities.User user = new();
            user.AddTodo(new List<Entities.Todo>() { new Entities.Todo(), new Entities.Todo() });
            Assert.NotEmpty(user.Todos);
        }

        [Fact]
        public void WhenTodotoUserQueryAdded_ThenTodosNotEmpty()
        {
            Entities.UserQuery user = new();
            user.AddTodo(new List<Entities.Todo>() { new Entities.Todo(), new Entities.Todo() });
            Assert.NotEmpty(user.Todos);
        }

        [Fact]
        public void WhenPostQuerytoUserQueryAdded_ThenPostsNotEmpty()
        {
            //Assign
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new UserProfile()));
            _mapper = new Mapper(configuration);
            Post p1Model = new Post() { tags = new List<string>() { "french" } };
            var p1Entity = _mapper.Map<Post, Entities.PostQuery>(p1Model);
            Entities.UserQuery user = new();
            user.AddPostQuery(new List<Entities.PostQuery>() { p1Entity });
            Assert.NotEmpty(user.Posts);
        }

        [Fact]
        public void WhenFrenchTagPresent_ThenPostQueryHasFrenchTag_IsTrue()
        {
            //Assign
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new UserProfile()));
            _mapper = new Mapper(configuration);
            Entities.UserQuery user = new();
            Post p1Model = new Post() { tags = new List<string>() { "french" } };
            var p1Entity = _mapper.Map<Post, Entities.PostQuery>(p1Model);
            //Act
            user.AddPostQuery(new List<Entities.PostQuery>() { p1Entity });
            //Assert
            Assert.True(user.Posts.FirstOrDefault()?.hasFrenchTag);
        }

        [Fact]
        public void WhenFictionTagPresent_ThenPostQueryHasFictionTag_IsTrue()
        {
            //Assign
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new UserProfile()));
            _mapper = new Mapper(configuration);
            Entities.UserQuery user = new();
            Post p1Model = new Post() { tags = new List<string>() { "fiction" } };
            var p1Entity = _mapper.Map<Post, Entities.PostQuery>(p1Model);

            //Act
            user.AddPostQuery(new List<Entities.PostQuery>() { p1Entity });
            //Assert
            Assert.True(user.Posts.FirstOrDefault()?.hasFictionTag);
        }

        [Fact]
        public void WhenHasMorethanTwoReactionsPresent_ThenPostQueryHasMorethanTwoReactions_IsTrue()
        {
            //Assign
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(new UserProfile()));
            _mapper = new Mapper(configuration);
            Entities.UserQuery user = new();
            Post p1Model = new Post() { reactions = 3};
            var p1Entity = _mapper.Map<Post, Entities.PostQuery>(p1Model);
            //Act
            user.AddPostQuery(new List<Entities.PostQuery>() { p1Entity });
            //Assert
            Assert.True(user.Posts.FirstOrDefault()?.hasMorethanTwoReactions);
        }
    }
}