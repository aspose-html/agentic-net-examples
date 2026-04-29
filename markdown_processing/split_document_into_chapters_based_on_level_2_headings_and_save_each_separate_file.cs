// Split the document into chapters based on level‑2 headings and save each as a separate file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Dom;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = @"C:\InputHtml";
            string outputFolder = @"C:\OutputChapters";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the source HTML document
                HTMLDocument sourceDoc = new HTMLDocument(htmlPath);

                // Get all level‑2 headings (h2)
                var headings = sourceDoc.QuerySelectorAll("h2");
                for (int i = 0; i < headings.Length; i++)
                {
                    HTMLElement heading = (HTMLElement)headings[i];

                    // Create a new document for the current chapter
                    HTMLDocument chapterDoc = new HTMLDocument();

                    // Append the heading itself
                    chapterDoc.Body.AppendChild(heading.CloneNode(true));

                    // Append all sibling nodes until the next h2 or end of body
                    Node sibling = heading.NextSibling;
                    while (sibling != null &&
                           !(sibling is HTMLElement elem && elem.TagName.Equals("h2", StringComparison.OrdinalIgnoreCase)))
                    {
                        chapterDoc.Body.AppendChild(sibling.CloneNode(true));
                        sibling = sibling.NextSibling;
                    }

                    // Build output file name
                    string baseName = Path.GetFileNameWithoutExtension(htmlPath);
                    string chapterFile = Path.Combine(outputFolder, $"{baseName}_Chapter{i + 1}.html");

                    // Save the chapter document
                    chapterDoc.Save(chapterFile);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}