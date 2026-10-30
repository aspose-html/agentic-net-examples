// Open the resulting PDF and confirm that interactive form fields are no longer editable, indicating successful flattening.

using System;
using System.IO;

public class Program
{
    public static void Main()
    {
        try
        {
            string sourcePath = "sample.html";
            string resultPath = "output.pdf";

            if (!File.Exists(sourcePath))
            {
                string htmlContent = "<!DOCTYPE html><html><body><form><input type='text' name='name' value='John Doe'></form></body></html>";
                File.WriteAllText(sourcePath, htmlContent);
            }

            Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
            options.FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened;

            Aspose.Html.Converters.Converter.ConvertHTML(sourcePath, options, resultPath);

            Console.WriteLine("PDF generated with flattened form fields at: " + resultPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}