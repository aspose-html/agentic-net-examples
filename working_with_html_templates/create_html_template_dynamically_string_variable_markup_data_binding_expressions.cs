// Create an HTML template dynamically from a string variable containing markup with data‑binding expressions.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Loading;

namespace AsposeHtmlTemplateExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // HTML template with data‑binding expressions
                string htmlTemplate = @"
                    <html>
                        <body>
                            <h1>Hello {{name}}!</h1>
                        </body>
                    </html>";

                // Path to JSON data file used for binding
                string dataPath = "data.json";

                // Output HTML file after merging template with data
                string outputPath = "merged.html";

                // Load user data for merging
                TemplateData data = new TemplateData(dataPath);

                // Set template loading options (default options are sufficient)
                TemplateLoadOptions options = new TemplateLoadOptions();

                // Merge the template with data and save the result
                Converter.ConvertTemplate(htmlTemplate, "", data, options, outputPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}