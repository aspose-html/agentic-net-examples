// Apply TemplateLoadOptions to enable loading HTML templates that contain external CSS references for styling.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "template.html";
            string outputPath = "output.html";

            // Create sample CSS file
            if (!System.IO.File.Exists("style.css"))
            {
                System.IO.File.WriteAllText("style.css", "body { background-color: #e5f3fd; }");
            }

            // Create sample HTML template with external CSS reference
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath,
                    "<!DOCTYPE html><html><head><link rel=\"stylesheet\" href=\"style.css\"></head><body><h1>Hello, Template!</h1></body></html>");
            }

            // Load the HTML template
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);

            // Prepare template data (empty in this example)
            Aspose.Html.Converters.TemplateData data = new Aspose.Html.Converters.TemplateData("");

            // Configure load options to enable external resources
            Aspose.Html.Loading.TemplateLoadOptions options = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert the template
            Aspose.Html.HTMLDocument result = Aspose.Html.Converters.Converter.ConvertTemplate(document, data, options);

            // Save the resulting document
            result.Save(outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
    }
}