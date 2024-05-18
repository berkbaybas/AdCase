using AdCase.Domain.DTO;
using AdCase.Domain.Entities;
using AdCase.Domain.Interfaces;
using AdCase.Infrastructre.Persistence;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Infrastructre.Repository
{
    public class GroupRepository : RepositoryBase<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
