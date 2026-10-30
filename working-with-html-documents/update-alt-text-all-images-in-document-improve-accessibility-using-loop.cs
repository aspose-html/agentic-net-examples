// Update alt text of all images in the document to improve accessibility using a loop.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content with images
            string htmlContent = "<html><body>" +
                                 "<img src='image1.png'>" +
                                 "<img src='image2.png' alt='Existing alt'>" +
                                 "<img src='image3.png' alt='   '>" +
                                 "</body></html>";

            // Load the HTML document from the content string
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Loop through each image and set alt text if missing or empty
            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string autoAlt = "Image";
                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }

            // Save the updated document
            string outputPath = "output.html";
            document.Save(outputPath);

            System.Console.WriteLine("Image alt attributes updated and saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}