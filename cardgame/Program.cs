int cardsValue;
Random rnd = new Random();
List<Card> cards = new List<Card>() {new Card(), new Card()};
List<Card> dealerCards = new List<Card>() {new Card(), new Card()};

for (int i = 0; i < cards.Count; i++)
{
    cards[i].type = cards[i].types[rnd.Next(4)];
    cards[i].value = rnd.Next(2, 10);
    dealerCards[i].type = dealerCards[i].types[rnd.Next(4)];
    dealerCards[i].value = rnd.Next(2, 10);
}

intro();

void intro() {
    //Console.Clear();
    Console.WriteLine("What cardgame would you like to play?");
    Console.WriteLine("Current choices\n<------|------>\nBlackjack\n\nPlease choose what you would like to play:");
    string choice = Console.ReadLine().ToLower();
    if (choice == "blackjack") {
        dealingBlackjack();
    }
    else {
        Console.WriteLine("That is not a valid choice");
        intro();
    }
}

void dealingBlackjack() {
    Console.Clear();
    Console.WriteLine("Welcome to Blackjack!\n");
    //Console.WriteLine("Please place your bets");
    Console.WriteLine("Generating cards...\nYour cards are:");
    Console.WriteLine(cards[0].type + " " + cards[0].value);
    Console.WriteLine(cards[1].type + " " + cards[1].value);
    Console.WriteLine("\nThe dealer cards are:");
    Console.WriteLine(dealerCards[0].type + " " + dealerCards[0].value);
    Console.WriteLine("Hidden  Hidden");
    if (cards[0].value + cards[1].value == 21) {
        Console.WriteLine("You got a blackjack!");
    }
    if (dealerCards[0].value + dealerCards[1].value == 21) {
        Console.WriteLine("The dealer got a blackjack!");
    }
    blackjack();
}

void blackjack() {
    cardsValue = 0;
    for (int i = 0; i < cards.Count; i++)
    {
        Console.WriteLine(cards[i].value);
        cardsValue += cards[i].value;
    }
    Console.WriteLine($"You currently have {cardsValue}");
    Console.WriteLine($"The dealer has {dealerCards[0].value}");
    Console.WriteLine("\nWhat would you like to do?\nHit\nStand\nDouble Down");
    string choice = Console.ReadLine().ToLower();
    if (choice == "hit") {
        blackjackHit();
    }

    if (choice == "stand") {
        blackjackStand();
    }
}

void blackjackHit () {
    Console.Clear();
    cards.Add(new Card());
    cards[cards.Count - 1].value = rnd.Next(2, 10);
    blackjack();
}

void blackjackStand () {
    Console.Clear();
}


Console.ReadLine();