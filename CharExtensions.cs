namespace WordleSolver;

internal static class CharExtensions
{
    internal static bool canBePlayedAt(this char c, WordleGame game, int i)
    {
        return game.Found[i] == '_' && !game.Played.Any(w => w[i] == c);
    }
}
