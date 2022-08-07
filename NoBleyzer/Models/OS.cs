namespace NoBleyzer.Models
{
    public class OS
    {
        public int Id { get; set; }
        public string NameOS { get; set; }
        public List<PC> PC { get; set; }
    }
}
