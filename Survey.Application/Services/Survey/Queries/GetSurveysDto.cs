using Survey.Application.Interfaces;
using Survey.Application.Services.Users.Queries;
using Survey.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Survey.Application.Services.Survey.Queries
{
    public interface IGetSurveysService
    {
        List<GetSurveysDto> Execute(RequestGetUsersDto request);
    }
    public class GetSurveysService :BaseService, IGetSurveysService
    {

        public GetSurveysService(IDatabaseContext context) : base(context) { }
     
        public List<GetSurveysDto> Execute(RequestGetUsersDto request)
        {
            var surveys = Context.Surveys.Include(a=>a.User).Include(b=>b.Questions).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.Searchkey))
            {
                surveys = surveys.Where(w => w.Title.Contains(request.Searchkey) || w.Description.Contains(request.Searchkey));
            }
            return surveys.ToPaged(request.Page, 20, out var total).Where(w=>w.IsRemoved==false).Select(s => new GetSurveysDto
            {
                Title = s.Title,
                Description = s.Description,
                Id = s.Id,
                CreateDate=s.CreateDate,
                IsActive=s.IsActive,
                UserId=s.UserId,
                UserFullName=s.User.FullName,
                QuestionsCount= s.Questions.Count()
            }).ToList();
        }
     
    }

    public class GetSurveysDto
    {
        public int Id { get; set; }
        public string   Title { get; set; }
        public string   Description { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserFullName { get; set; }
        public int QuestionsCount { get; set; }
    }
}
