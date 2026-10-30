// Provide a progress callback delegate to report percentage completed during download.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        try
        {
            // URL to download
            string url = "https://example.com";
            // Local paths
            string htmlPath = "downloaded.html";
            string pdfPath = "output.pdf";

            // Progress callback delegate
            Action<int> progressCallback = percent =>
                Console.WriteLine($"Download progress: {percent}%");

            // Download the HTML content with progress reporting
            DownloadFileAsync(url, htmlPath, progressCallback).GetAwaiter().GetResult();

            // Convert the downloaded HTML to PDF using Aspose.HTML
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(pdfPath))
            {
                document.RenderTo(device);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    private static async Task DownloadFileAsync(string requestUri, string destinationPath, Action<int> progressCallback)
    {
        using (HttpClient client = new HttpClient())
        using (HttpResponseMessage response = await client.GetAsync(requestUri, HttpCompletionOption.ResponseHeadersRead))
        {
            response.EnsureSuccessStatusCode();

            long? totalBytes = response.Content.Headers.ContentLength;
            using (Stream contentStream = await response.Content.ReadAsStreamAsync(),
                          fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.None, 8192, true))
            {
                var buffer = new byte[8192];
                long totalRead = 0;
                int bytesRead;
                int lastReportedPercent = 0;

                while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                {
                    await fileStream.WriteAsync(buffer, 0, bytesRead);
                    totalRead += bytesRead;

                    if (totalBytes.HasValue)
                    {
                        int percent = (int)((totalRead * 100L) / totalBytes.Value);
                        if (percent != lastReportedPercent)
                        {
                            lastReportedPercent = percent;
                            progressCallback(percent);
                        }
                    }
                }

                // Ensure 100% is reported if content length was known
                if (totalBytes.HasValue && lastReportedPercent < 100)
                {
                    progressCallback(100);
                }
            }
        }
    }
}