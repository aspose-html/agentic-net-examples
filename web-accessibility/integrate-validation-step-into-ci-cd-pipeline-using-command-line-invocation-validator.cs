// Integrate the validation step into a CI/CD pipeline using a command‑line invocation of the validator.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath;
                if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
                {
                    inputPath = args[0];
                }
                else
                {
                    string tempDir = System.IO.Path.GetTempPath();
                    inputPath = System.IO.Path.Combine(tempDir, "sample.html");
                    if (!System.IO.File.Exists(inputPath))
                    {
                        string sampleHtml = "<!DOCTYPE html><html><head><title>Sample</title></head><body><h1>Hello World</h1></body></html>";
                        System.IO.File.WriteAllText(inputPath, sampleHtml);
                    }
                }

                using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath))
                {
                    Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                    Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                    Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);

                    System.Console.WriteLine("Validation Success: " + validationResult.Success);
                    if (!validationResult.Success)
                    {
                        foreach (Aspose.Html.Accessibility.Results.RuleValidationResult detail in validationResult.Details)
                        {
                            System.Console.WriteLine($"Rule: {detail.Rule.Code} - {detail.Rule.Description} - Success: {detail.Success}");
                        }
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