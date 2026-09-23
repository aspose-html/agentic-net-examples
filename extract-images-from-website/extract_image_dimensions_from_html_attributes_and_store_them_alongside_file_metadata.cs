// Extract image dimensions from HTML attributes and store them alongside file metadata.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string htmlPath = "sample.html";
            string outputPath = "metadata.txt";

            // Create a minimal HTML file with an image
            string htmlContent = "<!DOCTYPE html><html><body><img src=\"image.jpg\" width=\"640\" height=\"480\" alt=\"Sample Image\" /></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Find the first <img> element
            Aspose.Html.Dom.Element element = document.QuerySelector("img");
            if (element != null)
            {
                Aspose.Html.HTMLImageElement img = (Aspose.Html.HTMLImageElement)element;

                // Extract dimensions (cast from float to int)
                int width = (int)img.Width;
                int height = (int)img.Height;
                string src = img.Src;

                // Store metadata
                string metadata = $"Source: {src}{Environment.NewLine}Width: {width}{Environment.NewLine}Height: {height}";
                System.IO.File.WriteAllText(outputPath, metadata);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}