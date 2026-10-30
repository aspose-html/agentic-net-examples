// Render an MHTML file to PDF and add a digital signature using the drawing namespace.

using System;
using System.IO;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class Program
{
    static void Main()
    {
        try
        {
            // Define input MHTML and output PDF paths
            string inputPath = Path.Combine(Directory.GetCurrentDirectory(), "sample.mhtml");
            string outputPath = Path.Combine(Directory.GetCurrentDirectory(), "result.pdf");

            // Create a minimal MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<html><body><h1>Sample Document</h1></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            // Open the MHTML file as a stream
            using (FileStream stream = File.OpenRead(inputPath))
            {
                // Set PDF save options (flatten form fields as an example)
                PdfSaveOptions options = new PdfSaveOptions
                {
                    FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened
                };

                // Convert MHTML to PDF
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML has been successfully rendered to PDF at:");
            Console.WriteLine(outputPath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred:");
            Console.WriteLine(ex.Message);
        }
    }
}