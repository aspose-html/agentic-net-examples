// Replace Markdown image syntax with HTML img tags while preserving alt text and source attributes.

using System;
using System.IO;
using System.Text.RegularExpressions;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            // Input markdown file and output HTML file paths
            string markdownPath = "input.md";
            string outputHtmlPath = "output.html";

            // Read markdown content
            string markdown = File.ReadAllText(markdownPath);

            // Replace markdown image syntax with HTML <img> tags
            string htmlContent = Regex.Replace(markdown, @"!\[(.*?)\]\((\S+?)(?:\s+""(.*?)"")?\)", match =>
            {
                string alt = match.Groups[1].Value;
                string src = match.Groups[2].Value;
                string title = match.Groups[3].Success ? match.Groups[3].Value : null;

                string imgTag = $"<img src=\"{src}\" alt=\"{alt}\"";
                if (!string.IsNullOrEmpty(title))
                {
                    imgTag += $" title=\"{title}\"";
                }
                imgTag += " />";
                return imgTag;
            });

            // Write intermediate HTML to a temporary file
            string tempHtmlPath = Path.Combine(Path.GetTempPath(), "temp_converted.html");
            File.WriteAllText(tempHtmlPath, htmlContent);

            // Load the HTML document using Aspose.Html
            HTMLDocument document = new HTMLDocument(tempHtmlPath);

            // Save the final HTML document
            document.Save(outputHtmlPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}