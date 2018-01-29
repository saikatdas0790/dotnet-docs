using System;
using System.Collections.Generic;
using System.Linq;

namespace FaroShuffle
{
    class Program
    {
        static void Main(string[] args)
        {
            var startingDeck = (from s in Suits().LogQuery("Suit Generation")
                               from r in Ranks().LogQuery("Rank Generation")
                               select new PlayingCard(s, r)).LogQuery("Starting Deck").ToArray();

            foreach (var c in startingDeck)
            {
                Console.WriteLine(c);
            }
            Console.WriteLine();


            //var top = startingDeck.Take(26);
            //var bottom = startingDeck.Skip(26);
            //var shuffle = top.InterleaveSequenceWith(bottom);

            //foreach (var c in shuffle)
            //{
            //    Console.WriteLine(c);
            //}
            //Console.WriteLine();


            var times = 0;
            var shuffle = startingDeck;

            do
            {
                // In shuffle
                //shuffle = shuffle.Take(26).LogQuery("Top Half").InterleaveSequenceWith(shuffle.Skip(26).LogQuery("Bottom Half")).LogQuery("Shuffle").ToArray();

                // Out shuffle
                shuffle = shuffle.Skip(26).LogQuery("Bottom Half").InterleaveSequenceWith(shuffle.Take(26).LogQuery("Top Half")).LogQuery("Shuffle").ToArray();

                foreach (var c in shuffle)
                {
                    Console.WriteLine(c);
                }

                times++;
                Console.WriteLine(times);
            } while (!startingDeck.SequenceEquals(shuffle));

            Console.WriteLine("\n\n");
            Console.WriteLine(times);
        }

        //static IEnumerable<string> Suits()
        //{
        //    yield return "clubs";
        //    yield return "diamonds";
        //    yield return "hearts";
        //    yield return "spades";
        //}

        static IEnumerable<Suit> Suits() => Enum.GetValues(typeof(Suit)) as IEnumerable<Suit>;

        //static IEnumerable<string> Ranks()
        //{
        //    yield return "two";
        //    yield return "three";
        //    yield return "four";
        //    yield return "five";
        //    yield return "six";
        //    yield return "seven";
        //    yield return "eight";
        //    yield return "nine";
        //    yield return "ten";
        //    yield return "jack";
        //    yield return "queen";
        //    yield return "king";
        //    yield return "ace";
        //}

        static IEnumerable<Rank> Ranks() => Enum.GetValues(typeof(Rank)) as IEnumerable<Rank>;
    }

    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }

    public enum Rank
    {
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public class PlayingCard
    {
        public Suit CardSuit { get; }
        public Rank CardRank { get; }

        public PlayingCard(Suit s, Rank r)
        {
            CardSuit = s;
            CardRank = r;
        }

        public override string ToString()
        {
            return $"{CardRank} of {CardSuit}";
        }
    }
}
