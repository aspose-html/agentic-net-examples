// Use a single line of code to convert a template string directly to an HTML file.

using System;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

namespace TemplateConversionExample
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Template HTML string
                string htmlContent = "<html><body>Hello {{name}}</body></html>";
                // Output file path
                string outputPath = "output.html";

                // Convert the template string directly to an HTML file in a single line
                Converter.ConvertTemplate(htmlContent, "", new TemplateData(""), new TemplateLoadOptions(), outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}