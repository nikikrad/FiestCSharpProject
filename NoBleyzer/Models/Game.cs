namespace NoBleyzer.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Price { get; set; }
        public List<Player> Player { get; set; }
    }
}
