// Insert a horizontal rule after every top‑level heading to visually separate sections.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputHtml";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                // Load the HTML document
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                // Find all top‑level headings (h1)
                var headings = document.QuerySelectorAll("h1");

                for (int i = 0; i < headings.Length; i++)
                {
                    Aspose.Html.HTMLElement heading = (Aspose.Html.HTMLElement)headings[i];

                    // Create <hr> element
                    Aspose.Html.HTMLElement hr = (Aspose.Html.HTMLElement)document.CreateElement("hr");

                    // Insert <hr> after the heading
                    var parent = heading.ParentNode;
                    var nextSibling = heading.NextSibling;
                    if (nextSibling != null)
                        parent.InsertBefore(hr, nextSibling);
                    else
                        parent.AppendChild(hr);
                }

                // Save the modified document
                string outputPath = Path.Combine(outputFolder, Path.GetFileName(htmlPath));
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}