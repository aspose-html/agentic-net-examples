// Use CancellationToken to allow graceful termination of the image extraction process.

using System;
using System.IO;
using System.Net.Http;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare directories
            string dataDir = Path.Combine(Directory.GetCurrentDirectory(), "Data");
            string outputDir = Path.Combine(Directory.GetCurrentDirectory(), "Output");
            Directory.CreateDirectory(dataDir);
            Directory.CreateDirectory(outputDir);

            // Create a minimal HTML file with images
            string htmlPath = Path.Combine(dataDir, "sample.html");
            if (!File.Exists(htmlPath))
            {
                string htmlContent = "<html><body>" +
                                     "<img src=\"https://via.placeholder.com/150\" />" +
                                     "<img src=\"https://via.placeholder.com/200\" />" +
                                     "</body></html>";
                File.WriteAllText(htmlPath, htmlContent);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // HttpClient for downloading images
            using (HttpClient httpClient = new HttpClient())
            {
                // Cancellation token that triggers after 10 seconds
                using (CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(10)))
                {
                    CancellationToken token = cts.Token;

                    for (int i = 0; i < images.Length; i++)
                    {
                        if (token.IsCancellationRequested)
                        {
                            Console.WriteLine("Cancellation requested. Stopping extraction.");
                            break;
                        }

                        Aspose.Html.Dom.Element imgElement = (Aspose.Html.Dom.Element)images[i];
                        string src = imgElement.GetAttribute("src");
                        if (string.IsNullOrEmpty(src))
                            continue;

                        // Resolve relative URLs against the document base URI
                        Aspose.Html.Url imageUrl = new Aspose.Html.Url(src, document.BaseURI);
                        string urlString = imageUrl.ToString();

                        // Download image with cancellation support
                        byte[] imageBytes = httpClient.GetByteArrayAsync(urlString, token).GetAwaiter().GetResult();

                        string fileName = Path.GetFileName(urlString);
                        string savePath = Path.Combine(outputDir, fileName);
                        File.WriteAllBytes(savePath, imageBytes);
                        Console.WriteLine($"Saved image: {savePath}");
                    }
                }
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Image extraction was canceled.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}