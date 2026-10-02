// Batch process HTML files, remove all script tags, and generate sanitized versions for safe distribution.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputHtml";
            string outputFolder = "SanitizedHtml";

            // Ensure folders exist
            Directory.CreateDirectory(inputFolder);
            Directory.CreateDirectory(outputFolder);

            // Create a sample HTML file if none exist
            string samplePath = Path.Combine(inputFolder, "sample.html");
            if (!File.Exists(samplePath))
            {
                File.WriteAllText(samplePath, "<html><head><script>alert('test');</script></head><body><p>Hello</p></body></html>");
            }

            // Process each HTML file
            foreach (string htmlPath in Directory.GetFiles(inputFolder, "*.html"))
            {
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath))
                {
                    var scripts = document.GetElementsByTagName("script");
                    for (int i = scripts.Length - 1; i >= 0; i--)
                    {
                        var script = scripts[i];
                        if (script.ParentNode != null)
                        {
                            script.ParentNode.RemoveChild(script);
                        }
                    }

                    string outputPath = Path.Combine(outputFolder, Path.GetFileName(htmlPath));
                    document.Save(outputPath);
                }
            }

            Console.WriteLine("Sanitization completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}