namespace ToiletSolitaire;

public class Program
{
    static void Main(string[] args)
    {
        var results = new Dictionary<int, int>();
        for (int i = 0; i < 1000000; i++) {
            var game = new Game();
            game.Play();
            results.TryAdd(game.Hand.Count, 0);
            results[game.Hand.Count]++;
        }
        foreach (var kv in results.OrderBy(kv => kv.Key))
            Console.WriteLine($"{kv.Key:00}: {kv.Value}");
    }
}