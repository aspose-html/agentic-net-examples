// Load multiple Markdown documents from a list and merge them into a single HTML output file.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Program
{
    static void Main()
    {
        try
        {
            // Sample markdown contents
            List<string> markdownList = new List<string>
            {
                "# Title One\n\nThis is the first markdown document.",
                "## Title Two\n\nThis is the second markdown document with *italic* text.",
                "### Title Three\n\n- Item 1\n- Item 2\n- Item 3"
            };

            // Create an empty HTML document to hold merged content
            string htmlSkeleton = "<!DOCTYPE html><html><head></head><body></body></html>";
            Aspose.Html.HTMLDocument mergedDocument = new Aspose.Html.HTMLDocument(htmlSkeleton, "about:blank");
            Aspose.Html.HTMLElement mergedBody = mergedDocument.QuerySelector("body") as Aspose.Html.HTMLElement;
            if (mergedBody == null)
            {
                throw new InvalidOperationException("Failed to create body element in the merged document.");
            }

            // Convert each markdown to HTML and merge
            foreach (string markdown in markdownList)
            {
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown)))
                {
                    Aspose.Html.HTMLDocument tempDoc = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "about:blank");
                    Aspose.Html.HTMLElement tempBody = tempDoc.QuerySelector("body") as Aspose.Html.HTMLElement;
                    if (tempBody != null)
                    {
                        mergedBody.InnerHTML += tempBody.InnerHTML;
                    }
                }
            }

            // Save merged HTML to file
            string outputPath = "merged.html";
            mergedDocument.Save(outputPath);

            // Output result to console
            Console.WriteLine(mergedDocument.DocumentElement.OuterHTML);
            Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}