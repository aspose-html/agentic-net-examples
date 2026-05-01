// Define a CSS variable for border color and reference it in the table border-color rule.

using System;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Load the source HTML document
            HTMLDocument document = new HTMLDocument("input.html");

            // Create a <style> element containing a CSS variable and using it for table borders
            Element style = document.CreateElement("style");
            style.TextContent = @"
                :root { --border-color: #00ff00; }
                table { border: 2px solid var(--border-color); }
            ";

            // Insert the style element into the <head> of the document
            Element head = document.QuerySelector("head");
            if (head != null)
            {
                head.AppendChild(style);
            }
            else
            {
                // Fallback: append to the document root if <head> is missing
                document.DocumentElement.AppendChild(style);
            }

            // Save the modified document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}