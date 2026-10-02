// Apply attribute binding to set the src attribute of an img tag from JSON image URLs.

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string htmlContent = "<html><body><img alt='first'/><img alt='second'/></body></html>";
            string jsonContent = "[\"https://example.com/image1.png\",\"https://example.com/image2.png\"]";

            List<string> imageUrls = JsonSerializer.Deserialize<List<string>>(jsonContent);

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");
                for (int i = 0; i < images.Length; i++)
                {
                    Aspose.Html.Dom.Element imageElement = (Aspose.Html.Dom.Element)images[i];
                    if (i < imageUrls.Count)
                    {
                        string url = imageUrls[i];
                        imageElement.SetAttribute("src", url);
                    }
                }

                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Document saved to " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}