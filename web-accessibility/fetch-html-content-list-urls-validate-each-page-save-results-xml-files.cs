// Fetch HTML content from a list of URLs, validate each page, and save results as XML files.

namespace AsposeHtmlValidationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                System.Collections.Generic.List<string> urls = new System.Collections.Generic.List<string>
                {
                    "https://example.com",
                    "https://example.org"
                };

                string outputDirectory = "ValidationResults";
                System.IO.Directory.CreateDirectory(outputDirectory);

                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);

                int index = 1;
                foreach (string url in urls)
                {
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(url))
                    {
                        Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                        string outputPath = System.IO.Path.Combine(outputDirectory, $"validation_result_{index}.xml");
                        System.IO.File.WriteAllText(outputPath, validationResult.ToString());
                    }
                    index++;
                }
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}