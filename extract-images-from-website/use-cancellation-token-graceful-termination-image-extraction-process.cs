// Use CancellationToken to allow graceful termination of the image extraction process.

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string inputPath = Path.Combine(baseDir, "sample.html");
            string outputDir = Path.Combine(baseDir, "output");
            Directory.CreateDirectory(outputDir);

            if (!File.Exists(inputPath))
            {
                string htmlContent = "<html><body><img src=\"https://via.placeholder.com/150\" /></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            using (HTMLDocument document = new HTMLDocument(inputPath))
            {
                HTMLCollection images = document.GetElementsByTagName("img");
                using (HttpClient httpClient = new HttpClient())
                {
                    using (CancellationTokenSource cts = new CancellationTokenSource())
                    {
                        // Optional timeout (e.g., 30 seconds)
                        cts.CancelAfter(TimeSpan.FromSeconds(30));
                        CancellationToken token = cts.Token;

                        for (int i = 0; i < images.Length; i++)
                        {
                            if (token.IsCancellationRequested)
                                break;

                            Element imgElement = (Element)images[i];
                            string src = imgElement.GetAttribute("src");
                            if (string.IsNullOrEmpty(src))
                                continue;

                            string absoluteUrl;
                            if (Uri.IsWellFormedUriString(src, UriKind.Absolute))
                            {
                                absoluteUrl = src;
                            }
                            else
                            {
                                Uri baseUri = new Uri(document.BaseURI, UriKind.Absolute);
                                Uri resolved = new Uri(baseUri, src);
                                absoluteUrl = resolved.ToString();
                            }

                            byte[] imageBytes = httpClient.GetByteArrayAsync(absoluteUrl, token).GetAwaiter().GetResult();
                            string fileName = Path.GetFileName(absoluteUrl);
                            string savePath = Path.Combine(outputDir, fileName);
                            File.WriteAllBytes(savePath, imageBytes);
                        }
                    }
                }
            }

            Console.WriteLine("Image extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}