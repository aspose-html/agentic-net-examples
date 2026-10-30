// Generate a unique CSS style block for each Markdown document based on its metadata before HTML conversion.

using System;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown with simple YAML front matter
            string markdownContent = @"---
title: Sample Document
author: John Doe
themeColor: #ff5733
---
# Hello World

This is a sample markdown document.";
            
            // Extract metadata between the first pair of "---" lines
            string themeColor = "#ffffff"; // default
            string[] lines = markdownContent.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
            bool inFrontMatter = false;
            foreach (string line in lines)
            {
                if (line.Trim() == "---")
                {
                    inFrontMatter = !inFrontMatter;
                    continue;
                }
                if (inFrontMatter)
                {
                    int colonIndex = line.IndexOf(':');
                    if (colonIndex > -1)
                    {
                        string key = line.Substring(0, colonIndex).Trim();
                        string value = line.Substring(colonIndex + 1).Trim();
                        if (key.Equals("themeColor", StringComparison.OrdinalIgnoreCase))
                        {
                            themeColor = value;
                        }
                    }
                }
                else if (!inFrontMatter && line.Trim().Length > 0)
                {
                    // Stop processing after front matter
                    break;
                }
            }

            // Prepare CSS based on metadata
            string cssContent = $"body {{ background-color: {themeColor}; }}";

            // Convert markdown to HTMLDocument using a memory stream
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(markdownContent));
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, string.Empty);

            // Ensure <head> exists
            Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
            if (head == null)
            {
                head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                document.DocumentElement.AppendChild(head);
            }

            // Create <style> element with the generated CSS
            Aspose.Html.HTMLStyleElement styleElement = document.CreateElement("style") as Aspose.Html.HTMLStyleElement;
            styleElement.TextContent = cssContent;
            head.AppendChild(styleElement);

            // Save the resulting HTML
            string outputPath = "output.html";
            document.Save(outputPath);

            // Output the final HTML to console
            Console.WriteLine(document.DocumentElement.OuterHTML);
            Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}