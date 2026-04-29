// Generate a summary paragraph that describes the document length and main topics.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.html";
            HTMLDocument document = new HTMLDocument(inputPath);

            string bodyText = document.Body.TextContent ?? string.Empty;
            int characterCount = bodyText.Length;

            var headings = document.GetElementsByTagName("h1");
            string topics = string.Empty;
            foreach (Element heading in headings)
            {
                topics += heading.TextContent + ", ";
            }
            topics = topics.TrimEnd(' ', ',');

            string summary = $"The document contains {characterCount} characters. Main topics: {topics}.";
            Console.WriteLine(summary);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}