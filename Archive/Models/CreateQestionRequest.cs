namespace Archive.Models
{
    public class CreateQestionRequest
    {
        public int Id { get; set; }
        
        public string Text { get; set; }

        public int? UserId { get; set; }
    }
}
