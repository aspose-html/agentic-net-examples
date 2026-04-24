// Identify all <img> elements in the DOM via document.Images.

using System;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Load an HTML document from a file (replace with your actual path)
            using (HTMLDocument document = new HTMLDocument("input.html"))
            {
                // Retrieve all <img> elements using the Images property
                HTMLCollection images = document.Images;

                // Iterate through the collection and output each image's source URL
                foreach (HTMLImageElement img in images)
                {
                    Console.WriteLine(img.Src);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}