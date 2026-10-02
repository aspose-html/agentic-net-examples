// Rewrite all hyperlink URLs to use HTTPS scheme for improved security compliance.

class Program
{
    static void Main()
    {
        try
        {
            string htmlContent = "<html><body><a href=\"http://example.com\">Example</a><a href=\"https://secure.com\">Secure</a></body></html>";
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");
            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;
                if (href.StartsWith("http://", System.StringComparison.OrdinalIgnoreCase))
                {
                    string httpsHref = "https://" + href.Substring("http://".Length);
                    linkElement.SetAttribute("href", httpsHref);
                }
            }
            string outputPath = "output.html";
            document.Save(outputPath);
            System.Console.WriteLine("Hyperlinks rewritten and saved to " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}