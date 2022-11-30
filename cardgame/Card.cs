public class Card
{
    Random rnd = new Random();
    public List<string> types = new List<string>() {"Heart", "Club", "Spade", "Diamond"};
    public int value { get; set; }
    public string type { get; set; }

    public Card() {
        value = rnd.Next(1, 13);
        if (value >= 11) {
            value = 10;
        }
        else if (value == 1) {
            value = 11;
        }
        type = types[rnd.Next(4)];
    }
}
