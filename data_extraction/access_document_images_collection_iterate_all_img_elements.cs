// Access the document's Images collection to iterate over all <img> elements.

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
                // Access the Images collection which contains all <img> elements
                HTMLCollection images = document.Images;

                // Iterate over each image element
                foreach (Element img in images)
                {
                    // Retrieve the src attribute (or any other processing you need)
                    string src = img.GetAttribute("src");
                    Console.WriteLine(src);
                }
            }
        }
        catch (Exception ex)
        {
            // Handle any errors that occur during processing
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}