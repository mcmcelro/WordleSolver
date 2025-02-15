using System.Text.Json;
using WordleSolver;

HashSet<string> guesses = [];
WordleGame? game = JsonSerializer.Deserialize<WordleGame>(File.Open("game.json", FileMode.Open, FileAccess.Read));
if (game != null)
{
    int gameSize = game.Found.Length;
    char[] answer = new char[gameSize];

    for (int i = 0; i < gameSize; i++)
    {
        answer[i] = game.Found[i] != '_' ? game.Found[i] : answer[i];
    }

    game.Played.ForEach(w =>
    {
        for (int i = 0; i < w.Length; i++)
        {
            game.Alphabet = ((answer[i] == w[i]) || (answer[i] != w[i] && !game.Needed.Contains(w[i]))) ? game.Alphabet.Replace($"{w[i]}", string.Empty) : game.Alphabet;
        }
    });

    game.Alphabet = string.Join(string.Empty, (game.Alphabet + game.Found.Replace("_", string.Empty)).Distinct());

    placeCharacters(answer, 0);
    guesses.ToList().ForEach(Console.WriteLine);
}

void placeCharacters(char[] answer, int position)
{
    for (int i = position; i < answer.Length; i++)
    {
        for (int a = 0; a < game.Alphabet.Length; a++)
        {
            if (game.Found[i] != '_')
            {
                continue;
            }
            if (game.Alphabet[a].canBePlayedAt(game, i))
            {
                answer[i] = game.Alphabet[a];
                if (!answer.Contains('\0') && game.Needed.ToList().FindAll(c => answer.Contains(c)).Count == game.Needed.Length)
                {
                    if(!guesses.Contains(new string(answer))) {
                        guesses.Add(new string(answer));
                    }
                }
                placeCharacters(answer, i + 1);
            }
        }
    }
}