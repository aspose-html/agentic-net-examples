// Load an HTML document, traverse its DOM to find all image tags, and log their sources.

using System;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Path to the HTML file to be loaded
            string htmlPath = "input.html";

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Get all <img> elements in the document
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate over each image element and log its src attribute
            foreach (Aspose.Html.Dom.Element image in images)
            {
                string imageUrl = image.GetAttribute("src");
                Console.WriteLine(imageUrl);
            }
        }
        catch (Exception ex)
        {
            // Log any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}