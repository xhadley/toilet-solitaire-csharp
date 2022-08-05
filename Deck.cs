namespace ToiletSolitaire;


public class Deck
{
    private static Random rng = new Random();


    private List<Card> cards = new List<Card>();


    public Deck()
    {
        foreach (var suit in Enum.GetValues<Suit>())
            foreach (var value in Enum.GetValues<Value>())
                cards.Add(new Card(suit, value));
    }


    public Deck(Deck otherDeck)
    {
        foreach (var card in otherDeck.cards)
            cards.Add(card);
    }


    public bool IsEmpty => cards.Count == 0;


    public void Shuffle()
    {
        int n = cards.Count;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            var card = cards[k];
            cards[k] = cards[n];
            cards[n] = card;
        }
    }


    public Card Draw()
    {
        var card = cards[cards.Count - 1];
        cards.RemoveAt(cards.Count - 1);
        return card;
    }


    public override string ToString() => string.Join<Card>(' ', cards);
}