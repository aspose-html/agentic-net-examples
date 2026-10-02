// Control the visibility of a div element by binding its style attribute to a data value.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Prepare sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><div id='myDiv'>Hello World</div></body></html>";
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Write the sample HTML to a file
            File.WriteAllText(inputPath, htmlContent);

            // Load the HTML document
            HTMLDocument document = new HTMLDocument(inputPath);

            // Find the target div element
            Element divElement = document.QuerySelector("#myDiv");

            // Data value controlling visibility
            bool isVisible = false; // Change to true to make the div visible

            // Bind the style attribute based on the data value
            if (isVisible)
            {
                divElement.SetAttribute("style", "display:block;");
            }
            else
            {
                divElement.SetAttribute("style", "display:none;");
            }

            // Save the modified document
            document.Save(outputPath);

            Console.WriteLine("Document saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}