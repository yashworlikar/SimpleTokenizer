# Simple Tokenizer 🔤🧩

## Overview

`SimpleTokenizer` is a C# implementation of a Byte Pair Encoding (BPE) tokenization algorithm designed to learn and generate a vocabulary from training texts. This console application demonstrates how to build a custom tokenizer that can break down text into meaningful tokens and assign unique IDs to them.

## Features

- Dynamic vocabulary learning
- Byte Pair Encoding (BPE)-like token merging
- Tokenization of input texts
- Encoding and decoding of tokens
- Support for special tokens

## How It Works

The tokenizer learns by:
1. Starting with individual characters
2. Iteratively merging the most frequent token pairs
3. Creating new tokens based on these frequent pairs
4. Building a vocabulary with unique token IDs

### Methods

- `AddToVocabulary()`: Add new tokens to the vocabulary
- `Train()`: Learn tokens by merging frequent pairs
- `Tokenize()`: Break text into tokens
- `Encode()`: Convert tokens to their unique IDs
- `Decode()`: Convert token IDs back to text

## Example Usage

```csharp
// Initialize tokenizer
var tokenizer = new SimpleTokenizer();

// Add initial character vocabulary
string chars = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=[]{}|;:'\",.<>?/";
foreach (char c in chars)
{
    tokenizer.AddToVocabulary(c.ToString());
}

// Provide training texts
var trainingTexts = new List<string> { 
    "A Hare was making fun of the Tortoise...", 
    "The Tale of Hazel and the Enchanted Meadow..." 
};

// Train the tokenizer
tokenizer.Train(trainingTexts, maxMerges: 10);

// Tokenize and encode text
string inputText = "A rabbit was sleeping peacefully";
var tokens = tokenizer.Tokenize(inputText);
var tokenIds = tokenizer.Encode(inputText);
```

## Special Tokens

The application supports adding special tokens like `<|start|>` and `<|endoftext|>` for more complex text processing scenarios.

## Console Output

The application provides a visually appealing console output that displays:
- Tokens with colorful representation
- Corresponding token IDs
- Training progress



