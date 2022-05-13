namespace Archive.Models
{
    public class CreateCollectionItemRequest
    {
        public int Id { get; set; }

        public int? CollectionId { get; set; }

        public int? ItemId { get; set; }
    }
}
