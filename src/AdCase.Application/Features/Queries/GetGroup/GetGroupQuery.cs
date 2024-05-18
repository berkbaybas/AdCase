﻿using AdCase.Domain.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdCase.Application.Features.Queries.GetGroup
{
    public class GetGroupsQuery : IRequest<List<GroupDto>>
    {
    }
}
