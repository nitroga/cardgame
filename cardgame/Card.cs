public class Card
{
    Random rnd = new Random();
    public List<string> types = new List<string>() {"Heart", "Club", "Spade", "Diamond"};
    public int value { get; set; }
    public string type { get; set; }

    public Card() {
        value = rnd.Next(2, 10);
        type = types[rnd.Next(4)];
    }
}
