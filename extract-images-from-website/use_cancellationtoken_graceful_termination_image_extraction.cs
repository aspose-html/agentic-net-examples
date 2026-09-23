// Use CancellationToken to allow graceful termination of the image extraction process.

using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;

class Program
{
    static void Main()
    {
        try
        {
            string dataDir = "Data";
            string inputFile = Path.Combine(dataDir, "sample.html");
            string outputDir = "OutputImages";

            // Ensure input file exists
            if (!File.Exists(inputFile))
            {
                Directory.CreateDirectory(dataDir);
                File.WriteAllText(inputFile, "<html><body><img src=\"https://via.placeholder.com/150.png\"/></body></html>", Encoding.UTF8);
            }

            Directory.CreateDirectory(outputDir);

            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                cts.CancelAfter(TimeSpan.FromSeconds(30));
                CancellationToken token = cts.Token;

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(new Aspose.Html.Url(inputFile)))
                {
                    Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                    using (HttpClient httpClient = new HttpClient())
                    {
                        for (int i = 0; i < images.Length; i++)
                        {
                            if (token.IsCancellationRequested)
                            {
                                Console.WriteLine("Operation cancelled.");
                                break;
                            }

                            Aspose.Html.Dom.Element imgElement = (Aspose.Html.Dom.Element)images[i];
                            string src = imgElement.GetAttribute("src");
                            if (string.IsNullOrEmpty(src))
                                continue;

                            string baseUri = document.BaseURI;
                            Uri imageUri;
                            if (Uri.IsWellFormedUriString(src, UriKind.Absolute))
                                imageUri = new Uri(src);
                            else
                                imageUri = new Uri(new Uri(baseUri), src);

                            string urlString = imageUri.ToString();
                            string extension = Path.GetExtension(urlString);
                            if (!extension.Equals(".png", StringComparison.OrdinalIgnoreCase) &&
                                !extension.Equals(".jpg", StringComparison.OrdinalIgnoreCase) &&
                                !extension.Equals(".jpeg", StringComparison.OrdinalIgnoreCase))
                                continue;

                            byte[] imageBytes = httpClient.GetByteArrayAsync(urlString, token).GetAwaiter().GetResult();
                            string fileName = Path.GetFileName(urlString);
                            string savePath = Path.Combine(outputDir, fileName);
                            File.WriteAllBytes(savePath, imageBytes);
                        }
                    }
                }
            }

            Console.WriteLine("Image extraction completed.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}