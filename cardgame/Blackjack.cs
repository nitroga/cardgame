public class Blackjack
{
int cardsValue = 0;
int dealerValue = 0;
int betChoice;
bool betFail = false;
List<Card> cards = new List<Card>();
List<Card> dealerCards = new List<Card>();
Player player = JsonSerializer.Deserialize<Player>(File.ReadAllText("Players.json"));

internal void intro() {
    Console.Clear();
    Console.WriteLine("What cardgame would you like to play?");
    Console.WriteLine("Current choices\n<------|------>\nBlackjack\n\nPlease choose what you would like to play:");
    string choice = Console.ReadLine().ToLower();
    if (choice != "blackjack") {
        intro();
    }
    else {
        dealingBlackjack();
    }
}

void dealingBlackjack() {
    Console.Clear();
    if (betFail) {
        Console.WriteLine("Input a valid bet");
        betFail = false;
    }
    Console.WriteLine($"Welcome to Blackjack!\nYou have {player.chips} chips\n");
    Console.WriteLine("Please place your bets");
    bool parse = int.TryParse(Console.ReadLine(), out betChoice);
    if (!parse || betChoice == 0 || betChoice > player.chips) {
        betFail = true;
        dealingBlackjack();
    }
    else {
        player.chips-=betChoice;
    }
    Console.WriteLine("Generating cards...\nYour cards are:");
    cards.Clear();
    dealerCards.Clear();
    for (int i = 0; i < 2; i++)
    {
        cards.Add(new Card());
        dealerCards.Add(new Card());
    }
    Console.WriteLine(cards[0].type + " " + cards[0].value);
    Console.WriteLine(cards[1].type + " " + cards[1].value);
    Console.WriteLine("\nThe dealer cards are:");
    Console.WriteLine(dealerCards[0].type + " " + dealerCards[0].value);
    Console.WriteLine("Hidden  Hidden");
    blackjack();
}

void blackjack() {
    cardsValue = 0;
    dealerValue = 0;
    for (int i = 0; i < cards.Count; i++)
    {
        cardsValue += cards[i].value;
    }
    for (int i = 0; i < dealerCards.Count; i++)
    {
        dealerValue += dealerCards[i].value;
    }
    if (cardsValue >= 21 || dealerValue >= 21) {
        blackjackStand();
    }
    else if (cardsValue > 21) {
        for (int i = 0; i < cards.Count; i++)
        {
            if (cards[i].value == 11) {
                cards[i].value = 1;
            }
        }
        blackjack();
    }
    else {
        Console.Clear();
        Console.WriteLine($"You currently have {cardsValue}");
        Console.WriteLine($"The dealer has {dealerCards[0].value}");
        Console.WriteLine("\nWhat would you like to do?\nHit\nStand");
        string choice = Console.ReadLine().ToLower();
        if (choice == "hit") {
            blackjackHit();
        }

        if (choice == "stand") {
            blackjackStand();
        }
    }
}

void blackjackHit() {
    Console.Clear();
    cards.Add(new Card());
    blackjack();
}

void blackjackStand() {
    Console.Clear();
    dealerValue = 0;
    for (int i = 0; i < dealerCards.Count; i++)
    {
        dealerValue += dealerCards[i].value;
    }
    if (dealerValue < 17) {
        dealerCards.Add(new Card());
        blackjackStand();
    }
    else {
        blackjackEnd();
    }
}

void blackjackEnd() {
    Console.Clear();
    Console.WriteLine("The game is now over!");
    cardsValue = dealerValue = 0;
    for (int i = 0; i < cards.Count; i++)
    {
        cardsValue += cards[i].value;
    }
    for (int i = 0; i < dealerCards.Count; i++)
    {
        dealerValue += dealerCards[i].value;
    }
    Console.WriteLine($"You have: {cardsValue}");
    Console.WriteLine($"The dealer has: {dealerValue}\n");
    if (cardsValue > 21 && dealerValue > 21 || cardsValue == dealerValue) {
        Console.WriteLine("Noone won");
        player.chips += betChoice;
    }
    else if (cardsValue > dealerValue && cardsValue < 22 || dealerValue > 21) {
        Console.WriteLine("You won");
        player.chips += betChoice * 2;
    }
    else if (cardsValue < dealerValue && cardsValue > 21 || dealerValue < 22) {
        Console.WriteLine("Dealer won");
    }
    File.WriteAllText("Players.json", JsonSerializer.Serialize<Player>(player));
    Console.WriteLine("\nWhat would you like to do?");
    Console.WriteLine("(1) Play again");
    Console.WriteLine("(2) Play another game");
    Console.WriteLine("Press enter to quit");
    string choice = Console.ReadLine();
    if (choice == "1") {
        dealingBlackjack();
    }
    else if (choice == "2") {
        intro();
    }
}   
}
