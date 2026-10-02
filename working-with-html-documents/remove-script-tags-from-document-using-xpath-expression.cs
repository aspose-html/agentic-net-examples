// Remove all <script> tags from the document using an XPath expression.

using System;

namespace RemoveScriptTags
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "input.html";
                string outputPath = "output.html";

                // Create a minimal sample input file if it does not exist
                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllText(inputPath,
                        "<html><head><script src='test.js'></script></head><body><h1>Hello</h1><script>alert('hi');</script></body></html>");
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
                Console.WriteLine("Script tags removed. Output saved to " + outputPath);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}