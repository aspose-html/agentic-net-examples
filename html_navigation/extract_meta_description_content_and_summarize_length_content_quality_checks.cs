// Extract all meta description content and summarize its length for content quality checks.

using System;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // URL of the HTML page to analyze
            string url = "https://example.com";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(url);

            // Retrieve all <meta> elements
            var metaElements = document.GetElementsByTagName("meta");

            int totalLength = 0;
            int descriptionCount = 0;

            for (int i = 0; i < metaElements.Length; i++)
            {
                var element = metaElements[i] as HTMLElement;
                if (element == null)
                    continue;

                // Check if the meta tag is a description
                string nameAttr = element.GetAttribute("name");
                if (string.IsNullOrEmpty(nameAttr) ||
                    !nameAttr.Equals("description", StringComparison.OrdinalIgnoreCase))
                    continue;

                // Get the content attribute
                string content = element.GetAttribute("content");
                if (string.IsNullOrEmpty(content))
                    continue;

                descriptionCount++;
                totalLength += content.Length;
                Console.WriteLine($"Description {descriptionCount}: {content}");
            }

            Console.WriteLine($"Found {descriptionCount} meta description(s) with total length {totalLength} characters.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}