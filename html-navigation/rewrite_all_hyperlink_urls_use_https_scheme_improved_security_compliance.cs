// Rewrite all hyperlink URLs to use HTTPS scheme for improved security compliance.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><a href=\"http://example.com\">Link</a><a href=\"https://secure.com\">Secure</a></body></html>";
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;
                if (href.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
                {
                    string newHref = "https://" + href.Substring("http://".Length);
                    linkElement.SetAttribute("href", newHref);
                }
            }

            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}