// Configure DocSaveOptions to enforce OpenXML strict compliance when generating DOCX from MHTML for enterprise standards.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.mhtml";
            string outputPath = "output.docx";

            // Create a minimal MHTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "<html><body><p>Sample content</p></body></html>");
            }

            System.IO.Stream stream = System.IO.File.OpenRead(inputPath);
            Aspose.Html.Saving.DocSaveOptions saveOptions = new Aspose.Html.Saving.DocSaveOptions();
            // Note: OpenXML strict compliance is not configurable via DocSaveOptions in the current API.

            Aspose.Html.Converters.Converter.ConvertMHTML(stream, saveOptions, outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}