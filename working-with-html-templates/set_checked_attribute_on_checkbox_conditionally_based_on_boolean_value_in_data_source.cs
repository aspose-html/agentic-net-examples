// Set the checked attribute on a checkbox conditionally based on a boolean value in the data source.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string htmlTemplate = "<!DOCTYPE html><html><body><input type=\"checkbox\" id=\"myCheckbox\"/></body></html>";
            bool isChecked = true;
            string outputPath = "output.html";

            Aspose.Html.HTMLDocument templateDocument = new Aspose.Html.HTMLDocument(htmlTemplate, "");

            Aspose.Html.Converters.TemplateContentOptions contentOptions = new Aspose.Html.Converters.TemplateContentOptions(htmlTemplate, Aspose.Html.Converters.TemplateContent.XML);
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(contentOptions);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(templateDocument, templateData, loadOptions);

            Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)resultDocument.GetElementsByTagName("input")[0];
            input.Checked = isChecked;

            resultDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}