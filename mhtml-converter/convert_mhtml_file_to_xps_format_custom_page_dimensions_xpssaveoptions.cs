// Convert an MHTML file to XPS format while specifying custom page dimensions in XpsSaveOptions.

class Program
{
    static void Main()
    {
        try
        {
            // Define input and output paths
            string inputPath = "sample.mhtml";
            string outputPath = "output.xps";

            // Create a minimal MHTML file if it does not exist
            if (!System.IO.File.Exists(inputPath))
            {
                string mhtmlContent = "MIME-Version: 1.0\r\nContent-Type: multipart/related; boundary=\"----=_NextPart_000_0000\"\r\n\r\n------=_NextPart_000_0000\r\nContent-Type: text/html; charset=\"utf-8\"\r\n\r\n<html><body><h1>Hello MHTML</h1></body></html>\r\n------=_NextPart_000_0000--";
                System.IO.File.WriteAllText(inputPath, mhtmlContent);
            }

            // Open the MHTML file as a read stream
            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
            {
                // Configure XPS save options with custom page size and background color
                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                Aspose.Html.Drawing.Page page = new Aspose.Html.Drawing.Page(
                    new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromInches(8.3f),
                        Aspose.Html.Drawing.Length.FromInches(5.8f)
                    )
                );
                options.PageSetup.AnyPage = page;
                options.BackgroundColor = System.Drawing.Color.AliceBlue;

                // Perform the conversion
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }

            System.Console.WriteLine("Conversion completed successfully. Output saved to: " + outputPath);
        }
        catch (System.Exception ex)
        {
            System.Console.Error.WriteLine("Error during conversion: " + ex.Message);
        }
    }
}