// Apply attribute binding to set the src attribute of an img tag from JSON image URLs.

using System;
using System.Threading.Tasks;
using System.Text.Json;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><img alt='first'/><img alt='second'/></body></html>";
            string baseUri = "about:blank";
            using (HTMLDocument document = new HTMLDocument(htmlContent, baseUri))
            {
                string json = "[\"https://example.com/image1.png\",\"https://example.com/image2.png\"]";
                string[] urls = JsonSerializer.Deserialize<string[]>(json);
                HTMLCollection images = document.GetElementsByTagName("img");
                int count = Math.Min(images.Length, urls.Length);
                for (int i = 0; i < count; i++)
                {
                    Element imgElement = (Element)images[i];
                    imgElement.SetAttribute("src", urls[i]);
                }
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Saved output to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}