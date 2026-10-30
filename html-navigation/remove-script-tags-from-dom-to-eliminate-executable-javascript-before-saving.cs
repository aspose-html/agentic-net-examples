// Remove all script tags from the DOM to eliminate executable JavaScript before saving.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output file paths
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample input file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1><script>alert('test');</script></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
            }

            // Load document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Get all script elements
            var scripts = document.GetElementsByTagName("script");

            // Iterate safely and remove
            for (int i = scripts.Length - 1; i >= 0; i--)
            {
                var script = scripts[i];
                if (script.ParentNode != null)
                {
                    script.ParentNode.RemoveChild(script);
                }
            }

            // Save document
            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}