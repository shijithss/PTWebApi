using MediatR;
using System.Threading;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Infrastructure.Data;
using Entities = User.Microservice.Domain.Entities;
using User.Microservice.Domain.Entities;
using User.Microservice.Application.Models;
using AutoMapper;

namespace User.Microservice.Application.Features.User.Events
{
    public class UserCreatedEvent : INotification
    {

        public List<Entities.User> Users { get; set; } = new();
    }

}
