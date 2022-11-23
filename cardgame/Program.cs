Card c = new Card();
Card cTwo = new Card();
Card dealerC = new Card();
Card dealerCtwo = new Card();
Random rnd = new Random();
for (int i = 0; i < 3; i++)
{
    
}
c.value = rnd.Next(2, 10);
c.type = c.types[rnd.Next(4)];
cTwo.value = rnd.Next(2, 10);
cTwo.type = c.types[rnd.Next(4)];
dealerC.value = rnd.Next(2, 10);
dealerC.type = c.types[rnd.Next(4)];
dealerCtwo.value = rnd.Next(2, 10);
dealerCtwo.type = c.types[rnd.Next(4)];

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
    Console.WriteLine("Welcome to Blackjack!\n");
    //Console.WriteLine("Please place your bets");
    Console.WriteLine("Generating cards...\nYour cards are:");
    Console.WriteLine(c.type + " " + c.value);
    Console.WriteLine(cTwo.type + " " + cTwo.value);
    Console.WriteLine("\nThe dealer cards are:");
    Console.WriteLine(dealerC.type + " " + dealerCtwo.value);
    Console.WriteLine("Hidden  Hidden");

}

Console.ReadLine();