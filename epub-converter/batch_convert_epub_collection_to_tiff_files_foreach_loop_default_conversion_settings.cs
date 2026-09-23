// Batch convert a collection of EPUB books to TIFF files using a foreach loop and default conversion settings.

using System;

class Program
{
    static void Main()
    {
        try
        {
            string[] epubFiles = new string[] { "book1.epub", "book2.epub" };

            foreach (var epubPath in epubFiles)
            {
                if (!System.IO.File.Exists(epubPath))
                {
                    System.IO.File.WriteAllBytes(epubPath, new byte[0]);
                }

                using (System.IO.Stream stream = System.IO.File.OpenRead(epubPath))
                {
                    var options = new Aspose.Html.Saving.ImageSaveOptions(Aspose.Html.Rendering.Image.ImageFormat.Tiff);
                    string outputFileName = System.IO.Path.GetFileNameWithoutExtension(epubPath) + ".tiff";
                    string outputPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), outputFileName);
                    Aspose.Html.Converters.Converter.ConvertEPUB(stream, options, outputPath);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }
}