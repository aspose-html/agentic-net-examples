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
using Aspose.Html.Rendering;

class MockHttpMessageHandler : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage(HttpStatusCode.OK);
        if (request.RequestUri.ToString() == "http://example.com/images/pic.png")
        {
            byte[] bytes = new byte[] { 1, 2, 3, 4 };
            response.Content = new ByteArrayContent(bytes);
        }
        else
        {
            response.StatusCode = HttpStatusCode.NotFound;
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
            RunTest();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void RunTest()
    {
        string html = "<html><body><img src=\"images/pic.png\"/></body></html>";
        string baseUri = "http://example.com/";
        HTMLDocument document = new HTMLDocument(html, baseUri);

        MockHttpMessageHandler handler = new MockHttpMessageHandler();
        HttpClient httpClient = new HttpClient(handler);

        string outputDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlTest");
        DownloadImages(document, httpClient, outputDir);

        string expectedPath = Path.Combine(outputDir, "pic.png");
        if (!File.Exists(expectedPath))
            throw new Exception("Image file was not created.");

        byte[] data = File.ReadAllBytes(expectedPath);
        if (data.Length != 4 || data[0] != 1 || data[1] != 2 || data[2] != 3 || data[3] != 4)
            throw new Exception("Image content does not match expected bytes.");

        Console.WriteLine("Test passed.");
    }

    static void DownloadImages(HTMLDocument document, HttpClient httpClient, string outputDir)
    {
        Directory.CreateDirectory(outputDir);
        HTMLCollection images = document.GetElementsByTagName("img");
        for (int i = 0; i < images.Length; i++)
        {
            Element imgElement = (Element)images[i];
            string src = imgElement.GetAttribute("src");
            if (string.IsNullOrEmpty(src))
                continue;

            Url imageUrl = new Url(src, document.BaseURI);
            string urlString = imageUrl.ToString();
            string extension = Path.GetExtension(urlString);
            if (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                continue;

            byte[] imageBytes = httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();
            string fileName = Path.GetFileName(urlString);
            string savePath = Path.Combine(outputDir, fileName);
            File.WriteAllBytes(savePath, imageBytes);
        }
    }
}