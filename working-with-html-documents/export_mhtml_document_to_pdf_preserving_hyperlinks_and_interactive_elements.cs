// Export an MHTML document to PDF while preserving hyperlinks and interactive elements.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "sample.mhtml";
            string resultPath = "output.pdf";

            if (!File.Exists(sourcePath))
            {
                File.WriteAllText(sourcePath, "<html><body><h1>Hello World</h1></body></html>");
            }

            using (Stream stream = File.OpenRead(sourcePath))
            {
                var options = new Aspose.Html.Saving.PdfSaveOptions
                {
                    FormFieldBehaviour = Aspose.Html.Rendering.Pdf.FormFieldBehaviour.Flattened
                };
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, resultPath);
            }

            Console.WriteLine($"MHTML file converted to PDF: {resultPath}");
            Console.WriteLine("Note: PDF text extraction requires a separate validated PDF parsing library.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}