// Replace Markdown image syntax with HTML img tags while preserving alt text and source attributes.

using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content with image syntax
            string markdownContent = @"
                <html>
                <body>
                    <p>Here is an image:</p>
                    ![Sample Image](https://example.com/image1.png)
                    <p>Another image without alt text:</p>
                    ![](https://example.com/image2.jpg)
                </body>
                </html>";

            // Replace markdown image syntax with HTML img tags
            string pattern = @"!\[([^\]]*)\]\(([^)]+)\)";
            string replacedContent = Regex.Replace(markdownContent, pattern, m =>
            {
                string alt = m.Groups[1].Value;
                string src = m.Groups[2].Value;
                return $"<img alt=\"{alt}\" src=\"{src}\" />";
            });

            // Write the replaced HTML to a temporary file
            string inputPath = Path.Combine(Path.GetTempPath(), "input.html");
            File.WriteAllText(inputPath, replacedContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all img elements
            Aspose.Html.Collections.HTMLCollection images = document.GetElementsByTagName("img");

            // Ensure each img has a non-empty alt attribute
            foreach (Aspose.Html.Dom.Element node in images)
            {
                Aspose.Html.HTMLImageElement img = node as Aspose.Html.HTMLImageElement;
                if (img != null)
                {
                    string alt = img.GetAttribute("alt");
                    if (string.IsNullOrWhiteSpace(alt))
                    {
                        string autoAlt = "Image";
                        img.SetAttribute("alt", autoAlt);
                    }
                }
            }

            // Save the updated document
            string outputPath = Path.Combine(Path.GetTempPath(), "output.html");
            document.Save(outputPath);

            Console.WriteLine($"Processing completed. Output saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}