// Convert a list of EPUB file paths to DOCX using a reusable method that accepts save options.

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var epubFiles = new System.Collections.Generic.List<string>
                {
                    "sample1.epub",
                    "sample2.epub"
                };

                foreach (var sourcePath in epubFiles)
                {
                    string outputPath = System.IO.Path.ChangeExtension(sourcePath, ".docx");
                    var options = new Aspose.Html.Saving.DocSaveOptions();
                    ConvertEpubToDocx(sourcePath, outputPath, options);
                    System.Console.WriteLine($"Converted '{sourcePath}' to '{outputPath}'.");
                }
            }
            catch (System.Exception ex)
            {
                System.Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ConvertEpubToDocx(string sourcePath, string outputPath, Aspose.Html.Saving.DocSaveOptions options)
        {
            Aspose.Html.Converters.Converter.ConvertEPUB(sourcePath, options, outputPath);
        }
    }
}