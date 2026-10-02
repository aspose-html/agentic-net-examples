// Create a template string that includes a conditional class attribute based on user role.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

class Program
{
    static void Main()
    {
        try
        {
            // Template with conditional class attribute based on role
            string htmlTemplate = "<div class=\"{{#if role='admin'}}admin{{else}}user{{/if}}\">Welcome</div>";

            // Data providing the role value
            string data = "<root><role>admin</role></root>";

            // Output file path
            string outputPath = "output.html";

            // Prepare template content options (XML data)
            TemplateContentOptions contentOptions = new TemplateContentOptions(data, TemplateContent.XML);

            // Create template data object
            TemplateData templateData = new TemplateData(contentOptions);

            // Load options (default)
            TemplateLoadOptions loadOptions = new TemplateLoadOptions();

            // Convert the template using the provided data
            HTMLDocument document = Aspose.Html.Converters.Converter.ConvertTemplate(htmlTemplate, data, templateData, loadOptions);

            // Save the resulting HTML
            document.Save(outputPath);

            Console.WriteLine("Template processed and saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}