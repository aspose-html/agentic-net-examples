// Create a template that binds a data‑driven title attribute to display tooltips on hover.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string templateHtml = "<!DOCTYPE html><html><head><title>Template</title></head><body><a href=\"#\" title=\"{{tooltip}}\">Hover me</a></body></html>";
            var document = new Aspose.Html.HTMLDocument(templateHtml, "about:blank");
            var data = new Aspose.Html.Converters.TemplateData("{\"tooltip\":\"This is a tooltip\"}");
            var options = new Aspose.Html.Loading.TemplateLoadOptions();
            var resultDoc = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);
            string outputPath = "output.html";
            resultDoc.Save(outputPath);
            Console.WriteLine("Template converted and saved to " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}