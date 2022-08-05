namespace ToiletSolitaire;


public class Game
{
    private Deck deck = new Deck();
    private Deck deckCopy;


    public Game()
    {
        deck.Shuffle();
        deckCopy = new Deck(deck);
    }


    public List<Card> Hand { get; } = new List<Card>();


    public void Play()
    {
        while (!deck.IsEmpty) {
            Hand.Add(deck.Draw());
            if (Hand.Count < 4)
                continue;
            TryRemoveCards_();
        }

        var tries = 0;
        while (tries < 4 && Hand.Count >= 4) {
            Hand.Add(Hand[0]);
            Hand.RemoveAt(0);
            if (TryRemoveCards_())
                tries = 0;
            else tries++;
        }
    }


    private bool TryRemoveCards_()
    {
        bool hasRemovedCards = false;
        while (Hand.Count >= 4) {
            if (Hand[Hand.Count - 1].Value == Hand[Hand.Count - 4].Value) {
                for (int i = 0; i < 4; i++)
                    Hand.RemoveAt(Hand.Count - 1);
                hasRemovedCards = true;
            }
            else if (Hand[Hand.Count - 1].Suit == Hand[Hand.Count - 4].Suit) {
                for (int i = 0; i < 2; i++)
                    Hand.RemoveAt(Hand.Count - 2);
                hasRemovedCards = true;
            }
            else break;
        }
        return hasRemovedCards;
    }
}