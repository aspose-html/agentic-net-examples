// Batch process a folder of MHTML files, rendering each to separate PDF outputs.

using System;
using System.IO;
using Aspose.Html.Net;

class logHandler : MessageHandler
{
    public override void Invoke(INetworkOperationContext context)
    {
        Next(context);
        Console.WriteLine($"{context.Request.RequestUri} | {context.Response.StatusCode}");
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "MhtmlFiles";

            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                // Optionally, create a minimal sample MHTML file here if needed.
            }

            ConvertMhtmlFilesInFolder(inputDir);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }

    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        foreach (string mhtmlPath in Directory.GetFiles(folderPath, "*.mhtml"))
        {
            using (FileStream stream = File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                string pdfPath = Path.ChangeExtension(mhtmlPath, ".pdf");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
                Console.WriteLine($"Converted: {Path.GetFileName(pdfPath)}");
            }
        }
    }
}