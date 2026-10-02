// Detect duplicate heading texts and rename them with unique identifiers to avoid ambiguity.

using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Html;
using Aspose.Html.Collections;
using Aspose.Html.Dom;

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

            // Create a minimal sample HTML file if none exist
            string[] existingFiles = Directory.GetFiles(inputFolder, "*.html");
            if (existingFiles.Length == 0)
            {
                string samplePath = Path.Combine(inputFolder, "sample.html");
                File.WriteAllText(samplePath,
@"<html><body>
<h1>Title</h1>
<h2>Section</h2>
<h2>Section</h2>
<h3>Subsection</h3>
<h3>Subsection</h3>
<h3>Subsection</h3>
</body></html>");
            }

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                HTMLDocument document = new HTMLDocument(htmlPath);
                NodeList headings = document.QuerySelectorAll("h1, h2, h3, h4, h5, h6");
                Dictionary<string, int> seen = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

                for (int i = 0; i < headings.Length; i++)
                {
                    HTMLElement element = (HTMLElement)headings[i];
                    string text = element.TextContent.Trim();

                    if (seen.ContainsKey(text))
                    {
                        seen[text] += 1;
                        string newId = text.Replace(" ", "_") + "_" + seen[text];
                        element.SetAttribute("id", newId);
                        element.TextContent = text + " (" + seen[text] + ")";
                    }
                    else
                    {
                        seen[text] = 1;
                        string newId = text.Replace(" ", "_") + "_1";
                        element.SetAttribute("id", newId);
                    }
                }

                string outputPath = Path.Combine(outputFolder, Path.GetFileName(htmlPath));
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}