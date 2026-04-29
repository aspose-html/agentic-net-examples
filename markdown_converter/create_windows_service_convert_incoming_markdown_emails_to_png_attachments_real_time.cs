// Create a Windows service that converts incoming Markdown emails to PNG attachments in real time.

using System;
using Aspose.Html;
using Aspose.Html.Converters;
using Aspose.Html.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 2) return;
            string sourcePath = args[0];
            string savePath = args[1];
            HTMLDocument document = Converter.ConvertMarkdown(sourcePath);
            ImageSaveOptions options = new ImageSaveOptions();
            Converter.ConvertHTML(document, options, savePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}