namespace Archive.Models
{
    public class CreateTtagItemRequest
    {
        public int Id { get; set; }

        public int? TtagId { get; set; }

        public int? ItemId { get; set; }
    }
}
