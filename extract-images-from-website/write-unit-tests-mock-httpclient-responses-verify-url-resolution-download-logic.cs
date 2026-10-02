// Write unit tests that mock HttpClient responses to verify URL resolution and download logic.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class MockHttpMessageHandler : HttpMessageHandler
{
    private readonly byte[] _responseContent;
    private readonly string _expectedUrl;

    public MockHttpMessageHandler(string expectedUrl, byte[] responseContent)
    {
        _expectedUrl = expectedUrl;
        _responseContent = responseContent;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response;
        if (request.RequestUri != null && request.RequestUri.ToString().Equals(_expectedUrl, StringComparison.OrdinalIgnoreCase))
        {
            response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new System.Net.Http.ByteArrayContent(_responseContent)
            };
        }
        else
        {
            response = new HttpResponseMessage(HttpStatusCode.NotFound);
        }
        return Task.FromResult(response);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            bool result = TestImageDownload();
            Console.WriteLine(result ? "Test passed." : "Test failed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static bool TestImageDownload()
    {
        // Prepare sample HTML with a relative image URL
        string html = "<html><body><img src=\"image.png\"/></body></html>";
        string baseUri = "http://example.com/folder/";
        string expectedUrl = "http://example.com/folder/image.png";
        byte[] imageBytes = new byte[] { 1, 2, 3, 4 };

        // Create a temporary output directory
        string outputDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlImageTest");
        Directory.CreateDirectory(outputDir);

        // Set up mocked HttpClient
        using (HttpClient httpClient = new HttpClient(new MockHttpMessageHandler(expectedUrl, imageBytes)))
        {
            // Execute the download logic
            DownloadImages(html, baseUri, outputDir, httpClient);
        }

        // Verify that the image file was saved correctly
        string savedFilePath = Path.Combine(outputDir, "image.png");
        if (!File.Exists(savedFilePath))
            return false;

        byte[] savedBytes = File.ReadAllBytes(savedFilePath);
        return savedBytes.Length == imageBytes.Length && savedBytes[0] == imageBytes[0] && savedBytes[1] == imageBytes[1];
    }

    static void DownloadImages(string htmlContent, string baseUri, string outputDir, HttpClient httpClient)
    {
        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        // Load HTML document from inline content
        using (HTMLDocument document = new HTMLDocument(htmlContent, baseUri))
        {
            // Get all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");
            for (int i = 0; i < images.Length; i++)
            {
                Element imgElement = (Element)images[i];
                string src = imgElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                // Resolve the image URL against the document's base URI
                Url imageUrl = new Url(src, document.BaseURI);
                string urlString = imageUrl.ToString();
                string extension = Path.GetExtension(urlString);
                if (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                    !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                    !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase) &&
                    !extension.Equals(".gif", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // Download image bytes
                byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();

                // Save to output directory
                string fileName = Path.GetFileName(urlString);
                string savePath = Path.Combine(outputDir, fileName);
                File.WriteAllBytes(savePath, imageBytes);
            }
        }
    }
}