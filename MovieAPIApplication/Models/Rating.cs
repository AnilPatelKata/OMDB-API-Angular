namespace MovieAPIApplication.Models
{
    public class Rating : IRating
    {
        public string Source { get; set; }
        public string Value { get; set; }
    }
}
