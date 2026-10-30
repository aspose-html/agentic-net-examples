// Convert all relative image source URLs to absolute URLs based on the document’s base tag.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML with a base tag and relative image URLs
            string htmlContent = "<html><head><base href='https://example.com/subdir/'></head><body>" +
                                 "<img src='images/pic.png'/>" +
                                 "<img src='https://already.com/img.jpg'/>" +
                                 "</body></html>";

            // Load the document with a base URI (required for relative URL resolution)
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "https://example.com/subdir/");

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Convert each image's src to an absolute URL
            for (int i = 0; i < images.Length; i++)
            {
                Aspose.Html.Dom.Element imgElement = images[i];
                string src = imgElement.GetAttribute("src");
                Aspose.Html.Url absoluteUrl = new Aspose.Html.Url(src, document.BaseURI);
                imgElement.SetAttribute("src", absoluteUrl.ToString());
            }

            // Save the modified HTML to a file
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine("Processed HTML saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}