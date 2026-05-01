// Create a style element, define a CSS variable for primary color, and use it in multiple rules.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Load an existing HTML document
            var document = new HTMLDocument("input.html");

            // Create a <style> element
            var style = document.CreateElement("style");

            // Define a CSS variable and use it in multiple rules
            style.TextContent = @"
                :root {
                    --primary-color: #3498db;
                }
                .header {
                    color: var(--primary-color);
                }
                .button {
                    background-color: var(--primary-color);
                }";

            // Append the style element to the <head> section
            var head = document.GetElementsByTagName("head")[0] as HTMLElement;
            if (head != null)
                head.AppendChild(style);
            else
                document.AppendChild(style); // fallback

            // Save the modified document
            document.Save("output.html");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}