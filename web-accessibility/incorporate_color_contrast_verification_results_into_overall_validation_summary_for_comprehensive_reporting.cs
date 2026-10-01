// Incorporate color contrast verification results into the overall validation summary for comprehensive reporting.

using System;
using System.IO;
using System.Drawing;

class Program
{
    static void Main()
    {
        try
        {
            // Prepare sample HTML file
            string htmlFilePath = Path.Combine(Path.GetTempPath(), "sample.html");
            string htmlContent = "<!DOCTYPE html><html><head><title>Test</title></head><body><h1>Hello World</h1><img src='image.png' alt='Sample Image'></body></html>";
            File.WriteAllText(htmlFilePath, htmlContent);

            // Accessibility validation
            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlFilePath))
            {
                Aspose.Html.Accessibility.WebAccessibility webAccessibility = new Aspose.Html.Accessibility.WebAccessibility();
                Aspose.Html.Accessibility.AccessibilityValidator validator = webAccessibility.CreateValidator(Aspose.Html.Accessibility.ValidationBuilder.All);
                Aspose.Html.Accessibility.Results.ValidationResult validationResult = validator.Validate(document);
                if (!validationResult.Success)
                {
                    foreach (Aspose.Html.Accessibility.Results.RuleValidationResult ruleResult in validationResult.Details)
                    {
                        if (!ruleResult.Success)
                        {
                            foreach (Aspose.Html.Accessibility.ITechniqueResult techResult in ruleResult.Errors)
                            {
                                if (techResult.Error.Target.TargetType == Aspose.Html.Accessibility.TargetTypes.HTMLElement)
                                {
                                    Aspose.Html.HTMLElement element = (Aspose.Html.HTMLElement)techResult.Error.Target.Item;
                                    string tagName = element.TagName;
                                    string attributeValue = element.GetAttribute("alt");
                                    Console.WriteLine($"Tag: {tagName}, Attribute: {attributeValue}, Message: {techResult.Error.ErrorMessage}");
                                }
                            }
                        }
                    }
                }
            }

            // PDF conversion
            string pdfOutputPath = Path.Combine(Path.GetTempPath(), "output.pdf");
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            pdfOptions.HorizontalResolution = 300;
            pdfOptions.VerticalResolution = 300;
            pdfOptions.BackgroundColor = System.Drawing.Color.AliceBlue;
            pdfOptions.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(new Aspose.Html.Drawing.Size(595, 842));

            using (Aspose.Html.HTMLDocument pdfDoc = new Aspose.Html.HTMLDocument(htmlFilePath))
            {
                Aspose.Html.Converters.Converter.ConvertHTML(pdfDoc, pdfOptions, pdfOutputPath);
            }

            // XPS conversion
            string xpsOutputPath = Path.Combine(Path.GetTempPath(), "output.xps");
            Aspose.Html.Saving.XpsSaveOptions xpsOptions = new Aspose.Html.Saving.XpsSaveOptions();

            using (Aspose.Html.HTMLDocument xpsDoc = new Aspose.Html.HTMLDocument(htmlFilePath))
            {
                Aspose.Html.Converters.Converter.ConvertHTML(xpsDoc, xpsOptions, xpsOutputPath);
            }

            Console.WriteLine("Processing completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}