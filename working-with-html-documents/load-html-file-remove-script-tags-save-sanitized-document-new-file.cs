// Load an HTML file, remove all script tags, and save the sanitized document to a new file.

namespace MyApp
{
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
                    string sampleHtml = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1><script>console.log('test');</script></body></html>";
                    System.IO.File.WriteAllText(inputPath, sampleHtml);
                }

                Aspose.Html.Configuration config = new Aspose.Html.Configuration();
                config.Security |= Aspose.Html.Sandbox.Scripts;

                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath, config);

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
                System.Console.WriteLine("Sanitized document saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}