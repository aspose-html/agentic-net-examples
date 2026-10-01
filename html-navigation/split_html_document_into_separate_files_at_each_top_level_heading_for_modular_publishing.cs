// Split an HTML document into separate files at each top‑level heading for modular publishing.

using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputSections";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the source HTML document
                Aspose.Html.HTMLDocument sourceDoc = new Aspose.Html.HTMLDocument(htmlPath);

                // Select all top‑level headings (h1)
                var headings = sourceDoc.QuerySelectorAll("h1");
                if (headings == null || headings.Length == 0)
                    continue;

                for (int i = 0; i < headings.Length; i++)
                {
                    Aspose.Html.HTMLElement heading = (Aspose.Html.HTMLElement)headings[i];

                    // Create a new document for the current section
                    Aspose.Html.HTMLDocument sectionDoc = new Aspose.Html.HTMLDocument();
                    Aspose.Html.HTMLElement body = sectionDoc.Body;

                    // Clone the heading and add it to the new document
                    Aspose.Html.Dom.Node clonedHeading = heading.CloneNode(true);
                    body.AppendChild((Aspose.Html.HTMLElement)clonedHeading);

                    // Append following sibling nodes until the next h1 or end of document
                    Aspose.Html.Dom.Node sibling = heading.NextSibling;
                    while (sibling != null)
                    {
                        // Stop when the next top‑level heading is reached
                        if (sibling is Aspose.Html.HTMLHeadingElement nextHeading &&
                            string.Equals(nextHeading.TagName, "h1", StringComparison.OrdinalIgnoreCase))
                        {
                            break;
                        }

                        Aspose.Html.Dom.Node clonedSibling = sibling.CloneNode(true);
                        body.AppendChild((Aspose.Html.HTMLElement)clonedSibling);
                        sibling = sibling.NextSibling;
                    }

                    // Save the section document
                    string sectionFileName = $"{Path.GetFileNameWithoutExtension(htmlPath)}_section{i + 1}.html";
                    string sectionPath = Path.Combine(outputFolder, sectionFileName);
                    sectionDoc.Save(sectionPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}