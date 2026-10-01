// Toggle the checked state of task list items programmatically to reflect completion status.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            // Define paths
            string templatePath = "task_template.html";
            string outputPath = "task_output.html";

            // Create a simple HTML template with a checkbox (task list item)
            string htmlContent = "<!DOCTYPE html><html><head><meta charset=\"UTF-8\"></head><body><ul><li><input type=\"checkbox\" id=\"task1\"/> Complete the report</li></ul></body></html>";
            File.WriteAllText(templatePath, htmlContent);

            // Define the desired checked state
            bool isChecked = true;

            // Load the template document
            Aspose.Html.HTMLDocument templateDocument = new Aspose.Html.HTMLDocument(templatePath, "");

            // Prepare template data (no dynamic data, just static XML content)
            Aspose.Html.Converters.TemplateContentOptions contentOptions = new Aspose.Html.Converters.TemplateContentOptions(string.Empty, Aspose.Html.Converters.TemplateContent.XML);
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(contentOptions);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template to a regular HTML document
            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(templateDocument, templateData, loadOptions);

            // Locate the checkbox input element and set its checked state
            Aspose.Html.HTMLInputElement input = (Aspose.Html.HTMLInputElement)resultDocument.GetElementsByTagName("input")[0];
            input.Checked = isChecked;

            // Save the modified document
            resultDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}