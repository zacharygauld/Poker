using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Play();
        }

        static void Play()
        {
            Deck deck = new Deck();
            int index = 0;
            List<Player> ListOfPlayers = new List<Player>();
            List<Card> ShuffledDeck = new List<Card>();
            Random rng = new Random();

            Console.Write("How many players are playing? ");
            int numOfPlayers = int.Parse(Console.ReadLine());
            Console.WriteLine();
            while (index < numOfPlayers)
            {
                Console.Write("What is player {0}'s name? ", index + 1);
                ListOfPlayers.Add(new Player());
                ListOfPlayers[index].Name = Console.ReadLine();
                index++;
            }
            while (ShuffledDeck.Count() != 52)
            {
                index = rng.Next(0, deck.CardsInDeck.Count());
                ShuffledDeck.Add(deck.CardsInDeck[index]);
                deck.CardsInDeck.RemoveAt(index);
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < ListOfPlayers.Count(); j++)
                {
                    ListOfPlayers[j].Cards.Add(ShuffledDeck[0]);
                    ShuffledDeck.RemoveAt(0);
                }
            }
            Console.WriteLine();
            foreach (Player player in ListOfPlayers)
            {
                Console.WriteLine(player.Name);
                foreach (Card card in player.Cards)
                {
                    Console.WriteLine("{0} of {1}", card.CardValue, card.CardSuit);
                }
                Console.WriteLine();
            }
            foreach (Player player in ListOfPlayers)
            {
                Console.Write("Does {0} want to remove any cards? ", player.Name);
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

                    }

                }
            done: ;
            }
        }
    }
}
