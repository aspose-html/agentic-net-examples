// Access the document's Images collection to iterate over all <img> elements.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content with <img> elements
            string htmlContent = "<html><body>" +
                                 "<h1>Sample Page</h1>" +
                                 "<img src=\"image1.png\" alt=\"Image 1\" />" +
                                 "<p>Some text here.</p>" +
                                 "<img src=\"https://example.com/image2.jpg\" alt=\"Image 2\" />" +
                                 "</body></html>";

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent);

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate over each image element and print its src attribute
            foreach (Aspose.Html.Dom.Element img in images)
            {
                string src = img.GetAttribute("src");
                Console.WriteLine("Image src: " + src);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}