// Provide a progress callback delegate to report percentage completed during download.

using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Rendering.Pdf;

public sealed class RequestLoggingHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        System.Diagnostics.Stopwatch requestTimer = System.Diagnostics.Stopwatch.StartNew();
        this.Next(context);
        requestTimer.Stop();
        System.Console.WriteLine("Request: " + context.Request.RequestUri + " | " + requestTimer.ElapsedMilliseconds + " ms");
    }
}

public class Program
{
    private static async Task<string> DownloadHtmlAsync(string url, Action<int> progress)
    {
        using (HttpClient client = new HttpClient())
        {
            using (HttpResponseMessage response = await client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();
                long? contentLength = response.Content.Headers.ContentLength;
                using (Stream stream = await response.Content.ReadAsStreamAsync())
                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] buffer = new byte[8192];
                    long totalRead = 0;
                    int read;
                    while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        ms.Write(buffer, 0, read);
                        totalRead += read;
                        if (contentLength.HasValue && contentLength.Value > 0)
                        {
                            int percent = (int)(totalRead * 100 / contentLength.Value);
                            progress(percent);
                        }
                    }
                    return Encoding.UTF8.GetString(ms.ToArray());
                }
            }
        }
    }

    public static async Task Main(string[] args)
    {
        try
        {
            string url = "https://example.com";
            string htmlPath = "sample.html";
            string outputPdfPath = "output.pdf";

            Action<int> progressCallback = percent => Console.WriteLine($"Download progress: {percent}%");

            string htmlContent = await DownloadHtmlAsync(url, progressCallback);
            File.WriteAllText(htmlPath, htmlContent, Encoding.UTF8);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService networkService = configuration.GetService<Aspose.Html.Services.INetworkService>();
            networkService.MessageHandlers.Add(new RequestLoggingHandler());

            System.Diagnostics.Stopwatch conversionTimer = System.Diagnostics.Stopwatch.StartNew();
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            using (Aspose.Html.Rendering.Pdf.PdfDevice device = new Aspose.Html.Rendering.Pdf.PdfDevice(outputPdfPath))
            {
                document.RenderTo(device);
            }
            conversionTimer.Stop();
            Console.WriteLine("Conversion completed in " + conversionTimer.Elapsed.TotalSeconds.ToString("F2") + " seconds.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}