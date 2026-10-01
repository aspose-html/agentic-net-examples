// Create a new HTML document, import an external CSS file, and export the combined result as HTML.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string outputDir = "output";
            System.IO.Directory.CreateDirectory(outputDir);

            string cssPath = System.IO.Path.Combine(outputDir, "style.css");
            System.IO.File.WriteAllText(cssPath, "body { background-color: #f0f0f0; }");

            string htmlContent = "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style.css\"></head><body><h1>Hello World</h1></body></html>";

            string baseUri = System.IO.Path.GetFullPath(outputDir) + System.IO.Path.DirectorySeparatorChar;

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, baseUri);

            string outputPath = System.IO.Path.Combine(outputDir, "result.html");
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}