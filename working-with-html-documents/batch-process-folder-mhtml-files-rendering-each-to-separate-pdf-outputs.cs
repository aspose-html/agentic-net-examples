// Batch process a folder of MHTML files, rendering each to separate PDF outputs.

using System;
using System.IO;
using Aspose.Html.Net;
using Aspose.Html.Saving;
using Aspose.Html.Converters;

class logHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        System.Console.WriteLine(context.Request.RequestUri + " | " + context.Response.StatusCode);
    }
}

class Program
{
    static void ConvertMhtmlFilesInFolder(string folderPath)
    {
        string[] files = System.IO.Directory.GetFiles(folderPath, "*.mhtml");
        foreach (string mhtmlPath in files)
        {
            using (System.IO.FileStream stream = System.IO.File.OpenRead(mhtmlPath))
            {
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                string pdfPath = System.IO.Path.ChangeExtension(mhtmlPath, ".pdf");
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, options, pdfPath);
                System.Console.WriteLine($"Converted: {mhtmlPath} -> {pdfPath}");
            }
        }
    }

    static void Main(string[] args)
    {
        try
        {
            string inputDir = "MhtmlFiles";
            System.IO.Directory.CreateDirectory(inputDir);
            ConvertMhtmlFilesInFolder(inputDir);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Error: {ex.Message}");
        }
    }
}