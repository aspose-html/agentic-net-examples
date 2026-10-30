// Control the visibility of a div element by binding its style attribute to a data value.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Sample HTML content with a div element
            string htmlContent = "<!DOCTYPE html><html><head><title>Visibility Demo</title></head><body><div id=\"myDiv\">Hello, Aspose.HTML!</div></body></html>";

            // Load the HTML content into an Aspose.HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Locate the div element by its ID
            Aspose.Html.HTMLElement divElement = (Aspose.Html.HTMLElement)document.QuerySelector("#myDiv");

            // Data value that controls visibility
            bool isVisible = false; // Change to true to make the div visible

            // Bind the visibility to the style attribute
            divElement.Style.Display = isVisible ? "block" : "none";

            // Save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);

            System.Console.WriteLine("Document saved successfully to: " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}