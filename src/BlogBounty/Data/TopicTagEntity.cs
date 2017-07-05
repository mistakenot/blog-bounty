namespace BlogBounty.Data
{
    public class TopicTagEntity
    {
        public int Id { get; set; }

        public int TopicId { get; set; }
        public TopicEntity Topic { get; set; }

        public int TagId { get; set; }
        public TagEntity Tag { get; set; }
    }
}