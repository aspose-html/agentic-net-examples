// Select the navigation menu using CSS selector "#nav" and set its font size to 16px.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Sample HTML content with a navigation menu
            string htmlContent = @"
                <html>
                    <head><title>Sample</title></head>
                    <body>
                        <nav id='nav'>
                            <ul>
                                <li>Home</li>
                                <li>About</li>
                                <li>Contact</li>
                            </ul>
                        </nav>
                    </body>
                </html>";

            // Load the HTML content into a document (base URI is not needed for this example)
            using (HTMLDocument document = new HTMLDocument(htmlContent, "about:blank"))
            {
                // Select the navigation element by CSS selector "#nav"
                Aspose.Html.Dom.Element navElement = document.QuerySelector("#nav");
                if (navElement != null)
                {
                    // Set its font size to 16px via the style attribute
                    navElement.SetAttribute("style", "font-size:16px;");
                }

                // Define output path
                string outputPath = "output.html";

                // Save the modified document
                document.Save(outputPath, new Aspose.Html.Saving.HTMLSaveOptions());

                Console.WriteLine($"Modified HTML saved to: {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}