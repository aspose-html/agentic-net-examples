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
            // Sample markdown with simple metadata
            string markdown = @"---
title: Sample Document
author: John Doe
themeColor: #ffcc00
---
# Hello World

This is a sample markdown document.";

            // Extract themeColor from metadata (default to white if not found)
            string themeColor = "#ffffff";
            bool inMetadata = false;
            using (StringReader sr = new StringReader(markdown))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Trim() == "---")
                    {
                        inMetadata = !inMetadata;
                        continue;
                    }

                    if (inMetadata && line.StartsWith("themeColor:", StringComparison.OrdinalIgnoreCase))
                    {
                        themeColor = line.Substring("themeColor:".Length).Trim();
                        break;
                    }
                }
            }

            // Build CSS style block based on metadata
            string css = $"body {{ background-color: {themeColor}; }}";

            // Convert markdown to HTMLDocument using a memory stream
            var stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown));
            Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "about:blank");

            // Ensure <head> element exists
            Aspose.Html.HTMLHeadElement head = document.QuerySelector("head") as Aspose.Html.HTMLHeadElement;
            if (head == null)
            {
                head = document.CreateElement("head") as Aspose.Html.HTMLHeadElement;
                document.DocumentElement.AppendChild(head);
            }

            // Create <style> element with the generated CSS
            Aspose.Html.HTMLStyleElement styleElement = document.CreateElement("style") as Aspose.Html.HTMLStyleElement;
            styleElement.TextContent = css;
            head.AppendChild(styleElement);

            // Save the resulting HTML to a file
            string outputPath = "output.html";
            document.Save(outputPath);

            Console.WriteLine(document.DocumentElement.OuterHTML);
            Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}