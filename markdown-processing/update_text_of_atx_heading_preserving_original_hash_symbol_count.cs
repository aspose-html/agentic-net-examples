// Update the text of an ATX heading while preserving its original number of hash symbols.

using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content with ATX headings
            string markdown = @"# Original Title
This is some content.
## Subheading One
More content.
### Subheading Two
Even more content.";

            Console.WriteLine("Original Markdown:");
            Console.WriteLine(markdown);
            Console.WriteLine();

            // New heading text to replace the first ATX heading
            string newHeadingText = "Updated Title";

            bool replaced = false;
            string updatedMarkdown = Regex.Replace(
                markdown,
                @"^(?<hash>#{1,6})\s*(?<text>.*)$",
                match =>
                {
                    if (!replaced)
                    {
                        replaced = true;
                        return $"{match.Groups["hash"].Value} {newHeadingText}";
                    }
                    return match.Value;
                },
                RegexOptions.Multiline);

            Console.WriteLine("Updated Markdown:");
            Console.WriteLine(updatedMarkdown);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}