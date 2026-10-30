// Remove all empty paragraph tags that contain only whitespace characters in the document.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            // Create a sample HTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = @"<!DOCTYPE html>
<html>
<head><title>Sample</title></head>
<body>
<p>First paragraph.</p>
<p>   </p>
<p>
    
</p>
<p>Second paragraph.</p>
</body>
</html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all <p> elements
            Aspose.Html.Collections.HTMLCollection paragraphs = document.GetElementsByTagName("p");

            // Iterate backwards and remove empty paragraphs (whitespace only)
            for (int i = paragraphs.Length - 1; i >= 0; i--)
            {
                Aspose.Html.Dom.Element element = (Aspose.Html.Dom.Element)paragraphs[i];
                if (string.IsNullOrWhiteSpace(element.TextContent))
                {
                    if (element.ParentNode != null)
                    {
                        element.ParentNode.RemoveChild(element);
                    }
                }
            }

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine("Empty paragraphs removed. Output saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}