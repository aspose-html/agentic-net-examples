// Detect duplicate heading texts and rename them with unique identifiers to avoid ambiguity.

using System;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Dom;

namespace DuplicateHeadingResolver
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                // Load the HTML document
                HTMLDocument document = new HTMLDocument(inputPath);

                // Select all heading elements
                var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");

                // Track occurrences of heading texts
                var headingCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

                for (int i = 0; i < headings.Length; i++)
                {
                    HTMLHeadingElement heading = (HTMLHeadingElement)headings[i];
                    string originalText = heading.TextContent.Trim();

                    if (headingCounts.ContainsKey(originalText))
                    {
                        headingCounts[originalText]++;
                        string newText = $"{originalText} ({headingCounts[originalText]})";
                        heading.TextContent = newText;
                    }
                    else
                    {
                        headingCounts[originalText] = 1;
                    }
                }

                // Save the modified document
                document.Save(outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}