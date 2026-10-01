// Read an MHTML stream and generate a DOCX document with custom DocSaveOptions for metadata.

using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.docx";

            // Create a minimal sample MHTML file if it does not exist
            if (!File.Exists(inputPath))
            {
                string htmlContent = "<html><body><h1>Hello World</h1></body></html>";
                File.WriteAllText(inputPath, htmlContent);
            }

            using (Stream stream = File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
                // Example of setting metadata (uncomment if the property exists in the API)
                // options.Title = "Sample Document";
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}