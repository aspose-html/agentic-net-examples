// Convert EPUB to PNG with ImageSaveOptions defining a specific page size to control image scaling.

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "sample.epub";
            string outputPath = "output.png";

            System.IO.Stream stream = System.IO.File.OpenRead(inputPath);

            Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions();
            options.HorizontalResolution = 300;
            options.VerticalResolution = 300;
            options.PageSetup.AnyPage = new Aspose.Html.Drawing.Page(
                new Aspose.Html.Drawing.Size(
                    Aspose.Html.Drawing.Length.FromPixels(800),
                    Aspose.Html.Drawing.Length.FromPixels(600)),
                new Aspose.Html.Drawing.Margin(0, 0, 0, 0));

            Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);

            stream.Dispose();
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}