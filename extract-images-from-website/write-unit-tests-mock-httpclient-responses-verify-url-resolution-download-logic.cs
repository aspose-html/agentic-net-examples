// Write unit tests that mock HttpClient responses to verify URL resolution and download logic.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

class ImageDownloader
{
    public static async Task<byte[]> DownloadImageAsync(string baseUri, string src, HttpClient httpClient)
    {
        // Create a dummy HTMLDocument to obtain BaseURI handling
        using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(string.Empty, baseUri))
        {
            Aspose.Html.Url imageUrl = new Aspose.Html.Url(src, doc.BaseURI);
            string urlString = imageUrl.ToString();
            return await httpClient.GetByteArrayAsync(urlString);
        }
    }
}

class MockHttpMessageHandler : HttpMessageHandler
{
    private readonly Func<HttpRequestMessage, HttpResponseMessage> _handlerFunc;

    public MockHttpMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> handlerFunc)
    {
        _handlerFunc = handlerFunc ?? throw new ArgumentNullException(nameof(handlerFunc));
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        HttpResponseMessage response = _handlerFunc(request);
        return Task.FromResult(response);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            RunTests().GetAwaiter().GetResult();
            Console.WriteLine("All tests passed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task RunTests()
    {
        await TestUrlResolutionAndDownloadAsync();
    }

    private static async Task TestUrlResolutionAndDownloadAsync()
    {
        // Arrange
        string baseUri = "https://example.com/folder/page.html";
        string relativeSrc = "../image.png";
        string expectedResolvedUrl = "https://example.com/image.png";
        byte[] expectedContent = new byte[] { 1, 2, 3, 4, 5 };

        // Mock HttpClient to return expectedContent for the resolved URL
        var mockHandler = new MockHttpMessageHandler(request =>
        {
            if (request.RequestUri.ToString() == expectedResolvedUrl)
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ByteArrayContent(expectedContent)
                };
                return response;
            }
            return new HttpResponseMessage(HttpStatusCode.NotFound);
        });

        using (HttpClient httpClient = new HttpClient(mockHandler))
        {
            // Act
            byte[] actualContent = await ImageDownloader.DownloadImageAsync(baseUri, relativeSrc, httpClient);

            // Resolve URL separately to verify resolution logic
            using (Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument(string.Empty, baseUri))
            {
                Aspose.Html.Url imageUrl = new Aspose.Html.Url(relativeSrc, doc.BaseURI);
                string resolvedUrl = imageUrl.ToString();

                // Assert URL resolution
                if (!string.Equals(resolvedUrl, expectedResolvedUrl, StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception($"URL resolution failed. Expected: {expectedResolvedUrl}, Got: {resolvedUrl}");
                }
            }

            // Assert downloaded content
            if (actualContent == null || actualContent.Length != expectedContent.Length)
            {
                throw new Exception("Downloaded content length mismatch.");
            }

            for (int i = 0; i < expectedContent.Length; i++)
            {
                if (actualContent[i] != expectedContent[i])
                {
                    throw new Exception("Downloaded content bytes mismatch.");
                }
            }
        }
    }
}