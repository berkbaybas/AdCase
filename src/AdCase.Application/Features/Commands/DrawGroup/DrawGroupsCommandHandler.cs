using AdCase.Domain.DTO;
using AdCase.Domain.Entities;
using AdCase.Domain.Interfaces;
using AdCase.Domain.Helpers;
using MediatR;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace AdCase.Application.Features.Commands.DrawGroup
{
    internal class DrawGroupsCommandHandler : IRequestHandler<DrawGroupsCommand, bool>
    {
        IGroupRepository _groupRepository;
        ITeamRepository _teamRepository;
        IDrawRepository _drawRepository;
        public DrawGroupsCommandHandler(IGroupRepository groupRepository, ITeamRepository teamRepository, IDrawRepository drawRepository)
        {
            _groupRepository = groupRepository;
            _teamRepository = teamRepository;
            _drawRepository = drawRepository;
        }

        public async Task<bool> Handle(DrawGroupsCommand request, CancellationToken cancellationToken)
        {
            var random = new Random();
            var teams = await _teamRepository.GetAllAsync();
            var groups = GroupHelper.InitializeGroups(request.GroupCount);
            var countryTeams = teams.GroupBy(t => t.Country).ToDictionary(g => g.Key, g => new List<Team>(g));

            int maxTeamsPerGroup = 4;

            for (int i = 1; i <= maxTeamsPerGroup; i++)
            {
                //1 draw 1.1
                //2 draw 2.1
                //3 draw 3.1
                //4 draw 4.1
                //5 draw 1.2
                //6 draw 2.2
                //7 draw 3.2
                //8 draw 4.2

                //1 draw 1.1
                //2 draw 2.1
                //3 draw 3.1
                //4 draw 4.1
                //5 draw 5.1
                //6 draw 6.1
                //7 draw 7.1
                //8 draw 8.1
                for (int y = 1; y <= request.GroupCount; y++)
                {
                    var order = y % (request.GroupCount + 1);
                    List<string> keys = countryTeams.Keys.ToList();

                    // Rastgele bir anahtar seç
                    string randomKey = keys[random.Next(keys.Count)];

                    // Rastgele seçilen anahtara karşılık gelen değeri al
                    List<Team> randomTeams = countryTeams[randomKey];
                    if (randomTeams.Count == 0) // Ülkede takım kalmadıysa birdaha random seç
                    {
                        y -= 1;
                        continue;
                    }
                    var randomTeam = randomTeams[random.Next(randomTeams.Count)];
                    if (groups[order - 1].Teams.Where(x => x.Country == randomTeam.Country).Any()) // Aynı torbada ülke varsa birdaha random seç
                    {
                        y -= 1;
                        continue;
                    }
                    else
                    {
                        groups[order - 1].Teams.Add(randomTeam);
                        countryTeams[randomKey].Remove(randomTeam);
                    }
                }
            }

            foreach (Domain.Entities.Group group in groups)
            {
                var GroupsInDb = await _groupRepository.AddAsync(group);
                foreach (Team team in group.Teams.ToList())
                {
                    var existingTeam = await _teamRepository.GetAsync(t => t.Name == team.Name);
                    if (existingTeam != null)
                    {
                        // Takım bilgilerini güncelle
                        existingTeam.GroupId = GroupsInDb.Id;

                        Draw draw = new()
                        {
                            DrawnBy = request.DrawnBy,
                            GroupId = group.Id,
                            TeamId = existingTeam.Id
                        };

                        await _drawRepository.AddAsync(draw);
                    }
                    else
                    {
                        // TODO ADD EXCEPTION
                    }
                }
            }

            return true;
        }
    }
}
