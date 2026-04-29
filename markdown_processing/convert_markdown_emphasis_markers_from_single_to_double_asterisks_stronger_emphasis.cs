// Convert Markdown emphasis markers from single asterisks to double asterisks for stronger emphasis.

using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MarkdownEmphasisConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Define input and output markdown file paths
                string inputPath = "input.md";
                string outputPath = "output.md";

                // Read the markdown content from the input file
                string markdown = File.ReadAllText(inputPath);

                // Replace single asterisk emphasis (*text*) with double asterisks (**text**)
                // The regex ensures that already bold (**text**) is not altered
                string updatedMarkdown = Regex.Replace(
                    markdown,
                    @"(?<!\*)\*(?!\*)([^*]+?)\*(?!\*)",
                    @"**$1**");

                // Write the transformed markdown to the output file
                File.WriteAllText(outputPath, updatedMarkdown);
            }
            catch (Exception ex)
            {
                // Output any errors that occur during processing
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}