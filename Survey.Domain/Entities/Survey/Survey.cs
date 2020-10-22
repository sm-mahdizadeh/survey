using Survey.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Survey.Domain.Entities.Survey
{
    public class Survey
    {
        public int Id { get; set; }
        public string   Title { get; set; }
        public string   Description { get; set; }
        public bool IsActive { get; set; } = true;
        public bool IsRemoved { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime CreateDate { get; set; }

        public virtual ICollection<Question> Questions { get; set; }

        public virtual ICollection<Respond.Respond> Responds { get; set; }
    }
}
