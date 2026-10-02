// Preserve existing alt attributes unchanged during the alt text addition process.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content with images, some missing alt attributes
            string htmlContent = "<html><body>" +
                                 "<img src='image1.png'>" +
                                 "<img src='image2.png' alt='Existing alt'>" +
                                 "<img src='image3.png' alt='   '>" +
                                 "</body></html>";

            // Load HTML document from inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate over each image element
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

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            System.Console.WriteLine("Processing completed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}