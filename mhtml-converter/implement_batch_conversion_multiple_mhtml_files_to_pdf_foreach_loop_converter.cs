// Implement batch conversion of multiple MHTML files to PDF using a foreach loop and Converter.

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFolder = "MhtmlFiles";
            System.IO.Directory.CreateDirectory(inputFolder);
            if (System.IO.Directory.GetFiles(inputFolder, "*.mhtml").Length == 0)
            {
                string samplePath = System.IO.Path.Combine(inputFolder, "sample.mhtml");
                System.IO.File.WriteAllText(samplePath, "<!-- Sample MHTML content -->");
            }
            ConvertMhtmlFilesInFolder(inputFolder);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        foreach (string mhtmlPath in System.IO.Directory.GetFiles(folderPath, "*.mhtml"))
        {
            using (System.IO.FileStream stream = System.IO.File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                string pdfPath = System.IO.Path.ChangeExtension(mhtmlPath, ".pdf");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
                System.Console.WriteLine("Converted: " + mhtmlPath + " -> " + pdfPath);
            }
        }
    }
}