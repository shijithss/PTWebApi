using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using User.Microservice.Infrastructure.Data;
using Entities = User.Microservice.Domain.Entities;
using AutoMapper;
using User.Microservice.Application.Models;

namespace User.Microservice.Application.Features.User.Queries
{
    /// <summary>
    /// GetPostDetailsQuery empty
    /// </summary>
    public class GetPostDetailsQuery : IRequest<IEnumerable<Models.PostViewModel>>
    {

    }

}
