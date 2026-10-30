// Detect GitHub Flavored Markdown features within a document and log identified elements.

using System;
using System.IO;
using System.Text;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Sample GitHub Flavored Markdown content
            string markdown = "# Sample Document\n" +
                              "\n" +
                              "This is a [link](https://example.com) and some **bold** text.\n" +
                              "\n" +
                              "- List item 1\n" +
                              "- List item 2\n" +
                              "\n" +
                              "```csharp\n" +
                              "Console.WriteLine(\"Hello, World!\");\n" +
                              "```\n";

            // Convert Markdown to HTMLDocument
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(markdown)))
            {
                Aspose.Html.HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(stream, "about:blank");

                // Detect and log various Markdown-derived HTML elements
                Aspose.Html.Collections.NodeList linkElements = document.QuerySelectorAll("a");
                Aspose.Html.Collections.NodeList headingElements = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
                Aspose.Html.Collections.NodeList listItemElements = document.QuerySelectorAll("li");
                Aspose.Html.Collections.NodeList codeElements = document.QuerySelectorAll("pre, code");

                Console.WriteLine($"Detected Links: {linkElements.Length}");
                Console.WriteLine($"Detected Headings: {headingElements.Length}");
                Console.WriteLine($"Detected List Items: {listItemElements.Length}");
                Console.WriteLine($"Detected Code Blocks/Inline Code: {codeElements.Length}");

                // Optionally, output the outer HTML of each detected element type
                for (int i = 0; i < linkElements.Length; i++)
                {
                    var element = linkElements[i] as Aspose.Html.HTMLElement;
                    if (element != null)
                        Console.WriteLine($"Link [{i}]: {element.OuterHTML}");
                }

                for (int i = 0; i < headingElements.Length; i++)
                {
                    var element = headingElements[i] as Aspose.Html.HTMLElement;
                    if (element != null)
                        Console.WriteLine($"Heading [{i}]: {element.OuterHTML}");
                }

                // Save the generated HTML for reference
                string outputPath = "output.html";
                document.Save(outputPath);
                Console.WriteLine("Conversion completed. HTML saved at " + outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}