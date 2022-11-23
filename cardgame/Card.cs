public class Card
{
    public Random rnd = new Random();
    public List<string> types = new List<string>() {"Heart", "Club", "Spade", "Diamond"};
    public int value { get; set; }
    public string type { get; set; }
}
