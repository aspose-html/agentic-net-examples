// Rewrite all hyperlink URLs to use HTTPS scheme for improved security compliance.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><a href=\"http://example.com\">Link</a></body></html>";
            string baseUri = "about:blank";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

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

            string outputPath = "output.html";
            document.Save(outputPath, new Aspose.Html.Saving.HTMLSaveOptions());
            Console.WriteLine($"Modified HTML saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}