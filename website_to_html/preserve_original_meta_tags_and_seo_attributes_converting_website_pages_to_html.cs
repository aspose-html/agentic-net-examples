// Preserve original meta tags and SEO attributes when converting website pages to HTML.

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

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
            document.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}