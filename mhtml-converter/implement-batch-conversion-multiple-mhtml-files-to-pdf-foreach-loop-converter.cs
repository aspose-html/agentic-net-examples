// Implement batch conversion of multiple MHTML files to PDF using a foreach loop and Converter.

namespace MyApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "InputMhtml");
                System.IO.Directory.CreateDirectory(inputFolder);
                string sampleFile = System.IO.Path.Combine(inputFolder, "sample.mhtml");
                if (!System.IO.File.Exists(sampleFile))
                {
                    System.IO.File.WriteAllText(sampleFile, "Dummy MHTML content");
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
            string[] files = System.IO.Directory.GetFiles(folderPath, "*.mhtml");
            foreach (string mhtmlPath in files)
            {
                string pdfPath = System.IO.Path.ChangeExtension(mhtmlPath, ".pdf");
                using (System.IO.FileStream stream = System.IO.File.OpenRead(mhtmlPath))
                {
                    Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                    Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
                }
                System.Console.WriteLine("Converted: " + pdfPath);
            }
        }
    }
}