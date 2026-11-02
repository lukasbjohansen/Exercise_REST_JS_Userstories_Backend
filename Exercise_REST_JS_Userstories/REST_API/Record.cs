namespace REST_API
{
    public class Record
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Artist { get; set; } = string.Empty;
        public int Duration { get; set; }
        public int PublicationYear { get; set; }
        override public string ToString()
        {
            return $"Id: {Id}, Title: {Title}, Artist: {Artist}, Duration: {Duration}, PublicationYear: {PublicationYear}";
        }
    }
}
