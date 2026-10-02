// Open the resulting PDF and confirm that interactive form fields are no longer editable, indicating successful flattening.

using System;
using System.IO;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string sourcePath = "sample.html";
            string resultPath = "flattened.pdf";

            // Create a minimal HTML file with a form field
            string htmlContent = @"<!DOCTYPE html>
<html>
<body>
    <form>
        <label for='name'>Name:</label>
        <input type='text' id='name' name='name' value='John Doe'>
    </form>
</body>
</html>";
            File.WriteAllText(sourcePath, htmlContent);

            // Load the HTML document from the file
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(sourcePath);

            // Configure PDF save options to flatten form fields
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;

            // Convert HTML to PDF with flattening
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, resultPath);

            Console.WriteLine($"PDF generated at '{Path.GetFullPath(resultPath)}' with form fields flattened.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}