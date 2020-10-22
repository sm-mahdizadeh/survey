using Survey.Domain.Entities.Survey;

namespace Survey.Domain.Entities.Respond
{
    public class Answer
    {
        public int Id { get; set; }
        public int RespondId { get; set; }
        public int OptionId { get; set; }
        public virtual Respond Reespond { get; set; }
        public virtual Option Option { get; set; }


    }
}
