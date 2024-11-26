
/// <summary>
/// Implements a simple tokenizer that can learn and use a vocabulary for tokenization.
/// This class provides functionality similar to Byte Pair Encoding (BPE) algorithm.
/// </summary>
public class SimpleTokenizer
{
    /// <summary>
    /// Dictionary to store the vocabulary, mapping tokens to their unique IDs.
    /// </summary>
    private readonly Dictionary<string, int> _vocabulary;

    /// <summary>
    /// Counter to keep track of the next available token ID.
    /// </summary>
    private int _nextTokenId;

    /// <summary>
    /// Initializes a new instance of the SimpleTokenizer class.
    /// </summary>
    public SimpleTokenizer()
    {
        _vocabulary = new Dictionary<string, int>();
        _nextTokenId = 0;
    }

    /// <summary>
    /// Adds a new token to the vocabulary if it doesn't already exist.
    /// </summary>
    /// <param name="token">The token to add to the vocabulary.</param>
    public void AddToVocabulary(string token)
    {
        // If the token is not in the vocabulary, add it with a new unique ID
        if (!_vocabulary.ContainsKey(token))
        {
            _vocabulary[token] = _nextTokenId++;
        }
    }

    /// <summary>
    /// Trains the tokenizer on a list of texts, merging frequent pairs up to maxMerges times.
    /// This method implements the core learning process of the tokenizer.
    /// </summary>
    /// <param name="texts">The list of texts to train on.</param>
    /// <param name="maxMerges">The maximum number of merges to perform. ie new tokens to add</param>
    public void Train(List<string> texts, int maxMerges)
    {
        // Set to keep track of merged pairs to avoid duplicates
        var mergedPairs = new HashSet<string>();

        for (int i = 0; i < maxMerges; i++)
        {
            string text = string.Join("", texts);
            // Find the most frequent pair of tokens in the texts
            var pairs = GetMostFrequentPair(text);

            // If no pairs are found, exit the training loop
            if (pairs.Item1 == null)
            {
                Console.WriteLine("No more pairs to merge. Exiting.");
                break;
            }

            // Create a new token by concatenating the pair
            string newToken = pairs.Item1 + pairs.Item2;

            // Check if this pair has already been merged
            if (mergedPairs.Contains(newToken))
            {
                Console.WriteLine($"Skipping already merged pair: ({pairs.Item1}, {pairs.Item2})");
                continue;
            }

            // Add the new token to the vocabulary
            AddToVocabulary(newToken);
            mergedPairs.Add(newToken);

            // Replace all occurrences of the pair with the new token in all texts
            for (int j = 0; j < texts.Count; j++)
            {
                texts[j] = texts[j].Replace(pairs.Item1 + pairs.Item2, newToken);
            }
        }
    }

    /// <summary>
    /// Tokenizes a given text using the learned vocabulary.
    /// </summary>
    /// <param name="text">The text to tokenize.</param>
    /// <returns>A list of tokens.</returns>
    public List<string> Tokenize(string text)
    {
        var tokens = new List<string>();
        int i = 0;

        while (i < text.Length)
        {
            string bestToken = null;

            // Find the longest matching token in the vocabulary
            foreach (var token in _vocabulary.Keys)
            {
                if (text.Substring(i).StartsWith(token) && (bestToken == null || token.Length > bestToken.Length))
                {
                    bestToken = token;
                }
            }

            // If a matching token is found, add it to the result
            if (bestToken != null)
            {
                tokens.Add(bestToken);
                i += bestToken.Length;
            }
            else
            {
                // If no match is found, add the current character as a single-character token
                tokens.Add(text[i].ToString());
                i++;
            }
        }

        return tokens;
    }

    /// <summary>
    /// Encodes a text into a list of token IDs.
    /// </summary>
    /// <param name="text">The text to encode.</param>
    /// <returns>A list of token IDs.</returns>
    public List<int> Encode(string text)
    {
        // First tokenize the text, then convert each token to its ID
        var tokens = Tokenize(text);
        return tokens.Select(t => _vocabulary[t]).ToList();
    }

    /// <summary>
    /// Decodes a list of token IDs back into text.
    /// </summary>
    /// <param name="ids">The list of token IDs to decode.</param>
    /// <returns>The decoded text.</returns>
    public string Decode(List<int> ids)
    {
        // Create an inverse vocabulary mapping IDs to tokens
        var inverseVocab = _vocabulary.ToDictionary(kvp => kvp.Value, kvp => kvp.Key);
        // Convert each ID back to its token and join them into a single string
        return string.Join("", ids.Select(id => inverseVocab[id]));
    }

    /// <summary>
    /// Finds the most frequent pair of tokens in the given texts.
    /// This is a helper method used in the training process.
    /// </summary>
    /// <param name="textData">The tokenized training data</param>
    /// <returns>A tuple containing the most frequent pair of tokens, or null if no pairs are found.</returns>
    private Tuple<string, string> GetMostFrequentPair(string textData)
    {
        var pairCounts = new Dictionary<Tuple<string, string>, int>();

        var tokens = Tokenize(textData);

        for (int i = 0; i < tokens.Count - 1; i++)
        {
            var pair = Tuple.Create(tokens[i], tokens[i + 1]);

            // Skip pairs with empty tokens or invalid pairs
            // We only want spaces at the start of our tokens not inbetween
            if (string.IsNullOrWhiteSpace(pair.Item2) ||
                (pair.Item1.Contains(" ") && !pair.Item1.StartsWith(" ")) ||
                pair.Item2.Contains(" "))
            {
                continue;
            }

            // Count the occurrences of each pair
            if (!pairCounts.ContainsKey(pair))
                pairCounts[pair] = 0;
            pairCounts[pair]++;
        }
        // If no pairs are found, return null
        if (pairCounts.Count == 0)
            return Tuple.Create<string, string>(null, null);

        // Return the most frequent pair
        return pairCounts.OrderByDescending(p => p.Value).First().Key;
    }
}
