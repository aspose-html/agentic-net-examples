// Replace empty alt attributes with descriptive text derived from surrounding caption elements.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample input file if it does not exist
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"
<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
    <figure>
        <img src='sample.jpg' alt=''>
        <figcaption>Sample image caption</figcaption>
    </figure>
    <p>Some other content.</p>
    <img src='no-caption.jpg' alt=''>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        // Search for a surrounding <figure> element
                        Aspose.Html.Dom.Element parent = img.ParentNode as Aspose.Html.Dom.Element;
                        while (parent != null && !string.Equals(parent.NodeName, "figure", StringComparison.OrdinalIgnoreCase))
                        {
                            parent = parent.ParentNode as Aspose.Html.Dom.Element;
                        }

                        string autoAlt = "Image";

                        if (parent != null)
                        {
                            // Look for a <figcaption> inside the figure
                            Aspose.Html.Collections.HTMLCollection captions = parent.GetElementsByTagName("figcaption");
                            if (captions.Length > 0)
                            {
                                Aspose.Html.HTMLElement captionElement = captions[0] as Aspose.Html.HTMLElement;
                                if (captionElement != null)
                                {
                                    // Use the caption's inner HTML as alt text
                                    autoAlt = captionElement.InnerHTML.Trim();
                                }
                            }
                        }

                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }

            // Save the modified document
            document.Save(outputPath);
            Console.WriteLine($"Processing completed. Output saved to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}