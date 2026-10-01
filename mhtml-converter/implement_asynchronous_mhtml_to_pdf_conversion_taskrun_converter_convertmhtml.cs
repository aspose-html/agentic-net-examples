// Implement asynchronous conversion of MHTML to PDF using Task.Run and Converter.ConvertMHTML method.

class Program
{
    static void Main()
    {
        try
        {
            string sampleFolder = "MhtmlSamples";
            System.IO.Directory.CreateDirectory(sampleFolder);
            string sampleFile = System.IO.Path.Combine(sampleFolder, "sample.mhtml");
            if (!System.IO.File.Exists(sampleFile))
            {
                string htmlContent = "<html><body><h1>Hello, MHTML!</h1></body></html>";
                System.IO.File.WriteAllText(sampleFile, htmlContent);
            }

            ConvertMhtmlFilesInFolder(sampleFolder).GetAwaiter().GetResult();
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static async System.Threading.Tasks.Task ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] files = System.IO.Directory.GetFiles(folderPath, "*.mhtml");
        foreach (var file in files)
        {
            string outputPath = System.IO.Path.ChangeExtension(file, ".pdf");
            await ConvertMhtmlToPdfAsync(file, outputPath);
            System.Console.WriteLine($"Converted: {System.IO.Path.GetFileName(file)} -> {System.IO.Path.GetFileName(outputPath)}");
            System.Console.WriteLine("Note: PDF text extraction requires a separate validated PDF parsing library.");
        }
    }

    static System.Threading.Tasks.Task ConvertMhtmlToPdfAsync(string inputPath, string outputPath)
    {
        return System.Threading.Tasks.Task.Run(() =>
        {
            using (System.IO.FileStream stream = System.IO.File.OpenRead(inputPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, outputPath);
            }
        });
    }
}