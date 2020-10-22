using Survey.Application.Interfaces;
using Survey.Application.Services.Users.Queries;
using Survey.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Survey.Application.Services.Survey.Queries
{
    public interface IGetSurveysService
    {
        List<GetSurveyDto> Execute(RequestGetUserDto request);
    }
    public class GetSurveysService : IGetSurveysService
    {
        private readonly IDatabaseContext _context;

        public GetSurveysService(IDatabaseContext context)
        {
            _context = context;
        }

        public List<GetSurveyDto> Execute(RequestGetUserDto request)
        {
            var surveys = _context.Surveys.AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Searchkey))
            {
                surveys = surveys.Where(w => w.Title.Contains(request.Searchkey) || w.Description.Contains(request.Searchkey));
            }
            return surveys.ToPaged(request.Page, 20, out var total).Where(w=>w.IsRemoved==false).Select(s => new GetSurveyDto
            {
                Title = s.Title,
                Description = s.Description,
                Id = s.Id,
                CreateDate=s.CreateDate,
                IsActive=s.IsActive,
                OwnerUserId=s.UserId
            }).ToList();
        }
    }

    public class GetSurveysDto
    {
        public int Id { get; set; }
        public string   Title { get; set; }
        public string   Description { get; set; }
        public bool IsActive { get; set; }
        public int OwnerUserId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
