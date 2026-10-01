// Identify and list all external stylesheet URLs for dependency management in the project.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = "sample.html";
            string htmlContent = @"<!DOCTYPE html><html><head>" +
                                 "<link rel='stylesheet' href='https://cdn.example.com/style.css'>" +
                                 "<link rel='stylesheet' href='/local/style.css'>" +
                                 "<link rel='icon' href='https://example.com/favicon.ico'>" +
                                 "</head><body></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                Aspose.Html.Collections.HTMLCollection linkElements = document.GetElementsByTagName("link");
                for (int i = 0; i < linkElements.Length; i++)
                {
                    Aspose.Html.Dom.Element linkElement = (Aspose.Html.Dom.Element)linkElements[i];
                    string rel = linkElement.GetAttribute("rel");
                    string href = linkElement.GetAttribute("href");
                    if (!string.IsNullOrEmpty(rel) &&
                        rel.Equals("stylesheet", StringComparison.OrdinalIgnoreCase) &&
                        !string.IsNullOrEmpty(href) &&
                        (href.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
                         href.StartsWith("https://", StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine(href);
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