// Load an HTML file, remove all script tags, and save the sanitized document to a new file.

using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.html";
            string outputPath = "output.html";

            if (!System.IO.File.Exists(inputPath))
            {
                string sampleHtml = "<html><head><script>alert('test');</script></head><body><p>Hello World</p></body></html>";
                System.IO.File.WriteAllText(inputPath, sampleHtml);
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