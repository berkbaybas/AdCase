using AdCase.Domain.DTO;
using AdCase.Domain.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Application.Features.Queries.GetGroup
{
    internal class GetGroupsQueryHandler : IRequestHandler<GetGroupsQuery, List<GroupDto>>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;


        public GetGroupsQueryHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<List<GroupDto>> Handle(GetGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = await _groupRepository.GetAllAsync(include: m => m.Include(m => m.Teams)
                                                                    , cancellationToken: cancellationToken);
            List<GroupDto> response = new();

            foreach (var group in groups)
            {
                List<string> teams = new();
                foreach (var team in group.Teams)
                {
                    teams.Add(team.Name);
                }
                GroupDto resultGroup = new()
                {
                    GroupName = group.GroupName,
                    Teams = teams
                };
                response.Add(resultGroup);
            }

            return response;
        }
    }
}
