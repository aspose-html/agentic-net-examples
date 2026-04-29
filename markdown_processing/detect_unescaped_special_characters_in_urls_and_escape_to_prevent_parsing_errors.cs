// Detect unescaped special characters in URLs and escape them to prevent parsing errors.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.html";

            string htmlContent = File.ReadAllText(sourcePath);
            HTMLDocument document = new HTMLDocument(htmlContent, "");

            foreach (Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                string escapedHref = Uri.EscapeUriString(href);
                if (escapedHref != href)
                    linkElement.SetAttribute("href", escapedHref);
            }

            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}