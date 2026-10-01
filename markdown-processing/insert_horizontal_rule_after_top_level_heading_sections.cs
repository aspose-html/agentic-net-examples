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

            if (!Directory.Exists(inputFolder))
                Directory.CreateDirectory(inputFolder);
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            if (Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath,
                    "<html><body>" +
                    "<h1>Section 1</h1><p>Content 1.</p>" +
                    "<h1>Section 2</h1><p>Content 2.</p>" +
                    "</body></html>");
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

                var headings = document.QuerySelectorAll("h1");
                foreach (Aspose.Html.HTMLElement heading in headings)
                {
                    Aspose.Html.HTMLElement hr = (Aspose.Html.HTMLElement)document.CreateElement("hr");
                    var parent = heading.ParentNode;
                    var next = heading.NextSibling;
                    if (next != null)
                        parent.InsertBefore(hr, next);
                    else
                        parent.AppendChild(hr);
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileName(htmlPath));
                document.Save(outputPath);
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}