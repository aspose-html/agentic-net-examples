// Apply TemplateLoadOptions to enable loading HTML templates that contain external CSS references for styling.

using System;
using Aspose.Html;
using Aspose.Html.Loading;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "template.html";
            string outputPath = "result.html";

            HTMLDocument document = new HTMLDocument(inputPath);

            TemplateData data = new TemplateData("{}");

            TemplateLoadOptions options = new TemplateLoadOptions();

            Converter.ConvertTemplate(document, data, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}