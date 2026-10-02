// Replace Markdown image syntax with HTML img tags while preserving alt text and source attributes.

using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown content
            string markdown = @"
# Example Document

Here is an image:

![Sample Image](sample.png)

Another image with title:

![Another Image](images/another.jpg)
";

            // Replace markdown image syntax with HTML img tags
            string pattern = @"!\[(.*?)\]\((.*?)\)";
            string replacement = "<img alt=\"$1\" src=\"$2\" />";
            string htmlContent = Regex.Replace(markdown, pattern, replacement, RegexOptions.Singleline);

            // Load the processed HTML content into an Aspose.HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank");

            // Save the result to a file
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine($"HTML file saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}