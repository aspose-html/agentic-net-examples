// Honor the <base> tag when constructing absolute URLs for resource download.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Net;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Load the HTML document from a URL. The constructor respects the <base> tag.
            HTMLDocument document = new HTMLDocument("https://example.com/page.html");

            // Get all <img> elements.
            HTMLCollection images = document.GetElementsByTagName("img");

            // Directory to save downloaded images.
            string outputDir = "downloaded_images";
            Directory.CreateDirectory(outputDir);

            // Iterate over each image element.
            for (int i = 0; i < images.Length; i++)
            {
                // Cast collection item to Element.
                Element imgElement = (Element)images[i];

                // Get the src attribute.
                string src = imgElement.GetAttribute("src");
                if (string.IsNullOrEmpty(src))
                    continue;

                // Resolve the src to an absolute URL using the document's BaseURI (honors <base> tag).
                Url imageUrl = new Url(src, document.BaseURI);

                // Create a request for the image.
                RequestMessage request = new RequestMessage(imageUrl);

                // Send the request using the document's network context.
                ResponseMessage response = document.Context.Network.Send(request);

                // If the request succeeded, save the image.
                if (response.IsSuccess)
                {
                    byte[] content = response.Content.ReadAsByteArray();
                    string fileName = Path.GetFileName(imageUrl.ToString());
                    string savePath = Path.Combine(outputDir, fileName);
                    File.WriteAllBytes(savePath, content);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}