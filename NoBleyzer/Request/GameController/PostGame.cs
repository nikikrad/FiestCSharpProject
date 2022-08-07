namespace NoBleyzer.Request.GameController
{
    public class PostGame
    {
        public string Title { get; set; }
        public int? Price { get; set; }
        public List<PlayerAdditional> Players { get; set; } 

    }
}
