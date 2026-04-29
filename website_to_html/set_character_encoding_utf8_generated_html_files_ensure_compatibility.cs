// Set character encoding to UTF‑8 for all generated HTML files to ensure compatibility.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "input.html";
            string outputPath = "output.html";
            string htmlContent = System.IO.File.ReadAllText(sourcePath, System.Text.Encoding.UTF8);
            string basePath = System.IO.Path.GetDirectoryName(sourcePath);
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, basePath);
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}