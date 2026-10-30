// Download image data asynchronously with HttpClient for each resolved image URL resource.

using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Net;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string inputPath = "sample.html";
            string outputDir = "downloaded_images";

            // Ensure sample HTML file exists
            Directory.CreateDirectory(Path.GetDirectoryName(inputPath));
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<html><body>" +
                                     "<img src=\"https://via.placeholder.com/150.png\" />" +
                                     "<img src=\"https://via.placeholder.com/100.jpg\" />" +
                                     "</body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            Directory.CreateDirectory(outputDir);

            using (HTMLDocument document = new HTMLDocument(inputPath))
            using (HttpClient httpClient = new HttpClient())
            {
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

                    byte[] imageBytes = await httpClient.GetByteArrayAsync(urlString);
                    string fileName = Path.GetFileName(urlString);
                    string savePath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(savePath, imageBytes);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}