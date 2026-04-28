// Replace empty alt attributes with descriptive text derived from surrounding caption elements.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;
using Aspose.Html.Collections;

class Program
{
    static void Main()
    {
        try
        {
            // Input and output HTML file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Retrieve all <img> elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Iterate through each image element
            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    // Check current alt attribute
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string generatedAlt = null;

                        // Attempt to derive alt text from a surrounding <figcaption>
                        var parent = img.ParentNode as Aspose.Html.Dom.Element;
                        if (parent != null && string.Equals(parent.TagName, "figure", StringComparison.OrdinalIgnoreCase))
                        {
                            var captions = parent.GetElementsByTagName("figcaption");
                            if (captions.Length > 0)
                            {
                                var captionElem = captions[0] as Aspose.Html.Dom.Element;
                                if (captionElem != null)
                                {
                                    generatedAlt = captionElem.TextContent.Trim();
                                }
                            }
                        }

                        // Fallback: use the image file name without extension
                        if (string.IsNullOrEmpty(generatedAlt))
                        {
                            if (!string.IsNullOrEmpty(img.Src))
                            {
                                generatedAlt = Path.GetFileNameWithoutExtension(img.Src);
                            }
                            else
                            {
                                generatedAlt = "image";
                            }
                        }

                        // Set the generated alt attribute
                        img.SetAttribute("alt", generatedAlt);
                    }
                }
            }

            // Save the modified document
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}