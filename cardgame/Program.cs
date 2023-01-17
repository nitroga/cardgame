global using System.Text.Json;

string fileName = "Players.json";
List<Card> cards = new List<Card>();
List<Card> dealerCards = new List<Card>();
Player player = JsonSerializer.Deserialize<Player>(File.ReadAllText(fileName));

start();

void start() {
    Console.Clear();
    Console.WriteLine("Welcome!\n");
    Console.WriteLine("Please input name");
    string nameChoice = Console.ReadLine();
    if (player.name == nameChoice) {
        Console.WriteLine("Character already exists\nPlease enter password to login.");
        if (Console.ReadLine() == player.password) {
            File.WriteAllText(fileName, JsonSerializer.Serialize<Player>(player));
            Blackjack b = new Blackjack();
            b.intro();
        }
        else {
            start();
        }
    }
    else {
        Console.WriteLine("Please type a password (can be empty)");
        player.password = Console.ReadLine();
        player.name = nameChoice;
        player.chips = 5000;
        File.WriteAllText(fileName, JsonSerializer.Serialize<Player>(player));
        Blackjack b = new Blackjack();
        b.intro();
    }
}