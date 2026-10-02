// Detect unescaped special characters in URLs and escape them to prevent parsing errors.

using System;

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string html = "<html><body><a href=\"http://example.com/space here.html\">Link</a></body></html>";
                string baseUri = "about:blank";

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(html, baseUri))
                {
                    foreach (Aspose.Html.Dom.Element linkElement in document.Links)
                    {
                        string href = linkElement.GetAttribute("href");
                        if (string.IsNullOrEmpty(href))
                            continue;

                        string escapedHref = System.Uri.EscapeUriString(href);
                        if (!href.Equals(escapedHref, StringComparison.Ordinal))
                        {
                            linkElement.SetAttribute("href", escapedHref);
                        }
                    }

                    string outputPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "escaped_output.html");
                    document.Save(outputPath);
                    Console.WriteLine("Escaped HTML saved to: " + outputPath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}