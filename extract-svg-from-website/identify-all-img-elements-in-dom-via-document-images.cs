// Identify all <img> elements in the DOM via document.Images.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with images
            string htmlContent = @"
                <html>
                    <body>
                        <h1>Sample Page</h1>
                        <img src='image1.png' alt='First Image' />
                        <p>Some text here.</p>
                        <img src='image2.jpg' alt='Second Image' />
                    </body>
                </html>";

            // Load HTML document from inline content
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
            {
                // Get all <img> elements via the Images collection
                Aspose.Html.Collections.HTMLCollection images = document.Images;

                Console.WriteLine($"Number of <img> elements found: {images.Length}");

                foreach (Aspose.Html.Dom.Element img in images)
                {
                    // Retrieve the 'src' attribute of each image
                    string src = img.GetAttribute("src");
                    Console.WriteLine($"Image src: {src}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}