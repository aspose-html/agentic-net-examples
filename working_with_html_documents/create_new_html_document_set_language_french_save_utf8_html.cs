// Create a new HTML document, set its language attribute to French, and save as UTF-8 HTML.

using System;
using Aspose.Html;

class Program
{
    static void Main()
    {
        try
        {
            string outputPath = "output.html";
            Aspose.Html.HTMLDocument doc = new Aspose.Html.HTMLDocument();
            doc.DocumentElement.SetAttribute("lang", "fr");
            doc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}