// Load an HTML page, extract its favicon link, download the image, and save as PNG.

using System;
using System.IO;
using System.Net.Http;
using System.Drawing;
using System.Drawing.Imaging;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Define input HTML file and output PNG path
            string htmlPath = "sample.html";
            string outputPath = "favicon.png";

            // Create a minimal HTML file with a favicon link
            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"icon\" href=\"https://www.google.com/favicon.ico\"></head><body></body></html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(htmlPath);

            // Find the first <link> element whose rel attribute contains "icon"
            string faviconUrl = null;
            HTMLCollection links = document.GetElementsByTagName("link");
            for (int i = 0; i < links.Length; i++)
            {
                Element element = links[i] as Element;
                if (element != null)
                {
                    string rel = element.GetAttribute("rel");
                    if (!string.IsNullOrEmpty(rel) && rel.ToLower().Contains("icon"))
                    {
                        faviconUrl = element.GetAttribute("href");
                        break;
                    }
                }
            }

            if (string.IsNullOrEmpty(faviconUrl))
            {
                Console.WriteLine("Favicon link not found.");
                return;
            }

            // Download the favicon image
            using (HttpClient client = new HttpClient())
            {
                byte[] imageData = client.GetByteArrayAsync(faviconUrl).Result;

                // Load image from bytes and save as PNG
                using (MemoryStream ms = new MemoryStream(imageData))
                using (Image img = Image.FromStream(ms))
                {
                    img.Save(outputPath, ImageFormat.Png);
                }
            }

            Console.WriteLine($"Favicon saved as PNG to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}