// Write unit tests that mock the HTTP response to verify the file saving logic works correctly.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class MockHttpMessageHandler : HttpMessageHandler
{
    private readonly string _responseContent;
    private readonly string _mediaType;

    public MockHttpMessageHandler(string responseContent, string mediaType = "text/html")
    {
        _responseContent = responseContent;
        _mediaType = mediaType;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new StringContent(_responseContent, Encoding.UTF8, _mediaType)
        };
        return Task.FromResult(response);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            RunFileSavingTest();
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    static void RunFileSavingTest()
    {
        // Prepare mock HTML containing a data URI image
        string html = @"<html><body><img src=""data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUA"" /></body></html>";

        // Mock HTTP response
        var handler = new MockHttpMessageHandler(html);
        var httpClient = new HttpClient(handler);

        // Simulate downloading the HTML
        HttpResponseMessage response = httpClient.GetAsync("http://example.com/test.html").Result;
        string downloadedHtml = response.Content.ReadAsStringAsync().Result;

        // Create temporary directory for extracted resources
        string tempDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlTest");
        Directory.CreateDirectory(tempDir);

        // Replace data URIs with physical files
        Regex regex = new Regex(@"data:([^;]+);([^,]+),([^\"")]+)", RegexOptions.IgnoreCase);
        int index = 0;
        string rewrittenHtml = regex.Replace(downloadedHtml, match =>
        {
            string mediaType = match.Groups[1].Value;
            string encodingMarker = match.Groups[2].Value;
            string payload = match.Groups[3].Value;

            byte[] bytes = string.Equals(encodingMarker, "base64", StringComparison.OrdinalIgnoreCase)
                ? Convert.FromBase64String(payload)
                : Encoding.UTF8.GetBytes(Uri.UnescapeDataString(payload));

            string extension = mediaType.Contains("png") ? ".png"
                             : mediaType.Contains("jpeg") ? ".jpg"
                             : ".bin";

            string filePath = Path.Combine(tempDir, "datauri_" + (index++) + extension);
            File.WriteAllBytes(filePath, bytes);
            return filePath.Replace("\\", "/");
        });

        // Base URI for the document
        string baseUri = tempDir.Replace("\\", "/") + "/";

        // Load HTML document from the rewritten content
        using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(rewrittenHtml, baseUri))
        {
            // Prepare PDF conversion options
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();

            // Define output PDF path
            string outputPdf = Path.Combine(tempDir, "result.pdf");

            // Perform conversion
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPdf);

            // Verify conversion result
            if (!File.Exists(outputPdf))
                throw new InvalidOperationException("PDF file was not created.");

            if (new FileInfo(outputPdf).Length == 0)
                throw new InvalidOperationException("PDF file is empty.");

            Console.WriteLine("Conversion verification passed.");
        }
    }
}