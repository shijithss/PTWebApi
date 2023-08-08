using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace User.Microservice.Domain.Entities
{
    
     public class UserQuery : BaseEntity
    {
        internal List<Todo> _Todos = new();
        public IReadOnlyCollection<Todo> Todos => new ReadOnlyCollection<Todo>(_Todos);
        internal List<PostQuery> _Posts = new();
        public IReadOnlyCollection<PostQuery> Posts => new ReadOnlyCollection<PostQuery>(_Posts);
        public void AddTodo(List<Todo> _TodosList)
        {

            _Todos.AddRange(_TodosList);
        }
        public void AddPostQuery(List<PostQuery> _PostsList)
        {
            foreach (var postQuery in _PostsList)
            {
                postQuery.CheckFictionTag();
                postQuery.CheckFrenchTag();
                postQuery.CheckMorethanTwoReactions();
            }
            _Posts.AddRange(_PostsList);
        }
        [Key]
        public int userid { get; private set; }
        public string? firstName { get; private set; }
        public string? lastName { get; private set; }
        public string? maidenName { get; private set; }
        public int age { get; private set; }
        public string? gender { get; private set; }
        public string? email { get; private set; }
        public string? phone { get; private set; }
        public string? username { get; private set; }
        public string? password { get; private set; }
        public string? birthDate { get; private set; }
        public string? image { get; private set; }
        public string? bloodGroup { get; private set; }
        public int height { get; private set; }
        public double weight { get; private set; }
        public string? eyeColor { get; private set; }
        public Hair hair { get; private set; }
        public string? domain { get; private set; }
        public string? ip { get; private set; }
        public Address address { get; private set; }
        public string? macAddress { get; private set; }
        public string? university { get; private set; }
        public Bank bank { get; private set; }
        public Company company { get; private set; }
        public string? ein { get; private set; }
        public string? ssn { get; private set; }
        public string? userAgent { get; private set; }

    }
}
