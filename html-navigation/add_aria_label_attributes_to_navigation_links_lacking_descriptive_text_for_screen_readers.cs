// Add aria‑label attributes to navigation links lacking descriptive text for screen readers.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string html = @"<!DOCTYPE html><html><head><title>Sample</title></head><body><nav><ul><li><a href='home.html'></a></li><li><a href='about.html'>About</a></li><li><a href='contact.html'></a></li></ul></nav></body></html>";

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, ""))
            {
                Aspose.Html.Collections.HTMLCollection links = document.GetElementsByTagName("a");
                for (int i = 0; i < links.Length; i++)
                {
                    Aspose.Html.Dom.Element link = links[i];
                    string text = link.TextContent != null ? link.TextContent.Trim() : string.Empty;
                    if (string.IsNullOrEmpty(text))
                    {
                        string href = link.GetAttribute("href");
                        string ariaLabel = !string.IsNullOrEmpty(href) ? $"Link to {href}" : "Navigation link";
                        link.SetAttribute("aria-label", ariaLabel);
                    }
                }

                string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "output.html");
                document.Save(outputPath);
                Console.WriteLine($"Modified HTML saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}