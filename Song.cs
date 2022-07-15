namespace RhythmsGonnaGetYou
{
    public class Song
    {
        public int Id { get; set; }
        public int TrackNumber { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        //this is a property that gives you back the Album object for this song 
    }
}