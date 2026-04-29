// Detect mismatched Markdown delimiters and automatically correct them to maintain valid syntax.

using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MarkdownDelimiterFixer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input and output file paths
                string inputPath = "input.md";
                string outputPath = "output.md";

                // Read the markdown content
                string markdown = File.ReadAllText(inputPath);

                // Fix backtick code fences (ensure even count)
                markdown = FixDelimiter(markdown, "`");

                // Fix asterisk emphasis (ensure even count)
                markdown = FixDelimiter(markdown, "*");

                // Fix underscore emphasis (ensure even count)
                markdown = FixDelimiter(markdown, "_");

                // Write the corrected markdown
                File.WriteAllText(outputPath, markdown);

                Console.WriteLine("Markdown delimiters have been corrected.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // Ensures that the specified delimiter appears an even number of times.
        // If the count is odd, appends the delimiter at the end of the document.
        static string FixDelimiter(string text, string delimiter)
        {
            int count = Regex.Matches(text, Regex.Escape(delimiter)).Count;
            if (count % 2 != 0)
            {
                text += delimiter;
            }
            return text;
        }
    }
}