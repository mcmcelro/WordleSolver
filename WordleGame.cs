namespace WordleSolver;

internal class WordleGame
{
    public string Alphabet { get; set; } = string.Empty;
    public string Needed { get; set; } = string.Empty;
    public string Found { get; set; } = string.Empty;
    public List<string> Played { get; set; } = [];
}
