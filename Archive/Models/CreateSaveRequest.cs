namespace Archive.Models
{
    public class CreateSaveRequest
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? CollectionId { get; set; }
    }
}
