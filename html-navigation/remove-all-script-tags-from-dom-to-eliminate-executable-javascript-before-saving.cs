// Remove all script tags from the DOM to eliminate executable JavaScript before saving.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "output.html";

            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath,
                    "<html><head><script>alert('test');</script></head><body><h1>Hello</h1><script>console.log('test');</script></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            var scripts = document.GetElementsByTagName("script");

            for (int i = scripts.Length - 1; i >= 0; i--)
            {
                var script = scripts[i];
                if (script.ParentNode != null)
                {
                    script.ParentNode.RemoveChild(script);
                }
            }

            document.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}