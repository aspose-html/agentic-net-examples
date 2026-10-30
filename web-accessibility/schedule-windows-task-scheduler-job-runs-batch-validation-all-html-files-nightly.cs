// Schedule a Windows Task Scheduler job that runs batch validation on all HTML files nightly.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "ValidationResults";

            System.IO.Directory.CreateDirectory(inputFolder);
            System.IO.Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            if (System.IO.Directory.GetFiles(inputFolder, "*.html").Length == 0)
            {
                string samplePath = System.IO.Path.Combine(inputFolder, "sample.html");
                System.IO.File.WriteAllText(samplePath, "<!DOCTYPE html><html><head><title>Sample</title></head><body><p>Hello</p></body></html>");
            }

            foreach (string htmlPath in System.IO.Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    Aspose.Html.Accessibility.WebAccessibility webAcc = new Aspose.Html.Accessibility.WebAccessibility();
                    var validator = webAcc.CreateValidator(); // default rule set
                    var result = validator.Validate(document);

                    string resultPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(htmlPath) + ".txt");
                    System.IO.File.WriteAllText(resultPath, result.SaveToString());

                    System.Console.WriteLine($"Validated '{htmlPath}'. Success: {result.Success}");
                }
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}