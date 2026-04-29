// Add a title attribute to image markdown nodes to provide additional tooltip information.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Paths to the input and output HTML files
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Retrieve all <img> elements
            HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate over each image element
            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    // Get the source attribute to derive a title
                    string src = img.GetAttribute("src");
                    if (!string.IsNullOrWhiteSpace(src))
                    {
                        string fileName = Path.GetFileName(src);
                        string title = $"Image: {fileName}";
                        // Set the title attribute for tooltip
                        img.SetAttribute("title", title);
                    }
                }
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}