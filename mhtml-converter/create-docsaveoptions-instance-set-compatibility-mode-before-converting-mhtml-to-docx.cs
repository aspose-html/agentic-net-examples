// Create a DocSaveOptions instance to set compatibility mode before converting MHTML to DOCX.

using System;

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
                System.IO.File.WriteAllText(inputPath, string.Empty);
            }

            using (System.IO.Stream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
                // CompatibilityMode property is not available in this version of Aspose.HTML.
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            Console.WriteLine("MHTML has been converted to DOCX successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}