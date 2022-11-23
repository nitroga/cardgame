Card card = new Card();
Random rnd = new Random();
card.value = rnd.Next(2, 10);

intro();

void intro() {
    Console.Clear();
    Console.WriteLine("What cardgame would you like to play?");
    Console.WriteLine("Current choices\n<------|------>\nBlackjack\n\nPlease choose what you would like to play:");
    string choice = Console.ReadLine().ToLower();
    if (choice == "blackjack") {
        blackjack();
    }
    else {
        Console.WriteLine("That is not a valid choice");
        intro();
    }
}

void blackjack() {
    Console.Clear();
    Console.WriteLine("Welcome to Blackjack!");
    Console.WriteLine(card.type);
    Console.WriteLine(card.value);
}



Console.ReadLine();