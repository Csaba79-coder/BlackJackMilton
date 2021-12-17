using System;

namespace BlackJackMilton
{
    class Program
    {
        static void Main(string[] args)
                {
            string namePlayer1;
            string namePlayer2;

            int player1Score;
            int player2Score;

            namePlayer1 = getUsername();
            welcomeMessage(namePlayer1);
            namePlayer2 = getUsername();
            welcomeMessage(namePlayer2);

            player1Score = startGame(namePlayer1);
            player2Score = startGame(namePlayer2);

            announcementOfResult(player1Score, namePlayer1, player2Score, namePlayer2);
        }


        public static int startGame(string name)
        {
            Random random = new Random();
            int sum = 0;
            int card;
            int cardValue;

            int startCard1 = getCard();
            int startCard2 = getCard();
            int cardValue1 = getCardValue(startCard1);
            int cardValue2 = getCardValue(startCard2);

            sum += cardValue1 + cardValue2;

            Console.WriteLine(getCardName(startCard1, name) + " & " + getCardName(startCard2, name));
            Console.WriteLine("Sum value of the cards: " + sum);

            if (sum == 22)
            {
                Console.WriteLine(name + ", you have BLACK JACK, two ACES!");
                return (sum - 1);
            }
            else if (sum < 21)
            {
                while(sum <= 16)
                {
                    card = random.Next(2, 15);
                    cardValue = getCardValue(card);
                    sum += cardValue;
                    Console.WriteLine(getCardName(card, name));
                    Console.WriteLine("Sum value of the cards: " + sum);

                } 

                while (sum > 16 && sum < 21)
                {
                    string answer;
                    Console.WriteLine(name + " would you like to get a new card? For yes - press: Y, for no - press: N!");
                    answer = Console.ReadLine();
                    switch (firstLetterToUpper(answer))
                    {
                        case "Y":
                            card = random.Next(2, 15);
                            cardValue = getCardValue(card);
                            sum += cardValue;
                            Console.WriteLine(getCardName(card, name));
                            return sum;

                        case "N":
                            Console.WriteLine(name + " you stopped with a sum of card value of " + sum);
                            sum += 0;
                            return sum;
                    }
                    return sum;
                }
                Console.WriteLine("Sum value of the cards: " + sum);
                return sum;
            }
            /*Console.WriteLine("Sum value of the cards: " + sum);*/
            return sum;
        }

        public static string getUsername()
        {
            string name;
            Console.WriteLine("Please enter the name of player: ");
            name = Console.ReadLine();
            name = firstLetterToUpper(name);
            return name;
        }

        public static string firstLetterToUpper(string str)
        {
            if (str == null)
            {
                return null;
            }

            if (str.Length > 1)
            {
                return char.ToUpper(str[0]) + str.Substring(1);
            }
            return str.ToUpper();
        }

        public static void welcomeMessage(string name)
        {
            Console.WriteLine("Hello: " + name);
        }

        public static int getCard()
        {
            Random random = new Random();
            int card = random.Next(2, 15);
            return card;
        }

        public static string getCardName(int card, string name)
        {
            if (card <= 10)
            {
                return name + ", your card is: " + card.ToString();
            }
            else if (card == 11)
            {
                return name + ", your card is: ACE";
            }
            else if (card == 12)
            {
                return name + ", your card is: JACK";
            }
            else if (card == 13)
            {
                return name + ", your card is: QUEEN";
            }
            else if (card == 14)
            {
                return name + ", your card is: KING";
            }
            return null;
        }

        public static int getCardValue(int card)
        {
            if (card <= 11)
            {
                return card;
            }
            else if (card == 12)
            {
                return 10;
            }
            else if (card == 13)
            {
                return 10;
            }
            else if (card == 14)
            {
                return 10;
            }
            return card;
        }

        public static void announcementOfResult(int score1, string name1, int score2, string name2)
        {
            if (score1 == score2)
            {
                Console.WriteLine("It's a tie!");
            }
            else if (score1 > score2 && score1 < 22)
            {
                Console.WriteLine("The winner is: " + name1);
            }
            else if (score1 < score2 && score2 < 22)
            {
                Console.WriteLine("The winner is: " + name2);
            }
            else if (score1 > 21 && score2 < 21)
            {
                Console.WriteLine("You both lost!");
            }
            else
            {
                Console.WriteLine("You both lost!");
            }
        }
    }
}
