// Split an HTML document into separate files at each top‑level heading for modular publishing.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputHtml";

            if (!System.IO.Directory.Exists(inputFolder))
            {
                System.IO.Directory.CreateDirectory(inputFolder);
                string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                string sampleContent = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Chapter 1</h1><p>Content of chapter 1.</p><h1>Chapter 2</h1><p>Content of chapter 2.</p></body></html>";
                System.IO.File.WriteAllText(samplePath, sampleContent);
            }

            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    var headings = document.QuerySelectorAll("h1");
                    for (int i = 0; i < headings.Length; i++)
                    {
                        Aspose.Html.HTMLElement heading = (Aspose.Html.HTMLElement)headings[i];

                        using (Aspose.Html.HTMLDocument newDoc = new Aspose.Html.HTMLDocument())
                        {
                            var newBody = newDoc.Body;

                            Aspose.Html.HTMLElement clonedHeading = (Aspose.Html.HTMLElement)heading.CloneNode(true);
                            newBody.AppendChild(clonedHeading);

                            var sibling = heading.NextSibling;
                            while (sibling != null && !(sibling is Aspose.Html.HTMLElement && ((Aspose.Html.HTMLElement)sibling).TagName.Equals("h1", System.StringComparison.OrdinalIgnoreCase)))
                            {
                                Aspose.Html.HTMLElement clonedSibling = (Aspose.Html.HTMLElement)sibling.CloneNode(true);
                                newBody.AppendChild(clonedSibling);
                                sibling = sibling.NextSibling;
                            }

                            string safeTitle = System.Text.RegularExpressions.Regex.Replace(heading.TextContent.Trim(), @"[^\w\-]+", "_");
                            string newFileName = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + "_" + safeTitle + ".html");
                            newDoc.Save(newFileName);
                        }
                    }
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}