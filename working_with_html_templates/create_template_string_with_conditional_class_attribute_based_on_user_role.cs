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
            // HTML template with a placeholder for the class attribute
            string htmlTemplate = "<div class=\"${class}\">Welcome, user!</div>";

            // XML data that defines the class based on the user role
            string xmlData = "<data><class>admin</class></data>";

            // Convert the template using the XML data
            HTMLDocument htmlDocument = Converter.ConvertTemplate(
                htmlTemplate,
                "", // base URL (empty)
                new TemplateData(
                    new TemplateContentOptions(xmlData, TemplateContent.XML)
                ),
                new TemplateLoadOptions()
            );

            // Save the resulting HTML file
            string outputPath = "output.html";
            htmlDocument.Save(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}