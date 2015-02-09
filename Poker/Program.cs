using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Play();
        }

        static void DisplayHands(List<Player> listOfPlayers)
        {
            foreach (Player player in listOfPlayers)
            {
                Console.WriteLine(player.Name);
                foreach (Card card in player.Cards)
                {
                    Console.WriteLine("{0} of {1}", card.CardValue, card.CardSuit);
                }
                Console.WriteLine();
            }
        }

        static void WriteShuffledDeckOrderToText(Card card)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\Admin\Desktop\ShuffledHandOrder.txt", true))
            {
                file.WriteLine("{0} of {1}", card.CardValue, card.CardSuit);
            }
        }

        static void Play()
        {
            Deck deck = new Deck();
            Deck shuffledDeck = new Deck();
            shuffledDeck.CardsInDeck = new List<Card>();
            int index = 0;
            List<Player> listOfPlayers = new List<Player>();
            CryptoRandom rng = new CryptoRandom();

            Console.Write("How many players are playing? ");
            int numOfPlayers = int.Parse(Console.ReadLine());
            Console.WriteLine();
            while (index < numOfPlayers)
            {
                Console.Write("What is player {0}'s name? ", index + 1);
                listOfPlayers.Add(new Player());
                listOfPlayers[index].Name = Console.ReadLine();
                index++;
            }
            while (shuffledDeck.CardsInDeck.Count() != 52)
            {
                index = rng.Next(0, deck.CardsInDeck.Count());
                shuffledDeck.CardsInDeck.Add(deck.CardsInDeck[index]);
                deck.CardsInDeck.RemoveAt(index);
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < listOfPlayers.Count(); j++)
                {
                    listOfPlayers[j].Cards.Add(shuffledDeck.CardsInDeck[0]);
                    shuffledDeck.CardsInDeck.RemoveAt(0);
                }
            }
            foreach (Card card in shuffledDeck.CardsInDeck)
            {
                WriteShuffledDeckOrderToText(card);
            }
            Console.Clear();
            DisplayHands(listOfPlayers);
            foreach (Player player in listOfPlayers)
            {
                int cardsToRemove = 0;
                Card card1 = null;
                Card card2 = null;
                Card card3 = null;
                Console.Write("\nDoes {0} want to remove any cards? ", player.Name);
                string input = Console.ReadLine();
                if (input == "Y" || input == "y")
                {
                    Console.Write("First card index to remove: ");
                    input = Console.ReadLine();
                    if (input == "")
                    {
                        goto done;
                    }
                    else
                    {
                        card1 = player.Cards[int.Parse(input)];
                        cardsToRemove++;
                    }
                    Console.Write("Second card index to remove: ");
                    input = Console.ReadLine();
                    if (input == "")
                    {
                        goto done;
                    }
                    else
                    {
                        card2 = player.Cards[int.Parse(input)];
                        cardsToRemove++;
                    }
                    Console.Write("Third card index to remove: ");
                    input = Console.ReadLine();
                    if (input == "")
                    {
                        goto done;
                    }
                    else
                    {
                        card3 = player.Cards[int.Parse(input)];
                        cardsToRemove++;
                    }
                }
            done:
                switch (cardsToRemove)
                {
                    case 1:
                        player.Cards.Remove(card1);
                        player.Cards.Add(shuffledDeck.CardsInDeck[0]);
                        shuffledDeck.CardsInDeck.RemoveAt(0);
                        break;
                    case 2:
                        player.Cards.Remove(card1);
                        player.Cards.Remove(card2);
                        player.Cards.Add(shuffledDeck.CardsInDeck[0]);
                        shuffledDeck.CardsInDeck.RemoveAt(0);
                        player.Cards.Add(shuffledDeck.CardsInDeck[0]);
                        shuffledDeck.CardsInDeck.RemoveAt(0);
                        break;
                    case 3:
                        player.Cards.Remove(card1);
                        player.Cards.Remove(card2);
                        player.Cards.Remove(card3);
                        player.Cards.Add(shuffledDeck.CardsInDeck[0]);
                        shuffledDeck.CardsInDeck.RemoveAt(0);
                        player.Cards.Add(shuffledDeck.CardsInDeck[0]);
                        shuffledDeck.CardsInDeck.RemoveAt(0);
                        player.Cards.Add(shuffledDeck.CardsInDeck[0]);
                        shuffledDeck.CardsInDeck.RemoveAt(0);
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine("\nNEW HANDS:\n");
            DisplayHands(listOfPlayers);
            Console.ReadKey();
        }
    }
}
