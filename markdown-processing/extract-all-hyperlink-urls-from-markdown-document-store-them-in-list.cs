// Extract all hyperlink URLs from the Markdown document and store them in a list.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare a sample Markdown file with hyperlinks
            string markdownPath = "sample.md";
            string markdownContent = @"
# Sample Document

This is a sample markdown document with some links:

- [Google](https://www.google.com)
- [OpenAI](https://openai.com)
- [GitHub](https://github.com)
";

            File.WriteAllText(markdownPath, markdownContent);

            // Load the Markdown document using Aspose.Html.HTMLDocument
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(markdownPath))
            {
                // List to store extracted hyperlink URLs
                List<string> hyperlinkUrls = new List<string>();

                // Iterate over all link elements in the document
                foreach (Aspose.Html.Dom.Element linkElement in document.Links)
                {
                    string href = linkElement.GetAttribute("href");
                    if (!string.IsNullOrEmpty(href))
                    {
                        hyperlinkUrls.Add(href);
                    }
                }

                // Output the extracted URLs
                Console.WriteLine("Extracted hyperlink URLs:");
                foreach (string url in hyperlinkUrls)
                {
                    Console.WriteLine(url);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}