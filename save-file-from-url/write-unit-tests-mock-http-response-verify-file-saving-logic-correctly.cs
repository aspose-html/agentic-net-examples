// Write unit tests that mock the HTTP response to verify the file saving logic works correctly.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML with a data URI image
            string html = "<html><body><img src=\"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAQAAAC1HAwCAAAAC0lEQVR42mP8/x8AAwMCAO+XK6cAAAAASUVORK5CYII=\" /></body></html>";

            // Create a temporary directory for extracted resources and output
            string tempDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlTest");
            Directory.CreateDirectory(tempDir);

            // Replace data URIs with physical files
            Regex regex = new Regex(@"data:(?<mediaType>[^;]+);(?<encodingMarker>[^,]+),(?<payload>.+)", RegexOptions.IgnoreCase);
            int index = 0;
            string rewrittenHtml = regex.Replace(html, match =>
            {
                string mediaType = match.Groups["mediaType"].Value;
                string encodingMarker = match.Groups["encodingMarker"].Value;
                string payload = match.Groups["payload"].Value;
                byte[] bytes = string.Equals(encodingMarker, "base64", StringComparison.OrdinalIgnoreCase)
                    ? Convert.FromBase64String(payload)
                    : Encoding.UTF8.GetBytes(Uri.UnescapeDataString(payload));
                string extension = mediaType.Contains("png") ? ".png" :
                                   (mediaType.Contains("jpeg") ? ".jpg" : ".bin");
                string filePath = Path.Combine(tempDir, "datauri_" + (index++) + extension);
                File.WriteAllBytes(filePath, bytes);
                return filePath.Replace("\\", "/");
            });

            // Base URI for the document
            string baseUri = tempDir.Replace("\\", "/") + "/";

            // Load the HTML document from the rewritten content
            using (HTMLDocument document = new HTMLDocument(rewrittenHtml, baseUri))
            {
                // Set PDF save options
                PdfSaveOptions options = new PdfSaveOptions();

                // Define output PDF path
                string pdfPath = Path.Combine(tempDir, "output.pdf");

                // Perform conversion
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

                // Verify the PDF file was created and is not empty
                if (!File.Exists(pdfPath))
                {
                    throw new Exception("PDF file was not created.");
                }

                if (new FileInfo(pdfPath).Length == 0)
                {
                    throw new Exception("PDF file is empty.");
                }

                Console.WriteLine("Conversion verification passed. PDF saved at: " + pdfPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}