namespace MyMusic.Api.Resources
{
    public class MusicResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ArtistResource Artist { get; set; }
    }
}