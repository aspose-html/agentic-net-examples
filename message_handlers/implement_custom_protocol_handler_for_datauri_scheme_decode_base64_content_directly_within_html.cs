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
    static void Main()
    {
        try
        {
            string html = @"<html><body><img src=""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUA"" /></body></html>";
            string tempDir = Path.Combine(Path.GetTempPath(), "DataUriTemp");
            Directory.CreateDirectory(tempDir);

            Regex regex = new Regex(@"data:(?<mediaType>[^;]+)(;(?<encodingMarker>base64))?,(?<payload>.+)", RegexOptions.IgnoreCase);
            int index = 0;
            string rewrittenHtml = regex.Replace(html, match =>
            {
                string mediaType = match.Groups["mediaType"].Value;
                string encodingMarker = match.Groups["encodingMarker"].Value;
                string payload = match.Groups["payload"].Value;

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

            string baseUri = tempDir.Replace("\\", "/") + "/";

            using (HTMLDocument document = new HTMLDocument(rewrittenHtml, baseUri))
            {
                PdfSaveOptions options = new PdfSaveOptions();
                string outputPath = Path.Combine(Environment.CurrentDirectory, "output.pdf");
                Converter.ConvertHTML(document, options, outputPath);
                Console.WriteLine("PDF saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}