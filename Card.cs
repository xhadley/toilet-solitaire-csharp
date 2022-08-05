namespace ToiletSolitaire;


public class Card
{
    public Card(Suit suit, Value value)
    {
        Suit = suit;
        Value = value;
    }


    public Suit Suit { get; }
    public Value Value { get; }


    public override string ToString() => $"{Value}-{Suit}";
}


public enum Suit { Spade, Heart, Diamond, Club }
public enum Value { Ace, King, Queen, Jack, Ten, Nine, Eight, Seven, Six, Five, Four, Three, Two }