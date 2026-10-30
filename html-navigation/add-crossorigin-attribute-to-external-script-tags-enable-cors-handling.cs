// Add a crossorigin attribute to external script tags to enable CORS handling.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><script src=\"https://example.com/script.js\"></script></head><body><h1>Hello</h1></body></html>";
            System.IO.File.WriteAllText(htmlPath, htmlContent);

            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            configuration.Security |= Aspose.Html.Sandbox.Scripts;

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                Aspose.Html.Collections.HTMLCollection scriptElements = document.GetElementsByTagName("script");
                for (int i = 0; i < scriptElements.Length; i++)
                {
                    Aspose.Html.Dom.Element scriptElement = (Aspose.Html.Dom.Element)scriptElements[i];
                    string src = scriptElement.GetAttribute("src");
                    if (!string.IsNullOrEmpty(src))
                    {
                        scriptElement.SetAttribute("crossorigin", "anonymous");
                        System.Console.WriteLine($"Updated script src: {src}");
                    }
                }

                string outputPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "sample_modified.html");
                document.Save(outputPath);
                System.Console.WriteLine($"Modified HTML saved to: {outputPath}");
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}