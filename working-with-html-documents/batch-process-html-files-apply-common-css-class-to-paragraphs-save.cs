// Batch process a list of HTML files, apply a common CSS class to all paragraphs, and save.

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
                System.IO.Directory.CreateDirectory(inputFolder);
            if (!System.IO.Directory.Exists(outputFolder))
                System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
            if (!System.IO.File.Exists(samplePath))
            {
                System.IO.File.WriteAllText(samplePath,
                    "<html><head><title>Sample</title></head><body><p>First paragraph.</p><p>Second paragraph.</p></body></html>");
            }

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);
                Aspose.Html.Collections.NodeList elements = document.QuerySelectorAll("p");
                foreach (Aspose.Html.HTMLElement element in elements)
                {
                    element.SetAttribute("class", "myClass");
                }

                string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileName(htmlPath));
                document.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}