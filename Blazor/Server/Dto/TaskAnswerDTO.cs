namespace Blazor.Server.Dto
{
    public class TaskAnswerDTO
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        public int TaskId { get; set; }
    }
}
