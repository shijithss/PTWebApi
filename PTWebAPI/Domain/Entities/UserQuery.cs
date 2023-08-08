using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace User.Microservice.Domain.Entities
{
    
    public class AddressQuery : BaseEntity
    {
        public string address { get; private set; }
        public string city { get; private set; }
        public CoordinatesQuery coordinates { get; private set; }
        public string postalCode { get; private set; }
        public string state { get; private set; }
    }

    public class BankQuery
    {
        public string cardExpire { get; private set; }
        public string cardNumber { get; private set; }
        public string cardType { get; private set; }
        public string currency { get; private set; }
        public string iban { get; private set; }
    }

    public class CompanyQuery
    {
        public AddressQuery address { get; private set; }
        public string department { get; private set; }
        public string name { get; private set; }
        public string title { get; private set; }
    }
  
    public class CoordinatesQuery
    {
        public double lat { get; private set; }
        public double lng { get; private set; }
    }

    public class HairQuery
    {
        public string color { get; private set; }
        public string type { get; private set; }
    }

    public class UserQuery : BaseEntity
    {
        internal List<TodoQuery> _Todos = new();
        public IReadOnlyCollection<TodoQuery> Todos => new ReadOnlyCollection<TodoQuery>(_Todos);
        internal List<PostQuery> _Posts = new();
        public IReadOnlyCollection<PostQuery> Posts => new ReadOnlyCollection<PostQuery>(_Posts);
        public void AddTodo(List<TodoQuery> _TodosList)
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
        public int id { get; private set; }
        public string firstName { get; private set; }
        public string lastName { get; private set; }
        public string maidenName { get; private set; }
        public int age { get; private set; }
        public string gender { get; private set; }
        public string email { get; private set; }
        public string phone { get; private set; }
        public string username { get; private set; }
        public string password { get; private set; }
        public string birthDate { get; private set; }
        public string image { get; private set; }
        public string bloodGroup { get; private set; }
        public int height { get; private set; }
        public double weight { get; private set; }
        public string eyeColor { get; private set; }
        public HairQuery hair { get; private set; }
        public string domain { get; private set; }
        public string ip { get; private set; }
        public AddressQuery address { get; private set; }
        public string macAddress { get; private set; }
        public string university { get; private set; }
        public BankQuery bank { get; private set; }
        public CompanyQuery company { get; private set; }
        public string ein { get; private set; }
        public string ssn { get; private set; }
        public string userAgent { get; private set; }

    }
}
