// Load an HTML page, extract its favicon link, download the image, and save as PNG.

namespace AsposeHtmlFaviconExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define input page URL and output PNG path
                string pageUrl = "https://example.com";
                string outputPath = "favicon.png";

                // Load the HTML page
                var document = new Aspose.Html.HTMLDocument(pageUrl);

                // Find the first <link> element with rel containing "icon"
                var links = document.GetElementsByTagName("link");
                string faviconHref = null;
                for (int i = 0; i < links.Length; i++)
                {
                    var element = links[i] as Aspose.Html.HTMLElement;
                    if (element != null)
                    {
                        string rel = element.GetAttribute("rel");
                        if (!string.IsNullOrEmpty(rel) && rel.ToLower().Contains("icon"))
                        {
                            faviconHref = element.GetAttribute("href");
                            break;
                        }
                    }
                }

                // If no favicon link found, fallback to default location
                if (string.IsNullOrEmpty(faviconHref))
                {
                    faviconHref = "/favicon.ico";
                }

                // Resolve relative favicon URL against the page URL
                var baseUri = new System.Uri(pageUrl);
                var faviconUri = new System.Uri(baseUri, faviconHref);

                // Create a minimal HTML that loads the favicon image
                string htmlContent = $"<html><body><img src=\"{faviconUri.AbsoluteUri}\"/></body></html>";
                var faviconDoc = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

                // Configure image save options for PNG format
                var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Png);

                // Convert the HTML containing the favicon image to PNG
                Aspose.Html.Converters.Converter.ConvertHTML(faviconDoc, options, outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}