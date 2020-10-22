using Microsoft.EntityFrameworkCore;
using Survey.Domain.Entities.Respond;
using Survey.Domain.Entities.Survey;
using Survey.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Survey.Application.Interfaces
{
    public interface IDatabaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Survey.Domain.Entities.Survey.Survey> Surveys { get; set; }
        DbSet<Question> Questions { get; set; }
        DbSet<Option> Options { get; set; }
        DbSet<Respond> Responds { get; set; }
        DbSet<Answer> Answers { get; set; }

        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken=new CancellationToken());
    }
}
