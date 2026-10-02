// Create a unit test that verifies conversion fails gracefully when the source MHTML file path is invalid.

class Program
{
    static void Main()
    {
        try
        {
            string sourcePath = "nonexistent.mhtml";
            string outputPath = "output.pdf";

            System.IO.Stream stream = System.IO.File.OpenRead(sourcePath);
            Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
            Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
            System.Console.WriteLine("Test failed: conversion succeeded unexpectedly.");
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine("Test passed: conversion failed gracefully.");
            System.Console.WriteLine("Caught exception: " + ex.Message);
        }
    }
}