using System.Collections.Generic;

namespace Survey.Domain.Entities.Survey
{
    public class Question
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual Survey Survey { get; set; }
        public virtual ICollection<Option> Options { get; set; }
    }
}
