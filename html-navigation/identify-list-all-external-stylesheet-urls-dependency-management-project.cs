// Identify and list all external stylesheet URLs for dependency management in the project.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><head>" +
                                 "<link rel=\"stylesheet\" href=\"https://example.com/style1.css\">" +
                                 "<link rel=\"stylesheet\" href=\"/local/style2.css\">" +
                                 "<link rel=\"icon\" href=\"favicon.ico\">" +
                                 "</head><body></body></html>";

            // Load HTML from string with a dummy base URI
            var document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all <link> elements
            var links = document.GetElementsByTagName("link");

            foreach (var node in links)
            {
                var element = node as Aspose.Html.Dom.Element;
                if (element == null)
                    continue;

                string rel = element.GetAttribute("rel");
                if (!string.Equals(rel, "stylesheet", StringComparison.OrdinalIgnoreCase))
                    continue;

                string href = element.GetAttribute("href");
                if (!string.IsNullOrEmpty(href))
                {
                    Console.WriteLine(href);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}