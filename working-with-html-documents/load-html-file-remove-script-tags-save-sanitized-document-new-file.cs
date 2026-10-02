// Load an HTML file, remove all script tags, and save the sanitized document to a new file.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllText(inputPath, "<html><head><script>alert('test');</script></head><body><h1>Hello</h1></body></html>");
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
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}