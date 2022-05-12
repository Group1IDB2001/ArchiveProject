namespace Archive.Models
{
    public class CreateLikeRequest
    {
        public int Id { get; set; }

        public int? UserId { get; set; }

        public int? ItemId { get; set; }
    }
}
