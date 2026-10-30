// Identify and list all external stylesheet URLs for dependency management in the project.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample HTML file with stylesheet links
            string htmlPath = "sample.html";
            string htmlContent = "<!DOCTYPE html><html><head>" +
                                 "<link rel=\"stylesheet\" href=\"https://cdn.example.com/style.css\">" +
                                 "<link rel=\"stylesheet\" href=\"/local/style.css\">" +
                                 "<link rel=\"stylesheet\" href=\"http://another.com/other.css\">" +
                                 "</head><body></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            using (HTMLDocument document = new HTMLDocument(htmlPath))
            {
                // Get all <link> elements
                HTMLCollection links = document.GetElementsByTagName("link");

                // Iterate and list external stylesheet URLs
                for (int i = 0; i < links.Length; i++)
                {
                    Element element = links[i] as Element;
                    if (element != null)
                    {
                        string rel = element.GetAttribute("rel");
                        if (!string.IsNullOrEmpty(rel) && rel.Equals("stylesheet", StringComparison.OrdinalIgnoreCase))
                        {
                            string href = element.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href) &&
                                (href.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                                 href.StartsWith("https://", StringComparison.OrdinalIgnoreCase)))
                            {
                                Console.WriteLine(href);
                            }
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}