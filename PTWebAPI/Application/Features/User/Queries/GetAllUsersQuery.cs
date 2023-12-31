﻿using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Infrastructure.Data;
using Entities = User.Microservice.Domain.Entities;
using AutoMapper;

namespace User.Microservice.Application.Features.User.Queries
{
    /// <summary>
    /// Query empty
    /// </summary>
    public class GetAllUsersQuery : IRequest<IEnumerable<Models.UserViewModel>>
    {

    }

}
