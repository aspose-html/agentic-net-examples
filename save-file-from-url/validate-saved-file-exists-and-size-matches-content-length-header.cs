// Validate that the saved file exists and its size matches the Content-Length header.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // URL of a sample HTML page (Content-Length header is expected)
            string url = "https://www.example.com";

            // Download content
            System.Net.Http.HttpClient client = new System.Net.Http.HttpClient();
            System.Net.Http.HttpResponseMessage response = client.GetAsync(url).Result;
            if (!response.IsSuccessStatusCode)
                throw new Exception($"Failed to download content. Status code: {response.StatusCode}");

            // Get Content-Length header
            if (!response.Content.Headers.ContentLength.HasValue)
                throw new Exception("Content-Length header is missing in the response.");

            long contentLength = response.Content.Headers.ContentLength.Value;

            // Read content as byte array
            byte[] data = response.Content.ReadAsByteArrayAsync().Result;

            // Save to file
            string htmlPath = "downloaded.html";
            System.IO.File.WriteAllBytes(htmlPath, data);

            // Validate file existence
            if (!System.IO.File.Exists(htmlPath))
                throw new Exception("Saved HTML file does not exist.");

            // Validate file size matches Content-Length
            long fileSize = new System.IO.FileInfo(htmlPath).Length;
            if (fileSize != contentLength)
                throw new Exception($"File size ({fileSize}) does not match Content-Length header ({contentLength}).");

            System.Console.WriteLine("HTML file saved and size matches Content-Length header.");

            // Convert saved HTML to PDF using Aspose.HTML
            string pdfPath = "output.pdf";
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(htmlPath, options, pdfPath);

            // Verify PDF conversion
            if (!System.IO.File.Exists(pdfPath))
                throw new Exception("PDF conversion failed: output file not found.");

            long pdfSize = new System.IO.FileInfo(pdfPath).Length;
            if (pdfSize == 0)
                throw new Exception("PDF conversion resulted in an empty file.");

            System.Console.WriteLine("PDF conversion succeeded and output file is valid.");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}