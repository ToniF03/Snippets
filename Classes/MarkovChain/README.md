MarkovChain
===========

Description: Simple Markov chain data structure for counting transitions between integer states and predicting next states.

File: `MarkovChain.cs`

Details:
- Stores transitions as a dictionary of dictionaries: `_markovChain[from][to] = count`.
- Methods: `addTransition(from,to)`, `getTransition(from,to)`, `getMostCommonTransition(from)`, `clear()`, `saveMarkovChain(path)`, `loadMarkovChain(path)`.

Usage example:
```csharp
var mc = new MarkovChain();
mc.addTransition(1, 2);
mc.addTransition(1, 3);
int predicted = mc.getMostCommonTransition(1);
mc.saveMarkovChain("chain.json");
```

Notes:
- Persistence uses JSON serialization. Keys are integers; adjust if you need string states.