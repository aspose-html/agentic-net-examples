// Create a reusable HTML email template and populate it with user data from an XML file.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string templatePath = "email_template.html";
            string dataPath = "user_data.xml";
            string resultPath = "email_result.html";

            if (!File.Exists(templatePath))
            {
                string templateContent = "<html><body><h1>Hello {{Name}}</h1><p>Your email is {{Email}}</p></body></html>";
                File.WriteAllText(templatePath, templateContent);
            }

            if (!File.Exists(dataPath))
            {
                string xmlContent = "<User><Name>John Doe</Name><Email>john.doe@example.com</Email></User>";
                File.WriteAllText(dataPath, xmlContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(templatePath, new Aspose.Html.Configuration());
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(dataPath);
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            Aspose.Html.HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(document, templateData, options);
            resultDocument.Save(resultPath);

            resultDocument.Dispose();
            document.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}