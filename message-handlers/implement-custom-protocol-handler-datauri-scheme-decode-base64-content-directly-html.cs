// Implement a custom protocol handler for the datauri scheme to decode base64 content directly within HTML.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML containing a data URI image
            string html = "<html><body><h1>Data URI Example</h1><img src=\"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XK6cAAAAASUVORK5CYII=\" /></body></html>";

            // Create a temporary directory to store extracted files
            string tempDir = Path.Combine(Path.GetTempPath(), "DataUriTemp");
            Directory.CreateDirectory(tempDir);

            // Regex to match data URI scheme
            Regex regex = new Regex(@"data:([^;]+);([^,]+),(.+)", RegexOptions.IgnoreCase);
            int index = 0;

            // Replace data URIs with file paths to extracted files
            string rewrittenHtml = regex.Replace(html, match =>
            {
                string mediaType = match.Groups[1].Value;
                string encodingMarker = match.Groups[2].Value;
                string payload = match.Groups[3].Value;

                byte[] bytes = string.Equals(encodingMarker, "base64", StringComparison.OrdinalIgnoreCase)
                    ? Convert.FromBase64String(payload)
                    : Encoding.UTF8.GetBytes(Uri.UnescapeDataString(payload));

                string extension = mediaType.Contains("image/png") ? ".png"
                                 : mediaType.Contains("image/jpeg") ? ".jpg"
                                 : ".bin";

                string filePath = Path.Combine(tempDir, "datauri_" + (index++) + extension);
                File.WriteAllBytes(filePath, bytes);
                return filePath.Replace("\\", "/");
            });

            // Base URI for the document (folder with extracted files)
            string baseUri = tempDir.Replace("\\", "/") + "/";

            // Load the HTML document with rewritten content
            using (HTMLDocument document = new HTMLDocument(rewrittenHtml, baseUri))
            {
                // Convert to PDF
                PdfSaveOptions options = new PdfSaveOptions();
                string outputPath = Path.Combine(Path.GetTempPath(), "DataUriOutput.pdf");
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                Console.WriteLine("PDF generated at: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}