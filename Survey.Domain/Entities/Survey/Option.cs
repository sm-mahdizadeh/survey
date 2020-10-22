using Survey.Domain.Entities.Respond;
using System.Collections.Generic;

namespace Survey.Domain.Entities.Survey
{
    public class Option
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual Question Question { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
