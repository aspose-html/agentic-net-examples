// Batch convert all EPUB files in a directory to JPEG images using a loop over Converter.ConvertEPUB.

class Program
{
    static void Main()
    {
        try
        {
            string inputFolder = "InputEpubs";
            string outputFolder = "OutputImages";

            System.IO.Directory.CreateDirectory(outputFolder);

            foreach (string epubPath in System.IO.Directory.GetFiles(inputFolder, "*.epub"))
            {
                using (System.IO.Stream stream = System.IO.File.OpenRead(epubPath))
                {
                    Aspose.Html.Saving.ImageSaveOptions options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Jpeg);
                    string outputPath = System.IO.Path.Combine(outputFolder, System.IO.Path.GetFileNameWithoutExtension(epubPath) + ".jpg");
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }
            }

            System.Console.WriteLine("Conversion completed.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}