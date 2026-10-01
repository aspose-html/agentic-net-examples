// Create a reusable configuration class that holds default PdfSaveOptions, DocSaveOptions, and ImageSaveOptions instances.

using System;

public class SaveOptionsConfig
{
    public Aspose.Html.Saving.PdfSaveOptions PdfOptions { get; }
    public Aspose.Html.Saving.DocSaveOptions DocOptions { get; }
    public Aspose.Html.Saving.ImageSaveOptions ImageOptions { get; }

    public SaveOptionsConfig()
    {
        PdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
        DocOptions = new Aspose.Html.Saving.DocSaveOptions();
        ImageOptions = new Aspose.Html.Saving.ImageSaveOptions();
    }
}

public class Program
{
    public static void Main()
    {
        try
        {
            var config = new SaveOptionsConfig();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}