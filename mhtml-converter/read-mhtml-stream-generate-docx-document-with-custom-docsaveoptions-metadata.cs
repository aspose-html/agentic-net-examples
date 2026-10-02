// Read an MHTML stream and generate a DOCX document with custom DocSaveOptions for metadata.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.mhtml";
            string outputPath = "output.docx";

            if (!System.IO.File.Exists(inputPath))
            {
                System.IO.File.WriteAllText(inputPath, "From: <test@example.com>\nSubject: Sample\n\n<html><body>Sample content</body></html>");
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.DocSaveOptions saveOptions = new Aspose.Html.Saving.DocSaveOptions();
                // DocSaveOptions does not expose metadata properties; additional options can be set here if needed.

                Aspose.Html.Converters.Converter.ConvertMHTML(stream, saveOptions, outputPath);
            }

            System.Console.WriteLine("Conversion completed successfully.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}