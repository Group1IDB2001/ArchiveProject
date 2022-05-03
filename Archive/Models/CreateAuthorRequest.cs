namespace Archive.Models
{
    public class CreateAuthorRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Born { get; set; }
        public int? Death { get; set; }
        public string? About { get; set; }
    }
}
