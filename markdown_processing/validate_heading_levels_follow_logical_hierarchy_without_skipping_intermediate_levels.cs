// Validate that heading levels follow a logical hierarchy without skipping intermediate levels.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            HTMLDocument document = new HTMLDocument(htmlPath);
            var headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
            int previousLevel = 0;
            bool isValid = true;
            for (int i = 0; i < headings.Length; i++)
            {
                HTMLElement element = (HTMLElement)headings[i];
                string tag = element.TagName.ToLower();
                int level = int.Parse(tag.Substring(1));
                if (previousLevel != 0 && level > previousLevel + 1)
                {
                    isValid = false;
                    Console.WriteLine($"Skipping heading level from h{previousLevel} to h{level}: \"{element.TextContent.Trim()}\"");
                }
                previousLevel = level;
            }
            Console.WriteLine(isValid ? "Heading hierarchy is valid." : "Heading hierarchy has errors.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}