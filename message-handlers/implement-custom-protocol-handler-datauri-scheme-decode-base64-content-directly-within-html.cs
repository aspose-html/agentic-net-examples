// Implement a custom protocol handler for the datauri scheme to decode base64 content directly within HTML.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string html = "<html><body><img src=\"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUA\" /></body></html>";
            string tempDir = Path.Combine(Path.GetTempPath(), "DataUriTemp");
            Directory.CreateDirectory(tempDir);
            Regex regex = new Regex(@"data:(?<media>[^;]+);(?<encoding>[^,]+),(?<payload>[^""]+)", RegexOptions.IgnoreCase);
            int index = 0;
            string rewrittenHtml = regex.Replace(html, match =>
            {
                string mediaType = match.Groups["media"].Value;
                string encodingMarker = match.Groups["encoding"].Value;
                string payload = match.Groups["payload"].Value;
                byte[] bytes = string.Equals(encodingMarker, "base64", StringComparison.OrdinalIgnoreCase)
                    ? Convert.FromBase64String(payload)
                    : Encoding.UTF8.GetBytes(Uri.UnescapeDataString(payload));
                string extension = mediaType.Contains("image/png") ? ".png"
                    : (mediaType.Contains("image/jpeg") ? ".jpg"
                    : ".bin");
                string filePath = Path.Combine(tempDir, "datauri_" + (index++) + extension);
                File.WriteAllBytes(filePath, bytes);
                return filePath.Replace("\\", "/");
            });
            string baseUri = tempDir.Replace("\\", "/") + "/";
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(rewrittenHtml, baseUri))
            {
                string outputPath = Path.Combine(tempDir, "output.pdf");
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);
                Console.WriteLine("PDF saved to: " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}