# WordleSolver

WordleSolver is a simple C# console application which can provide possible guesses for the answer to a Wordle puzzle. The puzzle can be of arbitrary length and use an arbitrary character set.

## Usage

Create a file called game.json in the same folder as the application. This file should have the format of:

```json
{
  "Alphabet": "ABCDEFGHIJKLMNOPQRSTUVWXYZ", // use whatever character set you want
  "Needed": "ABR", // all of the characters that you've found that are not in the right place
  "Found": "_U___", // all of the characters that you've found in the right place, with underscore '_' as a placeholder for unknown characters
  "Played": [ // a list of guesses played so far
    "QUOTE",
	"BURLS",
	"FUBAR"
  ]
}
```

## Output

The program will output a list of all "valid" Wordle guesses given the information you've provided. This takes into consideration:

1. The guesses played so far
2. The found characters so far
3. The known characters that are not yet in the right place

It skips any answers that are missing known or found characters.

Note that it doesn't validate that the guess is an actual word (hence "valid" being in quotation marks above).

## License

[MIT](https://choosealicense.com/licenses/mit/)