using Survey.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Domain.Entities.Respond
{
    public class Respond
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public int? UserId { get; set; }
        public string UserIp { get; set; }
        public string UserInfo { get; set; }
        public virtual User User { get; set; }
        public virtual Survey.Survey Suurvey { get; set; }
        public DateTime CreateDate { get; set; }

      //  public virtual ICollection<Answer> Answers { get; set; }
    }
}
