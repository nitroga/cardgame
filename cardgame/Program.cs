int cardsValue = 0;
int dealerValue = 0;
List<Card> cards = new List<Card>() {new Card(), new Card()};
List<Card> dealerCards = new List<Card>() {new Card(), new Card()};

intro();

void intro() {
    Console.Clear();
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
    Console.WriteLine("Generating cards...\nYour cards are:");
    Console.WriteLine(cards[0].type + " " + cards[0].value);
    Console.WriteLine(cards[1].type + " " + cards[1].value);
    Console.WriteLine("\nThe dealer cards are:");
    Console.WriteLine(dealerCards[0].type + " " + dealerCards[0].value);
    Console.WriteLine("Hidden  Hidden");
    blackjack();
}

void blackjack() {
    cardsValue = 0;
    for (int i = 0; i < cards.Count; i++)
    {
        cardsValue += cards[i].value;
    }
    if (cardsValue >= 21 || dealerValue >= 21) {
        blackjackStand();
    }
    else {
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
    }
    else if (cardsValue > dealerValue || cardsValue < 22 && dealerValue > 21) {
        Console.WriteLine("You won");
    }
    else if (cardsValue < dealerValue || cardsValue > 21 && dealerValue < 22) {
        Console.WriteLine("Dealer won");
    }
    else {
        Console.WriteLine("Error");
    }
    Console.WriteLine("Type 'print' to check the value of all cards");
    string action = Console.ReadLine().ToLower();
    if (action == "print") {
        for (int i = 0; i < cards.Count; i++)
        {
            Console.WriteLine(cards[i].value);
        }
        for (int i = 0; i < dealerCards.Count; i++)
        {
            Console.WriteLine(dealerCards[i].value);
        }
    }
}
Console.ReadLine();