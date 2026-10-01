// Split the document into chapters based on level‑2 headings and save each as a separate file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "OutputChapters";

            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                var document = new Aspose.Html.HTMLDocument(htmlPath);
                var headings = document.QuerySelectorAll("h2");

                for (int i = 0; i < headings.Length; i++)
                {
                    var chapterDoc = new Aspose.Html.HTMLDocument();
                    var body = chapterDoc.Body;

                    var clonedHeading = (Aspose.Html.HTMLElement)headings[i].CloneNode(true);
                    body.AppendChild(clonedHeading);

                    var node = headings[i].NextSibling;
                    while (node != null && !(node is Aspose.Html.HTMLElement element && element.TagName.Equals("h2", StringComparison.OrdinalIgnoreCase)))
                    {
                        var clonedNode = node.CloneNode(true);
                        body.AppendChild(clonedNode);
                        node = node.NextSibling;
                    }

                    string chapterFileName = $"{Path.GetFileNameWithoutExtension(htmlPath)}_Chapter{i + 1}.html";
                    string chapterPath = Path.Combine(outputFolder, chapterFileName);
                    chapterDoc.Save(chapterPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}