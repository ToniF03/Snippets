Tokenizer

Description: Tokenizer class that converts input text into integer token sequences and back.

File: `Tokenizer.cs`

Details:
- Implements a simple vocabulary-based tokenizer that maps words to integer IDs.
- Tracks a limited vocabulary (default 20,000 words) and reserves `<start>` and `<end>` tokens.
- Supports configurable filters, split character, lowercasing, and punctuation handling.

Usage:
```csharp
var tokenizer = new uClasses.Tokenizer();
int[] sequence = tokenizer.tokenize("Hello world");
string[] words = tokenizer.detokenize(sequence);
tokenizer.saveTokens("tokens.json");
tokenizer.loadTokens("tokens.json");
```

Notes:
- `saveTokens` / `loadTokens` persist the internal token dictionary as JSON.
- Class is internal to `uClasses`; change visibility if you want to reuse it across projects.
