// Convert an HTML file to an MHTML file with default MHTMLSaveOptions using the static ConvertHTML method.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string outputPath = "output.mhtml";

            if (!System.IO.File.Exists(sourcePath))
            {
                System.IO.File.WriteAllText(sourcePath, "<html><body><h1>Hello World</h1></body></html>");
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);
            Aspose.Html.Saving.MHTMLSaveOptions options = new Aspose.Html.Saving.MHTMLSaveOptions();
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}