namespace Archive.Models
{
    public class CreateItemRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Year { get; set; }
        public string? Field { get; set; }
        public Genres Genre { get; set; }
        public int CountryId { get; set; }
    }
}
