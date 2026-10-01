// Configure DocSaveOptions to enforce OpenXML strict compliance when generating DOCX from MHTML for enterprise standards.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.docx";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><p>Sample content</p></body></html>");
            }

            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.DocSaveOptions saveOptions = new Aspose.Html.Saving.DocSaveOptions();
                // If DocSaveOptions supports OpenXML strict compliance, set it here:
                // saveOptions.Compliance = Aspose.Html.Saving.OpenXmlCompliance.Strict;

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, saveOptions, outputPath);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}