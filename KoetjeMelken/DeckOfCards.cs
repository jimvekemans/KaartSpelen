using System;
using System.Collections.Generic;

namespace KoetjeMelken
{
    public class DeckOfCards
    {
        Stack<Card> deck;

        Array suits = Enum.GetValues(typeof(CardSuit));
        Array ranks = Enum.GetValues(typeof(CardRank));

        public DeckOfCards() {
            deck = new Stack<Card>(52);
            foreach (CardSuit s in suits)
            {
                foreach (CardRank r in ranks) {
                    deck.Push(new Card(s,r));
                }
            }
        }

        internal void shuffle()
        {
            //eerst vullen we een array willekeurig in met de kaarten van het deck
            Random r = new Random();
            Card[] cardArr = deck.ToArray();
            for (int count = cardArr.Length - 1; count > 0; --count)
            {
                int randInt = r.Next(count + 1);
                Card temp = cardArr[count];
                cardArr[count] = cardArr[randInt];
                cardArr[randInt] = temp;
            }

            //na het shuffelen steken we de kaarten over van array naar de (leeggemaakte) stack
            deck = new Stack<Card>(52);
            foreach (Card c in cardArr)
            {
                deck.Push(c);
            }
        }
    }

    class Card
    {
        public CardSuit Suit { get; }
        public CardRank Rank { get; }

        public Card(CardSuit suit, CardRank rank)
        {
            if (suit < CardSuit.Spades || suit > CardSuit.Clubs || rank < CardRank.Two || rank > CardRank.Ace)
            {
                throw new IndexOutOfRangeException();
            }
            Suit = suit;
            Rank = rank;
        }
    }
    public enum CardSuit
    {
        Spades,
        Hearts,
        Diamonds,
        Clubs
    }
    public enum CardRank
    {
        Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten,
        Jack, Queen, King, Ace
    }
}
