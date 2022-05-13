namespace Archive.Models
{
    public class CreateResponseRequest
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? QestionId { get; set; }
        public int? UserId { get; set; }
        public int? ItemId { get; set; }
        public int? CollectionId { get; set; }

    }
}
