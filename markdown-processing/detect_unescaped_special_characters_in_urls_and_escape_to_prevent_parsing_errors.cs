// Detect unescaped special characters in URLs and escape them to prevent parsing errors.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Create a sample HTML file with unescaped URLs
            string sourcePath = Path.Combine(Path.GetTempPath(), "sample.html");
            string htmlContent = "<html><body>" +
                                 "<a href=\"http://example.com/space link.html\">Link with space</a>" +
                                 "<a href=\"http://example.com/normal.html\">Normal link</a>" +
                                 "</body></html>";
            File.WriteAllText(sourcePath, htmlContent, Encoding.UTF8);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

            // Iterate over all link elements and escape unescaped URLs
            foreach (Aspose.Html.Dom.Element linkElement in document.Links)
            {
                string href = linkElement.GetAttribute("href");
                if (string.IsNullOrEmpty(href))
                    continue;

                string escaped = Uri.EscapeUriString(href);
                if (!escaped.Equals(href, StringComparison.Ordinal))
                {
                    linkElement.SetAttribute("href", escaped);
                }
            }

            // Save the updated document
            string outputPath = Path.Combine(Path.GetTempPath(), "sample_escaped.html");
            document.Save(outputPath);
            Console.WriteLine($"Escaped HTML saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}