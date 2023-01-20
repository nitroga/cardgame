global using System.Text.Json;

Player player = JsonSerializer.Deserialize<Player>(File.ReadAllText("Players.json"));

start();

void start() {
    Console.Clear();
    Console.WriteLine("Welcome!\n");
    Console.WriteLine("Please input name");
    string nameChoice = Console.ReadLine();
    if (player.name == nameChoice) {
        Console.WriteLine("Character already exists\nPlease enter password to login.");
        if (Console.ReadLine() == player.password) {
            File.WriteAllText("Players.json", JsonSerializer.Serialize<Player>(player));
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
        File.WriteAllText("Players.json", JsonSerializer.Serialize<Player>(player));
        Blackjack b = new Blackjack();
        b.intro();
    }
}