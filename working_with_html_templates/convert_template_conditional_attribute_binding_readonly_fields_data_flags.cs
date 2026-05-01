// Convert a template that uses conditional attribute binding for readonly fields based on data flags.

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
            string jsonPath = "data.json";
            string outputPath = "output.html";

            HTMLDocument templateDoc = new HTMLDocument(inputPath);
            TemplateData templateData = new TemplateData(jsonPath);
            TemplateLoadOptions loadOptions = new TemplateLoadOptions();

            Converter.ConvertTemplate(templateDoc, templateData, loadOptions, outputPath);

            HTMLDocument resultDoc = new HTMLDocument(outputPath);
            HTMLInputElement input = (HTMLInputElement)resultDoc.GetElementsByTagName("input")[0];
            input.ReadOnly = true;
            resultDoc.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}