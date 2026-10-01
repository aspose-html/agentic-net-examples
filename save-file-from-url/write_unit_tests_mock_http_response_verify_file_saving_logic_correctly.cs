// Write unit tests that mock the HTTP response to verify the file saving logic works correctly.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            RunTestAsync().GetAwaiter().GetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task RunTestAsync()
    {
        // Arrange
        string testUrl = "http://example.com/test";
        byte[] expectedContent = Encoding.UTF8.GetBytes("Hello World");
        string tempDir = Path.Combine(Path.GetTempPath(), "AsposeHtmlMockTest");
        Directory.CreateDirectory(tempDir);
        string outputPath = Path.Combine(tempDir, "output.bin");

        var mockHandler = new MockHttpMessageHandler(testUrl, expectedContent);
        using var httpClient = new HttpClient(mockHandler);

        // Act
        await SaveContentAsync(testUrl, outputPath, httpClient);

        // Assert
        if (!File.Exists(outputPath))
            throw new InvalidOperationException("Output file was not created.");

        byte[] actualContent = await File.ReadAllBytesAsync(outputPath);
        if (actualContent.Length == 0)
            throw new InvalidOperationException("Output file is empty.");

        if (actualContent.Length != expectedContent.Length)
            throw new InvalidOperationException("Output file size does not match expected size.");

        for (int i = 0; i < actualContent.Length; i++)
        {
            if (actualContent[i] != expectedContent[i])
                throw new InvalidOperationException("Output file content does not match expected content.");
        }

        Console.WriteLine("File saving verification passed.");
    }

    private static async Task SaveContentAsync(string url, string outputPath, HttpClient client)
    {
        using HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        using Stream contentStream = await response.Content.ReadAsStreamAsync();
        using FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None);
        await contentStream.CopyToAsync(fileStream);
    }

    private class MockHttpMessageHandler : HttpMessageHandler
    {
        private readonly string _expectedUrl;
        private readonly byte[] _responseContent;

        public MockHttpMessageHandler(string expectedUrl, byte[] responseContent)
        {
            _expectedUrl = expectedUrl;
            _responseContent = responseContent;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri?.ToString() != _expectedUrl)
            {
                var notFound = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    RequestMessage = request
                };
                return Task.FromResult(notFound);
            }

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(_responseContent),
                RequestMessage = request
            };
            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
            return Task.FromResult(response);
        }
    }
}