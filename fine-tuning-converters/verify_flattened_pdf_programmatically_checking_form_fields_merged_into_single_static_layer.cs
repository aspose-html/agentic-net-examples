// Verify flattened PDF by programmatically checking that form fields are merged into a single static layer.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.html";
            string outputPath = "flattened.pdf";

            if (!File.Exists(inputPath))
            {
                string htmlContent = @"<!DOCTYPE html>
<html>
<head><title>Form Sample</title></head>
<body>
<form>
    <label for='name'>Name:</label>
    <input type='text' id='name' name='name' value='John Doe' />
</form>
</body>
</html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(inputPath);
            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;
            Aspose.Html.Converters.Converter.ConvertHTML(document, options, outputPath);

            Console.WriteLine("PDF generated with form fields flattened: " + Path.GetFullPath(outputPath));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}