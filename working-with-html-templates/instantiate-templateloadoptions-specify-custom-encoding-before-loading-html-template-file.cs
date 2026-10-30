// Instantiate TemplateLoadOptions to specify custom encoding before loading an HTML template file.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "template.html";
            string outputPath = "output.html";

            if (!System.IO.File.Exists(inputPath))
            {
                string templateContent = "<html><head><title>{{title}}</title></head><body><h1>{{title}}</h1></body></html>";
                System.IO.File.WriteAllText(inputPath, templateContent, System.Text.Encoding.UTF8);
            }

            var options = new Aspose.Html.Loading.TemplateLoadOptions();

            var document = new Aspose.Html.HTMLDocument(inputPath);
            var data = new Aspose.Html.Converters.TemplateData("{\"title\":\"Hello World\"}");

            var resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);
            resultDocument.Save(outputPath);

            System.Console.WriteLine("Conversion completed. Output saved to " + outputPath);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}