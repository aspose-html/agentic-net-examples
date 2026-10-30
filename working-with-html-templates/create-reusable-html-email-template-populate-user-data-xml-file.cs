// Create a reusable HTML email template and populate it with user data from an XML file.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;
using Aspose.Html.Saving;

class Program
{
    static void Main()
    {
        try
        {
            // Define file paths
            string templatePath = "template.html";
            string dataPath = "data.xml";
            string resultPath = "result.html";

            // Create a simple HTML email template if it does not exist
            if (!File.Exists(templatePath))
            {
                string templateContent = @"
<!DOCTYPE html>
<html>
<head>
    <meta charset=""UTF-8"">
    <title>Email Template</title>
</head>
<body>
    <h1>Hello, {{Name}}!</h1>
    <p>We have your email as: {{Email}}</p>
</body>
</html>";
                File.WriteAllText(templatePath, templateContent);
            }

            // Create a simple XML data file if it does not exist
            if (!File.Exists(dataPath))
            {
                string xmlContent = @"
<Users>
    <User>
        <Name>John Doe</Name>
        <Email>john.doe@example.com</Email>
    </User>
</Users>";
                File.WriteAllText(dataPath, xmlContent);
            }

            // Load template data from XML
            TemplateData templateData = new TemplateData(dataPath);

            // Load the HTML template document
            HTMLDocument templateDocument = new HTMLDocument(templatePath, new Configuration());

            // Set template load options (default)
            TemplateLoadOptions options = new TemplateLoadOptions();

            // Convert the template with data
            HTMLDocument resultDocument = Aspose.Html.Converters.Converter.ConvertTemplate(templateDocument, templateData, options);

            // Save the populated result
            resultDocument.Save(resultPath, new HTMLSaveOptions());

            // Clean up
            resultDocument.Dispose();
            templateDocument.Dispose();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}