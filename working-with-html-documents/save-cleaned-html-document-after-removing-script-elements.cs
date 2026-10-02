// Save the cleaned HTML document after removing script elements from it.

using System;
using System.IO;
using Aspose.Html;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.html";
        string outputPath = "output.html";

        try
        {
            // Create a minimal sample input file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<html><head><script>alert('test');</script></head><body><p>Hello World</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            // Load document
            HTMLDocument document = new HTMLDocument(inputPath);

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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}