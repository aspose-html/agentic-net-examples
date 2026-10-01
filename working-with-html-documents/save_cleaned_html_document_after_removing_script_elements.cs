// Save the cleaned HTML document after removing script elements from it.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // ✔ Load document
            string inputPath = "input.html";
            string outputPath = "output.html";

            // Create a minimal sample input file if it does not exist
            if (!File.Exists(inputPath))
            {
                string sampleHtml = "<!DOCTYPE html><html><head><script>console.log('test');</script></head><body><p>Hello World</p></body></html>";
                File.WriteAllText(inputPath, sampleHtml);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // ✔ Get all script elements
            var scripts = document.GetElementsByTagName("script");

            // ✔ Iterate safely and remove
            for (int i = scripts.Length - 1; i >= 0; i--)
            {
                var script = scripts[i];
                if (script.ParentNode != null)
                {
                    script.ParentNode.RemoveChild(script);
                }
            }

            // ✔ Save document
            document.Save(outputPath);
            Console.WriteLine($"Document saved to {outputPath}");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}