var tokenizer = new SimpleTokenizer();

// Initilizing our vocab 
string chars = " ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=[]{}|;:'\",.<>?/";
foreach (char c in chars)
{
    tokenizer.AddToVocabulary(c.ToString());
}



//Training Data
var trainingTexts = new List<string> { "A Hare was making fun of the Tortoise one day for being so slow.\r\n\r\n\"Do you ever get anywhere?\" he asked with a mocking laugh.\r\n\r\n\"Yes,\" replied the Tortoise, \"and I get there sooner than you think. I'll run you a race and prove it.\"\r\n\r\nThe Hare was much amused at the idea of running a race with the Tortoise, but for the fun of the thing he agreed. So the Fox, who had consented to act as judge, marked the distance and started the runners off.\r\n\r\nThe Hare was soon far out of sight, and to make the Tortoise feel very deeply how ridiculous it was for him to try a race with a Hare, he lay down beside the course to take a nap until the Tortoise should catch up.\r\n\r\n\r\nThe Tortoise meanwhile kept going slowly but steadily, and, after a time, passed the place where the Hare was sleeping. But the Hare slept on very peacefully; and when at last he did wake up, the Tortoise was near the goal. The Hare now ran his swiftest, but he could not overtake the Tortoise in time." ,
"The Tale of Hazel and the Enchanted Meadow\r\n\r\nOnce upon a time, in a lush, green meadow surrounded by towering oak trees, lived a hare named Hazel. Hazel was not like the other hares in the meadow. She had a curious mind and a heart full of adventure. Her fur was a soft, tawny brown, and her eyes sparkled with a hint of mischief.\r\n\r\nEvery morning, Hazel would hop out of her cozy burrow and greet the day with a sense of wonder. She loved to explore the meadow, discovering new flowers, hidden streams, and secret paths. One sunny morning, as she was nibbling on some fresh clover, she overheard a conversation between two sparrows perched on a nearby branch.\r\n\r\n“Have you heard about the Enchanted Meadow?” chirped one sparrow.\r\n\r\n“Yes, it’s said to be a magical place where dreams come true,” replied the other.\r\n\r\nHazel’s ears perked up. An enchanted meadow? She had to find it! With a determined hop, she set off on her quest. She followed the winding paths, crossed babbling brooks, and ventured deeper into the forest than she ever had before.\r\n\r\nAs the sun began to set, casting a golden glow over the landscape, Hazel stumbled upon a clearing. In the center of the clearing was a meadow unlike any she had ever seen. The grass was a vibrant emerald green, and flowers of every color imaginable bloomed in abundance. The air was filled with the sweet scent of blossoms and the gentle hum of bees.\r\n\r\nHazel’s heart raced with excitement. She had found the Enchanted Meadow! As she hopped further into the meadow, she noticed something extraordinary. The flowers seemed to sway in rhythm with her movements, and the trees whispered secrets in the breeze. It was as if the meadow was alive, welcoming her with open arms.\r\n\r\nIn the center of the meadow stood a majestic oak tree, its branches stretching towards the sky. At the base of the tree was a small, sparkling pond. Hazel approached the pond and peered into its crystal-clear waters. To her amazement, she saw not just her reflection, but visions of her deepest dreams and desires.\r\n\r\nAs she gazed into the pond, a gentle voice filled the air. “Welcome, Hazel. You have found the Enchanted Meadow, a place where dreams come true. What is it that you seek?”\r\n\r\nHazel took a deep breath and spoke from her heart. “I wish for a world where all creatures live in harmony, where there is no fear or hunger, and where everyone is free to explore and discover the wonders of life.”\r\n\r\nThe voice replied, “Your wish is pure and noble, Hazel. Because of your kind heart and adventurous spirit, your wish shall be granted.”\r\n\r\nWith those words, a soft, shimmering light enveloped the meadow. Hazel felt a warm, comforting sensation wash over her. When the light faded, she found herself back in her own meadow, but something had changed. The air was filled with a sense of peace and joy. The animals of the meadow, from the tiniest insects to the largest deer, all seemed to be in perfect harmony.\r\n\r\nHazel’s heart swelled with happiness. She had brought the magic of the Enchanted Meadow back with her. From that day forward, the meadow was a place of wonder and beauty, where all creatures lived together in harmony.\r\n\r\nAnd so, Hazel’s adventure became a legend, passed down through generations of hares. The tale of the brave hare who found the Enchanted Meadow and made her dreams come true",
"\r\nThe Hare and the Rabbit: A Tale of Patience and Persistence\r\n\r\nOnce upon a time in a lush, green forest, a proud hare and a humble rabbit lived peacefully among the tall trees and blossoming flowers. Though they were cousins, the hare often looked down on the rabbit. \"Look at you,\" the hare would say, \"so slow and small. You could never keep up with me! I'm the fastest animal in the forest.\"\r\n\r\nThe rabbit, who was much quieter and more modest, simply smiled. He didn’t feel the need to prove himself, but he knew deep down that speed wasn’t everything.\r\n\r\nOne sunny day, the animals of the forest gathered for their annual festival. There were games, feasts, and races. As usual, the hare boasted about his speed. \"No one can outrun me,\" he declared. \"I challenge anyone to a race. I'll even give you a head start.\"\r\n\r\nThe animals all looked at one another, hesitant to accept the hare's challenge. Everyone knew he was fast, and most feared the embarrassment of losing. But then, to everyone’s surprise, the rabbit stepped forward.\r\n\r\n\"I’ll race you, cousin,\" said the rabbit quietly, his eyes steady and calm.\r\n\r\nThe hare burst into laughter. \"You? Race me? Oh, this will be too easy!\" The other animals whispered among themselves, surprised by the rabbit's courage.\r\n\r\nThe owl, the wisest of them all, was chosen to be the referee. \"The race will start at the edge of the meadow and end at the big oak tree on the far hill,\" the owl announced. \"Whoever touches the tree first wins.\"\r\n\r\nAs the race began, the hare sped off like a streak of lightning, leaving a cloud of dust behind him. The rabbit, true to his nature, moved steadily and calmly. He did not rush or panic, just hopped along at his usual pace.\r\n\r\nAfter running for a while, the hare felt tired and noticed how far ahead he was. Looking back, he saw the rabbit moving slowly, still a dot in the distance. \"Ha!\" he chuckled. \"I’ve got plenty of time.\" Deciding that he deserved a rest, the hare lay down under a shady tree and soon dozed off, confident that victory was his.\r\n\r\nMeanwhile, the rabbit kept moving. His legs were smaller, but he never stopped. He hopped over rocks, dodged through bushes, and stayed focused on his goal. As the hours passed, he quietly passed the sleeping hare.\r\n\r\nWhen the rabbit finally reached the big oak tree, he touched its rough bark with a soft paw. The other animals cheered, amazed by his persistence. The sound woke the hare, who jolted awake. In a panic, he bolted towards the finish line, but it was too late. The rabbit had already won.\r\n\r\nThe hare, breathless and ashamed, approached the rabbit. \"I underestimated you, cousin,\" he admitted. \"You may not be the fastest, but your patience and determination are something I never considered.\"\r\n\r\nThe rabbit smiled kindly. \"Speed isn't everything, my friend,\" he said. \"Sometimes, it's about the journey and how you choose to approach it.\"\r\n\r\nFrom that day on, the hare learned to respect the rabbit and all the animals, no matter how fast or slow they were. And the rabbit? He continued to live humbly, knowing that patience, persistence, and kindness were what truly mattered in life.\r\n\r\nAnd so, the forest echoed with a new lesson: it’s not always the fastest who win the race, but those who stay steady and true to their path.",
};

string inputText = "A rabbit was sleeping peacefully";
Console.WriteLine($"--------------------------Before Training--------------------------");

PrintTokens(tokenizer, inputText);
int merges = 10;
int loops = 10;
Console.WriteLine($"--------------------------Training--------------------------");

while (loops > 0)
{
    tokenizer.Train(trainingTexts, 10);
    Console.WriteLine($"Added {merges} new Tokens");
    PrintTokens(tokenizer, inputText);
    merges += 10;
    loops--;
}


//adding special tokens

string startToken = "<|start|>";
string endToken = "<|endoftext|>";
tokenizer.AddToVocabulary(startToken);
tokenizer.AddToVocabulary(endToken);


string specialinputText = "<|start|>A rabbit was sleeping peacefully<|endoftext|>";
Console.WriteLine($"--------------------------With Special Tokens--------------------------");

PrintTokens(tokenizer, specialinputText);

static void PrintTokens(SimpleTokenizer tokenizer, string inputText)
{
    var tokens = tokenizer.Tokenize(inputText);
    var tokenIds = tokenizer.Encode(inputText);
    var colors = new[] { ConsoleColor.Cyan, ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.Blue };

    // Calculate maximum width required for each column
    int[] columnWidths = new int[tokens.Count];
    for (int i = 0; i < tokens.Count; i++)
    {
        columnWidths[i] = Math.Max(tokens[i].Length, tokenIds[i].ToString().Length);
    }

    // Print the top border
    Console.Write("┌");
    for (int i = 0; i < tokens.Count; i++)
    {
        Console.Write(new string('─', columnWidths[i]));
        if (i < tokens.Count - 1)
            Console.Write("┬");
    }
    Console.WriteLine("┐");

    Console.ForegroundColor = ConsoleColor.White;
    // Print the token row
    Console.Write("│");
    for (int i = 0; i < tokens.Count; i++)
    {
        var color = colors[i % colors.Length];
        Console.ForegroundColor = color;
        string token = tokens[i].Replace(" ", "_").PadRight(columnWidths[i]);
        Console.Write(token);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("│");
    }
    Console.WriteLine();
    Console.ResetColor();

    // Print the middle separator
    Console.ForegroundColor = ConsoleColor.White;
    Console.Write("├");
    for (int i = 0; i < tokens.Count; i++)
    {
        Console.Write(new string('─', columnWidths[i]));
        if (i < tokens.Count - 1)
            Console.Write("┼");
    }
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("┤");

    // Print the token ID row
    Console.Write("│");
    for (int i = 0; i < tokenIds.Count; i++)
    {
        var color = colors[i % colors.Length];
        Console.ForegroundColor = color;
        string tokenId = tokenIds[i].ToString().PadRight(columnWidths[i]);
        Console.Write(tokenId);
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("│");
    }
    Console.WriteLine();
    Console.ResetColor();

    // Print the bottom border
    Console.Write("└");
    for (int i = 0; i < tokens.Count; i++)
    {
        Console.Write(new string('─', columnWidths[i]));
        if (i < tokens.Count - 1)
            Console.Write("┴");
    }
    Console.WriteLine("┘");

    Console.WriteLine();  // Blank line after the output
}
