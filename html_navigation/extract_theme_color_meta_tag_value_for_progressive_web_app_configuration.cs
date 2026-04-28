// Extract the theme‑color meta tag value for use in progressive web app configuration.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the HTML file containing the meta tag
            string htmlPath = "input.html";

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Find the <meta name="theme-color"> element
            var metaElement = document.QuerySelector("meta[name='theme-color']") as HTMLElement;

            if (metaElement != null)
            {
                // Extract the value of the content attribute
                string themeColor = metaElement.GetAttribute("content");
                Console.WriteLine($"Theme color: {themeColor}");
            }
            else
            {
                Console.WriteLine("Theme color meta tag not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}