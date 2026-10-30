// Create a unit test that verifies conversion fails gracefully when the source MHTML file path is invalid.

using System;

class Program
{
    static void Main()
    {
        try
        {
            RunInvalidMhtmlConversionTest();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Unexpected error: " + ex.Message);
        }
    }

    static void RunInvalidMhtmlConversionTest()
    {
        string sourcePath = "nonexistent.mhtml";
        string outputPath = "output.pdf";

        try
        {
            using (System.IO.Stream stream = System.IO.File.OpenRead(sourcePath))
            {
                Aspose.Html.Saving.PdfSaveOptions pdfOptions = new Aspose.Html.Saving.PdfSaveOptions();
                Aspose.Html.Converters.Converter.ConvertMHTML(stream, pdfOptions, outputPath);
            }

            Console.WriteLine("Test failed: conversion succeeded unexpectedly.");
        }
        catch (System.IO.FileNotFoundException)
        {
            Console.WriteLine("Test passed: caught FileNotFoundException as expected.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Test passed: caught exception as expected: " + ex.GetType().Name);
        }
    }
}