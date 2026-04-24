// Write unit tests that mock HttpClient responses to verify URL resolution and download logic.

using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Aspose.Html;

class Downloader
{
    public static byte[] ResolveAndDownload(string baseUri, string relativePath, HttpClient httpClient)
    {
        HTMLDocument document = new HTMLDocument(baseUri);
        Aspose.Html.Url url = new Aspose.Html.Url(relativePath, document.BaseURI);
        string urlString = url.ToString();
        return httpClient.GetByteArrayAsync(urlString).GetAwaiter().GetResult();
    }
}

class MockHttpMessageHandler : HttpMessageHandler
{
    private readonly Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> _handlerFunc;

    public MockHttpMessageHandler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> handlerFunc)
    {
        _handlerFunc = handlerFunc;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        return _handlerFunc(request, cancellationToken);
    }
}

static class DownloaderTests
{
    public static void RunAll()
    {
        TestResolveAndDownload();
    }

    private static void TestResolveAndDownload()
    {
        string baseUri = "http://example.com/folder/";
        string relativePath = "file.txt";
        string expectedUrl = "http://example.com/folder/file.txt";
        byte[] expectedBytes = new byte[] { 1, 2, 3 };

        var handler = new MockHttpMessageHandler((request, cancellation) =>
        {
            if (request.RequestUri.ToString() != expectedUrl)
                throw new Exception($"Unexpected URL: {request.RequestUri}");
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(expectedBytes)
            };
            return Task.FromResult(response);
        });

        using (HttpClient httpClient = new HttpClient(handler))
        {
            byte[] result = Downloader.ResolveAndDownload(baseUri, relativePath, httpClient);
            if (result.Length != expectedBytes.Length)
                throw new Exception("Byte array length mismatch.");
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] != expectedBytes[i])
                    throw new Exception("Byte array content mismatch.");
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            DownloaderTests.RunAll();
            Console.WriteLine("All tests passed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Test failed: {ex.Message}");
        }
    }
}