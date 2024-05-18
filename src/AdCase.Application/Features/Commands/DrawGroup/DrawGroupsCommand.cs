using AdCase.Domain.DTO;
using MediatR;

namespace AdCase.Application.Features.Commands.DrawGroup
{
    public class DrawGroupsCommand : IRequest<bool>
    {
        public int GroupCount { get; set; }
        public string DrawnBy { get; set; }
    }
}
