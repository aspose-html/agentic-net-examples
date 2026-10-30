// Redirect console output of validation issues to a log file for persistent storage.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string logPath = "validation_log.txt";
                using (System.IO.StreamWriter logWriter = new System.IO.StreamWriter(logPath, false))
                {
                    System.IO.TextWriter originalOut = System.Console.Out;
                    System.Console.SetOut(logWriter);

                    string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><img src='missing.jpg'></body></html>";
                    using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlContent, "about:blank"))
                    {
                        Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                        Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator();
                        Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                        string resultXml = validationResult.SaveToString();
                        System.Console.WriteLine(resultXml);
                    }

                    System.Console.SetOut(originalOut);
                }

                System.Console.WriteLine("Validation completed. Log written to validation_log.txt");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}