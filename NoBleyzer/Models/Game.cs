namespace NoBleyzer.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string NameGame { get; set; }
        public int Price { get; set; }


        public int PlayerId { get; set; }
        public List<Player> Player { get; set; }
    }
}
