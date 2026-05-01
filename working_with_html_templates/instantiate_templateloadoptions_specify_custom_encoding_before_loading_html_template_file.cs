// Instantiate TemplateLoadOptions to specify custom encoding before loading an HTML template file.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "template.html";
            string dataPath = "data.json";
            string outputPath = "output.html";

            TemplateLoadOptions options = new TemplateLoadOptions();
            options.NamesAreCaseSensitive = false; // example custom setting

            TemplateData data = new TemplateData(dataPath);

            Converter.ConvertTemplate(inputPath, data, options, outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}