// Verify that style changes have been applied by inspecting the style attribute of a target element.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with a target element
            string htmlContent = "<html><body><p id='target'>Hello</p></body></html>";

            // Load the HTML document from the inline content
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Select the target element
            Aspose.Html.Dom.Element element = document.QuerySelector("p#target");
            if (element == null)
            {
                System.Console.WriteLine("Target element not found.");
                return;
            }

            // Cast to HTMLElement to access style manipulation
            Aspose.Html.HTMLElement target = (Aspose.Html.HTMLElement)element;

            // Apply a style change
            target.Style.BackgroundColor = "red";

            // Verify the style attribute
            string styleAttribute = target.GetAttribute("style");
            System.Console.WriteLine($"Style attribute after change: {styleAttribute}");

            if (!string.IsNullOrEmpty(styleAttribute) && styleAttribute.Contains("background-color: red"))
            {
                System.Console.WriteLine("Style change verified successfully.");
            }
            else
            {
                System.Console.WriteLine("Style change verification failed.");
            }

            // Optionally save the modified document
            string outputPath = "output.html";
            document.Save(outputPath);
            System.Console.WriteLine($"Modified document saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}