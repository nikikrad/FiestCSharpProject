namespace NoBleyzer.Models
{
    public class Player
    {
        public int Id { get; set; } 
        public string Nickname { get; set; }

        
        public int GameId { get; set; }
        public List<Game> Game { get; set; }
    }
}
