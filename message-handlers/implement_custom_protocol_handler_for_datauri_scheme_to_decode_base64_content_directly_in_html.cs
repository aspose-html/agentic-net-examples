// Implement a custom protocol handler for the datauri scheme to decode base64 content directly within HTML.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML containing a data URI image
            string html = @"<html><body><h1>Data URI Example</h1><img src=""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUA
AAAAAQMAAAAl21bKAAAAA1BMVEUAAACnej3aAAAAAXRSTlMAQObYZgAAAApJREFUCNdjYGBgAAAABAABJzQnCgAAAABJRU5ErkJggg=="" /></body></html>";

            // Create temporary directory for extracted files
            string tempDir = Path.Combine(Path.GetTempPath(), "AsposeDataUriTemp");
            Directory.CreateDirectory(tempDir);

            // Regex to match data URIs
            Regex regex = new Regex(@"data:(?<media>[^;]+)(;(?<encoding>base64))?,(?<payload>.+)", RegexOptions.IgnoreCase);
            int index = 0;

            // Replace data URIs with file paths
            string rewrittenHtml = regex.Replace(html, match =>
            {
                string mediaType = match.Groups["media"].Value;
                string encodingMarker = match.Groups["encoding"].Value;
                string payload = match.Groups["payload"].Value;

                byte[] bytes = string.Equals(encodingMarker, "base64", StringComparison.OrdinalIgnoreCase)
                    ? Convert.FromBase64String(payload)
                    : Encoding.UTF8.GetBytes(Uri.UnescapeDataString(payload));

                string extension = mediaType.Contains("image/png") ? ".png" :
                                   (mediaType.Contains("image/jpeg") ? ".jpg" :
                                   (mediaType.Contains("image/gif") ? ".gif" : ".bin"));

                string filePath = Path.Combine(tempDir, "datauri_" + (index++) + extension);
                File.WriteAllBytes(filePath, bytes);
                return filePath.Replace("\\", "/");
            });

            // Base URI for the document
            string baseUri = tempDir.Replace("\\", "/") + "/";

            // Load the HTML document with rewritten content
            using (HTMLDocument document = new HTMLDocument(rewrittenHtml, baseUri))
            {
                // Set PDF save options (optional customizations can be added)
                PdfSaveOptions options = new PdfSaveOptions();

                // Define output PDF path
                string outputPath = Path.Combine(tempDir, "output.pdf");

                // Convert HTML to PDF
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

                Console.WriteLine("Conversion completed successfully.");
                Console.WriteLine("Output PDF: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}