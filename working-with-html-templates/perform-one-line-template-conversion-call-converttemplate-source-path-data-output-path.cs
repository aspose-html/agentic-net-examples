// Perform a one‑line template conversion by calling ConvertTemplate with source path, data, and output path.

using System;
using System.IO;

namespace TemplateConversionExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                string sourcePath = "template.html";
                string templateDataPath = "data.json";
                string resultPath = "result.html";

                if (!File.Exists(sourcePath))
                {
                    File.WriteAllText(sourcePath, "<html><body><h1>{{title}}</h1></body></html>");
                }

                if (!File.Exists(templateDataPath))
                {
                    File.WriteAllText(templateDataPath, "{\"title\":\"Hello World\"}");
                }

                Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(templateDataPath);
                Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();
                Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath, new Aspose.Html.Configuration());
                Aspose.Html.HTMLDocument resultDoc = Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, options);
                resultDoc.Save(resultPath);
                Console.WriteLine("Template conversion completed. Output saved to: " + resultPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}