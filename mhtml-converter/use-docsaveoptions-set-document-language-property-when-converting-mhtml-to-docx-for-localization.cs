// Use DocSaveOptions to set document language property when converting MHTML to DOCX for localization.

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

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
                // Language property is not available in DocSaveOptions; default settings are used.

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}