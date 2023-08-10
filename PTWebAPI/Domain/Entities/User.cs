using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace User.Microservice.Domain.Entities
{
    
    public class Address : BaseEntity
    {
        public string? address { get; private set; }
        public string? city { get; private set; }
        public Coordinates coordinates { get; private set; }
        public string? postalCode { get; private set; }
        public string? state { get; private set; }
    }

    public class Bank
    {
        public string? cardExpire { get; private set; }
        public string? cardNumber { get; private set; }
        public string? cardType { get; private set; }
        public string? currency { get; private set; }
        public string? iban { get; private set; }
    }

    public class Company
    {
        public Address address { get; private set; }
        public string? department { get; private set; }
        public string? name { get; private set; }
        public string? title { get; private set; }
    }
  
    public class Coordinates
    {
        public double lat { get; private set; }
        public double lng { get; private set; }
    }

    public class Hair
    {
        public string? color { get; private set; }
        public string? type { get; private set; }
    }

    public class User : BaseEntity
    {
        internal List<Todo> _Todos = new();
        public IReadOnlyCollection<Todo> Todos => new ReadOnlyCollection<Todo>(_Todos);
        internal List<Post> _Posts = new();
        public IReadOnlyCollection<Post> Posts => new ReadOnlyCollection<Post>(_Posts);
        public void AddTodo(List<Todo> _TodosList)
        {  
            _Todos.AddRange(_TodosList);
        }
        public void AddPost(List<Post> _PostsList)
        {
            //Apply Business Logic to filter the Posts for reactions greater than or equal 1 and tags contain history
            var filteredPostsList = _PostsList.Where(x => x.reactions >= 1 && x.tags.Any(c=> c.Contains("history")));
            _Posts.AddRange(filteredPostsList);
        }
        [Key]
        public int userId { get; private set; }
        public string? firstName { get; private set ; }
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
