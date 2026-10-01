// Implement error handling that catches conversion exceptions and logs source file path for failed MHTML.

namespace AsposeHtmlMhtmlConversion
{
    class Program
    {
        static void Main()
        {
            string sourcePath = "sample.mhtml";
            string outputPath = "output.doc";

            // Create a minimal MHTML file if it does not exist
            if (!System.IO.File.Exists(sourcePath))
            {
                string minimalMhtml = "From: test@example.com\r\nSubject: Sample\r\n\r\n<html><body><p>Sample content</p></body></html>";
                System.IO.File.WriteAllText(sourcePath, minimalMhtml);
            }

            try
            {
                using (System.IO.FileStream stream = System.IO.File.OpenRead(sourcePath))
                {
                    Aspose.Html.Saving.DocSaveOptions options = new Aspose.Html.Saving.DocSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
                }

                System.Console.WriteLine("Conversion succeeded. Output saved to: " + outputPath);
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error converting MHTML file: " + sourcePath);
                System.Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}