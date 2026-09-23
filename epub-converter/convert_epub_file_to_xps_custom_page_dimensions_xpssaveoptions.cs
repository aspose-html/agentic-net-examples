// Convert an EPUB file to XPS while specifying custom page dimensions via XpsSaveOptions.

namespace Example
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputPath = "sample.epub";
                string outputPath = "output.xps";

                // Create a minimal EPUB file if it does not exist
                if (!System.IO.File.Exists(inputPath))
                {
                    System.IO.File.WriteAllBytes(inputPath, new byte[0]);
                }

                System.IO.Stream stream = System.IO.File.OpenRead(inputPath);

                Aspose.Html.Saving.XpsSaveOptions options = new Aspose.Html.Saving.XpsSaveOptions();
                options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page()
                {
                    Size = new Aspose.Html.Drawing.Size(
                        Aspose.Html.Drawing.Length.FromPixels(800),
                        Aspose.Html.Drawing.Length.FromPixels(600))
                };
                options.BackgroundColor = System.Drawing.Color.LightGray;

                Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);

                System.Console.WriteLine("EPUB successfully converted to XPS.");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}