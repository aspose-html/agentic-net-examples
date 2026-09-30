// Open the resulting PDF and confirm that interactive form fields are no longer editable, indicating successful flattening.

using System;
using System.IO;
using System.Diagnostics;
using Aspose.Html;
using Aspose.Html.Saving;
using Aspose.Html.Rendering.Pdf;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string htmlPath = "sample.html";
            string pdfPath = "flattened_form.pdf";

            // Create a minimal HTML file with a form field
            string htmlContent = @"
<!DOCTYPE html>
<html>
<head><title>Form Test</title></head>
<body>
    <form>
        <label for='name'>Name:</label>
        <input type='text' id='name' name='name' value='John Doe' />
    </form>
</body>
</html>";
            File.WriteAllText(htmlPath, htmlContent);

            // Load the HTML document
            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath);

            // Set PDF save options to flatten form fields
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;

            // Convert HTML to PDF with flattening
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);

            // Open the resulting PDF for visual verification
            Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });

            Console.WriteLine("PDF generated with flattened form fields at: " + Path.GetFullPath(pdfPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}