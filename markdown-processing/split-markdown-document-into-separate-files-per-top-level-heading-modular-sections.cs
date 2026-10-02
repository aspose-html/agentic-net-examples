// Split a Markdown document into separate files for each top‑level heading to create modular sections.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Dom;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "Input";
            string outputFolder = "Output";

            if (!Directory.Exists(inputFolder)) Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder)) Directory.CreateDirectory(outputFolder);

            string sourcePath = Path.Combine(inputFolder, "document.md");
            string markdownContent = "# Introduction\nThis is the introduction.\n\n# Chapter One\nContent of chapter one.\n\n# Chapter Two\nContent of chapter two.\n";
            File.WriteAllText(sourcePath, markdownContent);

            // Convert the markdown file to an HTML document
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertMarkdown(sourcePath);

            // Select all top‑level headings (h1)
            var headings = document.QuerySelectorAll("h1");

            for (int i = 0; i < headings.Length; i++)
            {
                HTMLElement heading = (HTMLElement)headings[i];

                // Create a new HTML document for the current section
                HTMLDocument sectionDoc = new HTMLDocument();
                HTMLElement body = sectionDoc.Body;

                // Clone the heading and add it to the new document
                Node clonedHeading = heading.CloneNode(true);
                body.AppendChild(clonedHeading);

                // Append all sibling nodes until the next h1
                Node sibling = heading.NextSibling;
                while (sibling != null)
                {
                    if (sibling is HTMLElement elem && elem.TagName.Equals("h1", StringComparison.OrdinalIgnoreCase))
                        break;

                    Node clonedSibling = sibling.CloneNode(true);
                    body.AppendChild(clonedSibling);
                    sibling = sibling.NextSibling;
                }

                // Convert the section HTML back to markdown
                MarkdownSaveOptions options = new MarkdownSaveOptions();
                string outPath = Path.Combine(outputFolder, $"section_{i + 1}.md");
                Aspose.Html.Converters.Converter.ConvertHTML(sectionDoc, options, outPath);
            }

            Console.WriteLine("Markdown sections have been split successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}