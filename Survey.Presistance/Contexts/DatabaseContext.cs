using Microsoft.EntityFrameworkCore;
using Survey.Application.Interfaces;
using Survey.Common;
using Survey.Domain.Entities.Respond;
using Survey.Domain.Entities.Survey;
using Survey.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Survey.Presistance.Contexts
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Domain.Entities.Survey.Survey> Surveys { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Respond> Responds { get; set; }
        public DbSet<Answer> Answers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        //    modelBuilder.Entity<Answer>()       // THIS IS FIRST
        //.HasOne(u => u.Reespond).WithMany(u => u.Answers).IsRequired().OnDelete(DeleteBehavior.);


            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Survey>().HasQueryFilter(p => !p.IsRemoved);
            SeedData(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            (var hash, var salt) = PasswordManager.Hash("123456");

            modelBuilder.Entity<User>().HasData(new User { Id = 1, Email = "m@m.com", FullName = "Admin", PasswordHash = hash,PasswordSalt=salt,IsActive=true });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Survey>().HasData(new Domain.Entities.Survey.Survey { Id = 1, UserId = 1, Title = "Developer Roles",CreateDate=DateTime.Now });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Question>().HasData(new Domain.Entities.Survey.Question { Id = 1, SurveyId = 1, Title = "Developer Type" });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Question>().HasData(new Domain.Entities.Survey.Question { Id = 2, SurveyId = 1, Title = "Coding as a Hobby ", Description = "Many developers work on code outside of work. About 78% of our respondents say that they code as a hobby. Other responsibilities outside of software can reduce developers' engagement in coding as a hobby; developers who say they have children or other caretaking responsibilities are less likely to code as a hobby. Respondents who are women are also less likely to say they code as a hobby." });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Question>().HasData(new Domain.Entities.Survey.Question { Id = 3, SurveyId = 1, Title = "Years Since Learning to Code ", Description = "Experience" });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 1, QuestionId = 1, Title = "Developer, back-end" });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 2, QuestionId = 1, Title = "Developer, front-end" });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 3, QuestionId = 1, Title = "Developer, desktop or enterprise applications " });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 4, QuestionId = 1, Title = "Developer, mobile " });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 5, QuestionId = 1, Title = "DevOps specialist" });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 6, QuestionId = 1, Title = "Database administrator " });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 7, QuestionId = 1, Title = "Designer" });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 8, QuestionId = 1, Title = "System administrator " });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 9, QuestionId = 1, Title = "Developer, embedded applications or devices" });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 10, QuestionId = 1, Title = "Data or business analyst " });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 11, QuestionId = 1, Title = "Data scientist or machine learning specialist " });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 12, QuestionId = 1, Title = "Developer, QA or test " });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 13, QuestionId = 1, Title = "Engineer, data" });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 14, QuestionId = 1, Title = "Academic researcher " });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 15, QuestionId = 1, Title = "Educator " });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 16, QuestionId = 1, Title = "Developer, game or graphics " });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 17, QuestionId = 1, Title = "Engineering manager " });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 18, QuestionId = 1, Title = "Product manager" });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 19, QuestionId = 1, Title = "Scientist" });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 20, QuestionId = 1, Title = "Engineer, site reliability" });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 21, QuestionId = 1, Title = "Senior executive/VP " });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 22, QuestionId = 1, Title = "Marketing or sales professional " });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 23, QuestionId = 1, Title = "Marketing or sales professional " });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 24, QuestionId = 2, Title = "Yes" });
            modelBuilder.Entity<Survey.Domain.Entities.Survey.Option>().HasData(new Domain.Entities.Survey.Option { Id = 25, QuestionId = 2, Title = "No " });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 26, QuestionId = 3, Title = "Less than 5 years " });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 27, QuestionId = 3, Title = "5 to 9 years" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 28, QuestionId = 3, Title = "10 to 14 years " });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 29, QuestionId = 3, Title = "15 to 19 years " });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 30, QuestionId = 3, Title = "20 to 24 years" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 31, QuestionId = 3, Title = "25 to 29 years" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 32, QuestionId = 3, Title = "30 to 34 years" });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 33, QuestionId = 3, Title = "35 to 39 years " });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 34, QuestionId = 3, Title = "40 to 44 years " });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 35, QuestionId = 3, Title = "45 to 49 years " });
            modelBuilder.Entity<Option>().HasData(new Option { Id = 36, QuestionId = 3, Title = "50 years or more" });
            //modelBuilder.Entity<Option>().HasData(new Option {Id=37,QuestionId=3,Title= "" });
        }
    }
}
