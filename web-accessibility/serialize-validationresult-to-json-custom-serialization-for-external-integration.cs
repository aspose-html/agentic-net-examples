// Serialize the ValidationResult to JSON using custom serialization for external tool integration.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello</h1></body></html>";
                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
                {
                    Aspose.Html.Accessibility.AccessibilityValidator validator = new Aspose.Html.Accessibility.WebAccessibility().CreateValidator();
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                    using (System.IO.StringWriter sw = new System.IO.StringWriter())
                    {
                        validationResult.SaveTo(sw, Aspose.Html.Accessibility.Saving.ValidationResultSaveFormat.XML);
                        string xml = sw.ToString();
                        System.Text.Json.Nodes.JsonObject jsonObj = new System.Text.Json.Nodes.JsonObject();
                        jsonObj["validationResultXml"] = xml;
                        string json = jsonObj.ToJsonString();
                        System.Console.WriteLine(json);
                    }
                }
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine("Error: " + ex.Message);
            }
        }
    }
}