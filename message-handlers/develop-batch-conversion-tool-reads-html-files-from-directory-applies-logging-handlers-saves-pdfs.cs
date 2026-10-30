// Develop a batch conversion tool that reads HTML files from a directory, applies logging handlers, and saves PDFs.

using System;

class LogHandler : Aspose.Html.Net.MessageHandler
{
    public override void Invoke(Aspose.Html.Net.INetworkOperationContext context)
    {
        Next(context);
        System.Console.WriteLine(context.Request.RequestUri + " | " + context.Response.StatusCode);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            string inputDir = "HTMLInput";
            System.IO.Directory.CreateDirectory(inputDir);
            ConvertHtmlFilesInFolder(inputDir);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void ConvertHtmlFilesInFolder(string folderPath)
    {
        foreach (string htmlPath in System.IO.Directory.GetFiles(folderPath, "*.html"))
        {
            Aspose.Html.Configuration configuration = new Aspose.Html.Configuration();
            Aspose.Html.Services.INetworkService network = configuration.GetService<Aspose.Html.Services.INetworkService>();
            network.MessageHandlers.Add(new LogHandler());

            using (Aspose.Html.HTMLDocument document = new Aspose.Html.HTMLDocument(htmlPath, configuration))
            {
                string pdfPath = System.IO.Path.ChangeExtension(htmlPath, ".pdf");
                Aspose.Html.Saving.PdfSaveOptions options = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertHTML(document, options, pdfPath);
                System.Console.WriteLine("Converted: " + pdfPath);
            }
        }
    }
}