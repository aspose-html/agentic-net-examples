// Populate a template with user profile JSON and generate a personalized dashboard HTML page.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

namespace DashboardGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Paths to the template HTML, JSON data, and the output HTML file
                string templatePath = "template.html";
                string jsonPath = "userProfile.json";
                string outputPath = "dashboard.html";

                // Load JSON data for template merging
                TemplateData templateData = new TemplateData(jsonPath);

                // Use default template loading options
                TemplateLoadOptions options = new TemplateLoadOptions();

                // Merge the template with JSON data and save the result
                Converter.ConvertTemplate(templatePath, templateData, options, outputPath);

                Console.WriteLine("Dashboard generated successfully at: " + outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}