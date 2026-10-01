// Save validation results to a JSON file for later analysis and integration with reporting tools.

using System;
using System.IO;
using System.Text.Json.Nodes;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML content
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
            string htmlPath = "sample.html";
            File.WriteAllText(htmlPath, htmlContent);

            // Accessibility validation
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent))
            {
                Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                using (StringWriter sw = new StringWriter())
                {
                    validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                    string validationXml = sw.ToString();
                    Console.WriteLine("Accessibility Validation Result (XML):");
                    Console.WriteLine(validationXml);
                }
            }

            // Prepare sample JSON data for template
            string jsonPath = "data.json";
            File.WriteAllText(jsonPath, "{\"title\":\"World\"}");

            // Prepare a simple template file
            string templatePath = "template.html";
            string templateContent = "<!DOCTYPE html><html><head><title>{{title}}</title></head><body><h1>Hello {{title}}!</h1></body></html>";
            File.WriteAllText(templatePath, templateContent);

            // Convert template using JSON data
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(jsonPath);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();
            Aspose.Html.HTMLDocument convertedDoc = Aspose.Html.Converters.Converter.ConvertTemplate(templatePath, templateData, loadOptions);
            string convertedOutputPath = "converted.html";
            convertedDoc.Save(convertedOutputPath);
            Console.WriteLine($"Template converted and saved to '{convertedOutputPath}'.");

            // Configure network service with custom message handler
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new JsonModifyingHandler());

            // Load HTML document with custom configuration and save
            using (Aspose.Html.HTMLDocument docWithConfig = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                string finalOutputPath = "final.html";
                docWithConfig.Save(finalOutputPath);
                Console.WriteLine($"Document loaded with custom configuration and saved to '{finalOutputPath}'.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}

// Custom network message handler that modifies JSON responses
class JsonModifyingHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        // Continue the pipeline
        Next(context);

        if (context.Response.Content == null)
            return;

        string json = context.Response.Content.ReadAsString();
        try
        {
            JsonNode node = JsonNode.Parse(json);
            // Example modification: add a new property
            node["addedProperty"] = "newValue";
            string newJson = node.ToJsonString();
            Console.WriteLine("Modified JSON response:");
            Console.WriteLine(newJson);
        }
        catch
        {
            // Ignore parsing errors
        }
    }
}