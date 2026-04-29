// Convert inline Markdown links to reference‑style links and generate a reference list at the bottom.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MarkdownReferenceConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Input markdown content (could be read from a file)
                string markdown = @"
This is a sample document with inline links.

Visit the [Aspose website](https://www.aspose.com) for more information.
Check out the [GitHub repository](https://github.com/aspose) as well.
Another link to the [Aspose website](https://www.aspose.com) appears again.
";

                // Regular expression to match inline markdown links [text](url)
                string pattern = @"\[(?<text>[^\]]+)\]\((?<url>[^)]+)\)";
                var urlToIndex = new Dictionary<string, int>();
                int nextIndex = 1;

                // Replace inline links with reference-style links and collect URLs
                string transformed = Regex.Replace(markdown, pattern, match =>
                {
                    string text = match.Groups["text"].Value;
                    string url = match.Groups["url"].Value;

                    if (!urlToIndex.ContainsKey(url))
                    {
                        urlToIndex[url] = nextIndex++;
                    }

                    int index = urlToIndex[url];
                    return $"[{text}][{index}]";
                });

                // Build the reference list at the bottom of the document
                var sb = new StringBuilder();
                sb.AppendLine(transformed.TrimEnd());
                sb.AppendLine();
                foreach (var kvp in urlToIndex.OrderBy(k => k.Value))
                {
                    sb.AppendLine($"[{kvp.Value}]: {kvp.Key}");
                }

                string outputPath = "output.md";

                // Save the transformed markdown to a file
                File.WriteAllText(outputPath, sb.ToString());

                Console.WriteLine($"Conversion completed. Reference-style markdown saved at {outputPath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}