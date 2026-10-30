// Create a template string that includes a conditional class attribute based on user role.

using System;

class Program
{
    static void Main()
    {
        try
        {
            // Define role and compute class
            string role = "admin";
            string roleClass = role == "admin" ? "admin-class" : "user-class";

            // Template with placeholder for class attribute
            string template = "<div class=\"{{roleClass}}\">Welcome, user!</div>";

            // Replace placeholder based on role
            string processedTemplate = template.Replace("{{roleClass}}", roleClass);

            // Prepare template conversion options
            Aspose.Html.Converters.TemplateContentOptions contentOptions = new Aspose.Html.Converters.TemplateContentOptions(processedTemplate, Aspose.Html.Converters.TemplateContent.XML);
            Aspose.Html.Converters.TemplateData templateData = new Aspose.Html.Converters.TemplateData(contentOptions);
            Aspose.Html.Loading.TemplateLoadOptions loadOptions = new Aspose.Html.Loading.TemplateLoadOptions();

            // Convert template to HTMLDocument
            Aspose.Html.HTMLDocument htmlDocument = Aspose.Html.Converters.Converter.ConvertTemplate(string.Empty, string.Empty, templateData, loadOptions);

            // Save the result
            string outputPath = "output.html";
            htmlDocument.Save(outputPath);

            Console.WriteLine("HTML document saved to: " + outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}